using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NatzHarmonyCapstone.Models.ViewModels
{
    public class ConversationItem
    {
        public bool IsRead { get; set; }
        public ApplicationUser User { get; set; }
        public ApplicationUser Match { get; set; }
        public Messages RecentMessage { get; set; }
    }
}
