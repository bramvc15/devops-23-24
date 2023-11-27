using BlazorApp.Data;
using BlazorApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp.Services.Core
{
    public class TimeSlotService
    {
        private readonly DatabaseContext _ctx;

        public TimeSlotService(DatabaseContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<IEnumerable<TimeSlot>> GetTimeSlots()
        {
            return await _ctx.TimeSlots.ToListAsync();
        }

        public async Task<TimeSlot> GetTimeSlotById(int id)
        {
            var TimeSlot = await _ctx.TimeSlots.FindAsync(id);

            if (TimeSlot == null)
            {
                throw new InvalidOperationException($"There is no TimeSlot with id '{id}'");
            }

            return TimeSlot;
        }

        public async Task<TimeSlot> AddTimeSlot(TimeSlot timeSlot)
        {
            var NewTimeSlot = new TimeSlot
            {
                DoctorId = timeSlot.DoctorId,
                AppointmentType = timeSlot.AppointmentType,
                Date = timeSlot.Date,
                AppointmentId = timeSlot.AppointmentId,
                IsAvailable = timeSlot.IsAvailable


            };

            _ctx.TimeSlots.Add(NewTimeSlot);
            await _ctx.SaveChangesAsync();
            return NewTimeSlot;
        }

        public void UpdateTimeSlot(int id, TimeSlot timeSlot)
        {
            if (timeSlot == null)
            {
                throw new InvalidOperationException($"The timeSlot is null");
            }
            var existingTimeSlot = _ctx.TimeSlots.Find(id);
            if (existingTimeSlot == null)
            {
                throw new InvalidOperationException($"There is no appointment with id '{id}'");
            }

            existingTimeSlot.DoctorId = timeSlot.DoctorId;
            existingTimeSlot.AppointmentType = timeSlot.AppointmentType;
            existingTimeSlot.Date = timeSlot.Date;
            existingTimeSlot.AppointmentId = timeSlot.AppointmentId;
            existingTimeSlot.IsAvailable = timeSlot.IsAvailable;
            _ctx.SaveChangesAsync();
        }

        public async Task<TimeSlot> DeleteTimeSlot(int Id)
        {
            try
            {
                var timeSlot = await _ctx.TimeSlots.FindAsync(Id);

                if (timeSlot != null)
                {
                    _ctx.TimeSlots.Remove(timeSlot);
                    await _ctx.SaveChangesAsync();  // Make sure to await SaveChangesAsync
                }
                else
                {
                    // Log or handle the case where the entity with the given Id doesn't exist
                    Console.WriteLine($"TimeSlot with Id '{Id}' not found.");
                }

                return timeSlot; // This might be null, handle it appropriately in your calling code
            }
            catch (Exception ex)
            {
                // Log the exception for debugging purposes
                Console.WriteLine($"Error in DeleteTimeSlot: {ex.Message}");
                throw; // Rethrow the exception
            }
        }

    }
}