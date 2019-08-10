using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RabblyApi.Profiles.Dtos;
using RabblyApi.Profiles.Models;
using RabblyApi.Profiles.Services;

namespace RabblyApi.Profiles.Controllers
{
    [Route("profile")]
    [Produces("application/json")]
    [Authorize]
    public class ProfilesController : Controller
    {
        private readonly ProfileService _profileService;

        public ProfilesController(ProfileService profileService)
        {
            _profileService = profileService;
        }

        [HttpGet]
        public async Task<ActionResult<Profile>> GetUserProfile()
        {
            var email = HttpContext.User.Claims.Where(c => c.Type == ClaimTypes.Email).FirstOrDefault().Value;
            if(email == null)
            {
                email = HttpContext.User.Claims.Where(c => c.Type == "email").FirstOrDefault().Value;
            }
            var profile = await _profileService.GetProfile(email);
            if (profile == null)
            {
                return NotFound();
            }
            return Ok(profile);
        }

        [HttpPatch]
        public async Task<ActionResult<Profile>> EditUserProfile(ProfileEditDto profileToEdit)
        {
            var email = HttpContext.User.Claims.Where(c => c.Type == ClaimTypes.Email).FirstOrDefault().Value;
            if(email == null)
            {
                email = HttpContext.User.Claims.Where(c => c.Type == "email").FirstOrDefault().Value;
            }
            var profile = await _profileService.EditProfile(email, profileToEdit);
            if (profile == null)
            {
                return BadRequest(profileToEdit);
            }
            return Ok(profile);
        }
    }
}