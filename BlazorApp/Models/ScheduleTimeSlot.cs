namespace BlazorApp.Models
{
    public class ScheduleTimeSlot
    {
        public int Id { get; set; }
        public int Doctor_Id { get; set; }
        public string? ScheduleGroup { get; set; }
        public DateTime? DateTime { get; set; }
        public string? Duration { get; set; }
    }
}