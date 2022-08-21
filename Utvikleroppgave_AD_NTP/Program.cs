using Microsoft.EntityFrameworkCore;
using Utvikleroppgave_AD_NTP.DAL;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ProductContext>(options => options.UseSqlite("Data Source=Products.db"));
builder.Services.AddScoped<IProductRepository, ProductRepository>();

var app = builder.Build();
InitDB.Initialize(app);  // This can be commented out after first start of the game
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

app.MapFallbackToFile("index.html"); ;

app.Run();
