using Api.MusicNotes._2___Application._2___DTO_s.Correction;
using Api.MusicNotes._2___Application._2___DTO_s.Function;
using Api.MusicNotes._2___Services;
using Api.MusicNotes._5___Config._3___Utils;
using Azure.Core;
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



		[HttpGet("/group/{groupId}")]
		public async Task<ActionResult<List<CorrectionResponse>>> Get(int groupId)
		{
			var response = await _correctionService.GetAll(groupId);
			return Ok(response);
		}

        [HttpGet("/rehearsed/group/{groupId}")]
        public async Task<ActionResult<List<CorrectionResponse>>> GetAllRehearsed(int groupId)
        {
            var response = await _correctionService.GetAllRehearsed(groupId);
            return Ok(response);
        }

        [HttpGet("/{id}")]
		public async Task<ActionResult<CorrectionResponse>> GetById( int id)
		{
            if (id == 0)
            {
                return BadRequest(Message.MessageError);
            }

            var response = await _correctionService.GetById(id);
			return Ok(response);
		}

        [HttpPost()]
        public async Task<ActionResult> Insert(CorrectionInsert request)
        {
            if (request == null)
            {
                return BadRequest(Message.MessageError);
            }

            var response = await _correctionService.Insert(request);
            return Ok(response);
        }

        [HttpPut("/update/{id}")]
        public async Task<ActionResult> Update(int id, CorrectionUpdate request)
        {
            if (request == null)
            {
                return BadRequest(Message.MessageError);
            }

            var response = await _correctionService.Update(id, request);
            return Ok(response);
        }

        [HttpPatch("/rehearse/{id}")]
        public async Task<ActionResult> WentToRehearse(int id)
        {
            var response = await _correctionService.WentToRehearse(id);
            return Ok(response);
        }

    }

}
