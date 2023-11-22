using Microsoft.Playwright.NUnit;
using NUnit.Framework;

namespace PlaywrightTests;

[Parallelizable(ParallelScope.Self)]
[TestFixture]
public class NavigationTest : PageTest
{

    string _baseUrl = "http://192.168.0.123:5046";

    [SetUp]
    public async Task SetUp()
    {
        await Page.GotoAsync(_baseUrl);
    }

    [Test]
    public async Task NavbarRedirectsToOnsTeamPage()
    {
        await Page.ClickAsync("text=Ons team");
        Assert.AreEqual($"{_baseUrl}/onsTeam", Page.Url);
    }

    [Test]
    public async Task NavbarRedirectsToBehandelingenPage()
    {
        await Page.ClickAsync("text=Behandelingen");
        Assert.AreEqual($"{_baseUrl}/behandelingen", Page.Url);
    }

    [Test]
    public async Task NavbarRedirectsToContactPage()
    {
        await Page.ClickAsync("text=Contact");
        Assert.AreEqual($"{_baseUrl}/Contact", Page.Url);
    }

    [Test]
    public async Task NotLoggedIn_AdminRedirectsToLoginPage()
    {
        await Page.GotoAsync($"{_baseUrl}/admin");
        Assert.AreEqual($"{_baseUrl}/login", Page.Url);
    }

    [Test]
    public async Task LoggedIn_AdminRedirectsToAdminPage()
    {
        await Page.GotoAsync($"{_baseUrl}/login");
        await Page.GetByPlaceholder("Naam").FillAsync("admin1");
        await Page.GetByPlaceholder("Wachtwoord").FillAsync("admin1");
        await Page.ClickAsync("button:has-text(\"Login\")");
        await Page.GotoAsync($"{_baseUrl}/admin");
        Assert.AreEqual($"{_baseUrl}/admin", Page.Url);
    }
}