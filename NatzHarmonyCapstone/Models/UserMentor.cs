using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NatzHarmonyCapstone.Models
{
    public class UserMentor
    {
        public int UserMentorId { get; set; }
        public string UserId { get; set; }

        public ApplicationUser User { get; set; }

        public string MentorId { get; set; }

        public ApplicationUser Mentor { get; set; }

    }
}
