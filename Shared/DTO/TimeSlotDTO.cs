using Enums;
namespace Shared;

public class TimeSlotDTO
{
    public int? Id { get; set; }
    public AppointmentType AppointmentType { get; set; }
    public DateTime DateTime { get; set; }
    public int Duration { get; set; }
    public AppointmentDTO? AppointmentDTO { get; set; }
}