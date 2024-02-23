using Api.MusicNotes._2___Application._2___DTO_s.Function;
using Api.MusicNotes._2___Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.MusicNotes._1___Controllers
{

	[ApiController]
	[Route("[controller]")]
	public class FunctionController : ControllerBase
	{
		private readonly FunctionService _functionService;

		public FunctionController(FunctionService functionService)
		{
			_functionService = functionService ?? throw new ArgumentNullException(nameof(functionService));
		}


        /// <summary>
        ///Lista todos os registros
        /// </summary>
        [HttpGet]
        [Authorize()]
        public async Task<ActionResult<List<FunctionResponse>>> Get()
		{
			var response = await _functionService.GetFunctions();
			return Ok(response);
		}

        /// <summary>
        ///Lista um registro por Id
        /// </summary>
        /// <param name="id">.</param>
        [HttpGet("{id}")]
        [Authorize()]
        public async Task<ActionResult<FunctionResponse>>Get( int id)
		{
			var response = await _functionService.GetFunctionById(id);
			return Ok(response);
		}

	}

}
