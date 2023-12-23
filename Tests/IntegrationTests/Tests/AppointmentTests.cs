using Microsoft.Playwright.NUnit;
using Microsoft.Playwright;
using NUnit.Framework;
using Shouldly;
using System.Text.RegularExpressions;

namespace IntegrationTests;

[Parallelizable(ParallelScope.Self)]
public class AppointmentTests : PageTest
{
    [Test]
    public async Task AppointmentPage_LoadsDoctors()
    {
        await Page.GotoAsync($"{TestHelper.BaseUrl}afspraak");
        Assert.IsTrue(await Page.IsVisibleAsync("data-test-id=doctorcard"));
    }

    [Test]
    public async Task SelectingDoctor_ShowsSelectTimeSlotPage()
    {
        await Page.GotoAsync($"{TestHelper.BaseUrl}/afspraak");
        await Page.ClickAsync("data-test-id=doctorcard");
        Expect(Page.GetByText("2. Selecteer uw afspraakmoment")).ToBeVisibleAsync();
    }

    [Test]
    public async Task MakeAppointment_LoadTimeSlots()
    {
        await Page.GotoAsync($"{TestHelper.BaseUrl}/afspraak");
        await Page.ClickAsync("data-test-id=doctorcard");
        await Page.GetByRole(AriaRole.Button, new() { Name = "Volgende beschikbare dag" }).ClickAsync();
        Expect(Page.Locator("class=timeslot")).ToBeVisibleAsync();
    }

    [Test]
    public async Task SelectingTimeSlot_ShowsContactDetailsPage()
    {
        await Page.GotoAsync($"{TestHelper.BaseUrl}/afspraak");
        await Page.ClickAsync("data-test-id=doctorcard");
        await Page.GetByRole(AriaRole.Button, new() { Name = "Volgende beschikbare dag" }).ClickAsync();
        await Page.ClickAsync("data-test-id=timeslot");
        Expect(Page.GetByText("3. Vul uw contactgegevens in")).ToBeVisibleAsync();
    }

    [Test]
    public async Task ContactDetailsPage_EnterContactDetails_RequiredFields()
    {
        await Page.GotoAsync($"{TestHelper.BaseUrl}/afspraak");
        await Page.ClickAsync("data-test-id=doctorcard");
        await Page.GetByRole(AriaRole.Button, new() { Name = "Volgende beschikbare dag" }).ClickAsync();
        await Page.ClickAsync("data-test-id=timeslot");
        await Page.GetByRole(AriaRole.Button, new() { Name = "Verzenden" }).ClickAsync();
        Expect(Page.GetByText("Naam is verplicht")).ToBeVisibleAsync();
        Expect(Page.GetByText("Telefoon is verplicht")).ToBeVisibleAsync();
        Expect(Page.GetByText("Email is verplicht")).ToBeVisibleAsync();
        Expect(Page.GetByText("Reden voor consultatie is verplicht")).ToBeVisibleAsync();
    }

    [Test]
    public async Task ContactDetailsPage_EnterContactDetails_FieldValidation()
    {
        await Page.GotoAsync($"{TestHelper.BaseUrl}/afspraak");
        await Page.ClickAsync("data-test-id=doctorcard");
        await Page.GetByRole(AriaRole.Button, new() { Name = "Volgende beschikbare dag" }).ClickAsync();
        await Page.ClickAsync("data-test-id=timeslot");
        await Page.GetByPlaceholder("0489432312").FillAsync("test");
        await Page.GetByPlaceholder("john@mail.com").FillAsync("test");
        await Page.GetByLabel("Geboortedatum").FillAsync("2028-12-23");
        await Page.GetByRole(AriaRole.Button, new() { Name = "Verzenden" }).ClickAsync();
        Expect(Page.GetByText("Incorrect email formaat.")).ToBeVisibleAsync();
        Expect(Page.GetByText("Incorrect telefoonnummer formaat.")).ToBeVisibleAsync();
        Expect(Page.GetByText("Geboortedatum mag niet in de toekomst liggen")).ToBeVisibleAsync();
    }

    [Test]
    public async Task ContactDetailsPage_SubmitContactDetails()
    {
        await Page.GotoAsync($"{TestHelper.BaseUrl}/afspraak");
        await Page.ClickAsync("data-test-id=doctorcard");
        await Page.GetByRole(AriaRole.Button, new() { Name = "Volgende beschikbare dag" }).ClickAsync();
        await Page.ClickAsync("data-test-id=timeslot");
        await Page.GetByPlaceholder("John Doe").FillAsync("testnaam");
        await Page.GetByPlaceholder("0489432312").FillAsync("0489432312");
        await Page.GetByPlaceholder("john@mail.com").FillAsync("john@mail.com");
        await Page.GetByLabel("Geboortedatum").FillAsync("2000-12-23");
        await Page.GetByPlaceholder("Reden voor consultatie").FillAsync("test");
        await Page.GetByRole(AriaRole.Button, new() { Name = "Verzenden" }).ClickAsync();
        Expect(Page.GetByRole(AriaRole.Heading, new() { Name = "Succes!" })).ToBeVisibleAsync();
    }
}