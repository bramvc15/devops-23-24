namespace Domain;

public class ScheduleTimeSlot
{
    public AppointmentType AppointmentType { get; set; }
    public DateTime DateTime { get; set; }
    public string DayOfWeek { get; set; }
    public int Duration { get; set; }
}
