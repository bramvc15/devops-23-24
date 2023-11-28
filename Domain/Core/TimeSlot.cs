namespace Domain;

public class TimeSlot : Entity
{
    #region Fields
    private int _duration;
    private AppointmentType _appointmentType;
    private DateTime _dateTime;
    private Appointment _appointment;
    #endregion
    
    #region Properties
    public int Duration {
        get
        {
            return _duration;
        }
        private set
        {
            if (value == null)
            {
                throw new ArgumentNullException("Duration cannot be null");
            }
            if (value <= 0) throw new ArgumentException("Duration cannot be less than or equal to 0");
            if (value > 1440)
            {
                throw new ArgumentException("Duration cannot be longer than 24 hours");
            }
            _duration = value;
        }
    }
    public AppointmentType AppointmentType
    {
        get
        {
            return _appointmentType;
        }
        private set
        {
            if (!Enum.IsDefined(typeof(AppointmentType), value))
            {
                throw new ArgumentException("Invalid AppointmentType");
            }
            _appointmentType = value;
        }
    }
    public DateTime DateTime
    {
        get
        {
            return _dateTime;
        }
        private set
        {
            if (value == null)
            {
                throw new ArgumentNullException("DateTime cannot be null");
            }
            if (value < DateTime.Now)
            {
                throw new ArgumentException("DateTime cannot be in the past");
            }
            _dateTime = value;
        }
    }
    public Appointment Appointment { get { return _appointment; } }
    #endregion

    #region Constructors
    // Database Constructor
    private TimeSlot() { }

    public TimeSlot(AppointmentType appointmentType, DateTime dateTime, int duration)
    {
        if (!Enum.IsDefined(typeof(AppointmentType), appointmentType))
        {
            throw new ArgumentException("Invalid AppointmentType");
        }
        _appointmentType = appointmentType;

        if (dateTime == null)
        {
            throw new ArgumentNullException("DateTime cannot be null");
        }
        if (dateTime < DateTime.Now)
        {
            throw new ArgumentException("DateTime cannot be in the past");
        }
        _dateTime = dateTime;

        if (duration == null)
        {
            throw new ArgumentNullException("Duration cannot be null");
        }
        if (duration <= 0)
        {
            throw new ArgumentException("Duration cannot be less than or equal to 0");
        }
        if (duration > 1440)
        {
            throw new ArgumentException("Duration cannot be longer than 24 hours");
        }
        _duration = duration;

        _appointment = null;
    }
    #endregion

    #region Methods
    public bool IsTimeSlotAvailable()
    {
        return _appointment == null;
    }

    public Appointment CreateAppointment(Patient patient, string reason, string note)
    {
        _appointment = new Appointment(patient, reason, note);
        return _appointment;
    }

    public void UpdateAppointment(Appointment newAppointment)
    {
        _appointment = newAppointment;
    }

    public void DeleteAppointment()
    {
        if (_appointment == null) throw new ArgumentException("Appointment does not exist");
        _appointment = null;
    }

    public void UpdateTimeSlot(TimeSlot newTimeSlot)
    {
        _appointmentType = newTimeSlot.AppointmentType;
        _dateTime = newTimeSlot.DateTime;
        _duration = newTimeSlot.Duration;
    }

    public Appointment GetAppointment()
    {
        return _appointment;
    }
    #endregion
}