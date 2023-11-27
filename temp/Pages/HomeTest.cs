using Microsoft.Playwright.NUnit;
using NUnit.Framework;
using Shouldly;

namespace IntegrationTests;

[Parallelizable(ParallelScope.Self)]
[TestFixture]
public class HomeTest : PageTest
{


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
    public async Task Home_Show_BlogPosts_OnLoad() {
        Assert.IsTrue(await Page.IsVisibleAsync("data-test-id=actuafield-blogpost-title"));
        var blogpostTitle = await Page.TextContentAsync("data-test-id=actuafield-blogpost-title");
        blogpostTitle.ShouldNotBeEmpty();
    }

    [Test]
    public async Task Home_MaakAfspraakButtonRedirectsToMaakAfspraakPage()
    {
        await Page.ClickAsync("data-test-id=home-maakafspraak-button");
        Assert.AreEqual($"{TestHelper.BaseUrl}/Afspraak", Page.Url);
    }

    // [Test]
    // public async Task Home_ContacteerOnsButtonRedirectsToContactPage()
    // {
    //     await Page.ClickAsync("data-test-id=home-contacteerons-button");
    //     Assert.AreEqual($"{TestHelper.BaseUrl}/Contact", Page.Url);
    // }

    [Test]
    public async Task Home_BlogPostLeesVerderRedirectsToActuaDetailPage()
    {
        await Page.ClickAsync("data-test-id=actuafield-leesverder-button");
        Assert.IsTrue(Page.Url.Contains($"{TestHelper.BaseUrl}/ActuaDetail/"));
    }
}