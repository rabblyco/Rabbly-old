using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RabblyApi.Debates.Dtos;
using RabblyApi.Debates.Services;

namespace RabblyApi.Debates.Controllers
{
    [Route("debate")]
    public class DebateController : Controller
    {
        private readonly DebateService _debateService;

        public DebateController(DebateService debateService)
        {
            _debateService = debateService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDebate(string id)
        {
            var debate = await _debateService.GetDebate(id);
            if (debate == null)
            {
                return BadRequest();
            }
            return Ok(debate);
        }

        [Authorize]
        [HttpGet("all")]
        public async Task<IActionResult> GetAllDebates()
        {
            var debates = await _debateService.GetDebates();
            if (debates == null)
            {
                return BadRequest();
            }
            return Ok(debates);
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateDebate(DebateRequestDto newDebate)
        {
            var debate = await _debateService.CreateDebate(newDebate);
            if(!debate)
            {
                return BadRequest();
            }
            return Ok(debate);
        }

        [HttpPatch("edit")]
        [Authorize]
        public async Task<IActionResult> EditDebate(string id, DebateRequestDto editedDebate)
        {
            var debate = await _debateService.GetDebate(id);

            if (debate.CreatedAt > DateTime.Now.AddHours(-1))
            {
                return StatusCode(406, new {
                    error = "Debates are only editable within the first hour after they are created."
                });
            }

            var updatedDebate = await _debateService.EditDebate(id, editedDebate);

            if (updatedDebate == null)
            {
                return BadRequest();
            }

            return Ok(updatedDebate);
        }

        [Authorize]
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteDebate([FromRoute] string id)
        {
            var debate = await _debateService.GetDebate(id);
            if (debate == null) {
                return BadRequest();
            }
            var wasDebateDeleted = await _debateService.DeleteDebate(id);
            if(!wasDebateDeleted)
            {
                return BadRequest();
            }
            return NoContent();
        }
    }
}