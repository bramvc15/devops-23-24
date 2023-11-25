namespace Domain;

public class ScheduleTimeSlot
{
    #region Fields
    private int _duration;
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
    public DayOfWeek DayOfWeek { get; private set; }
    #endregion

    #region Constructors
    public ScheduleTimeSlot(AppointmentType appointmentType, DateTime dateTime, int duration, DayOfWeek dayOfWeek)
    {
        AppointmentType = appointmentType;
        Duration = duration;
        DateTime = dateTime;
        DayOfWeek = dayOfWeek;
    }
    #endregion

    #region Methods
    public void UpdateScheduleTimeSlot(ScheduleTimeSlot newScheduleTimeSlot)
    {
        AppointmentType = newScheduleTimeSlot.AppointmentType;
        DateTime = newScheduleTimeSlot.DateTime;
        Duration = newScheduleTimeSlot.Duration;
        DayOfWeek = newScheduleTimeSlot.DayOfWeek;
    }
    #endregion
}