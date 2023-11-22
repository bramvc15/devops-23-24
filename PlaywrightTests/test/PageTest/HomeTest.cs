using Microsoft.Playwright.NUnit;
using NUnit.Framework;

namespace PlaywrightTests;

[Parallelizable(ParallelScope.Self)]
[TestFixture]
public class HomeTest : PageTest
{

    string _baseUrl = "http://192.168.0.123:5046";

    [SetUp]
    public async Task SetUp()
    {
        await Page.GotoAsync(_baseUrl);
    }

    [Test]
    public async Task Home_MaakAfspraakButtonRedirectsToMaakAfspraakPage()
    {
        await Page.ClickAsync("data-test-id=home-maakafspraak-button");
        Assert.AreEqual($"{_baseUrl}/Afspraak", Page.Url);
    }

    [Test]
    public async Task Home_ContacteerOnsButtonRedirectsToContactPage()
    {
        await Page.ClickAsync("data-test-id=home-contacteerons-button");
        Assert.AreEqual($"{_baseUrl}/Contact", Page.Url);
    }

    [Test]
    public async Task Home_BlogPostLeesVerderRedirectsToActuaDetailPage()
    {
        await Page.ClickAsync("data-test-id=actuafield-leesverder-button");
        Assert.IsTrue(Page.Url.Contains($"{_baseUrl}/ActuaDetail/"));
    }
}