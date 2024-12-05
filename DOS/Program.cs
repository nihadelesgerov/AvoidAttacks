using AspNetCoreRateLimit;

var builder = WebApplication.CreateBuilder(args);

// Lets get into avoid DoS attacks as a Back End Developer

builder.Services.AddInMemoryRateLimiting();
builder.Services.AddSingleton<IRateLimitConfiguration,RateLimitConfiguration>();
builder.Services.Configure<IpRateLimitOptions>(x =>
{
    x.EnableEndpointRateLimiting= true;
    x.StackBlockedRequests = true;
    x.GeneralRules = new List<RateLimitRule>
    {
        new RateLimitRule
        {
            Endpoint = "GET:/Home/*", // with that u tell program consider request limiting for API s under Home Controller (Up to u)
            Period = "1h",
            Limit = 400 // Limit up to you but consider statistics of your app ( like how many people acively use you app)
            // You told program , One User (Per IP) will be able to send 400 requests to API s which is under Home Controller
            // (we used for get requests but u can use for even post request) 
        }
    };
});


builder.Services.AddControllersWithViews();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
