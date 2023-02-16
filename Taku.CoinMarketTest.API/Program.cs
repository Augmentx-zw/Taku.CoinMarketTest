using Taku.CoinMarketTest.API;
using Taku.CoinMarketTest.Data;
using Taku.CoinMarketTest.Domain.CommandHandler;
using Taku.CoinMarketTest.Domain.QueryHandlers;
using Taku.CoinMarketTest.Domain;
using Microsoft.EntityFrameworkCore;
using Taku.CoinMarketTest.API.Services;
using Microsoft.Extensions.Configuration;
using Taku.CoinMarketTest.Domain.Configurations;
using Taku.CoinMarketTest.Domain.Services;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using MediatR;
using System.Net.NetworkInformation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddHttpClient();


//you only need one mediator in my app life cylcle
builder.Services.Configure<AppConfigs>(builder.Configuration.GetSection("AppConfig"));

builder.Services.AddMediatR(cfg => {
    cfg.RegisterServicesFromAssembly(typeof(Program).Assembly);
});


builder.Services.AddTransient(typeof(IRepository<>), typeof(GenericRepository<>));
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
builder.Services.AddTransient<IHttpService, HttpService>();



builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
