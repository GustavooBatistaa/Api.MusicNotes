using Api.MusicNotes._2___Application._2___DTO_s.Hymn;
using Api.MusicNotes._2___Services;
using Microsoft.AspNetCore.Authorization;
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


        /// <summary>
        /// Lista todos os registros.
        /// </summary>
        [HttpGet]
        [Authorize()]
        public async Task<ActionResult<List<HymnResponse>>> Get()
		{
			var response = await _hymnService.GetAll();
			return Ok(response);
		}

        /// <summary>
        /// Lista um registro por Id
        /// </summary>
        /// <param name="id">ID do registro a ser atualizado.</param>
        [HttpGet("{id}")]
        [Authorize()]
        public async Task<ActionResult<HymnResponse>>Get( int id)
		{
			var response = await _hymnService.GetById(id);
			return Ok(response);
		}

	}

}
