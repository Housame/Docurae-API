using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;
using DocuraeAPI.Models.Entities;
using Microsoft.Extensions.Configuration;
using DocuraeAPI.Repositories;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace DocuraeAPI
{
    public class Startup
    {
        private readonly IConfiguration _config;

        public Startup(IConfiguration configuration)
        {
            _config = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            var connstring = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=DocuraeTestDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            //var connstring = _config.GetConnectionString("AppConnectionString");
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connstring));
            services.AddDbContext<IdDbContext>(o => o.UseSqlServer(connstring));
            services.AddScoped<ILogTextRepository, LogTextRepository>();
            services.AddScoped<ILoginRepository, LoginRepository>();
            services.AddScoped<ISettingsRepository, SettingsRepository>();

            services.AddAuthentication().AddJwtBearer(cfg =>
            {
                cfg.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidIssuer = _config["Tokens:Issuer"],
                    ValidAudience = _config["Tokens:Audience"],
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Tokens:Key"])),
                    ClockSkew = TimeSpan.Zero
                };
            });

            services.Configure<PasswordHasherOptions>(options => options.CompatibilityMode = PasswordHasherCompatibilityMode.IdentityV2);

            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials().SetPreflightMaxAge(TimeSpan.FromSeconds(2520))); // Prevent browser to send preflight requests on every request
            });

            //services.AddIdentity<ApplicationUser, ApplicationRole>(options =>
            //{
            //    options.Password.RequiredLength = 6;
            //    options.Password.RequireDigit = false;
            //    options.Password.RequireLowercase = false;
            //    options.Password.RequireUppercase = false;
            //    options.Password.RequireNonAlphanumeric = false;
            //})
            //    .AddEntityFrameworkStores<ApplicationDbContext>()
            //    .AddDefaultTokenProviders();
            services.AddIdentity<ApplicationUser, IdentityRole>(cfg =>
            {
                cfg.User.RequireUniqueEmail = true;
                //                cfg.Password.
            })
            .AddEntityFrameworkStores<IdDbContext>();
            services.AddSession();
            services.AddMvc();
        }
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseStatusCodePages();

            //AutoMapper.Mapper.Initialize(cfg =>
            //{
            //    cfg.CreateMap<User, Models.UserDTO>();
            //});

            app.UseCors("CorsPolicy");
            app.UseAuthentication();
            app.UseMvc();
        }
    }
}
