using System;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RabblyApi.Data;
using RabblyApi.Profiles.Dtos;
using RabblyApi.Users.Models;

namespace RabblyApi.Profiles.Services
{
    public class ProfileService
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;

        public ProfileService(DatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Models.Profile> GetProfile(string email)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
            if(user?.Profile == null)
            {
                return null;
            }
            return user.Profile;
        }

        public async Task<Models.Profile> EditProfile(string email, ProfileEditDto editProfile)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
            if (user.Profile == null) return null;
            user.Profile = _mapper.Map<RabblyApi.Profiles.Models.Profile>(editProfile);
            try
            {
                _context.Users.Update(user);
                await _context.SaveChangesAsync();
            }
            catch
            {
                return null;
            }

            return user.Profile;
        }
    }
}