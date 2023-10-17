
namespace BlazorApp.Data;


public class HomeHeaderService
{

    private string titel = "Vision Oogcenter Gent";
    private string tekst = "Welkom bij Vision Oogcenter Gent - uw venster naar helder zicht en een wereld van visuele perfectie.";

    public async Task<HomeHeader> GetHomeHeaderAsync()
    {
        return new HomeHeader
        {

            Title = titel,
            Text = tekst
        };

    }



    public async Task<bool> UpdateHomeHeaderAsync(HomeHeader homeHeader, string newTitle)
    {
        try
        {
            // Update the title of the HomeHeader
            homeHeader.Title = newTitle;
            Console.WriteLine(homeHeader.Title + "hello from service");
            // You can also update other properties if needed
            
            return true;
        }
        catch (Exception)
        {
            // Handle errors or return false
            return false;
        }
    }


}
