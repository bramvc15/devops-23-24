namespace Domain;

public class TimeSlot
{
    public DateTime DateTime { get; set; }
    public int Duration { get; set; }
    public AppointmentType AppointmentType { get; set; }
    public Appointment Appointment { get; set; }

    public Boolean IsTimeSlotAvailable()
    {
        throw new NotImplementedException();
    }

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