using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NatzHarmonyCapstone.Models.ViewModels
{
    public class MessagesViewList
    {
        public string UserId { get; set; }

        public ApplicationUser User { get; set; }

        public IEnumerable<ApplicationUser> Matches { get; set; }

        public IEnumerable<Messages> Messages { get; set; }
    }
}
