<h1>Solution Overview:</h1>

To Run the solution:
1. Clone the repo.
2. Restore the nugget packages.
3. You can set multiple projects as startup "API, Identity, and Client" like Below:
4. Run the solution.

N.B No need to update the database - this line already does it for you Database.EnsureCreated();

The solution is build using:
1. Domain Driven Design
2. Repository Patten 
3. Unit of work

<h1>The API Project</h1>

Our API project has connects to our domain layer using reflection as shown by the code below

<code>
builder.Services.AddMediatR(cfg =>
{
 cfg.RegisterServicesFromAssembly(typeof(Program).Assembly);
 cfg.RegisterServicesFromAssembly(typeof(GetExchangeRateQueryHandler).Assembly);
});

</code>
In our controller we call the Domain Layer Query Handlers as below.

On GetCurrentCoinMarket we pass the currency we want to get for example USD, ZAR,...

<code>
[HttpGet("GetCurrentCoinMarket")]
   public async Task<IActionResult> GetCurrentCoinMarketAsync(string currency)
   {
       CoinClassDto result = await _mediator.Send(new GetExchangeRateQuery {Currency = currency });
       return Ok(result);
   }
   
   [HttpGet("GetCoinMarketHistory")]
   public async Task<IActionResult> GetCoinMarketHistoryAsync()
   {
     var result = await _mediator.Send(new GetExchangeRatesQuery { });
     return Ok(result);
   }  
 </code>
 
N.B We make sure our API is protected by the [Authorize] attribute.

Our App settings contain our database connection string and AppConfig to get the coin market data
• The Key store the API key “This in production is set in env variables”
• The Limit is a parameter that we can modify to pass to the coin market API to limit the data we can get

<code>
 "AppConfig": {
 "Key": "xxx-xxx-xxx",
 "Limit": "50"
 }
 </code>
 
<h1>The Domain layer</h1>

<ol>
<li> DomainEntitites -these are our database models following the domain-driven design principles. </li>
<li> DTO allow us to transfer data from the API to the Domain </li>
<li> IRepositoy and IUnitOfWork are interfaces that are implemented in the Data layer </li>
<li> QueryHandlers allow follow the CQRS Pattern which stands for Command and Query Responsibility 
Segregation, a pattern that separates read and update operations for a data store. It can improve 
performance, scalability, and security of the application. </li>
</ol>

<h1> The Data layer </h1>
Holds the Migrations and DbContext and the Repository and unity of work used by the application –
this follows the Single responsibility is a principle.

<h1> Duende Identity Sever </h1>

We use Duende as our identity sever.

<h1>The Client Project </h1>

We are using Asp.net core MVC project.
We authorize our home controller by the <b> [Authorize] </b> attribute and send requests to the API with the JWT 
token as below

<code>
   using var client = new HttpClient();
   var token = await HttpContext.GetTokenAsync("access_token");
   client.SetBearerToken(token);
   var currency = "USD";
   var result = await client.GetAsync($"https://localhost:5445/api/CoinMarket/GetCurrentCoinMarket?currency={currency}");
   if (result.IsSuccessStatusCode)
   {
   var model = await result.Content.ReadAsStringAsync();
   var coinData = JsonConvert.DeserializeObject<CoinClassViewModel>(model);
  ...
 </code>
 
N.B: var currency = "USD"; the currency can set to any iso currency code.
