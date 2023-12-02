using Ardalis.GuardClauses;

namespace Domain;

public class Contact : Entity
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
    private Contact() { }

    public Contact(string context)
    {
        Context = context;
    }
    #endregion

    #region Methods
    public void UpdateContact(string context)
    {
        Context = context;
    }
    #endregion
}