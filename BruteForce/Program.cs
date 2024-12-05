using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Lets get into avoid Brute Force as a Back End Developer

// Most of time hackers can hack passwords which is like "12345" or "123nnn" 
// To avoid this kind of attacks the only thing you can force user to use Password like "MyPas123#"
// As you see Users uses Uppercase, lowercase,Minimum 8 elements and non alphametric element
// Lets get into it

builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequireNonAlphanumeric = true; // True if passwords must contain a lower case ASCII character.
    options.Password.RequireDigit = true; //  True if passwords must contain a digit.
    options.Password.RequireLowercase = true; // True if passwords must contain a lower case ASCII character.
    options.Password.RequireUppercase = true; // True if passwords must contain a upper case ASCII character.
    options.Password.RequiredLength = 8; // Gets or sets the minimum number of unique characters which a password must contain.
});
// Learn how to user Lockout with Identity 


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
