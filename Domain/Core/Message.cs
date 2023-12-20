using Ardalis.GuardClauses;

namespace Domain;

public class Message : Entity
{
    #region Properties
    private string name;
    private string lastname;
    private string email;
    private string phone;
    private DateTime birthdate;
    private string note;
    private bool read;


    public string Name
    {
        get => name;
        private set => name = Guard.Against.NullOrWhiteSpace(value, nameof(Name));
    }
    public string LastName
    {
        get => lastname;
        private set => lastname = Guard.Against.NullOrWhiteSpace(value, nameof(LastName));
    }
    public string Email
    {
        get => email;
        private set => email = Guard.Against.NullOrWhiteSpace(value, nameof(Email));
    }
    public string Phone
    {
        get => phone;
        private set => phone = Guard.Against.NullOrWhiteSpace(value, nameof(Phone));
    }
    public DateTime Birthdate
    {
        get => birthdate;
        private set => birthdate = Guard.Against.Default(value, nameof(Birthdate));
    }
    public string Note
    {
        get => note;
        private set => note = Guard.Against.NullOrWhiteSpace(value, nameof(Note));
    }
    public bool Read { get; set; } = false;
    #endregion

    #region Constructors
    // Database Constructor
    private Message() { }

    public Message(string name, string lastname, string email, string phone, DateTime birthdate, string note, bool read)
    {
        Name = name;
        LastName = lastname;
        Email = email;
        Phone = phone;
        Birthdate = birthdate;
        Note = note;
        Read = read;
    }
    #endregion
    #region Methods
    public void UpdateMessage(string name, string lastname, string email, string phone, DateTime birthdate, string note, bool read)
    {
        Name = name;
        LastName = lastname;
        Email = email;
        Phone = phone;
        Birthdate = birthdate;
        Note = note;
        Read = read;
    }
    #endregion
}