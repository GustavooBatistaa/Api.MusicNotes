using Api.MusicNotes._2___Application._2___DTO_s.User;
using Api.MusicNotes._3___Domain._1___Entities;
using Api.MusicNotes._4___InfraData;
using Api.MusicNotes._5___Config;
using Api.MusicNotes._5___Config._2___Jwt;
using Api.MusicNotes._5___Config._3___Utils;
using Microsoft.EntityFrameworkCore;


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
            var user = await _repository.Get(request.Email, request.Password.EncryptPassword());

            if (!IsUserValid(request, user))
            {
                return CreateUserResponseInvalid(request.Email);
            }

            return CreateUserResponseAuthorized(user);
        }

        public async Task<object> InsertUser(UserInsertDto request)
        {
            try
            {
                var userExists = await _repository.GetByEmail(request.Email);

                if (userExists != null)
                {
                    return UserLoginMessage.EmailExists;
                }

                var user = new User(request.Name, request.Email, request.Password.EncryptPassword());
                await _repository.AddUser(user);

                return Message.Success;
            }
            catch (Exception ex)
            {
                return UserLoginMessage.Error + ex;
            }
        }
        #endregion

        public async Task<ResetPasswordResponse> RedefinePassword(ResetPasswordRequest request)
        {
            var user = await _repository.GetByEmail(request.Email);

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

                await _repository.ResetPassword(user);

                await _emailService.SendPasswordResetEmailAsync(user.Email, newPassword);

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
                    Message = $"Falha ao redefinir a senha. Por favor, tente novamente mais tarde + {ex}."
                };
            }
        }
        public async Task<ResetPasswordResponse> ResetPassword(int userId, UpdatePasswordDto request)
        {
            
            try

            {
                var user = await _repository.GetByEmail(request.Email);

                if (user == null && user.Id != userId)
                {
                    return new ResetPasswordResponse
                    {
                        Success = false,
                        Message = Message.NotFound
                    };
                }
                user.Password = request.Password.EncryptPassword();

                await _repository.ResetPassword(user);



                return new ResetPasswordResponse
                {
                    Success = true,
                    Message = UserLoginMessage.PasswordSuccess
                };
            }
            catch (Exception ex)
            {
                return new ResetPasswordResponse
                {
                    Success = false,
                    Message = UserLoginMessage.PasswordFailed + ex.Message
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
                Role = user.Role,
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

