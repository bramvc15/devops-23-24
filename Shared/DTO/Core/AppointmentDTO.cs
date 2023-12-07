namespace Shared.DTO.Core;

public class AppointmentDTO
{
    public int? Id { get; set; }
    public string Reason { get; set; }
    public string Note { get; set; }
    public PatientDTO PatientDTO { get; set; }
}