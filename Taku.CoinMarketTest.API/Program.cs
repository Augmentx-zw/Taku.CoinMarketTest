using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Taku.CoinMarketTest.Data;
using Taku.CoinMarketTest.Domain;
using Taku.CoinMarketTest.Domain.Configurations;
using Taku.CoinMarketTest.Domain.QueryHandlers.ExchangeRateDetails;
using Taku.CoinMarketTest.Domain.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddHttpClient();

builder.Services.Configure<AppConfigs>(builder.Configuration.GetSection("AppConfig"));

builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssembly(typeof(Program).Assembly);
    cfg.RegisterServicesFromAssembly(typeof(GetExchangeRateQueryHandler).Assembly);
});


builder.Services.AddTransient<ICoinMarketService, CoinMarketService>();
builder.Services.AddTransient(typeof(IRepository<>), typeof(GenericRepository<>));
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
builder.Services.AddTransient<IHttpService, HttpService>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.Authority = "https://localhost:5443";
        options.Audience = "CoinMarketTestApi";
        options.TokenValidationParameters.ValidTypes = new[] { "at+jwt" };
    });




builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
