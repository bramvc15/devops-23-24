using Microsoft.Playwright.NUnit;
using NUnit.Framework;

namespace IntegrationTests;

[Parallelizable(ParallelScope.Self)]
[TestFixture]
public class NavigationTest : PageTest
{
    // debug: $env:PWDEBUG=0
    // run tests command: dotnet test --settings .runsettings
    // bin/Debug/net6.0/playwright.ps1 codegen 192.168.0.123:5046  

    [OneTimeSetUp]
    public void Init()
    {

    }

    [SetUp]
    public async Task SetUp()
    {
        await Page.GotoAsync(TestHelper.BaseUrl);
    }

    [Test]
    public async Task NavbarRedirectsToOnsTeamPage()
    {
        await Page.ClickAsync("text=Ons team");
        Assert.AreEqual($"{TestHelper.BaseUrl}/onsTeam", Page.Url);
    }

    [Test]
    public async Task NavbarRedirectsToBehandelingenPage()
    {
        await Page.ClickAsync("text=Behandelingen");
        Assert.AreEqual($"{TestHelper.BaseUrl}/behandelingen", Page.Url);
    }

    [Test]
    public async Task NavbarRedirectsToContactPage()
    {
        await Page.ClickAsync("text=Contact");
        Assert.AreEqual($"{TestHelper.BaseUrl}/Contact", Page.Url);
    }

    // [Test]
    // public async Task NotLoggedIn_AdminRedirectsToLoginPage()
    // {
    //     await Page.GotoAsync($"{baseUrl}/admin");
    //     Assert.AreEqual($"{baseUrl}/login", Page.Url);
    // }

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