using Microsoft.Playwright.NUnit;
using Microsoft.Playwright;
using NUnit.Framework;

namespace IntegrationTests;

[Parallelizable(ParallelScope.Self)]
public class NavigationTest : PageTest
{
    // debug: $env:PWDEBUG=0
    // run tests command: dotnet test
    // bin/Debug/net6.0/playwright.ps1 codegen 192.168.0.123:5046  

    [SetUp]
    public async Task SetUp()
    {
        await Page.GotoAsync(TestHelper.BaseUrl);
    }

    private async Task OpenMobileMenu()
    {
        if(await Page.Locator(".toggler").IsVisibleAsync())
            await Page.Locator(".toggler").ClickAsync();
    }

    [Test]
    public async Task NavbarRedirectsToOnsTeamPage()
    {
        OpenMobileMenu();
        await Page.GetByRole(AriaRole.Link, new() { Name = "Ons Team" }).ClickAsync();
        Assert.AreEqual($"{TestHelper.BaseUrl}ons-team", Page.Url);
    }

    [Test]
    public async Task NavbarRedirectsToBehandelingenPage()
    {
        OpenMobileMenu();
        await Page.GetByRole(AriaRole.Link, new() { Name = "Behandelingen" }).ClickAsync();
        Assert.AreEqual($"{TestHelper.BaseUrl}behandelingen", Page.Url);
    }

    [Test]
    public async Task NavbarRedirectsToContactPage()
    {
        OpenMobileMenu();
        await Page.GetByRole(AriaRole.Link, new() { Name = "Contact" }).ClickAsync();
        Assert.AreEqual($"{TestHelper.BaseUrl}contact", Page.Url);
    }

    [Test]
    public async Task NotLoggedIn_AdminShowsLoginButton()
    {
        await Page.GotoAsync($"{TestHelper.BaseUrl}admin");
        Assert.IsTrue(await Page.GetByRole(AriaRole.Link, new() { Name = "Log in" }).IsVisibleAsync());
    }

    // [Test]
    // public async Task LoggedIn_AdminRedirectsToAdminPage()
    // {
    //     await Page.GotoAsync($"{baseUrl}/login");
    //     await Page.GetByPlaceholder("Naam").FillAsync("admin1");
    //     await Page.GetByPlaceholder("Wachtwoord").FillAsync("admin1");
    //     await Page.ClickAsync("button:has-text(\"Login\")");
    //     await Page.GotoAsync($"{baseUrl}/admin");
    //     Assert.AreEqual($"{baseUrl}/admin", Page.Url);
    // }
}