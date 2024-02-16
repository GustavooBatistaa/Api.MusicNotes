using Api.MusicNotes._2___Application._2___DTO_s.User;
using Api.MusicNotes._3___Domain._1___Entities;
using Api.MusicNotes._4___InfraData;
using Api.MusicNotes._5___Config;
using Api.MusicNotes._5___Config._2___Jwt;
using Api.MusicNotes._5___Config._3___Utils;


namespace Api.MusicNotes._2___Services
{
	public class UserService
	{
		#region Construtor
		private readonly UserRepository _repository;

		public UserService(UserRepository repository)
		{
			_repository = repository ?? throw new ArgumentNullException(nameof(repository));
		}

		#endregion

		#region Metodos
		public async Task<UserResponseLogin> Login(UserLoginDto request)
		{
			var user =  _repository.Get(request.Email, request.Password);

			if (!IsUserValid(request, user))
			{
				return CreateUserResponseInvalid(request.Email);
			}

			return CreateUserResponseAuthorized(user);
		}


		public object InsertUser( UserInsertDto request)
		{
			if( request.Password != request.ConfirmPassword)
			{
				return UserLoginMessage.InvalidPassword;
			}

			var userexists = _repository.GetByEmail(request.Email);

			if (userexists != null)
			{
				return UserLoginMessage.EmailExists;
			}

			var user = new User(request.Name, request.Email, request.Password.EncryptPassword());
			_repository.AddUser(user);
			return Message.Sucess;
			
			
		}
		#endregion

		#region Metodos Privados
		private UserResponseLogin CreateUserResponseAuthorized(User user)
		{
			var token = TokenService.GenerateToken(user);
			
			return new UserResponseLogin
			{
				Email = user.Email,
				Token = token,
				Message = UserLoginMessage.Authorized
			};
		}

		

		private bool IsUserValid(UserLoginDto request, User user) => user != null && request.Email == user.Email && request.Password.EncryptPassword() == user.Password.EncryptPassword();

		private UserResponseLogin CreateUserResponseInvalid(string email)
		{
			return new UserResponseLogin
			{
				Email = email,
				Message = UserLoginMessage.InvalidCredentials
			};
		}

		#endregion


	}
}

