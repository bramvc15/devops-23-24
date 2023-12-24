using Microsoft.Playwright.NUnit;
using Microsoft.Playwright;
using NUnit.Framework;
using Shouldly;
using System.Text.RegularExpressions;

namespace IntegrationTests;

[Parallelizable(ParallelScope.Self)]
public class FaqTests : PageTest
{
    [SetUp]
    public async Task SetUp()
    {
        await Page.GotoAsync($"{TestHelper.BaseUrl}faq");
    }

    [Test]
    public async Task Team_Show_Questions_OnLoad() {
        Assert.IsTrue(await Page.IsVisibleAsync("data-test-id=faq-question"));
    }

    [Test]
    public async Task QuestionClicked_ShowsAnswer()
    {
        await Page.ClickAsync("data-test-id=faq-question");
        Assert.IsTrue(await Page.IsVisibleAsync("data-test-id=faq-answer"));
    }

    [Test]
    public async Task QuestionClickedTwice_HidesAnswer()
    {
        await Page.ClickAsync("data-test-id=faq-question");
        await Page.ClickAsync("data-test-id=faq-question");
        Assert.IsFalse(await Page.IsVisibleAsync("data-test-id=faq-answer"));
    }

    [Test]
    public async Task SearchQuestion_QuestionFound()
    {
        await Page.GetByPlaceholder("Zoek FAQ").FillAsync("Wat zijn de symptomen van droge ogen?");
        await Page.GetByPlaceholder("Zoek FAQ").PressAsync("Enter");
        Assert.AreEqual(1, await Page.Locator("[data-test-id=\"faq-question\"]").CountAsync());
        Expect(Page.Locator("div").Filter(new() { HasText = "> Wat zijn de symptomen van droge ogen?Brandend gevoel, jeuk, roodheid, wazig zi" })).ToBeVisibleAsync();
    }


}