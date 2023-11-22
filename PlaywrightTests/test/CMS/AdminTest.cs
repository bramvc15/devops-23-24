using Microsoft.Playwright.NUnit;
using Microsoft.Playwright;
using NUnit.Framework;

namespace PlaywrightTests;

[Parallelizable(ParallelScope.Self)]
[TestFixture]
public class AdminTest : PageTest
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
    public async Task EmployeeManagementTab_ShowsEmployees()
    {
        await Page.ClickAsync("data-test-id=sidebar-employees");
        await Page.WaitForLoadStateAsync(LoadState.NetworkIdle);
        Assert.AreEqual($"{baseUrl}/admin/employees", Page.Url);
        Assert.IsTrue(await Page.IsVisibleAsync("data-test-id=employees-title"));
        Assert.IsTrue(await Page.IsVisibleAsync("data-test-id=employees-card"));
    }

    public async Task LogIn() {
        await Page.GotoAsync($"{baseUrl}/login");
        await Page.FillAsync("data-test-id=login-username", "admin1");
        await Page.FillAsync("data-test-id=login-password", "admin123");
        await Page.ClickAsync("data-test-id=login-button");
        await Page.WaitForLoadStateAsync(LoadState.NetworkIdle);
    }
}