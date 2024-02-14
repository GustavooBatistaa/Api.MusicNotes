using Api.MusicNotes._2___Application._2___DTO_s.Hymn;
using Api.MusicNotes._2___Services;
using Microsoft.AspNetCore.Mvc;

namespace Api.MusicNotes._1___Controllers
{

	[ApiController]
	[Route("[controller]")]
	public class HymnController : ControllerBase
	{
		private readonly HymnService _hymnService;

		public HymnController(HymnService hymnService)
		{
			_hymnService = hymnService ?? throw new ArgumentNullException(nameof(hymnService));
		}



		[HttpGet]
		public async Task<ActionResult<List<HymnResponse>>> Get()
		{
			var response = await _hymnService.GetAll();
			return Ok(response);
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<HymnResponse>>Get( int id)
		{
			var response = await _hymnService.GetById(id);
			return Ok(response);
		}

	}

}
