using Shared.Enums;
namespace Shared.DTO.Core;

public class TimeSlotDTO
{
    public int? Id { get; set; }
    public int? DoctorId { get; set; } = 0;
    public AppointmentType AppointmentType { get; set; }
    public DateTime DateTime { get; set; }
    public int Duration { get; set; }
    public AppointmentDTO? AppointmentDTO { get; set; }
}