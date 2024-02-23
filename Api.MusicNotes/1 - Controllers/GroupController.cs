using Api.MusicNotes._2___Application._2___DTO_s.Correction;
using Api.MusicNotes._2___Application._2___DTO_s.Group;
using Api.MusicNotes._2___Services;
using Api.MusicNotes._5___Config._3___Utils;
using Microsoft.AspNetCore.Authorization;
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

        /// <summary>
        /// Lista todos os registros pelo id do usuário
        /// </summary>
        /// <param name="userId">.</param>

        [HttpGet("user/{userId}")]
        [Authorize()]
        public async Task<ActionResult<List<GroupResponse>>> Get(int userId)
		{
			var response = await _groupService.GetGroups(userId);
			return Ok(response);
		}

        /// <summary>
        /// Lista um registro pelo id do usuário
        /// </summary>
        /// <param name="userId">.</param>
		[HttpGet("{id}/user/{userId}")]
        [Authorize()]
        public async Task<ActionResult<GroupResponse>>Get( int id, int userId)
		{
			var response = await _groupService.GetById(id, userId);
			return Ok(response);
		}

        /// <summary>
        ///Insere um novo registro
        /// </summary>
        /// <param name="request">.</param>
        [HttpPost()]
        [Authorize()]
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
