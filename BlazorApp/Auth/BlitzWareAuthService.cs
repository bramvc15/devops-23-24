using static BlazorApp.Auth.BlitzWareAuth;
using Microsoft.Extensions.Configuration;

namespace BlazorApp.Auth
{
    public class BlitzWareAuthService
    {
        public API AuthService { get; set; }
        private static readonly IConfiguration config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .AddEnvironmentVariables()
            .AddUserSecrets<BlitzWareAuthService>()
            .Build();

        public BlitzWareAuthService()
        {
            AuthService = new API(
                apiUrl: config.GetValue<string>("blitzware:ApiBaseUrl")!,
                appName: config.GetValue<string>("blitzware:AppName")!,
                appSecret: config.GetValue<string>("blitzware:AppSecret")!,
                appVersion: config.GetValue<string>("blitzware:AppVersion")!
            );
        }
    }
}
