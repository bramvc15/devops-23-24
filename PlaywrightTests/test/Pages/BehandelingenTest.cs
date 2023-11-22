using Microsoft.Playwright.NUnit;
using Microsoft.Playwright;
using NUnit.Framework;
using Shouldly;

namespace PlaywrightTests;

[Parallelizable(ParallelScope.Self)]
[TestFixture]
public class BehandelingenTest : PageTest
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
        await Page.GotoAsync($"{baseUrl}/behandelingen");
        await Page.WaitForLoadStateAsync(LoadState.NetworkIdle);
    }

    [Test]
    public async Task Behandelingen_Show_Behandelingen_OnLoad() {
        Assert.IsTrue(await Page.IsVisibleAsync("data-test-id=treatmentcard-treatment-title"));
        var blogpostTitle = await Page.TextContentAsync("data-test-id=treatmentcard-treatment-title");
        blogpostTitle.ShouldNotBeEmpty();
    }

    [Test]
    public async Task Behandelingen_OoglidCorrectieRedirectsToTreatmentDetailPage()
    {
        await Page.ClickAsync("data-test-id=treatmentcard-behandeling-button");
        await Page.WaitForLoadStateAsync(LoadState.NetworkIdle);
        Assert.AreEqual($"{baseUrl}/behandelingen/ooglidcorrectie", Page.Url);
    }

    [Test]
    public async Task Behandelingen_NoFAQItemSelectedNoFAQAnswerVisible()
    {
        await Page.ClickAsync("data-test-id=treatmentcard-behandeling-button");
        await Page.WaitForLoadStateAsync(LoadState.NetworkIdle);
        Assert.IsFalse(await Page.IsVisibleAsync("data-test-id=faq-content"));
    }

    [Test]
    public async Task Behandelingen_ClickFAQQuestionFAQAnswerVisible()
    {
        await Page.ClickAsync("data-test-id=treatmentcard-behandeling-button");
        await Page.WaitForLoadStateAsync(LoadState.NetworkIdle);
        await Page.ClickAsync("data-test-id=faq-item");
        Assert.IsTrue(await Page.IsVisibleAsync("data-test-id=faq-content"));
    }
}