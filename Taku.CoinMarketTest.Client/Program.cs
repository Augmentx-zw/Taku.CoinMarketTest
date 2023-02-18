using Taku.CoinMarketTest.Client.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddHttpClient();
builder.Services.AddScoped<IHttpClientService, HttpClientService>();
builder.Services.Configure<IdentityServerSettings>(builder.Configuration.GetSection("IdentityServerSettings"));

builder.Services.AddSingleton<ITokenService, TokenService>();

builder.Services.AddAuthentication(
  options =>
  {
      options.DefaultScheme = "cookie";
      options.DefaultChallengeScheme = "oidc";
  }).AddCookie("cookie")

  .AddOpenIdConnect("oidc", options =>
  {
      options.Authority = builder.Configuration["InteractiveServiceSettings:AuthorityUrl"];
      options.ClientId = builder.Configuration["InteractiveServiceSettings:ClientId"];
      options.ClientSecret = builder.Configuration["InteractiveServiceSettings:ClientSecret"];
      options.Scope.Add(builder.Configuration["InteractiveServiceSettings:Scopes:0"]);

      options.ResponseType = "code";
      options.UsePkce = true;
      options.ResponseMode = "query";
      options.SaveTokens = true;
  });

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
