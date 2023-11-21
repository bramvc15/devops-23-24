namespace BlazorApp.Models;

public class ScheduleTimeSlot
{
    public int Id { get; set; }
    public int DoctorId { get; set; }
    public AppointmentType AppointmentType { get; set; }
    public DateTime DateTime { get; set; }
    public int Duration { get; set; }
}