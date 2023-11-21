namespace BlazorApp.Models;

public class Appointment
{
    public int Id { get; set; }
    public int PatientId { get; set; }
    public string Location { get; set; }
    public int DoctorId { get; set; }
    public string Reason { get; set; }
    public string? Note { get; set; }
}
