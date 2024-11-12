using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using webapp.Models;

var builder = WebApplication.CreateBuilder(args);

// Register services (must be before builder.Build())
builder.Services.AddControllersWithViews();

// Configure the DbContext with a connection string
var connectionString = builder.Configuration.GetConnectionString("Default");
builder.Services.AddDbContext<HrDatabaseContext>(options =>
    options.UseSqlServer(connectionString));

// Register Identity services before building the app
builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
    options.Password.RequireDigit = false)
    .AddEntityFrameworkStores<HrDatabaseContext>()
    .AddDefaultTokenProviders(); // Optionally add token providers like for password reset, etc.

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

// Define routing
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
