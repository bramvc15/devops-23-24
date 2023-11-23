using Microsoft.Playwright.NUnit;
using Microsoft.Playwright;
using NUnit.Framework;

namespace PlaywrightTests;

[Parallelizable(ParallelScope.Self)]
[TestFixture]
public class CMSTest : PageTest
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
        await Page.GotoAsync($"{baseUrl}/admin");
        
        bool loggedOut = await Page.IsVisibleAsync("data-test-id=login-username");

        if (loggedOut)
        {
            await LogIn();
        }
        
    }

    [Test]
    public async Task CMSHome_ShowsHome() 
    {
        await Page.ClickAsync("data-test-id=sidebar-cms");
        await Page.WaitForLoadStateAsync(LoadState.NetworkIdle);
        await Page.ClickAsync("data-test-id=sidebar-cms-home");
        await Page.WaitForLoadStateAsync(LoadState.NetworkIdle);
        Assert.AreEqual($"{baseUrl}/admin/cms/home", Page.Url);
    }

    [Test]
    public async Task CMSHome_ChangeHeader() 
    {
        await Page.ClickAsync("data-test-id=sidebar-cms");
        await Page.ClickAsync("data-test-id=sidebar-cms-home");
        await Page.WaitForLoadStateAsync(LoadState.NetworkIdle);
        await Page.ClickAsync("data-test-id=edit-header-popup");
        await Page.WaitForLoadStateAsync(LoadState.NetworkIdle);
        await Page.FillAsync("data-test-id=edit-header-title", "Test header");
        // await Page.ClickAsync("data-test-id=edit-header-save");
        // await Page.WaitForLoadStateAsync(LoadState.NetworkIdle);
        // Assert.AreEqual("Test header", await Page.TextContentAsync("data-test-id=edit-header-popup"));
    }

    [Test]
    public async Task CMSLocation_ShowsLocation() {
        await Page.ClickAsync("data-test-id=sidebar-cms");
        await Page.WaitForLoadStateAsync(LoadState.NetworkIdle);
        await Page.ClickAsync("data-test-id=sidebar-cms-location");
        await Page.WaitForLoadStateAsync(LoadState.NetworkIdle);
        Assert.AreEqual($"{baseUrl}/admin/cms/location", Page.Url);
    }

    [Test]
    public async Task CMSLocation_EditLocation()
    {
        await Page.ClickAsync("data-test-id=sidebar-cms");
        await Page.ClickAsync("data-test-id=sidebar-cms-location");
        await Page.WaitForLoadStateAsync(LoadState.NetworkIdle);
        await Page.GetByRole(AriaRole.Button, new() { Name = "Wijzig" }).ClickAsync();
        await Page.WaitForLoadStateAsync(LoadState.NetworkIdle);
        await Page.Locator(".ql-editor").FillAsync("Test location");
        await Page.Locator("[data-test-id=\"edit-location-save\"]").ClickAsync();
        await Page.WaitForLoadStateAsync(LoadState.NetworkIdle);

        await Page.GotoAsync($"{baseUrl}/admin/cms/location");

        await Expect(Page.GetByText("Test location")).ToBeVisibleAsync();
    }

    public async Task LogIn() {
        await Page.GotoAsync($"{baseUrl}/login");
        await Page.FillAsync("data-test-id=login-username", "admin1");
        await Page.FillAsync("data-test-id=login-password", "admin123");
        await Page.ClickAsync("data-test-id=login-button");
        await Page.WaitForLoadStateAsync(LoadState.NetworkIdle);
    }

}