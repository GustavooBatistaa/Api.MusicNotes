using Api.MusicNotes._2___Application._2___DTO_s.User;
using Api.MusicNotes._2___Services;
using Api.MusicNotes._3___Domain._1___Entities;
using Api.MusicNotes._4___InfraData;
using Api.MusicNotes._5___Config;
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

		[HttpPost]
		public async Task<IActionResult> Login([FromBody]UserLoginDto request)
		{


			var token = await _userService.Login(request);

			if (token == null)
			{
				return NotFound(new { message = "Usuário não encontrado" });
			}

			return Ok(new { token });
		}
	};
	
}