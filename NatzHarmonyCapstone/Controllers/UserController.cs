using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NatzHarmonyCapstone.Data;
using NatzHarmonyCapstone.Models;

namespace NatzHarmonyCapstone.Controllers
{
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public UserController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        // GET: User/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: User/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Profiles/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var user = await GetUserAsync();
            var viewModel = new ProfileFormViewModel
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Gender = user.Gender,
                Pronouns = user.Pronouns,
                //CountryId = user.CountryId,
                Country = user.Country,
                Mentor = user.Mentor,
                Admin = user.Admin,
                LanguagePref = user.LanguagePref,
                CountryPref = user.CountryPref,
                GenderPref = user.GenderPref,
                Availability = user.Availability,
                AvatarUrl = user.AvatarUrl
            };
            return View(viewModel);
        }

        // POST: Profiles/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, ProfileFormViewModel profileViewModel)
        {
            try
            {
                var user = await GetUserAsync();

                user.Id = profileViewModel.Id;
                user.FirstName = profileViewModel.FirstName;
                user.LastName = profileViewModel.LastName;
                user.Gender = profileViewModel.Gender;
                user.Pronouns = profileViewModel.Pronouns;
                //user.CountryId = profileViewModel.CountryId;
                user.Country = profileViewModel.Country;
                //user.Mentor = profileViewModel.Mentor,
                //user.Admin = profileViewModel.Admin,
                user.LanguagePref = profileViewModel.LanguagePref;
                user.CountryPref = profileViewModel.CountryPref;
                user.GenderPref = profileViewModel.GenderPref;
                user.Availability = profileViewModel.Availability;

                if (profileViewModel.File != null && profileViewModel.File.Length > 0)
                {
                    //creates the file name and makes it unique by generating a Guid and adding that to the file name
                    var fileName = Guid.NewGuid().ToString() + Path.GetFileName(profileViewModel.File.FileName);
                    //defines the filepath by adding the fileName above and combines it with the wwwroot directory 
                    //which is where our images are stored
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images", fileName);

                    //adds the newly created fileName to the product object we built up above to be stored in 
                    //the database as the ImagePath
                    user.AvatarUrl = fileName;

                    //what actually allows us to save the file to the folder path
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await profileViewModel.File.CopyToAsync(stream);
                    }

                }

                _context.ApplicationUsers.Update(user);
                await _context.SaveChangesAsync();

                return RedirectToAction("Details", new { id = user.Id});
            }
            catch
            {
                return View();
            }
        }

        // GET: User/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: User/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        private async Task<ApplicationUser> GetUserAsync() => await _userManager.GetUserAsync(HttpContext.User);
    }
}