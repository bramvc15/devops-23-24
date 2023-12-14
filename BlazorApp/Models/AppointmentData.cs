using System;
using Shared.DTO.Core;

namespace BlazorApp.Models
{
    public class AppointmentData
    {
        public int Id { get; set; }
        public string Subject { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string CssClass { get; set; }
        public AppointmentDTO AppointmentDTO { get; set; }
        public TimeSlotDTO TimeSlotDTO { get; set; }
        public bool IsReadonly { get; set;}
    }
}