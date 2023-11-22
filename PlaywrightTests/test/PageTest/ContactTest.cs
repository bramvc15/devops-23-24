using Microsoft.Playwright.NUnit;
using Microsoft.Playwright;
using NUnit.Framework;

namespace PlaywrightTests;

[Parallelizable(ParallelScope.Self)]
[TestFixture]
public class ContactTest : PageTest
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
        await Page.GotoAsync($"{baseUrl}/Contact");
    }

    [Test]
    public async Task ContactForm_SendsEmail() {
        await Page.FillAsync("data-test-id=contact-name", "TestNaam");
        await Page.FillAsync("data-test-id=contact-firstname", "TestFirstName");
        await Page.FillAsync("data-test-id=contact-email", "test@email.com");
        await Page.FillAsync("data-test-id=contact-date", "22/11/2023");
        await Page.FillAsync("data-test-id=contact-phone", "0414251470");
        await Page.FillAsync("data-test-id=contact-message", "TestMessage");
        await Page.ClickAsync("data-test-id=contact-submit-button");
        Assert.AreEqual($"{baseUrl}/submit_form.php", Page.Url);
    }
}