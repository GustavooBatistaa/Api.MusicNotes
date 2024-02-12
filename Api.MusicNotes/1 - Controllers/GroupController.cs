using Api.MusicNotes._2___Application._2___DTO_s.Events;
using Api.MusicNotes._2___Application._2___DTO_s.Function;
using Api.MusicNotes._2___Application._2___DTO_s.Group;
using Api.MusicNotes._2___Services;
using Api.MusicNotes._3___Domain._1___Entities;
using Microsoft.AspNetCore.Cors.Infrastructure;
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



		[HttpGet]
		public async Task<ActionResult<List<GroupResponse>>> Get()
		{
			var response = await _groupService.GetGroups();
			return Ok(response);
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<GroupResponse>>Get( int id)
		{
			var response = await _groupService.GetById(id);
			return Ok(response);
		}

	}

}
