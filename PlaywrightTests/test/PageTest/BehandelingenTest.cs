using Microsoft.Playwright.NUnit;
using Microsoft.Playwright;
using NUnit.Framework;

namespace PlaywrightTests;

[Parallelizable(ParallelScope.Self)]
[TestFixture]
public class BehandelingenTest : PageTest
{

    string _baseUrl = "http://192.168.0.123:5046";

    [SetUp]
    public async Task SetUp()
    {
        await Page.GotoAsync($"{_baseUrl}/behandelingen");
    }

    [Test]
    public async Task Behandelingen_OoglidCorrectieRedirectsToTreatmentDetailPage()
    {
        await Page.ClickAsync("data-test-id=treatmentcard-behandeling-button");
        await Page.WaitForLoadStateAsync(LoadState.NetworkIdle);
        Assert.AreEqual($"{_baseUrl}/behandelingen/ooglidcorrectie", Page.Url);
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