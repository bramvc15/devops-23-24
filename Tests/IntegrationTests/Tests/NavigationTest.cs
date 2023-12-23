using Microsoft.Playwright.NUnit;
using Microsoft.Playwright;
using NUnit.Framework;
using System.Text.RegularExpressions;

namespace IntegrationTests;

[Parallelizable(ParallelScope.Self)]
public class NavigationTest : PageTest
{
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

    [Test]
    public async Task Login_RedirectsToAuth0()
    {
        await Page.GotoAsync($"{TestHelper.BaseUrl}login");
        await Expect(Page).ToHaveURLAsync(new Regex(@"https://vision-oogcentrum\.eu\.auth0\.com/.*"));
    }
}