namespace Domain;

public class Appointment : Entity
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
            if(string.IsNullOrWhiteSpace(value)) throw new ArgumentNullException("Reason cannot be empty");
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
            if (string.IsNullOrWhiteSpace(value))
            {
                _note = "This appointment has no additional note.";
            }
            else
            {
                _note = value;
            }
        }
    }
    #endregion

    #region Constructors
    public Appointment(Patient patient, string reason, string note = null)
    {
        if (patient == null)
        {
            throw new ArgumentNullException("Patient cannot be empty, a appointment needs a patient");
        }
        _patient = patient;
        if (string.IsNullOrWhiteSpace(reason)) {
            throw new ArgumentNullException("Reason cannot be empty");
        }
        Reason = reason;
        if (!string.IsNullOrWhiteSpace(note))
        {
            Note = note;
        } 
        else
        {
            Note = "This appointment has no additional note.";
        }
    }
    #endregion

    #region Methods
    public bool HasPatient()
    {
        return _patient != null;
    }

    public void ChangePatient(Patient patient)
    {
        if (patient == null)
        {
            throw new ArgumentNullException("Patient cannot be empty, a appointment needs a patient");
        }
        _patient = patient;
    }

    public Patient GetPatient()
    {
        return _patient;
    }
    #endregion
}