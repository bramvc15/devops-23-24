using Blazorise;
using Blazorise.Bootstrap;
using Blazorise.Icons.FontAwesome;
using Blazorise.RichTextEdit;
using Microsoft.EntityFrameworkCore;
using Syncfusion.Blazor;
using Services.CMS;
using Services.Core;
using Persistence.Data;
using Auth0.AspNetCore.Authentication;

Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Ngo9BigBOggjHTQxAR8/V1NHaF1cWWhIf0x0TXxbf1xzZFRGalhXTnRdUiweQnxTdEZiWH1fcXRRQGJeV0N1WQ==");

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuth0WebAppAuthentication(options => 
{
    options.Domain = builder.Configuration["Auth0:Domain"];
    options.ClientId = builder.Configuration["Auth0:ClientId"];
    options.ClientSecret = builder.Configuration["Auth0:ClientSecret"];
});

builder.Services.AddAuth0AuthenticationClient(config =>
{
    config.Domain = builder.Configuration["Auth0MTM:Domain"];
    config.ClientId = builder.Configuration["Auth0MTM:ClientId"];
    config.ClientSecret = builder.Configuration["Auth0MTM:ClientSecret"];
});

builder.Services.AddAuth0ManagementClient().AddManagementAccessToken();

//builder.WebHost.ConfigureKestrel(options => options.Listen(System.Net.IPAddress.Parse(builder.Configuration.GetConnectionString("HostAdress")), 5046));

builder.Services.AddDbContext<DatabaseContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Connection"));
}, ServiceLifetime.Transient);

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddControllers();
builder.Services.AddScoped<HomeHeaderService>();
builder.Services.AddScoped<BlogService>();
builder.Services.AddScoped<LocationService>();
builder.Services.AddScoped<ChatbotService>();
builder.Services.AddScoped<TreatmentService>();
builder.Services.AddScoped<DoctorService>();
builder.Services.AddScoped<ScheduleTimeSlotService>();
builder.Services.AddScoped<TimeSlotService>();
builder.Services.AddScoped<AppointmentService>();
builder.Services.AddScoped<PatientService>();
builder.Services.AddScoped<FaqService>();
builder.Services.AddScoped<TimeSlotService>();
builder.Services.AddScoped<ScheduleTimeSlotService>();
builder.Services.AddScoped<NoteService>();
builder.Services.AddScoped<MessageService>();

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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();