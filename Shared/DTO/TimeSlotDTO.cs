using Enums;
namespace Shared;

public class TimeSlotDTO
{
    public AppointmentType AppointmentType { get; set; }
    public DateTime DateTime { get; set; }
    public int Duration { get; set; }
    public string NameDoctor { get; set; }
}