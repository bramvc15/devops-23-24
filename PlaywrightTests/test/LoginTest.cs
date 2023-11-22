using Microsoft.Playwright.NUnit;
using NUnit.Framework;

namespace PlaywrightTests;

[Parallelizable(ParallelScope.Self)]
[TestFixture]
public class LoginTest : PageTest
{

    // string _baseUrl = "http://192.168.0.123:5046";

    // [SetUp]
    // public async Task SetUp()
    // {
    //     await Page.GotoAsync(_baseUrl);
    // }

    // [Test]
    // public async Task LoginWithValidCredentials()
    // {
    //     await Page.GotoAsync($"{_baseUrl}/login");
    //     await Page.GetByPlaceholder("Naam").FillAsync("admin1");
    //     await Page.FillAsync("input[type=\"password\"]", "admin123");
    //     await Page.ClickAsync("button:has-text(\"Login\")");
    //     Assert.AreEqual($"{_baseUrl}/admin", Page.Url);

    //     await Page.ClickAsync("text=Logout");

    //     Assert.AreEqual($"{_baseUrl}/", Page.Url);
    // }
}