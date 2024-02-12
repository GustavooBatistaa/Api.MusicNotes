using Api.MusicNotes._2___Services;
using Api.MusicNotes._4___InfraData._2___AppSettings;
using Api.MusicNotes._4___InfraData;
using Api.MusicNotes._5___Config._3___Utils._4___AppSettings;
using Api.MusicNotes._5___Config._3___Utils;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

namespace Api.MusicNotes._5___Config._4__DependencyInjectionConfig
{
	public static class DependencyInjectionConfig
	{
		public static void Configure(IServiceCollection services, string connectionString)
		{
			// Configuração da conexão com o banco de dados
			services.AddDbContext<MusicNotesDbContext>(options => options.UseSqlServer(connectionString));

			// Configuração do serviço de autenticação JWT
			services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
				.AddJwtBearer(options =>
				{
					options.TokenValidationParameters = new TokenValidationParameters
					{
						ValidateIssuer = true,
						ValidateAudience = true,
						ValidateLifetime = true,
						ValidateIssuerSigningKey = true,
						ValidIssuer = "your_issuer",
						ValidAudience = "your_audience",
						IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("your_secret_key"))
					};
				});

			// Adição das dependências dos serviços
			services.AddScoped<EventService>();
			services.AddScoped<IAppSettings, AppSettings>();
			services.AddScoped<BaseService>();
			services.AddScoped<UserService>();
			services.AddScoped<FunctionService>();
			services.AddScoped<GroupService>();

			services.AddScoped<EventRepository>();
			services.AddScoped<UserRepository>();
			services.AddScoped<FunctionRepository>();
			services.AddScoped<GroupRepository>();

			// Configuração de outros serviços
			services.AddControllers();
			services.AddEndpointsApiExplorer();
			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new OpenApiInfo
				{
					Title = "MusicNotes.API",
					Version = "v1",
					Contact = new OpenApiContact
					{
						Name = "Gustavo Batista",
						Email = "gustavobatistaosp@gmail.com"
					}
				});

				var xmlFile = "MusicNotes.API.xml";
				var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
				// c.IncludeXmlComments(xmlPath);
			});
		}
	}
}

