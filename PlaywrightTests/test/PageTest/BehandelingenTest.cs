using Microsoft.Playwright.NUnit;
using Microsoft.Playwright;
using NUnit.Framework;

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