using Api.MusicNotes._2___Application._2___DTO_s.User;
using Api.MusicNotes._2___Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.MusicNotes.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
        }

        [HttpPost("/login")]
        public async Task<IActionResult> Login([FromBody] UserLoginDto request)
        {
            var userResponse = await _userService.Login(request);

            if (userResponse == null)
            {
                return NotFound(new { message = "Usuário não encontrado" });
            }

            return Ok(userResponse);
        }


        [HttpPost]
        public async Task<IActionResult> InsertUser([FromBody] UserInsertDto request)
        {
            if (request == null)
            {
                return NotFound(new { message = "Dados inválidos" });
            }

            var user = _userService.InsertUser(request);

            return Ok(user);
        }

        [HttpPut("redefine-password")]
        public async Task<IActionResult> RedefinePassword([FromBody] ResetPasswordRequest request)
        {
            if (request == null)
            {
                return NotFound(new { message = "Dados inválidos" });
            }

            var user = _userService.RedefinePassword(request);

            return Ok(user);
        }

        [HttpPut("/{userId}/reset-password")]
        [Authorize()]
        public async Task<IActionResult> ResetPassword(int userId, [FromBody] UpdatePasswordDto request)
        {
            if (request == null)
            {
                return NotFound(new { message = "Dados inválidos" });
            }

            var user = _userService.ResetPassword(userId, request);

            return Ok(user);
        }
    };

}