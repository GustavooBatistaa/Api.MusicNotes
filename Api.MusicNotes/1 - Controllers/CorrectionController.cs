﻿using Api.MusicNotes._2___Application._2___DTO_s.Correction;
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



		[HttpGet]
		public async Task<ActionResult<List<CorrectionResponse>>> Get()
		{
			var response = await _correctionService.GetAll();
			return Ok(response);
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<CorrectionResponse>>Get( int id)
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

    }

}
