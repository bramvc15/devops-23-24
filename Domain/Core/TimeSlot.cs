namespace Domain;

public class TimeSlot
{
    #region Fields
    private int _duration;
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
            if(value <= 0) throw new ArgumentException("Duration cannot be less than or equal to 0");
            _duration = value;
        }
    }
    public AppointmentType AppointmentType { get; private set; }
    public DateTime DateTime { get; private set; }
    #endregion

    #region Constructors
    public TimeSlot(AppointmentType appointmentType, DateTime dateTime, int duration)
    {
        AppointmentType = appointmentType;
        DateTime = dateTime;
        Duration = duration;
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
        AppointmentType = newTimeSlot.AppointmentType;
        DateTime = newTimeSlot.DateTime;
        Duration = newTimeSlot.Duration;
    }

    public Appointment GetAppointment()
    {
        return _appointment;
    }
    #endregion
}