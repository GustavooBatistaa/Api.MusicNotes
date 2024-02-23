namespace Api.MusicNotes._5___Config._3___Utils
{
    public interface IEmailService
    {
        Task SendPasswordResetEmailAsync(string emailAddress, string newPassword);
    }

}
