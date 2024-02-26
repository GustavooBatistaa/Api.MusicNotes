using Api.MusicNotes._5___Config._4__DependencyInjectionConfig;
using Microsoft.EntityFrameworkCore;

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
app.UseAuthentication();
app.UseCors(x => x
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());

app.UseRouting();
app.UseAuthorization();
app.MapControllers();
app.Run();

