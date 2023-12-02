using Ardalis.GuardClauses;

namespace Domain;

public class HomeHeader : Entity
{
    #region Properties
    private string title;
    private string context;

    public string Title
    {
        get => title;
        private set => title = Guard.Against.NullOrWhiteSpace(value, nameof(Title));
    }
    public string Context
    {
        get => context;
        private set => context = Guard.Against.NullOrWhiteSpace(value, nameof(Context));
    }
    #endregion

    #region Constructors
    // Database Constructor
    private HomeHeader() { }

    public HomeHeader(string title, string context)
    {
        Title = title;
        Context = context;
    }
    #endregion

    #region Methods
    public void UpdateHomeHeader(string title, string context)
    {
        Title = title;
        Context = context;
    }
    #endregion
}