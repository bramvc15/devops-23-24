using BlazorApp.Data;
using Microsoft.EntityFrameworkCore;
using Shared;
using Domain;

namespace Services.Core
{
    public class ScheduleTimeSlotService
    {
        private readonly DatabaseContext _DBContext;

        public ScheduleTimeSlotService(DatabaseContext databaseContext)
        {
            _DBContext = databaseContext;
        }

        public async Task<IEnumerable<ScheduleTimeSlotDTO>> GetScheduleTimeSlots(DoctorDTO doctor)
        {
            var doctorEntity = await _DBContext.Doctors
                .Include(d => d.ScheduleTimeSlots)
                .FirstOrDefaultAsync(d => d.Id == doctor.Id);

            if (doctorEntity != null)
            {
                var scheduleTimeSlotDTOs = doctorEntity.ScheduleTimeSlots.Select(s => new ScheduleTimeSlotDTO
                {
                    Id = s.Id,
                    AppointmentType = (Enums.AppointmentType) s.AppointmentType,
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
            ScheduleTimeSlotDTO response = new ScheduleTimeSlotDTO();

            var doctorEntity = await _DBContext.Doctors
                .Include(d => d.ScheduleTimeSlots)
                .FirstOrDefaultAsync(d => d.Id == docId);

            var newDomainSTS = new ScheduleTimeSlot((Domain.AppointmentType)newSTS.AppointmentType, newSTS.DateTime, newSTS.Duration, newSTS.DayOfWeek);

            if (doctorEntity != null)
            {
                try
                {
                    doctorEntity.AddScheduleTimeSlot(newDomainSTS);
                    await _DBContext.SaveChangesAsync();

                    response.Duration = newDomainSTS.Duration;
                    response.DayOfWeek = newDomainSTS.DayOfWeek;
                    response.AppointmentType = (Enums.AppointmentType)newDomainSTS.AppointmentType;
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
            ScheduleTimeSlotDTO response = new ScheduleTimeSlotDTO();

            ScheduleTimeSlot updatedDomainSTS = new ScheduleTimeSlot((Domain.AppointmentType) updatedSTS.AppointmentType, updatedSTS.DateTime, updatedSTS.Duration, updatedSTS.DayOfWeek);

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
                        scheduleTimeSlotToUpdate.UpdateScheduleTimeSlot(updatedDomainSTS);

                        // check overlapping
                        doctorEntity.DeleteScheduleTimeSlot(scheduleTimeSlotToUpdate);
                        doctorEntity.AddScheduleTimeSlot(scheduleTimeSlotToUpdate);

                        await _DBContext.SaveChangesAsync();

                        response.Id = scheduleTimeSlotToUpdate.Id;
                        response.Duration = scheduleTimeSlotToUpdate.Duration;
                        response.DayOfWeek = scheduleTimeSlotToUpdate.DayOfWeek;
                        response.AppointmentType = (Enums.AppointmentType) scheduleTimeSlotToUpdate.AppointmentType;
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
                    doctorEntity.DeleteScheduleTimeSlot(scheduleTimeSlotToRemove);
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
    }
}

