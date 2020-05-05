using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NatzHarmonyCapstone.Models
{
    public class ProfileFormViewModel
    {
        [Key]
        public string Id { get; set; }
       
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

       
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        public string Gender { get; set; }

        public string Pronouns { get; set; }

        //public int CountryId { get; set; }

        public Country Country { get; set; }

        public bool Mentor { get; set; }

        public bool Admin { get; set; }
        public bool LanguagePref { get; set; }

        public bool CountryPref { get; set; }

        public bool GenderPref { get; set; }

        public string Availability { get; set; }

        public string AvatarUrl { get; set; }

        //this file datatype is used for image upload
        [NotMappedAttribute]
        public IFormFile File { get; set; }

    }
}
