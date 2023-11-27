using Microsoft.Playwright.NUnit;
using Microsoft.Playwright;
using NUnit.Framework;
using Shouldly;
using System.Text.RegularExpressions;

namespace IntegrationTests;

[Parallelizable(ParallelScope.Self)]
[TestFixture]
public class TeamTests : PageTest
{


    [OneTimeSetUp]
    public void Init()
    {
        
    }

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
        await Page.ClickAsync("data-test-id=team-home-breadcrumb");
        await Expect(Page).ToHaveURLAsync($"{TestHelper.BaseUrl}/");
    }

    [Test]
    public async Task Team_DoctorLeesMeerRedirectsToDoctorDetailPage()
    {
        await Page.ClickAsync("data-test-id=team-doctor-details-button");
        Assert.IsTrue(Page.Url.Contains($"{TestHelper.BaseUrl}/docter-info/"));
    }

    [Test]
    public async Task Team_DoctorDetailBackButtonRedirectsToOnsTeamPage()
    {
        await Page.ClickAsync("data-test-id=team-doctor-details-button");
        Assert.IsTrue(Page.Url.Contains($"{TestHelper.BaseUrl}/docter-info/"));
        await Page.ClickAsync("data-test-id=doctordetail-back-button", new PageClickOptions { Force = true });
        Assert.AreEqual($"{TestHelper.BaseUrl}/ons-team", Page.Url);
    }
}