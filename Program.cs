using HappyPawsKennel.Data;
using HappyPawsKennel.Services;
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews(); 

// Add services to the container.
builder.Services.AddRazorPages();

// Register DbContext
builder.Services.AddDbContext<HappyPawsContext>(options => 
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))); 

builder.Services.AddScoped<IKennelService, KennelService>(); 

var app = builder.Build(); 

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment()) 
{ app.UseExceptionHandler("/Error");
 // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
 app.UseHsts(); } 

app.UseHttpsRedirection(); 

app.UseRouting(); 

app.UseAuthorization(); 

app.MapControllerRoute( name: "default", pattern: "{controller=Home}/{action=Index}/{id?}"); 

app.MapStaticAssets(); 

app.MapRazorPages() 
    .WithStaticAssets(); 
app.Run();
