using Api.MusicNotes._2___Application._2___DTO_s.Activity;
using Api.MusicNotes._2___Services;
using Api.MusicNotes._5___Config._3___Utils;
using Microsoft.AspNetCore.Mvc;


namespace Api.MusicNotes._1___Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class ActivityController : ControllerBase
    {
        private readonly ActivityService _service;

        public ActivityController(ActivityService service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }



        [HttpGet("/get-list/congregation/{congregationId}")]
        //[Authorize()]
        public async Task<ActionResult<List<ActivityResponse>>> GetAll(int congregationId)
        {
            var response = await _service.GetAllCongregationId(congregationId);
            return Ok(response);
        }

        

        [HttpGet("{id}")]
        //  [Authorize()]
        public async Task<ActionResult<ActivityResponse>> Get(int id)
        {
            var response = await _service.GetById(id);
            return Ok(response);
        }

        /// <summary>
        ///Insere um novo registro
        /// </summary>
        /// <param name="request">.</param>
        [HttpPost("insert")]
        //  [Authorize()]
        public async Task<ActionResult> Insert(ActivityInsert request)
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
