using Microsoft.Playwright.NUnit;
using Microsoft.Playwright;
using NUnit.Framework;

namespace IntegrationTests;

[Parallelizable(ParallelScope.Self)]
public class ContactTest : PageTest
{
    [SetUp]
    public async Task SetUp()
    {
        await Page.GotoAsync($"{TestHelper.BaseUrl}/contact");
    }

    [Test]
    public async Task Validation_RequiredFields() {
        await Page.GetByRole(AriaRole.Button, new() { Name = "Verstuur" }).ClickAsync();

        await Expect(Page.GetByText("Naam is verplicht").First).ToBeVisibleAsync();
        await Expect(Page.GetByText("Naam is verplicht").Nth(1)).ToBeVisibleAsync();
        await Expect(Page.GetByText("Telefoon is verplicht", new() { Exact = true })).ToBeVisibleAsync();
        await Expect(Page.GetByText("Bericht is verplicht", new() { Exact = true })).ToBeVisibleAsync();
    }

    [Test]
    public async Task Validation_ValidEmail() {
        Page.GetByPlaceholder("naam@mail.com").FillAsync("test");
        await Page.GetByRole(AriaRole.Button, new() { Name = "Verstuur" }).ClickAsync();

        await Expect(Page.GetByText("Email is niet geldig")).ToBeVisibleAsync();
    }

    [Test]
    public async Task Validation_ValidPhone() {
        Page.GetByPlaceholder("0489561475").FillAsync("test");
        await Page.GetByRole(AriaRole.Button, new() { Name = "Verstuur" }).ClickAsync();

        await Expect(Page.GetByText("Incorrect telefoonnummer formaat.")).ToBeVisibleAsync();
    }

    [Test]
    public async Task ContactForm_SendsMessage() {
        await Page.GetByPlaceholder("Naam", new() { Exact = true }).FillAsync("TestName");
        await Page.GetByPlaceholder("Achternaam").FillAsync("TestLastName");
        await Page.GetByPlaceholder("naam@mail.com").FillAsync("test@gmail.com");
        await Page.GetByPlaceholder("0489561475").FillAsync("0414251470");
        await Page.Locator("input[type=\"date\"]").FillAsync("2002-04-15");
        await Page.GetByPlaceholder(". . .").FillAsync("testbericht");
        await Page.GetByRole(AriaRole.Button, new() { Name = "Verstuur" }).ClickAsync();
        await Expect(Page.GetByText("Bericht verzonden!")).ToBeVisibleAsync();
    }
}