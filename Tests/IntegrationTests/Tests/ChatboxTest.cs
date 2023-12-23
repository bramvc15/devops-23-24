// using Microsoft.Playwright.NUnit;
// using Microsoft.Playwright;
// using NUnit.Framework;
// using Shouldly;

// namespace IntegrationTests;

// [Parallelizable(ParallelScope.Self)]
// public class ChatboxTest : PageTest
// { 
//     [SetUp]
//     public async Task SetUp()
//     {
//         await Page.GotoAsync($"{TestHelper.BaseUrl}");
//     }

//     [Test]
//     public async Task OnLoad_ChatboxNotVisible()
//     {
//         Assert.IsFalse(await Page.IsVisibleAsync("data-test-id=chatbox-content"));
//     }

//     [Test]
//     public async Task OnClick_ChatboxVisible()
//     {
//         await Page.ClickAsync("data-test-id=chatbox-header");
//         Assert.IsTrue(await Page.IsVisibleAsync("data-test-id=chatbox-content"));
//     }

//     [Test]
//     public async Task OnClick_ShowQuestions()
//     {
//         await OpenChatbox();
//         await Page.WaitForTimeoutAsync(300);
//         Assert.IsTrue(await Page.IsVisibleAsync("data-test-id=chatbox-question"));
//     }

//     [Test]
//     public async Task SelectQuestion_ShowsQuestion() {
//         await ClickQuestion();
//         Assert.IsFalse(await Page.IsVisibleAsync("data-test-id=chatbox-question"));
//     }

//     [Test]
//     public async Task SelectQuestion_ShowsAnswer() {
//         await ClickQuestion();
//         await Page.WaitForTimeoutAsync(300);
//         var amountOfMessages = await Page.Locator("data-test-id=chatbox-message").CountAsync();
//         amountOfMessages.ShouldBe(3);
//     }

//     public async Task OpenChatbox() {
//         await Page.ClickAsync("data-test-id=chatbox-header");
//     }

//     public async Task ClickQuestion() {
//         OpenChatbox();
//         await Page.ClickAsync("data-test-id=chatbox-question");
//     }
// }