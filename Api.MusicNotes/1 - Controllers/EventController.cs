using Api.MusicNotes._2___Application._2___DTO_s.Events;
using Api.MusicNotes._2___Services;
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



		[HttpGet]
		public async Task<ActionResult<List<EventResponse>>> Get()
		{
			var response = await _eventService.GetEvents();
			return Ok(response);
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<EventResponse>>Get( int id)
		{
			var response = await _eventService.GetEventById(id);
			return Ok(response);
		}

	}

}
