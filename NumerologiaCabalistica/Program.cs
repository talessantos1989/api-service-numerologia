
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;
using NumerologiaCabalistica.Calculos;
using NumerologiaCabalistica.Calculos.Interfaces;
using NumerologiaCabalistica.Data;
using NumerologiaCabalistica.Repository;
using NumerologiaCabalistica.Service;

var builder = WebApplication.CreateBuilder(args);


var connectionString = builder.Configuration.GetConnectionString("NumerologiaCabalisticaConnection");
//var databaseURl = Environment.GetEnvironmentVariable("MYSQL_URL");

string connection = BuildConnectionString(connectionString);

static string BuildConnectionString(string databaseURL)
{
    var databaseUri = new Uri(databaseURL);
    var userInfo = databaseUri.UserInfo.Split(':');
    var builder = new MySqlConnectionStringBuilder
    {
        Server = databaseUri.Host,
        Port = Convert.ToUInt32(databaseUri.Port),
        UserID = userInfo[0],
        Password = userInfo[1],
        Database = databaseUri.LocalPath.TrimStart('/'),
    };
    return builder.ToString();
}


//Adiciona o entity framework na aplicação
builder.Services.AddDbContext<NumerologiaCabalisticaDbContext>(
    opts => opts.UseLazyLoadingProxies().UseMySql(connection, ServerVersion.AutoDetect(connection)));

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
