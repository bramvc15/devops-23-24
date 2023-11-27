using Microsoft.Playwright.NUnit;
using Microsoft.Playwright;
using NUnit.Framework;

namespace IntegrationTests;

[Parallelizable(ParallelScope.Self)]
[TestFixture]
public class ContactTest : PageTest
{

    [OneTimeSetUp]
    public void Init()
    {
        
    }
    
    [SetUp]
    public async Task SetUp()
    {
        await Page.GotoAsync($"{TestHelper.BaseUrl}/contact");
    }

    [Test]
    public async Task Validation_RequiredFields() {
        await Page.ClickAsync("data-test-id=contact-submit-button");

        await Expect(Page.GetByText("Naam is verplicht.", new() { Exact = true })).ToBeVisibleAsync();
        await Expect(Page.GetByText("Voornaam is verplicht.", new() { Exact = true })).ToBeVisibleAsync();
        await Expect(Page.GetByText("Email is verplicht.", new() { Exact = true })).ToBeVisibleAsync();
        await Expect(Page.GetByText("Telefoonnummer is verplicht.", new() { Exact = true })).ToBeVisibleAsync();
        await Expect(Page.GetByText("Een bericht is verplicht.", new() { Exact = true })).ToBeVisibleAsync();
    }

    [Test]
    public async Task Validation_ValidEmail() {
        Page.GetByPlaceholder("E-mail").FillAsync("test");
        await Page.ClickAsync("data-test-id=contact-submit-button");

        await Expect(Page.GetByText("Voer een geldig emailadres in.", new() { Exact = true })).ToBeVisibleAsync();
    }

    [Test]
    public async Task Validation_ValidPhone() {
        Page.GetByPlaceholder("Telefoonnummer").FillAsync("test");
        await Page.ClickAsync("data-test-id=contact-submit-button");

        await Expect(Page.GetByText("Voer een geldig telefoonnummer in.", new() { Exact = true })).ToBeVisibleAsync();
    }

    // [Test]
    // public async Task ContactForm_SendsEmail() {
    //     await Page.FillAsync("data-test-id=contact-name", "TestNaam");
    //     await Page.FillAsync("data-test-id=contact-firstname", "TestFirstName");
    //     await Page.FillAsync("data-test-id=contact-email", "test@email.com");
    //     await Page.FillAsync("data-test-id=contact-date", "22/11/2023");
    //     await Page.FillAsync("data-test-id=contact-phone", "0414251470");
    //     await Page.FillAsync("data-test-id=contact-message", "TestMessage");
    //     await Page.ClickAsync("data-test-id=contact-submit-button");
    //     //Assert.AreEqual($"{TestHelper.BaseUrl}/submit_form.php", Page.Url);
    // }
}