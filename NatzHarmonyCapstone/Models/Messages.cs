using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NatzHarmonyCapstone.Models
{
    public class Messages
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        public string Recipient { get; set; }

        public string Content { get; set; }

        public DateTime TimeStamp { get; set; }

        public bool IsRead { get; set; }
    }
}
