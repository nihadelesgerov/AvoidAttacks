var builder = WebApplication.CreateBuilder(args);

// You have to Configure ApplicationCookie like this


builder.Services.ConfigureApplicationCookie(options =>
{
    options.Cookie.SameSite = SameSiteMode.Strict; // You can use SameSiteMode.Strict and SameSiteMode.Lax
    options.Cookie.SecurePolicy = CookieSecurePolicy.Always; // Make Sure cookies are only sent over HTTPS
});



builder.Services.AddControllersWithViews();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}
// Make Sure you are using app.UseHTTPSRedirection
app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();
app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
