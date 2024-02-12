using Api.MusicNotes._2___Services;
using Api.MusicNotes._4___InfraData;
using Api.MusicNotes._4___InfraData._2___AppSettings;
using Api.MusicNotes._5___Config._3___Utils;
using Api.MusicNotes._5___Config._3___Utils._4___AppSettings;
using Api.MusicNotes._5___Config._4__DependencyInjectionConfig;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.IO;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Configura��o da conex�o com o banco de dados
var connectionString = builder.Configuration.GetConnectionString("MusicNotesCs");

// Configura��o da inje��o de depend�ncia
DependencyInjectionConfig.Configure(builder.Services, connectionString);

var app = builder.Build();

// Configura��o do pipeline HTTP
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication(); // Adi��o do middleware de autentica��o JWT
app.UseAuthorization();
app.MapControllers();
app.Run();

