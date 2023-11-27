namespace Shared;

public class AppointmentDTO
{
    public DateTime DateTime { get; set; }
    public string NameDoctor { get; set; }
    public string Reason { get; set; }
    public string Note { get; set; }
    public PatientDTO Patient { get; set; }
}