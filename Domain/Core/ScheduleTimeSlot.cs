using Ardalis.GuardClauses;
using Shared.Enums;
using System.Xml.Linq;

namespace Domain;

public class ScheduleTimeSlot : Entity
{
    #region Properties
    private int duration;
    private AppointmentType appointmentType;
    private DateTime dateTime;
    private DayOfWeek dayOfWeek;

    public int Duration
    {
        get => duration;
        private set
        {
            Guard.Against.Null(value, nameof(value), "Duration cannot be null");
            Guard.Against.NegativeOrZero(value, nameof(value), "Duration cannot be less than or equal to 0");
            Guard.Against.OutOfRange(value, nameof(value), 1, 1440, "Duration must be between 1 and 1440 minutes");

            duration = value;
        }
    } 
    public AppointmentType AppointmentType {
        get => appointmentType;
        private set => appointmentType = Guard.Against.EnumOutOfRange<AppointmentType>(value, nameof(value), "Invalid AppointmentType");
    }
    public DateTime DateTime {
        get => dateTime;
        private set => dateTime = Guard.Against.Null(value, nameof(value), "DateTime cannot be null");
    }
    public DayOfWeek DayOfWeek
    {
        get => dayOfWeek;
        private set => dayOfWeek = Guard.Against.EnumOutOfRange<DayOfWeek>(value, nameof(value), "The given DayOfWeek does not exist");
    }
    #endregion

    #region Constructors
    // Database Constructor
    private ScheduleTimeSlot() { }

    public ScheduleTimeSlot(AppointmentType appointmentType, DateTime dateTime, int duration, DayOfWeek dayOfWeek)
    {
        if (!Enum.IsDefined(typeof(AppointmentType), appointmentType))
        {
            throw new ArgumentException("Invalid AppointmentType");
        }
        this.appointmentType = appointmentType;

        if (dateTime == null)
        {
            throw new ArgumentNullException("DateTime cannot be null");
        }
        this.dateTime = dateTime;

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
        this.duration = duration;

        if (!Enum.IsDefined(typeof(DayOfWeek), dayOfWeek))
        {
            throw new ArgumentException("The given DayOfWeek does not exist");
        }
        this.dayOfWeek = dayOfWeek;
    }
    #endregion

    #region Methods
    public void UpdateScheduleTimeSlot(ScheduleTimeSlot newScheduleTimeSlot)
    {
        appointmentType = newScheduleTimeSlot.appointmentType;
        dateTime = newScheduleTimeSlot.dateTime;
        duration = newScheduleTimeSlot.duration;
        dayOfWeek = newScheduleTimeSlot.dayOfWeek;
    }
    #endregion
}