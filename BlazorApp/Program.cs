using BlazorApp.Data;
using Blazorise;
using Blazorise.Bootstrap;
using Blazorise.Icons.FontAwesome;
using Blazorise.RichTextEdit;
using Microsoft.EntityFrameworkCore;
using BlazorApp.Services;

using static BlazorApp.Auth.BlitzWareAuth;
using BlazorApp.Auth;
using Blazored.LocalStorage;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSingleton<BlitzWareAuthService>();
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddControllers();
builder.Services.AddHttpClient();
builder.Services.AddTransient<DoctorService>();
builder.Services.AddTransient<HomeHeaderService>();
builder.Services.AddTransient<BlogService>();
builder.Services.AddTransient<LocationService>();
builder.Services.AddTransient<ContactService>();
builder.Services.AddTransient<TreatmentService>();
builder.Services.AddTransient<ChatbotService>();
builder.Services.AddBlazoredLocalStorage();


builder.Services.AddDbContext<DatabaseContext>( options => 
    {
    options.UseSqlServer(builder.Configuration.GetConnectionString("Connection"));
    }, ServiceLifetime.Transient);


 
builder.Services
    .AddBlazorise( options =>
    {
        options.Immediate = true;
    } )
    .AddBootstrapProviders()
    .AddFontAwesomeIcons();


builder.Services
    .AddBlazoriseRichTextEdit( options => {  } );

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}

app.CreateDbIfNotExists();
app.UseStaticFiles();

app.UseRouting();

//app.UseAuthentication();
//app.UseAuthorization();

app.MapControllers();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();