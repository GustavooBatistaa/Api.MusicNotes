using Api.MusicNotes._2___Application._2___DTO_s.Correction;
using Api.MusicNotes._2___Application._2___DTO_s.Group;
using Api.MusicNotes._2___Services;
using Api.MusicNotes._5___Config._3___Utils;
using Microsoft.AspNetCore.Mvc;

namespace Api.MusicNotes._1___Controllers
{

	[ApiController]
	[Route("[controller]")]
	public class GroupController : ControllerBase
	{
		private readonly GroupService _groupService;

		public GroupController(GroupService groupService)
		{
			_groupService = groupService ?? throw new ArgumentNullException(nameof(groupService));
		}



		[HttpGet("user/{userId}")]
		public async Task<ActionResult<List<GroupResponse>>> Get(int userId)
		{
			var response = await _groupService.GetGroups(userId);
			return Ok(response);
		}

		[HttpGet("{id}/user/{userId}")]
		public async Task<ActionResult<GroupResponse>>Get( int id, int userId)
		{
			var response = await _groupService.GetById(id, userId);
			return Ok(response);
		}

        [HttpPost()]
        public async Task<ActionResult> Insert(GroupInsert request)
        {
            if (request == null)
            {
                return BadRequest(Message.MessageError);
            }

            var response = await _groupService.Insert(request);
            return Ok(response);
        }

    }

}
