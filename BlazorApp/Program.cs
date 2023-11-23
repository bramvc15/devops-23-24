using BlazorApp.Data;
using Blazorise;
using Blazorise.Bootstrap;
using Blazorise.Icons.FontAwesome;
using Blazorise.RichTextEdit;
using Microsoft.EntityFrameworkCore;
using BlazorApp.Services;
using Syncfusion.Blazor;


using static BlazorApp.Auth.BlitzWareAuth;
using BlazorApp.Auth;
using Blazored.LocalStorage;

Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Ngo9BigBOggjHTQxAR8/V1NHaF1cWWhIf0x0TXxbf1xzZFRGalhXTnRdUiweQnxTdEZiWH1fcXRRQGJeV0N1WQ==");

var builder = WebApplication.CreateBuilder(args);
builder.WebHost.ConfigureKestrel(options => options.Listen(System.Net.IPAddress.Parse(builder.Configuration.GetConnectionString("HostAdress")), 5046));
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
builder.Services.AddTransient<PatientService>();
builder.Services.AddTransient<ScheduleTimeSlotService>(); 
builder.Services.AddTransient<AppointmentService>();
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddSyncfusionBlazor();
builder.Services.AddTransient<TimeSlotService>();
builder.Services.AddTransient<ScheduleTimeSlotService>();

builder.Services.AddDbContext<DatabaseContext>(options =>
    {
        options.UseSqlServer(builder.Configuration.GetConnectionString("Connection"));
    }, ServiceLifetime.Transient);



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