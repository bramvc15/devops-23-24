using Microsoft.Playwright.NUnit;
using Microsoft.Playwright;
using NUnit.Framework;

namespace PlaywrightTests;

[Parallelizable(ParallelScope.Self)]
[TestFixture]
public class OnsTeamTest : PageTest
{

    string _baseUrl = "http://192.168.0.123:5046";

    [SetUp]
    public async Task SetUp()
    {
        await Page.GotoAsync($"{_baseUrl}/onsTeam");
    }

    [Test]
    public async Task OnsTeam_BreadCrumbRedirectsToHomePage()
    {
        await Page.ClickAsync("data-test-id=onsteam-home-breadcrumb");
        Assert.AreEqual($"{_baseUrl}", Page.Url);
    }

    [Test]
    public async Task OnsTeam_DoctorLeesMeerRedirectsToDoctorDetailPage()
    {
        await Page.ClickAsync("data-test-id=onsteam-doctor-leesmeer-button");
        Assert.IsTrue(Page.Url.Contains($"{_baseUrl}/DoctorDetail/"));
    }

    [Test]
    public async Task OnsTeam_DoctorDetailBackButtonRedirectsToOnsTeamPage()
    {
        await Page.ClickAsync("data-test-id=onsteam-doctor-leesmeer-button");
        Assert.IsTrue(Page.Url.Contains($"{_baseUrl}/DoctorDetail/"));
        await Page.ClickAsync("data-test-id=doctordetail-back-button", new PageClickOptions { Force = true });
        Assert.AreEqual($"{_baseUrl}/", Page.Url);
    }
}