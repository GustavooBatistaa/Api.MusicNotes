namespace Api.MusicNotes._4___InfraData._2___AppSettings
{
	public interface IAppSettings : IDisposable
	{

		IConfiguration GetConfiguration();
		IHttpContextAccessor GetHttpContext();
		Microsoft.AspNetCore.Hosting.IWebHostEnvironment GetHostingEnvironment();
	}
}
