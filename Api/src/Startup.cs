using System.Text;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using RabblyApi.Comments.Services;
using RabblyApi.Data;
using RabblyApi.Debates.Services;
using RabblyApi.Groups.Services;
using RabblyApi.Profiles.Services;
using RabblyApi.Users.Services;
using Newtonsoft.Json;

namespace RabblyApi.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddScoped<UserService>();
            services.AddScoped<ProfileService>();
            services.AddScoped<DebateService>();
            services.AddScoped<CommentService>();
            services.AddScoped<GroupService>();

            services.AddEntityFrameworkNpgsql()
                .AddDbContext<DatabaseContext>(opt => opt.UseNpgsql(Configuration.GetConnectionString("Default")))
                .BuildServiceProvider();

            services.AddAutoMapper();

            services.AddAuthentication(opt =>
            {
                opt.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultForbidScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddGoogle("google", opt =>
            {
                opt.ClientId = "340114918710-6pebk36f1gccbri0fke24hqold2h058d.apps.googleusercontent.com";
                opt.ClientSecret = "UZsrHyn2SKUQX-BfNWyxXUmG";
            })
            .AddJwtBearer(opt =>
            {
                opt.TokenValidationParameters = new TokenValidationParameters()
                {
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Keys:TokenSecret"])),
                    RequireSignedTokens = false,
                    ValidIssuers = new string[] {
                        Configuration["Credentials:Issuer"],
                        "accounts.google.com"
                    },
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                };
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment() || env.IsStaging())
            {
                app.UseDeveloperExceptionPage();
                app.UseCors(opt => opt.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod());
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseMvc();
        }
    }
}
