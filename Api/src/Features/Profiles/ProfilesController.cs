using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
        [Authorize]
        public async Task<IActionResult> GetUserProfile()
        {
            var email = HttpContext.User.Claims.Where(c => c.Type == ClaimTypes.Email).FirstOrDefault().Value;
            var profile = await _profileService.GetProfile(email);
            if (profile == null)
            {
                return NotFound();
            }
            return Ok(profile);
        }
    }
}