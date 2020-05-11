using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NatzHarmonyCapstone.Models
{
    public class UserLanguage
    {
        public int UserLanguageId { get; set; }
        
        public string UserId { get; set; } 

        public ApplicationUser ApplicationUser { get; set; }

        public int LanguageId { get; set; }

        public Language Language { get; set; }

    }
}
