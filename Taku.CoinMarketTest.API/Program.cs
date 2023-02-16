using Taku.CoinMarketTest.API;
using Taku.CoinMarketTest.Data;
using Taku.CoinMarketTest.Domain.CommandHandler;
using Taku.CoinMarketTest.Domain.QueryHandlers;
using Taku.CoinMarketTest.Domain;
using Microsoft.EntityFrameworkCore;
using Taku.CoinMarketTest.API.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));

//you only need one mediator in my app life cylcle
builder.Services.AddSingleton<Mediator>();

builder.Services.AddTransient<IGetCoinData, GetCoinDataImplementation>();


//we only use the 
builder.Services.AddTransient(typeof(IRepository<>), typeof(GenericRepository<>));
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();

//abstract way fpr the prpgam to sel asses uts self at run ti - the program becomes self aware at runtime. it will look for icquery it reflection
builder.Services.AddCommandQueryHandlers(typeof(IQueryHandler<,>), "Taku.CoinMarketTest.Domain");
builder.Services.AddCommandQueryHandlers(typeof(ICommandHandler<>), "Taku.CoinMarketTest.Domain");



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
