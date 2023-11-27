namespace Shared;

public class AppointmentDTO
{
    public string Reason { get; set; }
    public string Note { get; set; }
    public PatientDTO Patient { get; set; }
}