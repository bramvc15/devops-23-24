using Microsoft.Playwright.NUnit;
using Microsoft.Playwright;
using NUnit.Framework;
using Shouldly;
using System.Text.RegularExpressions;

namespace IntegrationTests;

[Parallelizable(ParallelScope.Self)]
public class TeamTests : PageTest
{
    [SetUp]
    public async Task SetUp()
    {
        await Page.GotoAsync($"{TestHelper.BaseUrl}/ons-team");

    }

    [Test]
    public async Task Team_Show_Doctors_OnLoad() {
        Assert.IsTrue(await Page.IsVisibleAsync("data-test-id=team-doctor-name"));
        var doctorName = await Page.TextContentAsync("data-test-id=team-doctor-name");
        doctorName.ShouldNotBeEmpty();
    }

    [Test]
    public async Task Team_BreadCrumbRedirectsToHomePage()
    {
        await Page.GetByRole(AriaRole.Link, new() { Name = "" }).ClickAsync();
        await Expect(Page).ToHaveURLAsync($"{TestHelper.BaseUrl}");
    }

    [Test]
    public async Task Team_DoctorCardRedirectsToDoctorDetailPage()
    {
        await Page.ClickAsync("data-test-id=doctorcard");
        await Expect(Page).ToHaveURLAsync(new Regex(".*/ons-team/\\d+"));
    }

    [Test]
    public async Task Team_DoctorDetailOnsTeamBreadCrumbRedirectsToOnsTeamPage()
    {
        await Page.ClickAsync("data-test-id=doctorcard");
        await Expect(Page).ToHaveURLAsync(new Regex(".*/ons-team/\\d+"));
        await Page.GetByRole(AriaRole.Link, new() { Name = "ons-team" }).ClickAsync();
        Assert.AreEqual($"{TestHelper.BaseUrl}ons-team", Page.Url);
    }
}