using Microsoft.EntityFrameworkCore;
using Shared.Enums;
using Domain;
using Shared.DTO.Core;
using Persistence.Data;

namespace Services.Core
{
    public class ScheduleTimeSlotService
    {
        private readonly DatabaseContext _DBContext;

        public ScheduleTimeSlotService(DatabaseContext databaseContext)
        {
            _DBContext = databaseContext;
        }

        public async Task<IEnumerable<ScheduleTimeSlotDTO>> GetScheduleTimeSlots(int doctorId)
        {
            var doctorEntity = await _DBContext.Doctors
                .Include(d => d.ScheduleTimeSlots)
                .FirstOrDefaultAsync(d => d.Id == doctorId);

            if (doctorEntity != null)
            {
                var scheduleTimeSlotDTOs = doctorEntity.ScheduleTimeSlots.Select(s => new ScheduleTimeSlotDTO
                {
                    Id = s.Id,
                    DateTime = s.DateTime,
                    Duration = s.Duration,
                    DayOfWeek = s.DayOfWeek,
                });

                return scheduleTimeSlotDTOs;
            }

            return Enumerable.Empty<ScheduleTimeSlotDTO>();
        }

        public async Task<ScheduleTimeSlotDTO> CreateScheduleTimeSlot(ScheduleTimeSlotDTO newSTS, int docId)
        {
            ScheduleTimeSlotDTO response = new();

            var doctorEntity = await _DBContext.Doctors
                .Include(d => d.ScheduleTimeSlots)
                .FirstOrDefaultAsync(d => d.Id == docId);

            var newDomainSTS = new ScheduleTimeSlot(newSTS.DateTime, newSTS.Duration, newSTS.DayOfWeek);

            if (doctorEntity != null)
            {
                try
                {
                    doctorEntity.AddScheduleTimeSlot(newDomainSTS);
                    await _DBContext.SaveChangesAsync();

                    response.Duration = newDomainSTS.Duration;
                    response.DayOfWeek = newDomainSTS.DayOfWeek;
                    response.DateTime = newDomainSTS.DateTime;
                    response.Id = newDomainSTS.Id;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
                return response;
            }
            else
            {
                Console.WriteLine("Can't add a ScheduleTimeSlot to a Doctor that doesn't exist in the DB");
                return response;
            }
        }

        public async Task<ScheduleTimeSlotDTO> UpdateScheduleTimeSlot(ScheduleTimeSlotDTO updatedSTS, int docId)
        {
            ScheduleTimeSlotDTO response = new();

            ScheduleTimeSlot updatedDomainSTS = new(updatedSTS.DateTime, updatedSTS.Duration, updatedSTS.DayOfWeek);

            var doctorEntity = await _DBContext.Doctors
                .Include(d => d.ScheduleTimeSlots)
                .FirstOrDefaultAsync(d => d.Id == docId);

            if (doctorEntity != null)
            {
                try
                {
                    var scheduleTimeSlotToUpdate = doctorEntity.ScheduleTimeSlots.FirstOrDefault(s => s.Id == updatedSTS.Id);

                    if (scheduleTimeSlotToUpdate != null)
                    {
                        scheduleTimeSlotToUpdate.UpdateScheduleTimeSlot(updatedDomainSTS.DateTime, updatedDomainSTS.DayOfWeek, updatedDomainSTS.Duration);

                        // check overlapping
                        doctorEntity.ScheduleTimeSlots.Remove(scheduleTimeSlotToUpdate);
                        doctorEntity.AddScheduleTimeSlot(scheduleTimeSlotToUpdate);

                        await _DBContext.SaveChangesAsync();

                        response.Id = scheduleTimeSlotToUpdate.Id;
                        response.Duration = scheduleTimeSlotToUpdate.Duration;
                        response.DayOfWeek = scheduleTimeSlotToUpdate.DayOfWeek;
                        response.DateTime = scheduleTimeSlotToUpdate.DateTime;
                    }
                    else
                    {
                        Console.WriteLine("ScheduleTimeSlot not found for the given Doctor ID");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
            else
            {
                Console.WriteLine("Can't update a ScheduleTimeSlot of a Doctor that doesn't exist in the DB");
            }

            return response;
        }

        public async Task DeleteScheduleTimeSlot(ScheduleTimeSlotDTO scheduleTimeSlotToDelete, int docId)
        {
            var doctorEntity = await _DBContext.Doctors
                .Include(d => d.ScheduleTimeSlots)
                .FirstOrDefaultAsync(d => d.Id == docId);

            if (doctorEntity != null)
            {
                var scheduleTimeSlotToRemove = doctorEntity.ScheduleTimeSlots.FirstOrDefault(s => s.Id == scheduleTimeSlotToDelete.Id);

                if (scheduleTimeSlotToRemove != null)
                {
                    doctorEntity.ScheduleTimeSlots.Remove(scheduleTimeSlotToRemove);
                    await _DBContext.SaveChangesAsync();
                }
                else
                {
                    Console.WriteLine("ScheduleTimeSlot not found for the given Doctor ID");
                }
            }
            else
            {
                Console.WriteLine("Can't delete a ScheduleTimeSlot of a Doctor that doesn't exist in the DB");
            }
        }

        public async Task ConvertScheduleToTimeSlots(DateTime startOfWeek1, int amountOfWeeks, int docId) {
            var doctorEntity = await _DBContext.Doctors
                .Include(d => d.ScheduleTimeSlots)
                .Include(d => d.TimeSlots)
                .FirstOrDefaultAsync(d => d.Id == docId);

            if (doctorEntity != null)
            {   
                doctorEntity.ConvertScheduleToTimeSlots(startOfWeek1, amountOfWeeks);
                await _DBContext.SaveChangesAsync();
            }
            else
            {
                Console.WriteLine("Can't delete a ScheduleTimeSlot of a Doctor that doesn't exist in the DB");
            }
        }
    }
}

