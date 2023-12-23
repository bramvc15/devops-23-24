namespace IntegrationTests
{
    public class TestHelper
    {

        // Debug mode:
        // $env:PWDEBUG=1

        // Run tests:
        // dotnet test

        // Codegen:
        // bin/Debug/net6.0/playwright.ps1 codegen 192.168.0.123:5046  

        // BaseUrl inclusief / op het einde
        public static string BaseUrl = "http://192.168.0.123:5002/";
    }
}