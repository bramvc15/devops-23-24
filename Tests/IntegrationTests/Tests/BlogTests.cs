using Microsoft.Playwright.NUnit;
using NUnit.Framework;
using Shouldly;
using System.Text.RegularExpressions;

namespace IntegrationTests;

[Parallelizable(ParallelScope.Self)]
public class ActuaDetailTests : PageTest
{
    [Test]
    public async Task Show_Blogpost_OnLoad()
    {
        await Page.GotoAsync($"{TestHelper.BaseUrl}actua");
        Expect(Page.GetByLabel("Slide show")).ToBeVisibleAsync();
    }
}