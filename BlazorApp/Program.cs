using BlazorApp.Data;
using Blazorise;
using Blazorise.Bootstrap;
using Blazorise.Icons.FontAwesome;
using Blazorise.RichTextEdit;
using Microsoft.EntityFrameworkCore;
using Syncfusion.Blazor;


using static BlazorApp.Auth.BlitzWareAuth;
using BlazorApp.Auth;
using Blazored.LocalStorage;
using BlazorApp.Services.Core;
using BlazorApp.Services.CMS;
using Microsoft.Extensions.DependencyInjection;

Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Ngo9BigBOggjHTQxAR8/V1NHaF1cWWhIf0x0TXxbf1xzZFRGalhXTnRdUiweQnxTdEZiWH1fcXRRQGJeV0N1WQ==");

var builder = WebApplication.CreateBuilder(args);
builder.WebHost.ConfigureKestrel(options => options.Listen(System.Net.IPAddress.Parse(builder.Configuration.GetConnectionString("HostAdress")), 5046));
// Add services to the container.
builder.Services.AddDbContext<DatabaseContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Connection"));
}, ServiceLifetime.Transient);

builder.Services.AddSingleton<BlitzWareAuthService>();
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddControllers();
builder.Services.AddHttpClient();
builder.Services.AddScoped<DoctorService>();
builder.Services.AddScoped<CMSHomeHeaderService>();
builder.Services.AddScoped<CMSBlogService>();
builder.Services.AddScoped<LocationService>();
builder.Services.AddScoped<CMSContactService>();
builder.Services.AddScoped<TreatmentService>();
builder.Services.AddScoped<CMSChatbotService>();
builder.Services.AddScoped<PatientService>();
builder.Services.AddScoped<ScheduleTimeSlotService>(); 
builder.Services.AddScoped<AppointmentService>();
builder.Services.AddScoped<TimeSlotService>();
builder.Services.AddScoped<ScheduleTimeSlotService>();
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddSyncfusionBlazor();

builder.Services
    .AddBlazorise(options =>
    {
        options.Immediate = true;
    })
    .AddBootstrapProviders()
    .AddFontAwesomeIcons();


builder.Services
    .AddBlazoriseRichTextEdit(options => { });

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