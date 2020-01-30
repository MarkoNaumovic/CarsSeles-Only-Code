using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SlikaOglasi.Models;

[assembly: HostingStartup(typeof(SlikaOglasi.Areas.Identity.IdentityHostingStartup))]
namespace SlikaOglasi.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<SlikaOglasiContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("SlikaOglasiContextConnection")));

                services.AddDefaultIdentity<IdentityUser>()
                    .AddEntityFrameworkStores<SlikaOglasiContext>();
            });
        }
    }
}