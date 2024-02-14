using Api.MusicNotes._2___Application._2___DTO_s.Correction;
using Api.MusicNotes._2___Application._2___DTO_s.Events;
using Api.MusicNotes._2___Application._2___DTO_s.Function;
using Api.MusicNotes._2___Services;
using Api.MusicNotes._3___Domain._1___Entities;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace Api.MusicNotes._1___Controllers
{

	[ApiController]
	[Route("[controller]")]
	public class CorrectionController : ControllerBase
	{
		private readonly CorrectionService _correctionService;

		public CorrectionController(CorrectionService correctionService)
		{
			_correctionService = correctionService ?? throw new ArgumentNullException(nameof(correctionService));
		}



		[HttpGet]
		public async Task<ActionResult<List<CorrectionResponse>>> Get()
		{
			var response = await _correctionService.GetAll();
			return Ok(response);
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<FunctionResponse>>Get( int id)
		{
			var response = await _correctionService.GetById(id);
			return Ok(response);
		}

	}

}
