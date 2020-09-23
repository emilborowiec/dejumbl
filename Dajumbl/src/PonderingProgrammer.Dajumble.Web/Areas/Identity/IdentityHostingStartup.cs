using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PonderingProgrammer.Dajumble.Web.Data;

[assembly: HostingStartup(typeof(PonderingProgrammer.Dajumble.Web.Areas.Identity.IdentityHostingStartup))]
namespace PonderingProgrammer.Dajumble.Web.Areas.Identity
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