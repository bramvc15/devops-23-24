using Microsoft.Playwright.NUnit;
using Microsoft.Playwright;
using NUnit.Framework;
using Shouldly;

namespace PlaywrightTests;

[Parallelizable(ParallelScope.Self)]
[TestFixture]
public class OnsTeamTest : PageTest
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
        await Page.GotoAsync($"{baseUrl}/onsTeam");
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
        await Page.ClickAsync("data-test-id=onsteam-home-breadcrumb");
        Assert.AreEqual($"{baseUrl}", Page.Url);
    }

    [Test]
    public async Task OnsTeam_DoctorLeesMeerRedirectsToDoctorDetailPage()
    {
        await Page.ClickAsync("data-test-id=onsteam-doctor-leesmeer-button");
        Assert.IsTrue(Page.Url.Contains($"{baseUrl}/DoctorDetail/"));
    }

    [Test]
    public async Task OnsTeam_DoctorDetailBackButtonRedirectsToOnsTeamPage()
    {
        await Page.ClickAsync("data-test-id=onsteam-doctor-leesmeer-button");
        Assert.IsTrue(Page.Url.Contains($"{baseUrl}/DoctorDetail/"));
        await Page.ClickAsync("data-test-id=doctordetail-back-button", new PageClickOptions { Force = true });
        Assert.AreEqual($"{baseUrl}/", Page.Url);
    }
}