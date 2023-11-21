namespace BlazorApp.Models;

public class TimeSlot
{
    public int Id { get; set; }
    public int? DoctorId { get; set; }
    public AppointmentType? AppointmentType { get; set; }
    public DateTime? Date { get; set; }
    public int? AppointmentId { get; set; }
    public Boolean? IsAvailable { get; set; }
}
