using Ardalis.GuardClauses;

namespace Domain;

public class Note : Entity
{
    #region Properties
    private string title;
    private string content;


    public string Title
    {
        get => title;
        private set => title = Guard.Against.NullOrWhiteSpace(value, nameof(Title));
    }
    public string Content
    {
        get => content;
        private set => content = Guard.Against.NullOrWhiteSpace(value, nameof(Content));
    }
    #endregion

    #region Constructors
    // Database Constructor
    private Note() { }

    public Note(string title, string content)
    {
        Title = title;
        Content = content;
    }
    #endregion

    #region Methods
    public void UpdateNote(string title, string content)
    {
        Title = title;
        Content = content;
    }
    #endregion
}