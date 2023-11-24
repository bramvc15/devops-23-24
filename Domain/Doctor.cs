namespace Domain
{
    public class Doctor
    {
        public string Name { get; set; }
        public Gender Gender { get; set; }
        public string Specialization { get; set; }
        public string Biograph { get; set; }
        public string IsAvailable { get; set; }
        public List<TimeSlot> TimeSlots { get; set; }
        public List<ScheduleTimeSlot> ScheduleTimeSlots { get; set; }
    }

    public void IsDoctorAvailable()
    {
        throw new System.NotImplementedException();
    }

    public void HasAvailableTimeSlots()
    {
        throw new System.NotImplementedException();
    }

    public void AddScheduleTimeSlot()
    {
        throw new System.NotImplementedException();
    }

    public void UpdateScheduleTimeSlot()
    {
        throw new System.NotImplementedException();
    }

    public void DeleteScheduleTimeSlot()
    {
        throw new System.NotImplementedException();
    }

    public void AddTimeSlot()
    {
        throw new System.NotImplementedException();
    }

    public void UpdateTimeSlot()
    {
        throw new System.NotImplementedException();
    }

    public void DeleteTimeSlot()
    {
        throw new System.NotImplementedException();
    }

    public void CreateForcedAppointment()
    {
        throw new System.NotImplementedException();
    }
}