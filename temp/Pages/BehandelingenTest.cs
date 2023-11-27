using Microsoft.Playwright.NUnit;
using Microsoft.Playwright;
using NUnit.Framework;
using Shouldly;

namespace IntegrationTests;

[Parallelizable(ParallelScope.Self)]
[TestFixture]
public class BehandelingenTest : PageTest
{


    [OneTimeSetUp]
    public void Init()
    {

    }

    [SetUp]
    public async Task SetUp()
    {
        await Page.GotoAsync($"{TestHelper.BaseUrl}/behandelingen");
        await Page.WaitForLoadStateAsync(LoadState.NetworkIdle);
    }

    [Test]
    public async Task Behandelingen_Show_Behandelingen_OnLoad() {
        Assert.IsTrue(await Page.IsVisibleAsync("data-test-id=treatmentcard-treatment-title"));
        var blogpostTitle = await Page.TextContentAsync("data-test-id=treatmentcard-treatment-title");
        blogpostTitle.ShouldNotBeEmpty();
    }

    // [Test]
    // public async Task Behandelingen_OoglidCorrectieRedirectsToTreatmentDetailPage()
    // {
    //     await Page.ClickAsync("data-test-id=treatmentcard-behandeling-button");
    //     await Page.WaitForLoadStateAsync(LoadState.NetworkIdle);
    //     Assert.AreEqual($"{TestHelper.BaseUrl}/behandelingen/ooglidcorrectie", Page.Url);
    // }

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