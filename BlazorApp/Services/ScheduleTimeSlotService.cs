using BlazorApp.Data;
using BlazorApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp.Services
{
    public class ScheduleTimeSlotService
    {
        private readonly DatabaseContext _ctx;

        public ScheduleTimeSlotService(DatabaseContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<List<ScheduleTimeSlot>> GetScheduleTimeSlots()
        {
            return await _ctx.ScheduleTimeSlots.ToListAsync();
        }

        public async Task<ScheduleTimeSlot> GetScheduleTimeSlot(int id)
        {
            return await _ctx.ScheduleTimeSlots.FindAsync(id);
        }

        public async Task<ScheduleTimeSlot> AddScheduleTimeSlot(int Id, int DoctorId, AppointmentType AppointmentType, DateTime DateTime, int Duration)
        {
            var NewScheduleTimeSlot = new ScheduleTimeSlot
            {
                Id = Id,
                DoctorId = DoctorId,
                AppointmentType = AppointmentType,
                DateTime = DateTime,
                Duration = Duration
            };

            _ctx.ScheduleTimeSlots.Add(NewScheduleTimeSlot);
            await _ctx.SaveChangesAsync();
            return NewScheduleTimeSlot;
        }

        public async Task<ScheduleTimeSlot> UpdateScheduleTimeSlot(int Id, int DoctorId, AppointmentType AppointmentType, DateTime DateTime, int Duration)
        {
            var UpdatedScheduleTimeSlot = new ScheduleTimeSlot
            {
                Id = Id,
                DoctorId = DoctorId,
                AppointmentType = AppointmentType,
                DateTime = DateTime,
                Duration = Duration
            };

            _ctx.ScheduleTimeSlots.Update(UpdatedScheduleTimeSlot);
            await _ctx.SaveChangesAsync();
            return UpdatedScheduleTimeSlot;
        }

        public async Task<ScheduleTimeSlot> DeleteScheduleTimeSlot(int id)
        {
            var ScheduleTimeSlot = await _ctx.ScheduleTimeSlots.FindAsync(id);
            _ctx.ScheduleTimeSlots.Remove(ScheduleTimeSlot);
            await _ctx.SaveChangesAsync();
            return ScheduleTimeSlot;
        }
    }
}

