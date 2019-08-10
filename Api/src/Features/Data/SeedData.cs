
using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RabblyApi.Data.Utils;
using RabblyApi.Users.Services;
using RabblyApi.Debates.Services;
using RabblyApi.Groups.Services;
using RabblyApi.Users.Dtos;
using RabblyApi.Profiles.Dtos;
using RabblyApi.Debates.Dtos;
using RabblyApi.Comments.Dtos;
using RabblyApi.Groups.Dtos;
using RabblyApi.Profiles.Services;
using RabblyApi.Comments.Services;

namespace RabblyApi.Data
{
    public class SeedData
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;
        private readonly UserService _userService;
        private readonly ProfileService _profileService;
        private readonly DebateService _debateService;
        private readonly CommentService _commentService;
        private readonly GroupService _groupService;

        public SeedData(DatabaseContext context, IMapper mapper, UserService userService, ProfileService profileService, DebateService debateService, CommentService commentService, GroupService groupService)
        {
            _context = context;
            _mapper = mapper;
            _userService = userService;
            _profileService = profileService;
            _debateService = debateService;
            _commentService = commentService;
            _groupService = groupService;
        }

        public void GenerateData()
        {
            GenerateDevelopmentUsers().Wait();
            GenerateDevelopmentEditedProfiles().Wait();
            GenerateDebates().Wait();
            GenerateComments().Wait();
            GenerateGroups().Wait();
            GenerateComments().Wait();
        }

        private async Task GenerateDevelopmentUsers()
        {
            var users = new[]
            {
                new LoginRegisterDto() { Email = "dwdewul@gmail.com", Password = "password1234" },
                new LoginRegisterDto() { Email = "captain1@aol.com", Password = "testpass1234" },
                new LoginRegisterDto() { Email = "testerguy@gmail.com", Password = "testpass1234" },
                new LoginRegisterDto() { Email = "tbhfam1@hotmail.com", Password = "porcupinedream" },
                new LoginRegisterDto() { Email = "nowayjose", Password = "129iter8@guy" },
            };

            foreach (var user in users)
            {
                await _userService.Register(user);
            }

            await _context.SaveChangesAsync();
        }

        private async Task GenerateDevelopmentEditedProfiles()
        {
            var users = await _context.Users.ToArrayAsync();
            var countryValues = Enum.GetValues(typeof(Countries));
            var stateValues = Enum.GetValues(typeof(States));
            var genderValues = Enum.GetValues(typeof(Gender));
            foreach (var user in users)
            {
                var editProfile = _mapper.Map<ProfileEditDto>(user.Profile);
                var random = new Random();
                editProfile.Country = (Countries)countryValues.GetValue(random.Next(countryValues.Length));
                if (editProfile.Country == Countries.United_States)
                {
                    random = new Random();
                    editProfile.State = (States)stateValues.GetValue(random.Next(stateValues.Length));
                }
                editProfile.Gender = (Gender)genderValues.GetValue(random.Next(genderValues.Length));
                editProfile.Username = user.Email;
                editProfile.ZipCode = (random.Next(10000, 99999)).ToString();
                editProfile.Ideology = "Communist";
                editProfile.SocialCoordinate = random.Next(-10, 10);
                editProfile.EconomicCoordinate = random.Next(-10, 10);
                await _profileService.EditProfile(user.Email, editProfile);
            }

            await _context.SaveChangesAsync();
        }

        private async Task GenerateDebates()
        {
            var users = await _context.Users.ToListAsync();
            var debates = new DebateRequestDto[] {
                new DebateRequestDto() {
                    Topic = $"{users[0].Email} Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur.Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                    Description = $"{users[0].Email} Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                    CreatedById = users[0].Id
                },
                new DebateRequestDto()
        {
            Topic = $"{users[1].Email} Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                    Description = $"{users[1].Email} Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                    CreatedById = users[1].Id
                },
                new DebateRequestDto()
        {
            Topic = $"{users[2].Email} Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                    Description = $"{users[2].Email} Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                    CreatedById = users[2].Id
                },
                new DebateRequestDto()
        {
            Topic = $"{users[3].Email} Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                    Description = $"{users[3].Email} Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                    CreatedById = users[3].Id
                },
                new DebateRequestDto()
        {
            Topic = $"{users[4].Email} Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                    Description = $"{users[4].Email} Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                    CreatedById = users[4].Id
                },
            };

            foreach (var debate in debates)
            {
                await _debateService.CreateDebate(debate);
}
await _context.SaveChangesAsync();
        }

        private async Task GenerateComments()
{
    var users = await _context.Users.ToListAsync();
    var debates = await _context.Debates.Take(5).ToListAsync();
    var comments = new CommentRequestDto[] {
                new CommentRequestDto() {
                    Text = $"{debates[0].Topic} Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                    CreatedBy = users[0],
                    DebateId = debates[0].Id,
                    Parent = null
                },
                new CommentRequestDto() {
                    Text = $"{debates[1].Topic} Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                    CreatedBy = users[1],
                    DebateId = debates[1].Id,
                    Parent = null
                },
                new CommentRequestDto() {
                    Text = $"{debates[2].Topic} Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                    CreatedBy = users[2],
                    DebateId = debates[2].Id,
                    Parent = null
                },
                new CommentRequestDto() {
                    Text = $"{debates[3].Topic} Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                    CreatedBy = users[3],
                    DebateId = debates[3].Id,
                    Parent = null
                },
                new CommentRequestDto() {
                    Text = $"{debates[4].Topic} Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                    CreatedBy = users[4],
                    DebateId = debates[4].Id,
                    Parent = null
                }
            };
    foreach (var comment in comments)
    {
        await _commentService.CreateComment(comment);
    }
    await _context.SaveChangesAsync();
}

private async Task GenerateGroups()
{
    var users = await _context.Users.ToListAsync();
    var groups = new GroupCreateRequestDto[] {
                new GroupCreateRequestDto() { Bio = "A new bio", Creator = users[0], LogoUrl = "https://www.mylogo.com/group.png",  Name = $"Group by: {users[0].Profile.Username}" },
                new GroupCreateRequestDto() { Bio = "A new bio", Creator = users[1], LogoUrl = "https://www.mylogo.com/group.png",  Name = $"Group by: {users[1].Profile.Username}" },
            };

    foreach (var group in groups)
    {
        await _groupService.CreateGroup(group);
    }
    await _context.SaveChangesAsync();
}
    }
}