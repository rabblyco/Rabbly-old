using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RabblyApi.Groups.Dtos;
using RabblyApi.Groups.Services;

namespace RabblyApi.Groups.Controllers
{
    [Route("group")]
    [Authorize]
    public class GroupController : Controller
    {
        private readonly GroupService _groupService;

        public GroupController(GroupService groupService)
        {
            _groupService = groupService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetGroup([FromRoute] string id)
        {
            var group = await _groupService.GetGroup(id);
            if (group == null)
            {
                return NotFound();
            }
            return Ok(group);
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetGroups()
        {
            var groups = await _groupService.GetAllGroups();
            if (groups == null)
            {
                return BadRequest();
            }
            return Ok(groups);
        }

        // [HttpPost("create")]
        // public async Task<IActionResult> CreateGroup(GroupCreateRequestDto group)
        // {
        //     var groupCreated = await _groupService.CreateGroup(group);
        //     if (!groupCreated)
        //     {
        //         return BadRequest();
        //     }
        //     return Ok();
        // }

        // [HttpPatch("edit")]
        // public async Task<IActionResult> EditGroup([FromRoute] string id, GroupCreateRequestDto group)
        // {
        //     var editedGroup = await _groupService.EditGroup(id, group);
        //     if (editedGroup == null)
        //     {
        //         return BadRequest();
        //     }
        //     return Ok(editedGroup);
        // }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteGroup([FromRoute] string id)
        {
            var deletedGroup = await _groupService.DeleteGroup(id);
            if(!deletedGroup)
            {
                return BadRequest();
            }
            return NoContent();
        }
    }
}
