using System.Runtime.CompilerServices;

namespace Domain;

public class Doctor : Entity
{
    #region Fields
    private string _name;
    private string _specialization;
    private Gender _gender;
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
    public Gender Gender {
        get
        {
            return _gender;
        }
        private set
        {
            if (!Enum.IsDefined(typeof(Gender), value))
            {
                throw new ArgumentException("Invalid gender value");
            }

            _gender = value;
        }
    }
    public string Biograph { get; private set; } = "This doctor has not written a biograph yet.";
    public bool IsAvailable { get; private set; } = true;
    #endregion

    #region Constructors
    public Doctor(string name, string specialization, Gender gender, string biograph = null) {
        if (string.IsNullOrEmpty(name))
        {
            throw new ArgumentNullException("Name cannot be empty");
        }

        if (!string.IsNullOrWhiteSpace(biograph)) {
            Biograph = biograph;
        }

        if (string.IsNullOrWhiteSpace(specialization)) {
            throw new ArgumentNullException("Specialization cannot be empty");
        }

        if (!Enum.IsDefined(typeof(Gender), gender)) {
            throw new ArgumentException("Invalid gender value");
        }

        _name = name;
        _specialization = specialization;
        _gender = gender;
    }
    #endregion

    #region Methods
    public void AddScheduleTimeSlot(ScheduleTimeSlot scheduleTimeSlot)
    {
        if (IsValidScheduleTimeSlot(scheduleTimeSlot, _scheduleTimeSlots)) {
            _scheduleTimeSlots.Add(scheduleTimeSlot);
        } 
        else
        {
            throw new ArgumentException("The given schedule time slot overlaps with a existing schedule time slot");
        }
    }

    public IEnumerable<ScheduleTimeSlot> GetScheduleTimeSlots()
    {
        return _scheduleTimeSlots;
    }

    public void UpdateScheduleTimeSlot(ScheduleTimeSlot oldScheduleTimeSlot, ScheduleTimeSlot newScheduleTimeSlot)
    {
        if (_scheduleTimeSlots.Contains(oldScheduleTimeSlot))
        {
             _scheduleTimeSlots.FirstOrDefault(oldScheduleTimeSlot).UpdateScheduleTimeSlot(newScheduleTimeSlot);
        }
        else
        { 
            throw new ArgumentException("The schedule time slot does not exist in the schedule.");
        }
    }


    public void DeleteScheduleTimeSlot(ScheduleTimeSlot scheduleTimeSlot)
    {
        _scheduleTimeSlots.Remove(scheduleTimeSlot);
    }

    public void AddTimeSlot(TimeSlot timeSlot)
    {
        if (IsValidTimeSlot(timeSlot, _timeSlots))
        {
            _timeSlots.Add(timeSlot);
        }
        else
        {
            throw new ArgumentException("The given schedule time slot overlaps with a existing schedule time slot");
        }
    }

    public IEnumerable<TimeSlot> GetTimeSlots()
    {
        return _timeSlots;
    }

    public void UpdateTimeSlot(TimeSlot oldTimeSlot, TimeSlot newTimeSlot)
    {
        if (_timeSlots.Contains(oldTimeSlot))
        {
             _timeSlots.FirstOrDefault(oldTimeSlot).UpdateTimeSlot(newTimeSlot);
        }
        else
        { 
            throw new ArgumentException("The time slot does not exist.");
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

    public void CreateAppointmentForPatient(Patient patient, TimeSlot timeSlot, string reason, string note)
    {
        if (_timeSlots.Contains(timeSlot))
        {
            if (timeSlot.IsTimeSlotAvailable())
            {
                timeSlot.CreateAppointment(patient, reason, note);
            }
            else
            {
                throw new ArgumentException("This time slot is not available.");
            }
        }
        else
        {
            throw new ArgumentException("This time slot does not exist.");
        }
    }
    #endregion

    #region ValidationMethods
    private static bool IsValidScheduleTimeSlot(ScheduleTimeSlot scheduleTimeSlot, List<ScheduleTimeSlot> li)
    {
        foreach (var existingSlot in li)
        {
            // Check for overlap: new slot start should not be between existing slot's start and end
            if (scheduleTimeSlot.DateTime >= existingSlot.DateTime &&
                scheduleTimeSlot.DateTime < existingSlot.DateTime.AddMinutes(existingSlot.Duration) && scheduleTimeSlot.DayOfWeek == existingSlot.DayOfWeek)
            {
                return false;
            }

            // Check for overlap: new slot end should not be between existing slot's start and end
            if (scheduleTimeSlot.DateTime.AddMinutes(scheduleTimeSlot.Duration) > existingSlot.DateTime &&
                scheduleTimeSlot.DateTime.AddMinutes(scheduleTimeSlot.Duration) <= existingSlot.DateTime.AddMinutes(existingSlot.Duration))
            {
                return false;
            }
        }
        return true;
    }

    private static bool IsValidTimeSlot(TimeSlot timeSlot, List<TimeSlot> li)
    {
        foreach (var existingSlot in li)
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