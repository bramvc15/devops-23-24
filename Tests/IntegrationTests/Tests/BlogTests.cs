using Microsoft.Playwright.NUnit;
using NUnit.Framework;
using Shouldly;
using System.Text.RegularExpressions;

namespace IntegrationTests;

[Parallelizable(ParallelScope.Self)]
[TestFixture]
public class ActuaDetailTests : PageTest
{
    [OneTimeSetUp]
    public void Init()
    {

    }

    [Test]
    public async Task Home_BlogPostLeesVerderRedirectsToActuaDetailPage()
    {
        await Page.GotoAsync($"{TestHelper.BaseUrl}/");
        await Page.ClickAsync("data-test-id=actua-detail-button");
        Assert.IsTrue(Page.Url.Contains($"{TestHelper.BaseUrl}/actua-detail/"));
    }

    [Test]
    public async Task Show_Blogpost_OnLoad()
    {
        await Page.GotoAsync($"{TestHelper.BaseUrl}/actua-detail/1");
        var description = await Page.QuerySelectorAsync("data-test-id=actua-detail-description");
        Assert.IsTrue(description != null);
    }

    [Test]
    public async Task ActuaDetail_BackButtonRedirectsToHome()
    {
        await Page.GotoAsync($"{TestHelper.BaseUrl}/actua-detail/1");
        await Page.ClickAsync("data-test-id=actua-detail-back");
        Expect(Page).ToHaveURLAsync(new Regex($@"^{Regex.Escape(TestHelper.BaseUrl)}/?$"));
    }
}