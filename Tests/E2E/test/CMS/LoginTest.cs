using Microsoft.Playwright.NUnit;
using Microsoft.Playwright;
using NUnit.Framework;

namespace PlaywrightTests;

[Parallelizable(ParallelScope.Self)]
[TestFixture]
public class LoginTest : PageTest
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

    // [Test]
    // public async Task LoginWithInvalidCredentials_ShowsMessage()
    // {
    //     await Page.GotoAsync($"{baseUrl}/login");
    //     await Page.FillAsync("data-test-id=login-username", "testnaam");
    //     await Page.FillAsync("data-test-id=login-password", "admin123");
    //     await Page.ClickAsync("data-test-id=login-button");
    //     await Page.WaitForLoadStateAsync(LoadState.NetworkIdle);
    //     var loginMessage = await Page.TextContentAsync("data-test-id=login-message");
    //     Assert.IsTrue(loginMessage.Contains("The given username does not exist!"));
    // }

    // [Test]
    // public async Task LoginNoUsername_ShowsMessage() {
    //     await Page.GotoAsync($"{baseUrl}/login");
    //     await Page.FillAsync("data-test-id=login-password", "admin123");
    //     await Page.ClickAsync("data-test-id=login-button");
    //     await Page.WaitForLoadStateAsync(LoadState.NetworkIdle);
    //     var loginMessage = Page.GetByText("Username is required.");
    //     Assert.IsTrue(loginMessage != null);
    // }

    // [Test]
    // public async Task LoginNoPassword_ShowsMessage() {
    //     await Page.GotoAsync($"{baseUrl}/login");
    //     await Page.FillAsync("data-test-id=login-username", "admin1");
    //     await Page.ClickAsync("data-test-id=login-button");
    //     await Page.WaitForLoadStateAsync(LoadState.NetworkIdle);
    //     var loginMessage = Page.GetByText("Password is required.");
    //     Assert.IsTrue(loginMessage != null);
    // }

    // [Test]
    // public async Task LoginPasswordTooShort_ShowsMessage() {
    //     await Page.GotoAsync($"{baseUrl}/login");
    //     await Page.FillAsync("data-test-id=login-username", "admin1");
    //     await Page.FillAsync("data-test-id=login-password", "admin");
    //     await Page.ClickAsync("data-test-id=login-button");
    //     await Page.WaitForLoadStateAsync(LoadState.NetworkIdle);
    //     var loginMessage = Page.GetByText("Password must be at least 6 characters long.");
    //     Assert.IsTrue(loginMessage != null);
    // }
    
    // [Test]
    // public async Task LoginValidCredentials_RedirectsToAdminPage() {
    //     await Page.GotoAsync($"{baseUrl}/login");
    //     await Page.FillAsync("data-test-id=login-username", "admin1");
    //     await Page.FillAsync("data-test-id=login-password", "admin123");
    //     await Page.ClickAsync("data-test-id=login-button");
    //     await Page.WaitForLoadStateAsync(LoadState.NetworkIdle);
    //     Assert.AreEqual($"{baseUrl}/admin", Page.Url);
    // }
}