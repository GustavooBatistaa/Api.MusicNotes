using Api.MusicNotes._4___InfraData._2___AppSettings;

namespace Api.MusicNotes._5___Config._3___Utils._4___AppSettings
{
	public class AppSettings : IAppSettings
	{
		#region [ Fields ]
		public void Dispose() { }

		private readonly ILogger _logger;
		private readonly IConfiguration _configuration;
		private readonly IWebHostEnvironment _environment;
		private readonly IHttpContextAccessor _httpContextAccessor;
		#endregion

		#region [ Constructor ]

		public AppSettings(
			IConfiguration configuration = null,
			IWebHostEnvironment environment = null,
			IHttpContextAccessor httpContextAccessor = null)
		{
			
			_environment = environment;
			_configuration = configuration;
			_httpContextAccessor = httpContextAccessor;

		}
		#endregion

		#region [ Public Methods ]
		public IConfiguration GetConfiguration() => _configuration;
		public IHttpContextAccessor GetHttpContext() => _httpContextAccessor;
		public IWebHostEnvironment GetHostingEnvironment() => _environment;
		#endregion
	}
}
