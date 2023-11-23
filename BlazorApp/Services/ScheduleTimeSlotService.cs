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

        public async Task<ScheduleTimeSlot> GetScheduleTimeSlotById(int id)
        {
            return await _ctx.ScheduleTimeSlots.FindAsync(id);
        }

        public async Task<List<ScheduleTimeSlot>> GetScheduleTimeSlotsByDoctorId(int DoctorId)
        {
            return await _ctx.ScheduleTimeSlots.Where(x => x.DoctorId == DoctorId).ToListAsync();
        }

        public async Task<ScheduleTimeSlot> AddScheduleTimeSlot(int DoctorId, AppointmentType AppointmentType, string DayOfWeek, DateTime DateTime, int Duration)
        {
            // check if new ScheduleTimeSlot doesn't have any conflicts with existing ScheduleTimeSlots
            var ScheduleTimeSlots = await _ctx.ScheduleTimeSlots.Where(x => x.DoctorId == DoctorId).ToListAsync();
            foreach (var ScheduleTimeSlot in ScheduleTimeSlots)
            {
                if (ScheduleTimeSlot.DayOfWeek == DayOfWeek)
                {
                    // StartTime in minutes
                    var ScheduleTimeSlotStart = (ScheduleTimeSlot.DateTime.Hour * 60) + ScheduleTimeSlot.DateTime.Minute;
                    // EndTime in minutes
                    var ScheduleTimeSlotEnd = (ScheduleTimeSlot.DateTime.Hour * 60) + ScheduleTimeSlot.DateTime.Minute + ScheduleTimeSlot.Duration;

                    // Check if StartTime of ScheduleTimeSlot is in the same time interval
                    if ((DateTime.Hour * 60 + DateTime.Minute) > ScheduleTimeSlotStart && (DateTime.Hour * 60 + DateTime.Minute) < ScheduleTimeSlotEnd)
                    {
                        throw new InvalidOperationException("Gepland tijdslot valt in hetzelfde tijdsinterval als een bestaand gepland tijdslot 1");
                    }

                    // Check if EndTime of ScheduleTimeSlot is in the same time interval
                    if ((DateTime.Hour * 60 + DateTime.Minute + Duration) > ScheduleTimeSlotStart && (DateTime.Hour * 60 + DateTime.Minute + Duration) < ScheduleTimeSlotEnd)
                    {
                        throw new InvalidOperationException("Gepland tijdslot valt in hetzelfde tijdsinterval als een bestaand gepland tijdslot 2");
                    }
                }
            }

            var NewScheduleTimeSlot = new ScheduleTimeSlot
            {
                DoctorId = DoctorId,
                AppointmentType = AppointmentType,
                DayOfWeek = DayOfWeek,
                DateTime = DateTime,
                Duration = Duration
            };

            _ctx.ScheduleTimeSlots.Add(NewScheduleTimeSlot);
            await _ctx.SaveChangesAsync();
            return NewScheduleTimeSlot;
        }

        public async Task<ScheduleTimeSlot> UpdateScheduleTimeSlot(int Id, int DoctorId, AppointmentType AppointmentType, string DayOfWeek, DateTime DateTime, int Duration)
        {
            var UpdatedScheduleTimeSlot = new ScheduleTimeSlot
            {
                Id = Id,
                DoctorId = DoctorId,
                AppointmentType = AppointmentType,
                DayOfWeek = DayOfWeek,
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

