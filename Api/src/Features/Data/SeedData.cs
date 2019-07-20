
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
                if (editProfile.Country == Countries.UnitedStates)
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
                await _profileService.EditProfile(user.Id, editProfile);
            }

            await _context.SaveChangesAsync();
        }

        private async Task GenerateDebates()
        {
            var users = await _context.Users.ToListAsync();
            var debates = new DebateRequestDto[] {
                new DebateRequestDto() {
                    Topic = $"New guy {users[0].Email}",
                    Description = $"Description {users[0].Email}",
                    CreatedBy = users[0]
                },
                new DebateRequestDto() {
                    Topic = $"New guy {users[1].Email}",
                    Description = $"Description {users[1].Email}",
                    CreatedBy = users[1]
                },
                new DebateRequestDto() {
                    Topic = $"New guy {users[2].Email}",
                    Description = $"Description {users[2].Email}",
                    CreatedBy = users[2]
                },
                new DebateRequestDto() {
                    Topic = $"New guy {users[3].Email}",
                    Description = $"Description {users[3].Email}",
                    CreatedBy = users[3]
                },
                new DebateRequestDto() {
                    Topic = $"New guy {users[4].Email}",
                    Description = $"Description {users[4].Email}",
                    CreatedBy = users[4]
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
                    Text = $"Texty {debates[0].Topic}",
                    CreatedBy = users[0],
                    Debate = debates[0],
                    Parent = null
                },
                new CommentRequestDto() {
                    Text = $"Texty {debates[1].Topic}",
                    CreatedBy = users[1],
                    Debate = debates[1],
                    Parent = null
                },
                new CommentRequestDto() {
                    Text = $"Texty {debates[2].Topic}",
                    CreatedBy = users[2],
                    Debate = debates[2],
                    Parent = null
                },
                new CommentRequestDto() {
                    Text = $"Texty {debates[3].Topic}",
                    CreatedBy = users[3],
                    Debate = debates[3],
                    Parent = null
                },
                new CommentRequestDto() {
                    Text = $"Texty {debates[4].Topic}",
                    CreatedBy = users[4],
                    Debate = debates[4],
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