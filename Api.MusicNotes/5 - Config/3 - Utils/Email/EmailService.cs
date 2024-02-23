using System.Net;
using System.Net.Mail;

namespace Api.MusicNotes._5___Config._3___Utils
{
  
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _configuration;

        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task SendPasswordResetEmailAsync(string emailAddress, string newPassword)
        {
            var email = _configuration["EmailSettings:Email"];
            var password = _configuration["EmailSettings:Password"];

            var smtpClient = new SmtpClient("smtp.outlook.com")
            {
                Port = 587,
                Credentials = new NetworkCredential(email, password),
                EnableSsl = true
            };

            var mailMessage = new MailMessage
            {
                From = new MailAddress(email),
                Subject = "Redefinição de Senha",
                Body = $"Sua nova senha é: {newPassword}. Lembre-se de atualizar sua senha ao fazer login."
            };

            mailMessage.To.Add(emailAddress);

            await smtpClient.SendMailAsync(mailMessage);
        }
    }
}
