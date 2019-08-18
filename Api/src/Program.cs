using AutoMapper;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RabblyApi.Data;
using RabblyApi.Debates.Services;
using RabblyApi.Groups.Services;
using RabblyApi.Users.Services;
using RabblyApi.Profiles.Services;
using RabblyApi.Comments.Services;

namespace RabblyApi.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateWebHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var context = scope.ServiceProvider.GetRequiredService<DatabaseContext>();
                var env = scope.ServiceProvider.GetService<IHostingEnvironment>();
                var userService = scope.ServiceProvider.GetService<UserService>();
                var mapper = scope.ServiceProvider.GetService<IMapper>();
                var profileService = scope.ServiceProvider.GetService<ProfileService>();
                var debateService = scope.ServiceProvider.GetService<DebateService>();
                var commentService = scope.ServiceProvider.GetService<CommentService>();
                var groupService = scope.ServiceProvider.GetService<GroupService>();
                context.Database.Migrate();
                if (env.IsDevelopment()) {
                    var dataSeeder = new SeedData(context, mapper, userService, profileService, debateService, commentService, groupService);
                    dataSeeder.GenerateData().Wait();
                }
            }
            host.Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
