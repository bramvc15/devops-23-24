using Enums;
namespace Shared;

public class ScheduleTimeSlotDTO
{
    public AppointmentType AppointmentType { get; set; }
    public DateTime DateTime { get; set; }
    public int Duration { get; set; }
    public DayOfWeek DayOfWeek { get; set; }
}