using Microsoft.EntityFrameworkCore;
using Mission06_Powers.Models;




var builder = WebApplication.CreateBuilder(args);

var dbPath = Path.Combine(builder.Environment.ContentRootPath, "JoelHiltonMovieCollection.sqlite"); // my pathing got all messed up, this was the fix. I renamed my folder and bad news
Console.WriteLine($"[DB] Absolute path: {dbPath}"); // had to change pathing to be the new db

builder.Services.AddDbContext<Mission06Context>(options =>
    options.UseSqlite($"Data Source={dbPath}"));


builder.Services.AddControllersWithViews();     // registers MVC and related services
builder.Services.AddAuthorization();           // explicitly register authorization services

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}") // ? means I may not enter the id....
    .WithStaticAssets();


app.Run();
