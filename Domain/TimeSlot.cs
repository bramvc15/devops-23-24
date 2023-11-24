namespace Domain;

public class TimeSlot
{
    #region Fields
    private int _duration;
    private readonly Appointment _appointment;
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

    public void CreateAppointment()
    {
         // to be implemented
    }

    public void UpdateAppointment()
    {
         // to be implemented
    }

    public void DeleteAppointment()
    {
         // to be implemented
    }
    #endregion
}