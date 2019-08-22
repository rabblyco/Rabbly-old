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
using System;
using System.Diagnostics;
using Newtonsoft.Json.Linq;

namespace RabblyApi.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IHostingEnvironment env)
        {
            Configuration = configuration;
            Env = env;
        }

        public IConfiguration Configuration { get; }

        public IHostingEnvironment Env { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddScoped<UserService>();
            services.AddScoped<ProfileService>();
            services.AddScoped<DebateService>();
            services.AddScoped<CommentService>();
            services.AddScoped<GroupService>();

            if (Env.IsProduction())
            {
                var secretData = JObject.Parse(Environment.GetEnvironmentVariable("DB_CREDS"));
                dynamic secretString = JObject.Parse(secretData.GetValue("SecretString").ToString());
                // "Host=database;Database=rabbly;Username=rabbly;Password=password1234"
                string connectionString = $"Host={secretString.host};Port={secretString.port};Database={secretString.dbInstanceIdentifier};Username={secretString.username};Password={secretString.password}";
                Console.WriteLine("FUCKING FUCK");
                Debug.WriteLine("FUCKITY DAMN");
                Console.WriteLine(secretData);
                Console.WriteLine(secretString);
                Console.WriteLine(connectionString);
                

                services.AddEntityFrameworkNpgsql()
                .AddDbContext<DatabaseContext>(opt => opt.UseNpgsql(connectionString))
                .BuildServiceProvider();

            }
            else
            {
                services.AddEntityFrameworkNpgsql()
                    .AddDbContext<DatabaseContext>(opt => opt.UseNpgsql(Configuration.GetConnectionString("Default")))
                    .BuildServiceProvider();
            }

            services.AddAutoMapper();

            services.AddAuthentication(opt =>
            {
                opt.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultForbidScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(opt =>
            {
                var tokenSecretKey = Env.IsProduction() ? Environment.GetEnvironmentVariable("TokenSecret") ?? "" : Configuration["Keys:TokenSecret"];

                opt.TokenValidationParameters = new TokenValidationParameters()
                {
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenSecretKey)),
                    RequireSignedTokens = false,
                    ValidIssuers = new string[] {
                        Configuration["Credentials:Issuer"],
                    },
                    ValidAudience = Configuration["Credentials:Audience"],
                    ValidateAudience = true,
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
