namespace IntegrationTests
{
    public class TestHelper
    {

        // Debug mode:
        // $env:PWDEBUG=1

        // Run tests:
        // dotnet test

        // Codegen:
        // bin/Debug/net6.0/playwright.ps1 codegen {IP HERE}

        // BaseUrl inclusief / op het einde
        public static string BaseUrl = "https://localhost:5001/";
    }
}