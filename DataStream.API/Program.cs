using DataStream.API.Database.Dapper;
using DataStream.API.Database.Dapper.Interfaces;
using DataStream.API.Database.EF;
using DataStream.API.Infra.Settings;
using DataStream.API.Repositories.Dapper;
using DataStream.API.Repositories.Interfaces;
using DataStream.API.Services;
using DataStream.API.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<ConnectionStringSetting>(
    builder.Configuration.GetSection("ConnectionStrings"));

builder.Services.AddDbContext<DataStreamDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddSingleton<IDbConnectionFactory, SqlConnectionFactory>();

builder.Services.AddScoped<IClientService, ClientService>();
builder.Services.AddScoped<IClientRepository, DClientRepository>();

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();
