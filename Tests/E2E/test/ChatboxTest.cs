using Microsoft.Playwright.NUnit;
using Microsoft.Playwright;
using NUnit.Framework;
using Shouldly;

namespace PlaywrightTests;

[Parallelizable(ParallelScope.Self)]
[TestFixture]
public class ChatboxTest : PageTest
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
        await Page.GotoAsync($"{baseUrl}");
    }

    [Test]
    public async Task OnLoad_ChatboxNotVisible()
    {
        Assert.IsFalse(await Page.IsVisibleAsync("data-test-id=chatbox-content"));
    }

    [Test]
    public async Task OnClick_ChatboxVisible()
    {
        await Page.ClickAsync("data-test-id=chatbox-header");
        Assert.IsTrue(await Page.IsVisibleAsync("data-test-id=chatbox-content"));
    }

    [Test]
    public async Task OnClick_ShowQuestions()
    {
        await OpenChatbox();
        Assert.IsTrue(await Page.IsVisibleAsync("data-test-id=chatbox-question"));
    }

    [Test]
    public async Task SelectQuestion_ShowsQuestion() {
        await ClickQuestion();
        Assert.IsFalse(await Page.IsVisibleAsync("data-test-id=chatbox-question"));
    }

    [Test]
    public async Task SelectQuestion_ShowsAnswer() {
        await ClickQuestion();
        await Page.WaitForTimeoutAsync(300);
        var amountOfMessages = await Page.Locator("data-test-id=chatbox-message").CountAsync();
        amountOfMessages.ShouldBe(3);
    }

    public async Task OpenChatbox() {
        await Page.ClickAsync("data-test-id=chatbox-header");
        await Page.WaitForLoadStateAsync(LoadState.NetworkIdle);
    }

    public async Task ClickQuestion() {
        OpenChatbox();
        await Page.ClickAsync("data-test-id=chatbox-question");
    }
}