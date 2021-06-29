using System;
using LinkSharedBlazor.Areas.Identity.Data;
using LinkSharedBlazor.Data;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(LinkSharedBlazor.Areas.Identity.IdentityHostingStartup))]
namespace LinkSharedBlazor.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<LinkSharedIdentityContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("DefaultConnection"))); 
                services.AddIdentity<LinkSharedUser, IdentityRole>(options =>
                {
                    options.User.RequireUniqueEmail = false; 
                })
                    .AddEntityFrameworkStores<LinkSharedIdentityContext>()
                    .AddDefaultTokenProviders();
                services.AddScoped<AuthenticationStateProvider, RevalidatingIdentityAuthenticationStateProvider<LinkSharedUser>>();
                services.Configure<IdentityOptions>(options =>
                {
                    options.Password.RequireNonAlphanumeric = false; 
                    options.User.RequireUniqueEmail = true; 
                    options.User.AllowedUserNameCharacters = String.Empty;
                });
            });
        }
    }
}