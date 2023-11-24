namespace Domain;

public class Doctor
{
    public string Name { get; set; }
    public Gender Gender { get; set; }
    public string Specialization { get; set; }
    public string Biograph { get; set; }
    public string IsAvailable { get; set; }
    public List<TimeSlot> TimeSlots { get; set; }
    public List<ScheduleTimeSlot> ScheduleTimeSlots { get; set; }

    public void IsDoctorAvailable()
    {
        throw new NotImplementedException();
    }

    public void HasAvailableTimeSlots()
    {
        throw new NotImplementedException();
    }

    public void AddScheduleTimeSlot()
    {
        throw new NotImplementedException();
    }

    public void UpdateScheduleTimeSlot()
    {
        throw new NotImplementedException();
    }

    public void DeleteScheduleTimeSlot()
    {
        throw new NotImplementedException();
    }

    public void AddTimeSlot()
    {
        throw new NotImplementedException();
    }

    public void UpdateTimeSlot()
    {
        throw new NotImplementedException();
    }

    public void DeleteTimeSlot()
    {
        throw new NotImplementedException();
    }

    public void CreateForcedAppointment()
    {
        throw new NotImplementedException();
    }
}