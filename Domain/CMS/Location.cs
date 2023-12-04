using Ardalis.GuardClauses;

namespace Domain;

public class Location : Entity
{
    #region Properties
    private string context;

    public string Context
    {
        get => context;
        private set => context = Guard.Against.NullOrWhiteSpace(value, nameof(Context));
    }
    #endregion

    #region Constructors
    // Database Constructor
    private Location() { }

    public Location(string context)
    {
        Context = context;
    }
    #endregion

    #region Methods
    public void UpdateLocation(string context)
    {
        Context = context;
    }
    #endregion
}