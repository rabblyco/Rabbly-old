using System.Threading.Tasks;
using RabblyApi.Data;
using Microsoft.EntityFrameworkCore;
using System;
using RabblyApi.Users.Models;
using RabblyApi.Profiles.Models;
using RabblyApi.Users.Dtos;
using System.Linq;

namespace RabblyApi.Users.Services
{
    public class UserService
    {
        private readonly DatabaseContext _context;

        public UserService(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<User> GetUser(string email)
        {
            var user = await _context.Users
                            .Include(u => u.Profile)
                            .Include(u => u.Group)
                            .Include(u => u.Rank)
                            .SingleOrDefaultAsync(u => u.Email == email);

            var debates = await _context.Debates.Where(u => u.CreatedBy == user).ToListAsync();
            if (user == null) return null;
            return user;
        }

        public async Task<User> Login(LoginRegisterDto model)
        {
            var user = await _context.Users
                            .Include(u => u.Profile)
                            .Include(u => u.Group)
                            .Include(u => u.Rank)
                            .SingleOrDefaultAsync(u => u.Email == model.Email);
            if (user == null) return null;
            var result = BCrypt.Net.BCrypt.EnhancedVerify(model.Password, user.Password);
            if (result)
            {
                return user;
            }
            return null;
        }

        public async Task<bool> Register(LoginRegisterDto model)
        {
            // This may need to be refactored, as it does not specify whyit failed
            var userExists = await _context.Users.AnyAsync(u => u.Email == model.Email);
            if (userExists) return false;
            // Make a new user object
            User newUser = new User();
            newUser.Email = model.Email;
            newUser.Password = BCrypt.Net.BCrypt.EnhancedHashPassword(model.Password, 12);
            var profile = new Profile();
            profile.User = newUser;
            profile.Username = newUser.Email.Split("@")[0];
            try
            {
                // Ensure user is created first
                await _context.Users.AddAsync(newUser);
                await _context.Profiles.AddAsync(profile);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.Write(ex);
                return false;
            }

            return true;
        }

        public async Task<bool> Register(string email)
        {
            var userExists = await _context.Users.AnyAsync(u => u.Email == email);
            if (userExists) return false;

            User newUser = new User();
            newUser.Email = email;
            var profile = new Profile();
            profile.User = newUser;

            try
            {
                // Ensure user is created first
                await _context.Users.AddAsync(newUser);
                await _context.Profiles.AddAsync(profile);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.Write("THIS IS MY SERMON: ", ex);
                return false;
            }

            return true;
        }

        public async Task<bool> ChangePassword(ChangePasswordDto model)
        {
            var user = await _context.Users.SingleOrDefaultAsync(u => u.Email == model.Email);
            if (user == null) return false;
            var oldPasswordMatches = BCrypt.Net.BCrypt.EnhancedVerify(model.Password, user.Password);
            if (!oldPasswordMatches) return false;
            // update password
            user.Password = BCrypt.Net.BCrypt.EnhancedHashPassword(model.NewPassword, 12);
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}