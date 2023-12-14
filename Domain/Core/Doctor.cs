using Ardalis.GuardClauses;
using Shared.Enums;

namespace Domain;

public class Doctor : Entity
{
    #region Properties
    private string name;
    private string specialization;
    private Gender gender;
    public string Name
    {
        get => name;
        private set => name = Guard.Against.NullOrWhiteSpace(value, nameof(Name));
    }
    public string Specialization
    {
        get => specialization;
        private set => specialization = Guard.Against.NullOrWhiteSpace(value, nameof(Specialization));
    }
    public Gender Gender
    {
        get => gender;
        private set => gender = Guard.Against.EnumOutOfRange(value, nameof(Gender));
    }
    public string? Biograph { get; private set; }
    public bool IsAvailable { get; set; } = true;
    public string ImageLink { get; set; } = string.Empty;
    public string Auth0Id { get; set; } = string.Empty;
    public List<ScheduleTimeSlot> ScheduleTimeSlots { get; set; }
    public List<TimeSlot> TimeSlots { get; set; }
    #endregion

    #region Constructors
    // Database Constructor
    private Doctor() { }

    public Doctor(string name, string specialization, Gender gender, string? biograph = default)
    {
        Name = name;
        Specialization = specialization;
        Gender = gender;
        Biograph = biograph;
        ScheduleTimeSlots = new List<ScheduleTimeSlot>();
        TimeSlots = new List<TimeSlot>();
    }
    #endregion

    #region Methods
    public void UpdateDoctor(string name, string specialization, Gender gender, string? biograph)
    {
        Name = name;
        Specialization = specialization;
        Gender = gender;
        Biograph = biograph;
    }

    public void AddScheduleTimeSlot(ScheduleTimeSlot scheduleTimeSlot)
    {
        if (IsValidScheduleTimeSlot(scheduleTimeSlot))
        {
            ScheduleTimeSlots.Add(scheduleTimeSlot);
        }
        else
        {
            throw new ArgumentException("The given scheduletimeslot overlaps with a existing scheduletimeslot");
        }
    }

    public void AddTimeSlot(TimeSlot timeSlot)
    {
        if (IsValidTimeSlot(timeSlot))
        {
            TimeSlots.Add(timeSlot);
        }
        else
        {
            throw new ArgumentException("The given timeslot overlaps with a existing timeslot");
        }
    }

    public void UpdateScheduleTimeSlot(ScheduleTimeSlot scheduleTimeSlot, DateTime dateTime, int duration, DayOfWeek dayOfWeek)
    {
        if (ScheduleTimeSlots.Contains(scheduleTimeSlot))
        {
            ScheduleTimeSlots.Remove(scheduleTimeSlot);
            scheduleTimeSlot.UpdateScheduleTimeSlot(dateTime, dayOfWeek, duration);

            AddScheduleTimeSlot(scheduleTimeSlot);
        }
        else
        {
            throw new ArgumentException("The scheduletimeslot does not exist in the schedule of this doctor.");
        }
    }

    public void UpdateTimeSlot(TimeSlot timeSlot, AppointmentType appointmentType, DateTime dateTime, int duration)
    {
        if (TimeSlots.Contains(timeSlot))
        {
            TimeSlots.Remove(timeSlot);
            timeSlot.UpdateTimeSlot(appointmentType, dateTime, duration);

            AddTimeSlot(timeSlot);
        }
        else
        {
            throw new ArgumentException("The timeslot does not exist for this doctor.");
        }
    }

    public Appointment CreateAppointment(Patient patient, TimeSlot timeSlot, string reason, string note)
    {
        if (TimeSlots.Contains(timeSlot))
        {
            if (IsAvailable == true && timeSlot.Appointment == null)
            {
                return TimeSlots.FirstOrDefault(timeSlot).CreateAppointment(patient, reason, note);
            }
            else
            {
                throw new ArgumentException("This timeslot is not available.");
            }
        }
        else
        {
            throw new ArgumentException("This timeslot does not exist for this doctor.");
        }
    }

    public void UpdateAppointment(TimeSlot timeSlot, string reason, string note)
    {
        if (TimeSlots.Contains(timeSlot))
        {
            if (timeSlot.Appointment != null)
            {
                TimeSlots.FirstOrDefault(timeSlot).Appointment.UpdateAppointment(reason, note);
            }
            else
            {
                throw new ArgumentException("This timeslot has no appointment.");
            }
        }
        else
        {
            throw new ArgumentException("This timeslot does not exist for this doctor.");
        }
    }

    public void DeleteAppointment(TimeSlot timeSlot)
    {
        if (TimeSlots.Contains(timeSlot))
        {
            if (timeSlot.Appointment != null)
            {
                TimeSlots.FirstOrDefault(timeSlot).Appointment = null;
            }
            else
            {
                throw new ArgumentException("This timeslot has no appointment.");
            }
        }
        else
        {
            throw new ArgumentException("This timeslot does not exist for this doctor.");
        }
    }

    public void ConvertScheduleToTimeSlots(DateTime startOfWeek1, int amountOfWeeks)
    {
        var start = startOfWeek1.Date;
        var timeSlotsToAdd = new List<TimeSlot>();

        for (int i = 0; i < amountOfWeeks; i++)
        {
            foreach (var scheduleTimeSlot in ScheduleTimeSlots)
            {
                DateTime date = start.Date;
                double hour = scheduleTimeSlot.DateTime.Hour;
                double minutes = scheduleTimeSlot.DateTime.Minute;
                double seconds = scheduleTimeSlot.DateTime.Second;

                if (scheduleTimeSlot.DayOfWeek == DayOfWeek.Monday) { date = date.AddDays(0); }
                if (scheduleTimeSlot.DayOfWeek == DayOfWeek.Tuesday) { date = date.AddDays(1); }
                if (scheduleTimeSlot.DayOfWeek == DayOfWeek.Wednesday) { date = date.AddDays(2); }
                if (scheduleTimeSlot.DayOfWeek == DayOfWeek.Thursday) { date = date.AddDays(3); }
                if (scheduleTimeSlot.DayOfWeek == DayOfWeek.Friday) { date = date.AddDays(4); }
                if (scheduleTimeSlot.DayOfWeek == DayOfWeek.Saturday) { date = date.AddDays(5); }
                if (scheduleTimeSlot.DayOfWeek == DayOfWeek.Sunday) { date = date.AddDays(6); }

                date = date.AddHours(hour);
                date = date.AddMinutes(minutes);
                date = date.AddSeconds(seconds);

                TimeSlot newTimeSlot = new TimeSlot(AppointmentType.Consultation, date, scheduleTimeSlot.Duration);
                if (IsValidTimeSlot(newTimeSlot))
                {
                    timeSlotsToAdd.Add(newTimeSlot);
                }
                else
                {
                    throw new InvalidOperationException("One of the given timeslots overlaps with a existing timeslot");
                }
            }

            // Move to the next week
            start = start.AddDays(7).Date;
        }

        foreach(var timeSlot in timeSlotsToAdd)
        {
            TimeSlots.Add(timeSlot);
        }
    }

    public bool HasAvailableTimeSlots()
    {
        foreach (var timeSlot in TimeSlots)
        {
            if (timeSlot.Appointment == null)
            {
                return true;
            }
        }
        return false;
    }
    #endregion

    #region ValidationMethods
    private bool IsValidScheduleTimeSlot(ScheduleTimeSlot scheduleTimeSlot)
    {
        foreach (var existingSlot in ScheduleTimeSlots)
        {
            // Check for overlap: new slot start should not be between existing slot's start and end
            if (scheduleTimeSlot.DateTime >= existingSlot.DateTime &&
                scheduleTimeSlot.DateTime < existingSlot.DateTime.AddMinutes(existingSlot.Duration) && scheduleTimeSlot.DayOfWeek == existingSlot.DayOfWeek)
            {
                return false;
            }

            // Check for overlap: new slot end should not be between existing slot's start and end
            if (scheduleTimeSlot.DateTime.AddMinutes(scheduleTimeSlot.Duration) > existingSlot.DateTime &&
                scheduleTimeSlot.DateTime.AddMinutes(scheduleTimeSlot.Duration) <= existingSlot.DateTime.AddMinutes(existingSlot.Duration) && scheduleTimeSlot.DayOfWeek == existingSlot.DayOfWeek)
            {
                return false;
            }
        }
        return true;
    }

    private bool IsValidTimeSlot(TimeSlot timeSlot)
    {
        foreach (var existingSlot in TimeSlots)
        {
            // Check for overlap: new slot start should not be between existing slot's start and end
            if (timeSlot.DateTime >= existingSlot.DateTime &&
                timeSlot.DateTime < existingSlot.DateTime.AddMinutes(existingSlot.Duration))
            {
                return false;
            }

            // Check for overlap: new slot end should not be between existing slot's start and end
            if (timeSlot.DateTime.AddMinutes(timeSlot.Duration) > existingSlot.DateTime &&
                timeSlot.DateTime.AddMinutes(timeSlot.Duration) <= existingSlot.DateTime.AddMinutes(existingSlot.Duration))
            {
                return false;
            }
        }
        return true;
    }
    #endregion
}