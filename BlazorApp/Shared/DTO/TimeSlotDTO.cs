namespace Domain;

public class TimeSlotDTO
{
    public AppointmentType AppointmentType { get; set; }
    public DateTime DateTime { get; set; }
    public int Duration { get; set; }
}