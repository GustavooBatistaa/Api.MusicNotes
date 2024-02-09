using Api.MusicNotes._2___Services;
using Api.MusicNotes._4___InfraData;
using Api.MusicNotes._4___InfraData._2___AppSettings;
using Api.MusicNotes._5___Config._3___Utils;
using Api.MusicNotes._5___Config._3___Utils._4___AppSettings;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.IO;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Configuração da conexão com o banco de dados
var connectionString = builder.Configuration.GetConnectionString("MusicNotesCs");
builder.Services.AddDbContext<MusicNotesDbContext>(options => options.UseSqlServer(connectionString));

// Configuração do serviço de autenticação JWT
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
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

// Adição da dependência do EventService
builder.Services.AddScoped<EventService>();
builder.Services.AddScoped<IAppSettings, AppSettings>();

builder.Services.AddScoped<BaseService>();

builder.Services.AddScoped<UserService>();

builder.Services.AddScoped<EventRepository>();

builder.Services.AddScoped<UserRepository>();

// Configuração de outros serviços
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
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

var app = builder.Build();

// Configuração do pipeline HTTP
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication(); // Adição do middleware de autenticação JWT
app.UseAuthorization();

app.MapControllers();

app.Run();
