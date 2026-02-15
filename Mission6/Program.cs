using Microsoft.EntityFrameworkCore;
using Mission06_Powers.Models;

var builder = WebApplication.CreateBuilder(args);

// Read connection string from appsettings.json
var connectionString = builder.Configuration.GetConnectionString("Connection");
Console.WriteLine($"[DB] Connection String: {connectionString}");

builder.Services.AddDbContext<Mission06Context>(options =>
    options.UseSqlite(connectionString));

builder.Services.AddControllersWithViews();
builder.Services.AddAuthorization();

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