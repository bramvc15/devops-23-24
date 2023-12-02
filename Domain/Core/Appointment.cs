using Ardalis.GuardClauses;

namespace Domain;

public class Appointment : Entity
{
    #region Properties
    private string reason;
    public string Reason
    {
        get => reason;
        private set => reason = Guard.Against.NullOrWhiteSpace(value, nameof(Reason));
    }

    public string? Note { get; private set; }

    public Patient Patient { get; }
    #endregion Properties

    #region Constructors
    // Database Constructor
    private Appointment() { }

    public Appointment(Patient patient, string reason, string? note = default)
    {
        Patient = Guard.Against.Null(patient);
        Reason = reason;
        Note = note;
    }
    #endregion

    #region Methods
    public void UpdateAppointment(string reason, string? note)
    {
        Reason = reason;
        Note = note;
    }
    #endregion
}