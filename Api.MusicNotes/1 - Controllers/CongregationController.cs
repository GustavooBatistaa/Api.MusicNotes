using Api.MusicNotes._2___Application._2___DTO_s.Congregation;
using Api.MusicNotes._2___Application._2___DTO_s.Correction;
using Api.MusicNotes._2___Application._2___DTO_s.Group;
using Api.MusicNotes._2___Services;
using Api.MusicNotes._5___Config._3___Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.MusicNotes._1___Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class CongregationController : ControllerBase
    {
        private readonly CongregationService _service;

        public CongregationController(CongregationService service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }



        [HttpGet()]
        //[Authorize()]
        public async Task<ActionResult<List<CongregationResponse>>> GetAll()
        {
            var response = await _service.GetAll();
            return Ok(response);
        }


        [HttpGet("{id}")]
        //  [Authorize()]
        public async Task<ActionResult<CongregationResponse>> Get(int id)
        {
            var response = await _service.GetById(id);
            return Ok(response);
        }

        /// <summary>
        ///Insere um novo registro
        /// </summary>
        /// <param name="request">.</param>
        [HttpPost()]
        //  [Authorize()]
        public async Task<ActionResult> Insert(CongregationInsert request)
        {
            if (request == null)
            {
                return BadRequest(Message.MessageError);
            }

            var response = await _service.Insert(request);
            return Ok(response);
        }

    }

}
