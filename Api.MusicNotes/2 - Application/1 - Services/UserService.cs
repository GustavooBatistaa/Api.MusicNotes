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
        private readonly EmailService _emailService;

        public UserService(UserRepository repository, EmailService emailService)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _emailService = emailService;
        }

        #endregion

        #region Metodos
        public async Task<UserResponseLogin> Login(UserLoginDto request)
        {
            var user = _repository.Get(request.Email, request.Password.EncryptPassword());

            if (!IsUserValid(request, user))
            {
                return CreateUserResponseInvalid(request.Email);
            }

            return CreateUserResponseAuthorized(user);
        }


        public object InsertUser(UserInsertDto request)
        {
            if (request.Password != request.ConfirmPassword)
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

        public ResetPasswordResponse RedefinePassword(ResetPasswordRequest request)
        {
            var user = _repository.GetByEmail(request.Email);

            if (user == null)
            {
                return new ResetPasswordResponse
                {
                    Success = false,
                    Message = Message.NotFound
                };
            }

            try
            {
                var newPassword = GenerateNewPassword();
                user.Password = newPassword.EncryptPassword();

                _repository.ResetPassword(user);

                _emailService.SendPasswordResetEmailAsync(user.Email, newPassword);

                return new ResetPasswordResponse
                {
                    Success = true,
                    Message = "Uma nova senha foi enviada para o seu email."
                };
            }
            catch (Exception ex)
            {
                return new ResetPasswordResponse
                {
                    Success = false,
                    Message = "Falha ao redefinir a senha. Por favor, tente novamente mais tarde."
                };
            }
        }

       

        public ResetPasswordResponse ResetPassword(int userId, UpdatePasswordDto request)
        {
            var user = _repository.GetByEmail(request.Email);

            if (user == null && user.Id != userId)
            {
                return new ResetPasswordResponse
                {
                    Success = false,
                    Message = Message.NotFound
                };
            }

            try
            {
                user.Password = request.Password.EncryptPassword();

                _repository.ResetPassword(user);

             

                return new ResetPasswordResponse
                {
                    Success = true,
                    Message = "Senha Alterada com Sucesso!"
                };
            }
            catch (Exception ex)
            {
                return new ResetPasswordResponse
                {
                    Success = false,
                    Message = "Falha ao redefinir a senha. Por favor, tente novamente mais tarde."
                };
            }
        }

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

        private string GenerateNewPassword()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var random = new Random();
            var newPassword = new string(Enumerable.Repeat(chars, 6)
                .Select(s => s[random.Next(s.Length)]).ToArray());
            return newPassword;
        }

        private bool IsUserValid(UserLoginDto request, User user) => user != null && request.Email == user.Email && request.Password.EncryptPassword() == user.Password;

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

