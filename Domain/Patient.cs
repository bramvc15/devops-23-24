namespace Domain;

public class Patient
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public Gender Gender { get; set; }
    public DateTime DateOfBirth { get; set; }
    public BloodType BloodType { get; set; }
    public List<Appointment> Appointments { get; set; }

    public void AddAppointment()
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