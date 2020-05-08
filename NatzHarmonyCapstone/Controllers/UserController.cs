using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.UserSecrets;
using NatzHarmonyCapstone.Data;
using NatzHarmonyCapstone.Models;
using NatzHarmonyCapstone.Models.ViewModels;

namespace NatzHarmonyCapstone.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IConfiguration _config;


        public UserController(ApplicationDbContext context, UserManager<ApplicationUser> userManager, IConfiguration config)
        {
            _context = context;
            _userManager = userManager;
            _config = config;
        }

        ///////section for raw SQL cmd config BEGIN
        public SqlConnection Connection
        {
            get
            {
                return new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            }
        }
        ///////section for raw SQL cmd config END

        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> MyMatches()
        {
            var currentUser = await GetCurrentUserAsync();
            var currentUserId = currentUser.Id.ToString();
            var user = await _context.ApplicationUsers
                .Include(u => u.Languages)
                    .ThenInclude(ul => ul.Language)
                        .FirstOrDefaultAsync(user => user.Id == currentUserId);

            var matches = MatchEngine(user);

            var viewModel = new MatchViewModel
            {
                MatchList = matches
            };

            return View(viewModel);

        }

        // GET: User/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var userId = id.ToString();
            var user = await _userManager.FindByIdAsync(userId);
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

        // GET: User/Details/MyProfile
        public async Task<ActionResult> MyProfile()
        {
            var user = await GetCurrentUserAsync();
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

        // GET: User/Create
        public ActionResult AddMentor(int id)
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
        public async Task<ActionResult> Edit()
        {
            var user = await GetCurrentUserAsync();
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
                var user = await GetCurrentUserAsync();

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

                return RedirectToAction("Details", new { id = user.Id });
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
        private async Task<ApplicationUser> GetCurrentUserAsync() => await _userManager.GetUserAsync(HttpContext.User);


        private List<ApplicationUser> MatchEngine(ApplicationUser user)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    if (user.GenderPref == false && user.CountryPref == false && user.LanguagePref == false)
                    {
                        //refactor to include availability as part of ranking
                        cmd.CommandText = @"SELECT TOP 3 u.Id, u.FirstName, u.LastName, u.Mentor, u.Gender, u.CountryId, u.[Availability], u.AvatarUrl,
                                            ul.LanguageId, l.[Name]
                                            FROM AspNetUsers u
                                            LEFT JOIN UserLanguage ul ON ul.UserId = u.Id
                                            LEFT JOIN [Language] l ON l.LanguageId = ul.LanguageId
                                            GROUP BY u.Id, u.FirstName, u.LastName, u.Mentor, u.Gender, u.CountryId, u.[Availability], ul.LanguageId, l.[Name], u.AvatarUrl
                                            HAVING u.Mentor = 1
                                            ORDER BY u.LastName DESC";
                    }
                    else
                    {
                        cmd.CommandText = @"SELECT TOP 3 u.Id, u.FirstName, u.LastName, u.Mentor, u.Gender, u.CountryId, u.[Availability], u.AvatarUrl,
                                        ul.LanguageId, l.[Name],
                                        + COUNT(CASE WHEN u.[Availability] = '@Availability' THEN 1 END) ";

                        cmd.Parameters.Add(new SqlParameter("@Availability", user.Availability));

                        if (user.GenderPref == true)
                        {
                            cmd.CommandText += " + COUNT(CASE WHEN u.Gender = '@Gender' THEN 1 END) ";
                            cmd.Parameters.Add(new SqlParameter("@Gender", user.Gender));
                        }

                        if (user.CountryPref == true)
                        {
                            cmd.CommandText += "  + COUNT(CASE WHEN u.CountryId = @Country THEN 1 END) ";
                            cmd.Parameters.Add(new SqlParameter("@Country", user.CountryId));
                        }

                        if (user.LanguagePref == true)
                        {
                            for (var i = 0; i < user.Languages.Count; i++)
                            //foreach (UserLanguage lang in user.Languages)
                            {
                                cmd.CommandText += " + COUNT(CASE WHEN ul.LanguageId = @Lang" + i + " THEN 1 END)  ";
                                cmd.Parameters.Add(new SqlParameter("@Lang"+i, user.Languages[i].Language.LanguageId));
                            }

                        }
                        cmd.CommandText += @" AS CriteriaRank
                                            FROM AspNetUsers u
                                            LEFT JOIN UserLanguage ul ON ul.UserId = u.Id
                                            LEFT JOIN[Language] l ON l.LanguageId = ul.LanguageId
                                            GROUP BY u.Id, u.FirstName, u.LastName, u.Mentor, u.Gender, u.CountryId, u.[Availability], ul.LanguageId, l.[Name], u.AvatarUrl
                                            HAVING u.Mentor = 1
                                            ORDER BY CriteriaRank DESC, u.LastName DESC ";

                    }
                    var reader = cmd.ExecuteReader();
                    var matches = new List<ApplicationUser>();

                    while (reader.Read())
                    {
                        var match = new ApplicationUser()
                        {
                            Id = reader.GetString(reader.GetOrdinal("Id")),
                            FirstName = reader.GetString(reader.GetOrdinal("FirstName")),
                            LastName = reader.GetString(reader.GetOrdinal("LastName")),
                            //AvatarUrl = reader.GetString(reader.GetOrdinal("AvatarUrl")),
                            Gender = reader.GetString(reader.GetOrdinal("Gender")),
                            Availability = reader.GetString(reader.GetOrdinal("Availability")),
                            CountryId = reader.GetInt32(reader.GetOrdinal("CountryId"))

                        };
                        //checks against db to return nullable AvatarUrl 
                        if (!reader.IsDBNull(reader.GetOrdinal("AvatarUrl")))
                        {
                            match.AvatarUrl = reader.GetString(reader.GetOrdinal("AvatarUrl"));
                        }

                        matches.Add(match);
                    }
                    reader.Close();
                    return matches;
                }
            }
        }
    }
}