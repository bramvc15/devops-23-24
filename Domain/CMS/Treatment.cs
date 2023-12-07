using Ardalis.GuardClauses;

namespace Domain;

public class Treatment : Entity
{
    #region Properties
    private string name;
    private string description;
    private string imageLink;

    public string Name
    {
        get => name;
        private set => name = Guard.Against.NullOrWhiteSpace(value, nameof(Name));
    }
    public string Description
    {
        get => description;
        private set => description = Guard.Against.NullOrWhiteSpace(value, nameof(Description));
    }
    public string ImageLink
    {
        get => imageLink;
        private set => imageLink = Guard.Against.NullOrWhiteSpace(value, nameof(ImageLink));
    }
    #endregion

    #region Constructors
    // Database Constructor
    private Treatment() { }

    public Treatment(string name, string description, string imageLink)
    {
        Name = name;
        Description = description;
        ImageLink = imageLink;
    }
    #endregion

    #region Methods
    public void UpdateTreatment(string name, string description, string imageLink)
    {
        Name = name;
        Description = description;
        ImageLink = imageLink;
    }
    #endregion
}