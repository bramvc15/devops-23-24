using Microsoft.Playwright.NUnit;
using Microsoft.Playwright;
using NUnit.Framework;
using Shouldly;

namespace IntegrationTests;

[Parallelizable(ParallelScope.Self)]
[TestFixture]
public class OnsTeamTest : PageTest
{


    [OneTimeSetUp]
    public void Init()
    {
        
    }

    [SetUp]
    public async Task SetUp()
    {
        await Page.GotoAsync($"{TestHelper.BaseUrl}/onsTeam");
    }

    [Test]
    public async Task OnsTeam_Show_Doctors_OnLoad() {
        Assert.IsTrue(await Page.IsVisibleAsync("data-test-id=onsteam-doctor-name"));
        var doctorName = await Page.TextContentAsync("data-test-id=onsteam-doctor-name");
        doctorName.ShouldNotBeEmpty();
    }

    [Test]
    public async Task OnsTeam_BreadCrumbRedirectsToHomePage()
    {
        await Page.ClickAsync("data-test-id=team-home-breadcrumb");
        Assert.AreEqual($"{TestHelper.BaseUrl}", Page.Url);
    }

    [Test]
    public async Task OnsTeam_DoctorLeesMeerRedirectsToDoctorDetailPage()
    {
        await Page.ClickAsync("data-test-id=onsteam-doctor-leesmeer-button");
        Assert.IsTrue(Page.Url.Contains($"{TestHelper.BaseUrl}/DoctorDetail/"));
    }

    [Test]
    public async Task OnsTeam_DoctorDetailBackButtonRedirectsToOnsTeamPage()
    {
        await Page.ClickAsync("data-test-id=onsteam-doctor-leesmeer-button");
        Assert.IsTrue(Page.Url.Contains($"{TestHelper.BaseUrl}/DoctorDetail/"));
        await Page.ClickAsync("data-test-id=doctordetail-back-button", new PageClickOptions { Force = true });
        Assert.AreEqual($"{TestHelper.BaseUrl}/", Page.Url);
    }
}