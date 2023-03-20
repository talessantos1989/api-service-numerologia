
using Microsoft.EntityFrameworkCore;
using NumerologiaCabalistica.Calculos;
using NumerologiaCabalistica.Calculos.Interfaces;
using NumerologiaCabalistica.Data;
using NumerologiaCabalistica.Service;
using Pomelo.EntityFrameworkCore.MySql;

var builder = WebApplication.CreateBuilder(args);


//var connectionString = "mysql://u317257256_root:Primeiradama0811@sql725.main-hosting.eu:3306/u317257256_numerologia";
//var databaseURl = Environment.GetEnvironmentVariable("MYSQL_URL");
//string connectionString = "server=containers-us-west-57.railway.app;database=railway;uid=root;pwd=Ma3GXkBCE2hU5LiCKGgV;port=5993";

string connectionString = builder.Configuration.GetConnectionString("NumerologiaCabalisticaConnection");
Console.WriteLine(connectionString);
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
