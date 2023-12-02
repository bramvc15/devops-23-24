using Ardalis.GuardClauses;
using Shared.Enums;
namespace Domain;

public class TimeSlot : Entity
{
    #region Properties
    private int duration;
    private AppointmentType appointmentType;
    private DateTime dateTime;
    private Appointment appointment;

    public int Duration {
        get => duration;
        private set
        {
            Guard.Against.Null(value, nameof(Duration), "Duration cannot be null");
            Guard.Against.NegativeOrZero(value, nameof(Duration), "Duration cannot be less than or equal to 0");
            Guard.Against.OutOfRange(value, nameof(Duration), 1, 1440, "Duration must be between 1 and 1440 minutes");

            duration = value;
        }
    }
    public AppointmentType AppointmentType
    {
        get => appointmentType;
        private set => appointmentType = Guard.Against.EnumOutOfRange<AppointmentType>(value, nameof(AppointmentType), "Invalid AppointmentType");
    }
    public DateTime DateTime
    {
        get => dateTime;
        private set
        {
            Guard.Against.Null(value, nameof(DateTime), "DateTime cannot be null");
            Guard.Against.Default(value, nameof(DateTime), "DateTime cannot be the default value");
            Guard.Against.OutOfRange(value, nameof(DateTime), DateTime.MinValue, DateTime.Now, "DateTime cannot be in the past");

            dateTime = value;
        }
    }
    public Appointment Appointment { 
        get => appointment;
    }
    #endregion

    #region Constructors
    // Database Constructor
    private TimeSlot() { }

    public TimeSlot(AppointmentType appointmentType, DateTime dateTime, int duration)
    {
        AppointmentType = appointmentType;
        DateTime = dateTime;
        Duration = duration;
        //Appointment = null;
    }
    #endregion

    #region Methods
    public bool IsTimeSlotAvailable()
    {
        // Useless?
        return Appointment == null;
    }

    public Appointment CreateAppointment(Patient patient, string reason, string note)
    {
        appointment = new Appointment(patient, reason, note);
        return appointment;
    }

    public void UpdateAppointment(Appointment newAppointment)
    {
        appointment = newAppointment;
    }

    public void DeleteAppointment()
    {
        if (appointment == null) throw new ArgumentException("Appointment does not exist");
        appointment = null;
    }

    public void UpdateTimeSlot(TimeSlot newTimeSlot)
    {
        AppointmentType = newTimeSlot.AppointmentType;
        DateTime = newTimeSlot.DateTime;
        Duration = newTimeSlot.Duration;
    }
    #endregion
}