namespace Domain;

public class Doctor
{
    #region Fields
    private string _name;
    private string _specialization;
    private readonly List<TimeSlot> _timeSlots = new();
    private readonly List<ScheduleTimeSlot> _scheduleTimeSlots = new();
    #endregion

    #region Properties
    public string Name {
        get 
        {
            return _name;
        }
        private set
        { 
            if(string.IsNullOrWhiteSpace(value)) throw new ArgumentNullException("Name cannot be empty"); 
            _name = value;
        }
    }
    public string Specialization {
        get 
        { 
            return _specialization;
        }
        private set
        { 
            if(string.IsNullOrWhiteSpace(value)) throw new ArgumentNullException("Specialization cannot be empty"); 
            _specialization = value;
        }
    }
    public Gender Gender { get; private set; }
    public string Biograph { get; private set; } = "This doctor has not written a biograph yet.";
    public bool IsAvailable { get; private set; } = true;
    #endregion

    #region Constructors
    public Doctor(string name, string specialization, Gender gender, string biograph = null) {
        Name = name;
        Specialization = specialization;
        Gender = gender;

        if (!string.IsNullOrWhiteSpace(biograph)) {
            Biograph = biograph;
        }
    }
    #endregion

    #region Methods
    public void AddScheduleTimeSlot(ScheduleTimeSlot scheduleTimeSlot)
    {
        _scheduleTimeSlots.Add(scheduleTimeSlot);
    }

    public IEnumerable<ScheduleTimeSlot> GetScheduleTimeSlots()
    {
        return _scheduleTimeSlots;
    }

    public void UpdateScheduleTimeSlot(ScheduleTimeSlot scheduleTimeSlot)
    {
        ScheduleTimeSlot existingTimeSlot = _scheduleTimeSlots.FirstOrDefault(t => t.DayOfWeek == scheduleTimeSlot.DayOfWeek && t.DateTime == scheduleTimeSlot.DateTime);

        if (existingTimeSlot != null)
        {
/*            existingTimeSlot.AppointmentType = scheduleTimeSlot.AppointmentType;
            existingTimeSlot.DateTime = scheduleTimeSlot.DateTime;
            existingTimeSlot.Duration = scheduleTimeSlot.Duration;
            existingTimeSlot.DayOfWeek = scheduleTimeSlot.DayOfWeek;*/
        }
        else
        {
            throw new ArgumentException("Specified time slot not found in the schedule.");
        }
    }


    public void DeleteScheduleTimeSlot(ScheduleTimeSlot scheduleTimeSlot)
    {
        _scheduleTimeSlots.Remove(scheduleTimeSlot);
    }

    public void AddTimeSlot(TimeSlot timeSlot)
    {
        _timeSlots.Add(timeSlot);
    }

    public IEnumerable<TimeSlot> GetTimeSlots()
    {
        return _timeSlots;
    }

    public void UpdateTimeSlot(TimeSlot timeSlot)
    {
        TimeSlot existingTimeSlot = _timeSlots.FirstOrDefault(t => t.DateTime == timeSlot.DateTime);

        if (existingTimeSlot != null)
        {
/*            existingTimeSlot.AppointmentType = timeSlot.AppointmentType;
            existingTimeSlot.Duration = timeSlot.Duration;
            existingTimeSlot.DateTime = timeSlot.DateTime;*/
        }
        else
        {
            throw new ArgumentException("Specified time slot not found in the schedule.");
        }
    }

    public void DeleteTimeSlot(TimeSlot timeSlot)
    {
        _timeSlots.Remove(timeSlot);
    }

    public bool IsDoctorAvailable()
    {
        if (IsAvailable) return true;
        else return false;
    }

    public bool HasAvailableTimeSlots()
    {
        foreach (var timeSlot in _timeSlots) 
        {
            if (timeSlot.IsTimeSlotAvailable())
            {
                return true;
            }
        }
        return false;
    }

    public void CreateForcedAppointment()
    {
        // to be implemented
    }
    #endregion
}