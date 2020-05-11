using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NatzHarmonyCapstone.Data;
using NatzHarmonyCapstone.Models;

[assembly: HostingStartup(typeof(NatzHarmonyCapstone.Areas.Identity.IdentityHostingStartup))]
namespace NatzHarmonyCapstone.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
            });
        }
    }
}