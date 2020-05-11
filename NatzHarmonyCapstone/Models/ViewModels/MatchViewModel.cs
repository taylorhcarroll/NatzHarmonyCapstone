using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NatzHarmonyCapstone.Models.ViewModels
{
    public class MatchViewModel
    {
       public List<ApplicationUser> MatchList { get; set; }

       public ApplicationUser match { get; set; }

       public string ReturnAction { get; set; } 
       public string ReturnController { get; set; }
    }
}
