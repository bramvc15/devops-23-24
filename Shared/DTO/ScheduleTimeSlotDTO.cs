using Enums;
namespace Shared;

public class ScheduleTimeSlotDTO
{
    public int? Id { get; set; }
    public AppointmentType AppointmentType { get; set; }
    public DateTime DateTime { get; set; }
    public int Duration { get; set; }
    public DayOfWeek DayOfWeek { get; set; }
    public string NameDoctor { get; set; }
}