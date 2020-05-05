using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace NatzHarmonyCapstone.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        public string Gender { get; set; }

        public string Pronouns { get; set; }

        public int CountryId { get; set; }

        public Country Country { get; set; }

        public bool Mentor { get; set; }

        public bool Admin { get; set; }
        public bool LanguagePref { get; set; }

        public bool CountryPref { get; set; }

        public bool GenderPref { get; set; }

        public string Availability { get; set; }

        public string AvatarUrl { get; set; }

        public virtual List<UserMentor> UserMentors { get; set; }

        public virtual List<UserMentor> UserMentees { get; set; }

        public virtual List<Language> Languages { get; set; }

        public virtual List<Messages> SentMessages { get; set; }

        public virtual List<Messages> ReceiviedMessages { get; set; }


    }
}
