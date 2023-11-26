namespace Domain;

public class Appointment
{
    #region Fields
    private string _reason;
    private string _note;
    private Patient _patient;
    #endregion

    #region Properties
    public string Reason {
        get
        {
            return _reason;
        }
        private set
        {
            if(string.IsNullOrWhiteSpace(value)) throw new ArgumentException("Reason cannot be empty");
            _reason = value;
        }
    }
    public string Note { 
        get
        {
            return _note;
        }
        private set
        {
            if(string.IsNullOrWhiteSpace(value)) throw new ArgumentException("Note cannot be empty");
            _note = value;
        }
    }
    #endregion

    #region Constructors
    public Appointment(Patient patient, string reason, string note)
    {
        _patient = patient;
        Reason = reason;
        Note = note;
    }
    #endregion

    #region Methods
    public bool HasPatient()
    {
        return _patient != null;
    }

    public void ChangePatient(Patient patient)
    {
        _patient = patient;
    }

    public Patient GetPatient()
    {
        return _patient;
    }
    #endregion
}