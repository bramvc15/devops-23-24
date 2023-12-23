using Microsoft.Playwright.NUnit;
using Microsoft.Playwright;
using NUnit.Framework;
using Shouldly;

using System.Text.RegularExpressions;

namespace IntegrationTests;

[Parallelizable(ParallelScope.Self)]
public class TreatmentTests : PageTest
{
    [SetUp]
    public async Task SetUp()
    {
        await Page.GotoAsync($"{TestHelper.BaseUrl}/behandelingen");
    }

    [Test]
    public async Task Show_Treatments_OnLoad() {
        Assert.IsTrue(await Page.IsVisibleAsync("data-test-id=treatmentcard-treatment-title"));
        var treatmentName = await Page.TextContentAsync("data-test-id=treatmentcard-treatment-title");
        treatmentName.ShouldNotBeEmpty();
    }

    [Test]
    public async Task TreatmentCard_RedirectsToTreatmentDetailPage()
    {
        await Page.ClickAsync("data-test-id=treatmentcard-button");
        await Expect(Page).ToHaveURLAsync(new Regex(".*/behandelingen/\\w+"));
    }

    [Test]
    public async Task NoFAQItemSelected_FAQAnswerNotVisible()
    {
        await Page.ClickAsync("data-test-id=treatmentcard-button");
        Assert.IsFalse(await Page.IsVisibleAsync("data-test-id=faq-content"));
    }

    [Test]
    public async Task FaqItemSelected_FAQAnswerVisible()
    {
        await Page.ClickAsync("data-test-id=treatmentcard-button");
        await Page.ClickAsync("data-test-id=faq-item");
        Assert.IsTrue(await Page.IsVisibleAsync("data-test-id=faq-content"));
    }

    [Test]
    public async Task FaqItemDeselected_FAQAnswerNotVisible()
    {
        await Page.ClickAsync("data-test-id=treatmentcard-button");
        await Page.ClickAsync("data-test-id=faq-item");
        await Page.ClickAsync("data-test-id=faq-item");
        Assert.IsFalse(await Page.IsVisibleAsync("data-test-id=faq-content"));
    }

    [Test]
    public async Task SearchTreatment_TreatmentFound()
    {
        await Page.GetByPlaceholder("Zoek behandelingen").FillAsync("straal");
        await Page.GetByPlaceholder("Zoek behandelingen").PressAsync("Enter");
        Assert.AreEqual(1, await Page.Locator("[data-test-id=\"treatmentcard-button\"]").CountAsync());
        Expect(Page.GetByRole(AriaRole.Heading, new() { Name = "Straaloperatie" })).ToBeVisibleAsync();
    }
}