using Shared.Enums;
namespace Shared.DTO.Core;

public class ScheduleTimeSlotDTO
{
    public int? Id { get; set; }
    public DateTime DateTime { get; set; }
    public int Duration { get; set; }
    public DayOfWeek DayOfWeek { get; set; }
}