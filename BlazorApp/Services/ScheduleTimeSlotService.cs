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

        public async Task<IEnumerable<ScheduleTimeSlot>> GetContent()
        {
            return await _ctx.ScheduleTimeSlots.ToListAsync();
        }

        public void UpdateScheduleTimeSlot(int Id, int Doctor_Id, string ScheduleGroup, DateTime DateTime, int Duration)
        {
            ScheduleTimeSlot scheduleTimeSlot = _ctx.ScheduleTimeSlots.Find(Id);
            scheduleTimeSlot.Doctor_Id = Doctor_Id;
            scheduleTimeSlot.ScheduleGroup = ScheduleGroup;
            scheduleTimeSlot.DateTime = DateTime;
            scheduleTimeSlot.Duration = Duration;
            _ctx.ScheduleTimeSlots.Update(scheduleTimeSlot);
            _ctx.SaveChanges();
        }
    }
}