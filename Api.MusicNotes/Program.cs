using Api.MusicNotes._5___Config._4__DependencyInjectionConfig;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Configuração da conexão com o banco de dados
var connectionString = builder.Configuration.GetConnectionString("MusicNotesCs");

// Configuração da injeção de dependência
DependencyInjectionConfig.Configure(builder.Services, connectionString);

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

