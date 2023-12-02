namespace Domain;
using Ardalis.GuardClauses;
using Shared.Enums;
using System.Xml.Linq;

public class Blog : Entity
{
    #region Properties
    private string title;
    private string text;
    private string imageLink;

    public string Title
    {
        get => title;
        private set => title = Guard.Against.NullOrWhiteSpace(value, nameof(Title));
    }
    public string Text
    {
        get => text;
        private set => text = Guard.Against.NullOrWhiteSpace(value, nameof(Text));
    }
    public string ImageLink
    {
        get => imageLink;
        private set => imageLink = Guard.Against.NullOrWhiteSpace(value, nameof(ImageLink));
    }
    #endregion

    #region Constructors
    // Database Constructor
    private Blog() { }

    public Blog(string title, string text, string imageLink)
    {
        Title = title;
        Text = text;
        ImageLink = imageLink;
    }
    #endregion

    #region Methods
    public void UpdateBlog(string title, string text, string imageLink)
    {
        Title = title;
        Text = text;
        ImageLink = imageLink;
    }
    #endregion
}