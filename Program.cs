using HappyPawsKennel.Data;
using HappyPawsKennel.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.Text.Json;
using HappyPawsKennel.Health;

var builder = WebApplication.CreateBuilder(args);

// Logging
builder.Logging.AddConsole();
builder.Logging.AddDebug();

builder.Services.AddControllersWithViews(); 

// Add services to the container.
builder.Services.AddRazorPages();

// Register DbContext
builder.Services.AddDbContext<HappyPawsContext>(options => 
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))); 

builder.Services.AddScoped<IKennelService, KennelService>();

builder.Services.AddHealthChecks()
    .AddCheck<DbHealthCheck>("database");

var app = builder.Build(); 

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment()) 
{ app.UseExceptionHandler("/Error");
 // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
 app.UseHsts(); } 

app.UseHttpsRedirection(); 

app.UseRouting(); 

app.UseAuthorization(); 

app.MapControllerRoute( name: "default", 
    pattern: "{controller=Home}/{action=Index}/{id?}"); 

app.MapStaticAssets(); 

app.MapRazorPages() 
    .WithStaticAssets();

app.MapHealthChecks("/healthz", new HealthCheckOptions
{
    ResponseWriter = async (context, report) =>
    {
        context.Response.ContentType = "application/json";

        var result = new
        {
            status = report.Status.ToString(),
            totalDuration = report.TotalDuration.TotalMilliseconds + " ms",
            checks = report.Entries.Select(e => new {
                name = e.Key,
                status = e.Value.Status.ToString(),
                description = e.Value.Description,
                duration = e.Value.Duration.TotalMilliseconds + " ms"
            })
        };

        // Serialize with System.Text.Json
        await context.Response.WriteAsync(JsonSerializer.Serialize(result, new JsonSerializerOptions { WriteIndented = true }));
    }
});

app.Run();
