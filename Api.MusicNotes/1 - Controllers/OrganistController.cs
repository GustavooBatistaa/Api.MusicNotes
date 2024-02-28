using Api.MusicNotes._2___Application._2___DTO_s.Organist;
using Api.MusicNotes._2___Services;
using Api.MusicNotes._5___Config._3___Utils;
using Microsoft.AspNetCore.Mvc;

namespace Api.MusicNotes._1___Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class OrganistController : ControllerBase
    {
        private readonly OrganistService _service;

        public OrganistController(OrganistService service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }



        [HttpGet()]
        //[Authorize()]
        public async Task<ActionResult<List<OrganistResponse>>> GetAll()
        {
            var response = await _service.GetAll();
            return Ok(response);
        }

        [HttpGet("/get-all/congregation/{congregationId}")]
        //[Authorize()]
        public async Task<ActionResult<List<OrganistResponse>>> GetAllCongregationId(int congregationId)
        {
            var response = await _service.GetAllCongregationId(congregationId);
            return Ok(response);
        }

        [HttpGet("{id}")]
        //  [Authorize()]
        public async Task<ActionResult<OrganistResponse>> Get(int id)
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
        public async Task<ActionResult> Insert(OrganistInsert request)
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
