using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NatzHarmonyCapstone.Models
{
    public class Messages
    {
        public int MessagesId { get; set; }

        public string SenderId { get; set; }

        
        public ApplicationUser Sender { get; set; }

        public string RecipientId { get; set; }

      
        public ApplicationUser Recipient { get; set; }

        public string Content { get; set; }

        public DateTime TimeStamp { get; set; }

        public bool IsRead { get; set; }
    }
}
