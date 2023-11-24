namespace Domain;

public class Appointment
{
    public string? Reason { get; set; }
    public string? Note { get; set; }
    public Patient Patient { get; set; }

    public void CreateAppointment()
    {
        throw new NotImplementedException();
    }

    public void UpdateAppointment()
    {
        throw new NotImplementedException();
    }

    public void DeleteAppointment()
    {
        throw new NotImplementedException();
    }
}