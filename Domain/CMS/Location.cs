using Ardalis.GuardClauses;

namespace Domain;

public class Location : Entity
{
    #region Properties
    private string straat;
    private string stad;
    private string land;
    private string email;
    private string telefoon;

    public string Straat
    {
        get => straat;
        private set => straat = Guard.Against.NullOrWhiteSpace(value, nameof(Straat));
    }

    public string Stad
    {
        get => stad;
        private set => stad = Guard.Against.NullOrWhiteSpace(value, nameof(Stad));
    }

    public string Land
    {
        get => land;
        private set => land = Guard.Against.NullOrWhiteSpace(value, nameof(Land));
    }

    public string Email
    {
        get => email;
        private set => email = Guard.Against.NullOrWhiteSpace(value, nameof(Email));
    }

    public string Telefoon
    {
        get => telefoon;
        private set => telefoon = Guard.Against.NullOrWhiteSpace(value, nameof(Telefoon));
    }
    #endregion

    #region Constructors
    // Database Constructor
    private Location() { }

    public Location(string straat, string stad, string land, string email, string telefoon)
    {
        Straat = straat;
        Stad = stad;
        Land = land;
        Email = email;
        Telefoon = telefoon;
    }
    #endregion

    #region Methods
    public void UpdateLocation(string straat, string stad, string land, string email, string telefoon)
    {
        Straat = straat;
        Stad = stad;
        Land = land;
        Email = email;
        Telefoon = telefoon;
    }
    #endregion
}