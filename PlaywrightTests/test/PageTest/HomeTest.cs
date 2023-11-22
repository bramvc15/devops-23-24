using Microsoft.Playwright.NUnit;
using NUnit.Framework;

namespace PlaywrightTests;

[Parallelizable(ParallelScope.Self)]
[TestFixture]
public class HomeTest : PageTest
{

    public static string baseUrl;

    [OneTimeSetUp]
    public void Init()
    {
        baseUrl = TestContext.Parameters["WebAppUrl"] ?? throw new Exception("WebAppUrl is not configured as a parameter.");
    }
    [SetUp]
    public async Task SetUp()
    {
        await Page.GotoAsync(baseUrl);
    }

    [Test]
    public async Task Home_MaakAfspraakButtonRedirectsToMaakAfspraakPage()
    {
        await Page.ClickAsync("data-test-id=home-maakafspraak-button");
        Assert.AreEqual($"{baseUrl}/Afspraak", Page.Url);
    }

    [Test]
    public async Task Home_ContacteerOnsButtonRedirectsToContactPage()
    {
        await Page.ClickAsync("data-test-id=home-contacteerons-button");
        Assert.AreEqual($"{baseUrl}/Contact", Page.Url);
    }

    [Test]
    public async Task Home_BlogPostLeesVerderRedirectsToActuaDetailPage()
    {
        await Page.ClickAsync("data-test-id=actuafield-leesverder-button");
        Assert.IsTrue(Page.Url.Contains($"{baseUrl}/ActuaDetail/"));
    }
}