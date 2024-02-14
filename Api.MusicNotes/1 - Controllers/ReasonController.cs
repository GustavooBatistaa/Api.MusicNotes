using Api.MusicNotes._2___Application._2___DTO_s.Hymn;
using Api.MusicNotes._2___Services;
using Microsoft.AspNetCore.Mvc;

namespace Api.MusicNotes._1___Controllers
{

	[ApiController]
	[Route("[controller]")]
	public class ReasonController : ControllerBase
	{
		private readonly ReasonService _reasonService;

		public ReasonController(ReasonService reasonService)
		{
			_reasonService = reasonService ?? throw new ArgumentNullException(nameof(reasonService));
		}



		[HttpGet]
		public async Task<ActionResult<List<ReasonResponse>>> Get()
		{
			var response = await _reasonService.GetAll();
			return Ok(response);
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<ReasonResponse>>Get( int id)
		{
			var response = await _reasonService.GetById(id);
			return Ok(response);
		}

	}

}
