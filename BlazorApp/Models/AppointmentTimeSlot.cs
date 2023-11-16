namespace BlazorApp.Models
{
    public class AppointmentTimeSlot
    {
        public int Id { get; set; }
        public int Doctor_Id { get; set; }
        public int Patient_Id { get; set; }
        public DateTime? DateTime { get; set; }
        public int? Duration { get; set; }
    }
}