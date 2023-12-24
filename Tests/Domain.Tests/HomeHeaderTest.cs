namespace Domain.Tests;

public class HomeHeaderTest
{
    #region Fields
    private readonly HomeHeader _homeheader;
    #endregion

    #region Init
    public HomeHeaderTest()
    {
        _homeheader = new HomeHeader("title!", "text");
    }
    #endregion

    #region Constructor tests
    [Fact]
    public void HomeHeader_Constructor_ValidParameters()
    {
        new HomeHeader("title!", "text");
    }

    [Fact]
    public void HomeHeader_Constructor_EmptyTitle_ThrowsException()
    {
        Assert.Throws<ArgumentException>(() => new HomeHeader("", "text"));
    }

    [Fact]
    public void HomeHeader_Constructor_EmptyContext_ThrowsException()
    {
        Assert.Throws<ArgumentException>(() => new HomeHeader("title!", ""));
    }
    #endregion

    #region Method tests
    [Fact]
    public void HomeHeader_UpdateHomeHeader()
    {
        _homeheader.UpdateHomeHeader("new", "new2");
        Assert.Equal(_homeheader.Title, "new");
        Assert.Equal(_homeheader.Context, "new2");
    }
    #endregion
}