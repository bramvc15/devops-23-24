using Microsoft.Playwright.NUnit;
using Microsoft.Playwright;
using NUnit.Framework;

namespace IntegrationTests;

[Parallelizable(ParallelScope.Self)]
[TestFixture]
public class AdminTest : PageTest
{

    [OneTimeSetUp]
    public void Init()
    {
       
    }
    
    [SetUp]
    public async Task SetUp()
    {
        await Page.GotoAsync($"{TestHelper.BaseUrl}/admin");
        
        bool loggedOut = await Page.IsVisibleAsync("data-test-id=login-username");

        if (loggedOut)
        {
            await LogIn();
        }
        
    }

    // [Test]
    // public async Task EmployeeManagementTab_ShowsEmployees()
    // {
    //     await Page.ClickAsync("data-test-id=sidebar-employees");
    //     await Page.WaitForLoadStateAsync(LoadState.NetworkIdle);
    //     Assert.AreEqual($"{TestHelper.TestHelper.BaseUrl}/admin/employees", Page.Url);
    //     Assert.IsTrue(await Page.IsVisibleAsync("data-test-id=employees-title"));
    //     Assert.IsTrue(await Page.IsVisibleAsync("data-test-id=employees-card"));
    // }

    public async Task LogIn() {
        await Page.GotoAsync($"{TestHelper.BaseUrl}/login");
        await Page.FillAsync("data-test-id=login-username", "admin1");
        await Page.FillAsync("data-test-id=login-password", "admin123");
        await Page.ClickAsync("data-test-id=login-button");
        await Page.WaitForLoadStateAsync(LoadState.NetworkIdle);
    }
}