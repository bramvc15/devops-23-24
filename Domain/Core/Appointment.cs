using System;

namespace Domain;

public class Appointment : Entity
{
    #region Fields
    private string _reason;
    private string _note;
    private Patient _patient;
    private DateTime _dateTime;
    private string _nameDoctor;
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
    public Patient Patient { get { return _patient; } }

    // empty reference for one-to-one relation for db
    public TimeSlot TimeSlot { get; private set; } = null!;
    #endregion

    #region Constructors
    // Database Constructor
    private Appointment() { }

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
        _reason = reason;
        if (!string.IsNullOrWhiteSpace(note))
        {
            Note = note;
        } 
        else
        {
            Note = "This appointment has no additional note.";
        }

        if (dateTime == null)
        {
            throw new ArgumentNullException("DateTime cannot be null");
        }
        if (dateTime < DateTime.Now)
        {
            throw new ArgumentException("DateTime cannot be in the past");
        }
        _dateTime = dateTime;

        if (string.IsNullOrWhiteSpace(nameDoctor)) throw new ArgumentNullException("Name Doctor cannot be empty");
        _nameDoctor = nameDoctor;
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

    public void UpdateAppointment(Appointment appointment)
    {
        Reason = appointment.Reason;
        Note = appointment.Note;
    }
    #endregion
}