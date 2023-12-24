namespace Domain.Tests;

public class LocationTest
{
    #region Fields
    private readonly Location _location;
    #endregion

    #region Init
    public LocationTest()
    {
        _location = new Location("Antwerpsesteenweg 1022", "9040 Gent", "België", "vision@mail.com", "09 89 78 78 11", "Maandag - Vrijdag: 8:00 - 18:00", "Zaterdag - Zondag: Gesloten");
    }
    #endregion

    #region Constructor tests
    [Fact]
    public void Location_Constructor_ValidParameters()
    {
        new Location("Antwerpsesteenweg 1022", "9040 Gent", "België", "vision@mail.com", "09 89 78 78 11", "Maandag - Vrijdag: 8:00 - 18:00", "Zaterdag - Zondag: Gesloten");
    }

    [Fact]
    public void Location_Constructor_EmptyStraat_ThrowsException()
    {
        Assert.Throws<ArgumentException>(() => new Location("", "9040 Gent", "België", "vision@mail.com", "09 89 78 78 11", "Maandag - Vrijdag: 8:00 - 18:00", "Zaterdag - Zondag: Gesloten"));
    }

    [Fact]
    public void Location_Constructor_EmptyStad_ThrowsException()
    {
        Assert.Throws<ArgumentException>(() => new Location("Antwerpsesteenweg 1022", "", "België", "vision@mail.com", "09 89 78 78 11", "Maandag - Vrijdag: 8:00 - 18:00", "Zaterdag - Zondag: Gesloten"));
    }

    [Fact]
    public void Location_Constructor_EmptyLand_ThrowsException()
    {
        Assert.Throws<ArgumentException>(() => new Location("Antwerpsesteenweg 1022", "9040 Gent", "", "vision@mail.com", "09 89 78 78 11", "Maandag - Vrijdag: 8:00 - 18:00", "Zaterdag - Zondag: Gesloten"));
    }

    [Fact]
    public void Location_Constructor_EmptyEmail_ThrowsException()
    {
        Assert.Throws<ArgumentException>(() => new Location("Antwerpsesteenweg 1022", "9040 Gent", "België", "", "09 89 78 78 11", "Maandag - Vrijdag: 8:00 - 18:00", "Zaterdag - Zondag: Gesloten"));
    }

    [Fact]
    public void Location_Constructor_EmptyTelefoon_ThrowsException()
    {
        Assert.Throws<ArgumentException>(() => new Location("Antwerpsesteenweg 1022", "9040 Gent", "België", "vision@mail.com", "", "Maandag - Vrijdag: 8:00 - 18:00", "Zaterdag - Zondag: Gesloten"));
    }

    [Fact]
    public void Location_Constructor_EmptyWeek_ThrowsException()
    {
        Assert.Throws<ArgumentException>(() => new Location("Antwerpsesteenweg 1022", "9040 Gent", "België", "vision@mail.com", "09 89 78 78 11", "", "Zaterdag - Zondag: Gesloten"));
    }

    [Fact]
    public void Location_Constructor_EmptyWeekend_ThrowsException()
    {
        Assert.Throws<ArgumentException>(() => new Location("Antwerpsesteenweg 1022", "9040 Gent", "België", "vision@mail.com", "09 89 78 78 11", "Maandag - Vrijdag: 8:00 - 18:00", ""));
    }
    #endregion

    #region Method tests
    [Fact]
    public void Location_UpdateLocation()
    {
        _location.UpdateLocation("new", "new2", "new3", "new4", "new5", "new6", "new7");
        Assert.Equal(_location.Straat, "new");
        Assert.Equal(_location.Stad, "new2");
        Assert.Equal(_location.Land, "new3");
        Assert.Equal(_location.Email, "new4");
        Assert.Equal(_location.Telefoon, "new5");
        Assert.Equal(_location.Week, "new6");
        Assert.Equal(_location.Weekend, "new7");
    }
    #endregion
}