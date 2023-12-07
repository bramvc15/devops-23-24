using Ardalis.GuardClauses;

namespace Domain;

public class ScheduleTimeSlot : Entity
{
    #region Properties
    private int duration;
    private DateTime dateTime;
    private DayOfWeek dayOfWeek;

    public int Duration
    {
        get => duration;
        private set
        {
            Guard.Against.Null(value, nameof(Duration), "Duration cannot be null");
            Guard.Against.NegativeOrZero(value, nameof(Duration), "Duration cannot be less than or equal to 0");
            Guard.Against.OutOfRange(value, nameof(Duration), 1, 1440, "Duration must be between 1 and 1440 minutes");

            duration = value;
        }
    } 
    public DateTime DateTime {
        get => dateTime;
        private set => dateTime = Guard.Against.Null(value, nameof(DateTime), "DateTime cannot be null");
    }
    public DayOfWeek DayOfWeek
    {
        get => dayOfWeek;
        private set => dayOfWeek = Guard.Against.EnumOutOfRange<DayOfWeek>(value, nameof(DayOfWeek), "The given DayOfWeek does not exist");
    }
    #endregion

    #region Constructors
    // Database Constructor
    private ScheduleTimeSlot() { }

    public ScheduleTimeSlot(DateTime dateTime, int duration, DayOfWeek dayOfWeek)
    {
        DateTime = dateTime;
        Duration = duration;
        DayOfWeek = dayOfWeek;
    }
    #endregion

    #region Methods
    public void UpdateScheduleTimeSlot(DateTime dateTime, DayOfWeek dayOfWeek, int duration)
    {
        DateTime = dateTime;
        Duration = duration;
        DayOfWeek = dayOfWeek;
    }
    #endregion
}