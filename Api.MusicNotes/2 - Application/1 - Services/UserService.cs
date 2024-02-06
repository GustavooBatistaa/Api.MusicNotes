using Api.MusicNotes._2___Application._2___DTO_s.Events;
using Api.MusicNotes._2___Application._2___DTO_s.User;
using Api.MusicNotes._3___Domain._1___Entities;
using Api.MusicNotes._4___InfraData;
using Api.MusicNotes._5___Config;
using Api.MusicNotes._5___Config._2___Jwt;
using Microsoft.VisualBasic;

namespace Api.MusicNotes._2___Services
{
	public class UserService
	{
		private readonly UserRepository _repository;

		private const string MessageError = "Dados Inválidos";

		public UserService(UserRepository repository)
		{
			_repository = repository ?? throw new ArgumentNullException(nameof(repository));
		}


		public async Task<string> Login(UserLoginDto request)
		{
			var user = _repository.Get(request.Email, request.Password);


			if (request.Password != user.Password)
			{
				return "Erro";
			}
			

			
			var token = TokenService.GenerateToken(user);

			user.Password = "";

			return token;
			
		}

	}
}

