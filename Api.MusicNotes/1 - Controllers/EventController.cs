using Api.MusicNotes._2___Application._2___DTO_s.Events;
using Api.MusicNotes._2___Services;
using Api.MusicNotes._3___Domain._1___Entities;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace Api.MusicNotes._1___Controllers
{

	[ApiController]
	[Route("[controller]")]
	public class EventController : ControllerBase
	{
		private readonly EventService _eventService;

		public EventController(EventService eventService)
		{
			_eventService = eventService ?? throw new ArgumentNullException(nameof(eventService));
		}

		

		[HttpPost]
		public async Task<ActionResult> AddEvent([FromBody] EventInsertDto request)
		{
			if (request == null)
			{
				return BadRequest("Invalid event data");
			}

			_eventService.AddEvent(request);

			return Ok("Inserido com Sucesso!");
		}

	}

}
