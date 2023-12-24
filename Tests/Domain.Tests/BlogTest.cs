namespace Domain.Tests;

public class BlogTest
{
    #region Fields
    private readonly Blog _blog;
    #endregion

    #region Init
    public BlogTest() 
    {
        _blog = new Blog("BlogTitle!", "This is the text of this blog", "link");
    }
    #endregion

    #region Constructor tests
    [Fact]
    public void Blog_Constructor_ValidParameters()
    {
        new Blog("blog", "text", "link");
    }

    [Fact]
    public void Blog_Constructor_EmptyTitle_ThrowsException()
    {
        Assert.Throws<ArgumentException>(() => new Blog("", "text", "link"));
    }

    [Fact]
    public void Blog_Constructor_EmptyText_ThrowsException()
    {
        Assert.Throws<ArgumentException>(() => new Blog("blog", "", "link"));
    }

    [Fact]
    public void Blog_Constructor_EmptyLink_ThrowsException()
    {
        Assert.Throws<ArgumentException>(() => new Blog("blog", "text", ""));
    }
    #endregion

    #region Method tests
    [Fact]
    public void Blog_UpdateBlog()
    {
        _blog.UpdateBlog("blog", "text", "link");
        Assert.Equal(_blog.Title, "blog");
        Assert.Equal(_blog.Text, "text");
        Assert.Equal(_blog.ImageLink, "link");
    }
    #endregion
}