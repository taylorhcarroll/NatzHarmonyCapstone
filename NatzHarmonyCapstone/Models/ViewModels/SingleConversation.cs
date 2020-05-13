using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NatzHarmonyCapstone.Models.ViewModels
{
    public class SingleConversation
    {
        public ApplicationUser User { get; set; }
        public ApplicationUser Match { get; set; }
        public List<Messages> Messages { get; set; }

        public string RecipientId { get; set; }
        public string Content { get; set; }

        public DateTime TimeStamp { get; set; }

    }
}
