﻿using Api.MusicNotes._2___Services;
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
			var key = Encoding.ASCII.GetBytes(Settings.Secret);

			services.AddAuthentication(x =>
			{
				x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
				x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
			}).AddJwtBearer(x =>
			{
				x.RequireHttpsMetadata = false;
				x.SaveToken = true;
				x.TokenValidationParameters = new TokenValidationParameters
				{
					ValidateIssuerSigningKey = true,
					IssuerSigningKey = new SymmetricSecurityKey(key),
					ValidateIssuer = false,
					ValidateAudience = false
				};
			});
			services.AddAuthorization(options =>
			{
				options.AddPolicy("EncarregadoLocal", policy => policy.RequireRole("Encarregado Local"));
				options.AddPolicy("EncarregadoRegional", policy => policy.RequireRole("Encarregado Regional"));
				options.AddPolicy("Instrutor", policy => policy.RequireRole("Instrutor"));
				options.AddPolicy("Aluno", policy => policy.RequireRole("Aluno"));
			});
            services.AddCors();
            #region dependências 

            #region Services
            services.AddScoped<EventService>();
			services.AddScoped<IAppSettings, AppSettings>();
			services.AddScoped<BaseService>();
			services.AddScoped<UserService>();
			services.AddScoped<FunctionService>();
			services.AddScoped<GroupService>();
			services.AddScoped<CorrectionService>();
			services.AddScoped<HymnService>();
			services.AddScoped<ReasonService>();
			services.AddScoped<EmailService>();
			services.AddScoped<CongregationService>();
			services.AddScoped<OrganistService>();
			#endregion
			
			#region Repositories
			services.AddScoped<EventRepository>();
			services.AddScoped<UserRepository>();
			services.AddScoped<FunctionRepository>();
			services.AddScoped<GroupRepository>();
			services.AddScoped<CorrectionRepository>();
			services.AddScoped<HymnRepository>();
			services.AddScoped<ReasonRepository>();
			services.AddScoped<OrganistRepository>();
			services.AddScoped<ActivityRepository>();
			services.AddScoped<CongregationRepository>();
			#endregion
			#endregion

			#region Configuração de outros serviços
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
			#endregion
		}
	}
}

