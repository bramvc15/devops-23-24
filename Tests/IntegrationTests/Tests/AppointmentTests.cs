using Microsoft.Playwright.NUnit;
using NUnit.Framework;
using Shouldly;
using System.Text.RegularExpressions;

namespace IntegrationTests;

[Parallelizable(ParallelScope.Self)]
public class AppointmentTests : PageTest
{
    [Test]
    public async Task SelectingProcedure_ShowsDoctors()
    {
        await Page.GotoAsync($"{TestHelper.BaseUrl}/afspraak");
        await Page.ClickAsync("data-test-id=treatmentcard-button");
        Assert.IsTrue(await Page.IsVisibleAsync("data-test-id=doctorcard"));
    }

    [Test]
    public async Task SelectingDoctor_ShowsSelectTimeSlotPage()
    {
        await Page.GotoAsync($"{TestHelper.BaseUrl}/afspraak");
        await Page.ClickAsync("data-test-id=treatmentcard-button");
        await Page.ClickAsync("data-test-id=doctorcard");
        Assert.IsTrue(await Page.IsVisibleAsync("data-test-id=appointment-box"));
    }

    [Test]
    public async Task SelectingTimeSlot_EnterContactDetails_Validation_RequiredFields()
    {
        await Page.GotoAsync($"{TestHelper.BaseUrl}/afspraak");
        await Page.ClickAsync("data-test-id=treatmentcard-button");
        await Page.ClickAsync("data-test-id=doctorcard");
        await Page.ClickAsync("data-test-id=appointment-temp-button");
        await Page.ClickAsync("data-test-id=appointment-submit");
        await Expect(Page.GetByText("Naam is verplicht", new() { Exact = true })).ToBeVisibleAsync();
        await Expect(Page.GetByText("Telefoon is verplicht", new() { Exact = true })).ToBeVisibleAsync();
        await Expect(Page.GetByText("Email is verplicht", new() { Exact = true })).ToBeVisibleAsync();
    }

    [Test]
    public async Task SelectingTimeSlot_EnterContactDetails_InvalidPhoneAndEmail()
    {
        await Page.GotoAsync($"{TestHelper.BaseUrl}/afspraak");
        await Page.ClickAsync("data-test-id=treatmentcard-button");
        await Page.ClickAsync("data-test-id=doctorcard");
        await Page.ClickAsync("data-test-id=appointment-temp-button");
        await Page.GetByPlaceholder("john@mail.com").FillAsync("test");
        await Page.GetByPlaceholder("0489432312").FillAsync("test");
        await Page.ClickAsync("data-test-id=appointment-submit");
        await Expect(Page.GetByText("Incorrect telefoonnummer formaat.", new() { Exact = true })).ToBeVisibleAsync();
        await Expect(Page.GetByText("Email is niet geldig", new() { Exact = true })).ToBeVisibleAsync();
    }


}