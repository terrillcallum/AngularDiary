using Microsoft.AspNetCore.Identity;
using Project1;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Project1.Models;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString).EnableSensitiveDataLogging());


builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddControllersWithViews();
builder.Services.AddControllers();
builder.Services.AddSingleton<ITokenService, TokenService>();


var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var dbContext = services.GetRequiredService<ApplicationDbContext>();
    var userManager = services.GetRequiredService<UserManager<IdentityUser>>();

    dbContext.Database.EnsureCreated();


    // Check if the user already exists
    var existingUser = await userManager.FindByEmailAsync("example@example.com");

    if (existingUser == null)
    {
        // Create a new user
        var user = new IdentityUser
        {
            UserName = "example@example.com",
            Email = "example@example.com"
        };

        var result = await userManager.CreateAsync(user, "123");

        if (result.Succeeded)
        {
            // User created successfully
        }
        else
        {
            // Error creating user
        }
    }

}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html");

app.Run();
