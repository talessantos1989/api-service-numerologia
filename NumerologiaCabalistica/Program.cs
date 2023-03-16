
using Microsoft.EntityFrameworkCore;
using NumerologiaCabalistica.Calculos;
using NumerologiaCabalistica.Calculos.Interfaces;
using NumerologiaCabalistica.Data;
using NumerologiaCabalistica.Repository;
using NumerologiaCabalistica.Service;

var builder = WebApplication.CreateBuilder(args);


var connectionString = builder.Configuration.GetConnectionString("NumerologiaCabalisticaConnection");
//var databaseURl = Environment.GetEnvironmentVariable("MYSQL_URL");

//var connection = string.IsNullOrEmpty(databaseURl) ? connectionString : DataBaseConnector.GetConnectionString(databaseURl);


//Adiciona o entity framework na aplicação
builder.Services.AddDbContext<NumerologiaCabalisticaDbContext>(
    opts => opts.UseLazyLoadingProxies().UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

// Add services to the container.

builder.Services.AddControllers().AddNewtonsoftJson();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Configura os plugins Automapper e Automapper Dependency Injection na aplicacao
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddHostedService<SendMapWorker>();


builder.Services.AddScoped<INumerologiaCabalisticaCalculos, NumerologiaCabalisticaCalculos>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();


app.MapControllers();

app.Run();
