namespace Domain;

public class ScheduleTimeSlot : Entity
{
    #region Fields
    private int _duration;
    private AppointmentType _appointmentType;
    private DateTime _dateTime;
    private DayOfWeek _dayOfWeek;
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
    public AppointmentType AppointmentType {
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
    public DateTime DateTime {
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
            _dateTime = value;
        }
    }
    public DayOfWeek DayOfWeek {
        get
        {
            return _dayOfWeek;
        }
        private set
        {
            if (!Enum.IsDefined(typeof(DayOfWeek), value))
            {
                throw new ArgumentException("The given DayOfWeek does not exist");
            }
            _dayOfWeek = value;
        }
    }
    #endregion

    #region Constructors
    public ScheduleTimeSlot(AppointmentType appointmentType, DateTime dateTime, int duration, DayOfWeek dayOfWeek)
    {
        if (!Enum.IsDefined(typeof(AppointmentType), appointmentType)) {
            throw new ArgumentException("Invalid AppointmentType");
        }
        _appointmentType = appointmentType;

        if (dateTime == null) {
            throw new ArgumentNullException("DateTime cannot be null");
        }
        _dateTime = dateTime;

        if (duration == null) {
            throw new ArgumentNullException("Duration cannot be null");
        }
        if (duration <= 0) {
            throw new ArgumentException("Duration cannot be less than or equal to 0");
        }
        if (duration > 1440)
        {
            throw new ArgumentException("Duration cannot be longer than 24 hours");
        }
        _duration = duration;

        if (!Enum.IsDefined(typeof(DayOfWeek), dayOfWeek)) {
            throw new ArgumentException("The given DayOfWeek does not exist");
        }
        _dayOfWeek = dayOfWeek;
    }
    #endregion

    #region Methods
    public void UpdateScheduleTimeSlot(ScheduleTimeSlot newScheduleTimeSlot)
    {
        _appointmentType = newScheduleTimeSlot._appointmentType;
        _dateTime = newScheduleTimeSlot._dateTime;
        _duration = newScheduleTimeSlot._duration;
        _dayOfWeek = newScheduleTimeSlot._dayOfWeek;
    }
    #endregion
}