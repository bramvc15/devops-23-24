using BlazorApp.Data;
using BlazorApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp.Services
{
    public class AppointmentTimeSlotService
    {
        private readonly DatabaseContext _ctx;

        public AppointmentTimeSlotService(DatabaseContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<IEnumerable<AppointmentTimeSlot>> GetContent()
        {
            return await _ctx.AppointmentTimeSlots.ToListAsync();
        }

        public void UpdateAppointmentTimeSlot(int Id, int Doctor_Id, int Patient_Id, DateTime DateTime, int Duration)
        {
            AppointmentTimeSlot appointmentTimeSlot = _ctx.AppointmentTimeSlots.Find(Id);
            appointmentTimeSlot.Doctor_Id = Doctor_Id;
            appointmentTimeSlot.Patient_Id = Patient_Id;
            appointmentTimeSlot.DateTime = DateTime;
            appointmentTimeSlot.Duration = Duration;
            _ctx.AppointmentTimeSlots.Update(appointmentTimeSlot);
            _ctx.SaveChanges();
        }
    }
}