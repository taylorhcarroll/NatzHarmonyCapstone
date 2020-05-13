using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.Extensions.Configuration.UserSecrets;
using Microsoft.Extensions.Logging;
using NatzHarmonyCapstone.Data;
using NatzHarmonyCapstone.Models;

namespace NatzHarmonyCapstone.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;
        private readonly ApplicationDbContext _context;

        public RegisterModel(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ILogger<RegisterModel> logger,
            IEmailSender emailSender,
            ApplicationDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
            _context = context;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public List<SelectListItem> GenderOptions { get; set; }

        public List<SelectListItem> CountryOptions { get; set; }

        public List<SelectListItem> LanguageOptions { get; set; }

        public List<SelectListItem> AvailabilityOptions { get; set; }

        public class InputModel
        {
            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            
            public bool IsMentor { get; set; }
            public string ConfirmPassword { get; set; }

            [Display(Name = "First Name")]
            public string FirstName { get; set; }

            [Display(Name = "Last Name")]
            public string LastName { get; set; }

            public string Gender { get; set; }

            [DataType(DataType.Date)]
            [Display(Name = "Date of Birth")]
            public DateTime DoB { get; set; }

            public string Pronouns { get; set; }

            public string PhoneNumber { get; set; }

            public int CountryId { get; set; }
            
            public virtual List<Language> Languages { get; set; }

            public List<int> SelectLangIds { get; set; }

            [Display(Name = "Do you prefer your mentor speak the same native language as you?")]
            public bool LanguagePref { get; set; }
            
            [Display(Name = "Do you prefer your mentor is from the same country as you?")]
            public bool CountryPref { get; set; }

            [Display(Name = "Do you prefer your mentor have the same gender as you?")]
            public bool GenderPref { get; set; }

            public string Availability { get; set; }
          
            public string AvatarUrl { get; set; }

            //[NotMapped]
            public IFormFile File { get; set; }
        }

        public async Task OnGetAsync(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            
            
            //populate my view options here
            
            //hardcode
            var genderOptions = new List<SelectListItem>
            {
            new SelectListItem() { Text = "Male", Value = "Male"},
            new SelectListItem() { Text = "Female", Value = "Female"},
            new SelectListItem() { Text = "Non-Binary", Value = "Non-Binary"},
            new SelectListItem() { Text = "Other", Value = "Other"}
            };

            var availabilityOptions = new List<SelectListItem>
            {
            new SelectListItem() { Text = "Mornings (7am-11am)", Value = "Mornings"},
            new SelectListItem() { Text = "Midday (11am-4pm)", Value = "Midday"},
            new SelectListItem() { Text = "Evenings (4pm-8pm)", Value = "Evenings"},
            new SelectListItem() { Text = "No Preference", Value = "NoPreference"}
            };

            //one2many
            var countryOptions = await _context.Country
                .Select(c => new SelectListItem() { Text = c.Name, Value = c.CountryId.ToString() })
                .ToListAsync();


            //many2many
            var languageOptions = await _context.Language.Select(l => new SelectListItem()
            { Text = l.Name, Value = l.LanguageId.ToString() }).ToListAsync();

            //var viewModel = new Model
            //{
            
            GenderOptions = genderOptions;
            CountryOptions = countryOptions;
            LanguageOptions = languageOptions;
            AvailabilityOptions = availabilityOptions;

            //};


        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/User/MyMatches");
            //returnUrl = returnUrl ?? Url.Action("MyMatches", "User", new { variable = value })
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            ModelState.Remove("Input.IsMentor");
            if (ModelState.IsValid)
            {

                var user = new ApplicationUser
                {
                    UserName = Input.Email,
                    Email = Input.Email,
                    Mentor = Input.IsMentor,
                    Admin = false,
                    FirstName = Input.FirstName,
                    LastName = Input.LastName,
                    //decouple rest of account creation?
                    DoB = Input.DoB,
                    CountryId = Input.CountryId,
                    Gender = Input.Gender,
                    Pronouns = Input.Pronouns,
                    //pref section
                    CountryPref = Input.CountryPref,
                    GenderPref = Input.GenderPref,
                    LanguagePref = Input.LanguagePref,
                    Availability = Input.Availability,
                };
                if (Input.PhoneNumber != null)
                {
                    user.PhoneNumber = Input.PhoneNumber;
                }

                user.Languages = Input.SelectLangIds.Select(langId => new UserLanguage()
                {
                    
                    UserId = user.Id,
                    LanguageId = langId
                }).ToList();

                if (Input.File != null && Input.File.Length > 0)
                {
                    //creates the file name and makes it unique by generating a Guid and adding that to the file name
                    var fileName = Guid.NewGuid().ToString() + Path.GetFileName(Input.File.FileName);
                    //defines the filepath by adding the fileName above and combines it with the wwwroot directory 
                    //which is where our images are stored
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images", fileName);

                    //adds the newly created fileName to the product object we built up above to be stored in 
                    //the database as the ImagePath
                    user.AvatarUrl = fileName;

                    //what actually allows us to save the file to the folder path
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await Input.File.CopyToAsync(stream);
                    }

                }

                var result = await _userManager.CreateAsync(user, Input.Password);
                if (result.Succeeded)
                {
                    _logger.LogInformation("User created a new account with password.");

                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                    //var callbackUrl = Url.Page(
                    //    "/User/MyMatches",
                    //    pageHandler: null,
                    //    values: new { userId = user.Id, code = code },
                    //    protocol: Request.Scheme);


                    var callbackUrl = Url.Page(
                        "/Account/ConfirmEmail",
                        pageHandler: null,
                        values: new { area = "Identity", userId = user.Id, code = code },
                        protocol: Request.Scheme);

                    //await _emailSender.SendEmailAsync(Input.Email, "Confirm your email",
                    //    $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");


                    //if (_userManager.Options.SignIn.RequireConfirmedAccount)
                    //{
                    //    return RedirectToPage("RegisterConfirmation", new { email = Input.Email });
                    //}
                    //else

                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return LocalRedirect(returnUrl);
                    
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }
    }
}
