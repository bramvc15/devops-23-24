using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using BlazorApp.Data;
using static BlazorApp.Auth.BlitzWareAuth;
using BlazorApp.Auth;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSingleton<BlitzWareAuthService>();
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}


app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

// Resolve the BlitzWareAuthService from the service provider
var blitzWareAuthService = app.Services.GetRequiredService<BlitzWareAuthService>();
// Initialize the BlitzWareAuthService before running the application
blitzWareAuthService.AuthService.Initialize();

app.Run();