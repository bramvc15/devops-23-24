using Microsoft.EntityFrameworkCore;
using Shared.Enums;
using Domain;
using Shared.DTO.Core;
using Persistence.Data;

namespace Services.Core
{
    public class TimeSlotService
    {
        private readonly DatabaseContext _DBContext;

        public TimeSlotService(DatabaseContext databaseContext)
        {
            _DBContext = databaseContext;
        }

        public async Task<IEnumerable<TimeSlotDTO>> GetTimeSlots(int docId)
        {
            var doctorEntity = await _DBContext.Doctors
                .Include(d => d.TimeSlots)
                    .ThenInclude(ts => ts.Appointment)
                        .ThenInclude(a => a.Patient)
                .FirstOrDefaultAsync(d => d.Id == docId);

            if (doctorEntity != null)
            {
                var timeSlotDTOs = doctorEntity.TimeSlots.Select(ts => new TimeSlotDTO
                {
                    Id = ts.Id,
                    DoctorId = docId,
                    AppointmentType = ts.AppointmentType,
                    DateTime = ts.DateTime,
                    Duration = ts.Duration,
                    AppointmentDTO = ts.Appointment != null ? new AppointmentDTO
                    {
                        Id = ts.Appointment.Id,
                        Reason = ts.Appointment.Reason,
                        Note = ts.Appointment.Note,
                        PatientDTO = new PatientDTO
                        {
                            Id = ts.Appointment.Patient.Id,
                            Name = ts.Appointment.Patient.Name,
                            Email = ts.Appointment.Patient.Email,
                            PhoneNumber = ts.Appointment.Patient.PhoneNumber,
                            DateOfBirth = ts.Appointment.Patient.DateOfBirth,
                            Gender = ts.Appointment.Patient.Gender,
                            BloodType = ts.Appointment.Patient.BloodType,
                        }
                    } : null
                }) ;

                return timeSlotDTOs;
            }
            else
            {
                Console.WriteLine("Can't get TimeSlots of a Doctor that doesn't exist in the DB");
            }

            return Enumerable.Empty<TimeSlotDTO>();
        }

        public async Task<TimeSlotDTO> CreateTimeSlot(TimeSlotDTO timeSlot, int docId)
        {
            TimeSlotDTO response = new();

            var doctorEntity = await _DBContext.Doctors
                .Include(d => d.TimeSlots)
                .FirstOrDefaultAsync(d => d.Id == docId);

            var newDomainTS = new TimeSlot(timeSlot.AppointmentType, timeSlot.DateTime, timeSlot.Duration);

            if (doctorEntity != null)
            {
                try
                {
                    doctorEntity.AddTimeSlot(newDomainTS);
                    await _DBContext.SaveChangesAsync();

                    response.Duration = newDomainTS.Duration;
                    response.AppointmentType = newDomainTS.AppointmentType;
                    response.DateTime = newDomainTS.DateTime;
                    response.Id = newDomainTS.Id;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
                return response;
            }
            else
            {
                Console.WriteLine("Can't add a TimeSlot to a Doctor that doesn't exist in the DB");
                return response;
            }
        }

        public async Task<TimeSlotDTO> UpdateTimeSlot(TimeSlotDTO updatedTimeSlot, int docId)
        {
            TimeSlotDTO response = new();

            TimeSlot updatedDomainTimeSlot = new(updatedTimeSlot.AppointmentType, updatedTimeSlot.DateTime, updatedTimeSlot.Duration);

            var doctorEntity = await _DBContext.Doctors
                .Include(d => d.TimeSlots)
                    .ThenInclude(ts => ts.Appointment)
                        .ThenInclude(a => a.Patient)
                .FirstOrDefaultAsync(d => d.Id == docId);

            if (doctorEntity != null)
            {
                try
                {
                    var timeSlotToUpdate = doctorEntity.TimeSlots.FirstOrDefault(s => s.Id == updatedTimeSlot.Id);

                    if (timeSlotToUpdate != null)
                    {
                        timeSlotToUpdate.UpdateTimeSlot(updatedDomainTimeSlot.AppointmentType, updatedDomainTimeSlot.DateTime, updatedDomainTimeSlot.Duration);

                        // check overlapping
                        doctorEntity.TimeSlots.Remove(timeSlotToUpdate);
                        doctorEntity.AddTimeSlot(timeSlotToUpdate);

                        await _DBContext.SaveChangesAsync();

                        response.Id = timeSlotToUpdate.Id;
                        response.Duration = timeSlotToUpdate.Duration;
                        response.AppointmentType = (AppointmentType)timeSlotToUpdate.AppointmentType;
                        response.DateTime = timeSlotToUpdate.DateTime;
                        response.AppointmentDTO = timeSlotToUpdate.Appointment != null ? new AppointmentDTO
                        {
                            Id = timeSlotToUpdate.Appointment.Id,
                            Reason = timeSlotToUpdate.Appointment.Reason,
                            Note = timeSlotToUpdate.Appointment.Note,
                            PatientDTO = new PatientDTO
                            {
                                Id = timeSlotToUpdate.Appointment.Patient.Id,
                                Name = timeSlotToUpdate.Appointment.Patient.Name,
                                Email = timeSlotToUpdate.Appointment.Patient.Email,
                                PhoneNumber = timeSlotToUpdate.Appointment.Patient.PhoneNumber,
                                DateOfBirth = timeSlotToUpdate.Appointment.Patient.DateOfBirth,
                                Gender = (Gender)timeSlotToUpdate.Appointment.Patient.Gender,
                                BloodType = (BloodType)timeSlotToUpdate.Appointment.Patient.BloodType,
                            }
                        } : null;

                    }
                    else
                    {
                        Console.WriteLine("TimeSlot not found for the given Doctor ID");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
            else
            {
                Console.WriteLine("Can't update a TimeSlot of a Doctor that doesn't exist in the DB");
            }

            return response;
        }

        public async Task DeleteTimeSlot(TimeSlotDTO timeSlotToDelete, int docId)
        {
            var doctorEntity = await _DBContext.Doctors
                .Include(d => d.TimeSlots)
                    .ThenInclude(ts => ts.Appointment)
                        .ThenInclude(a => a.Patient)
                .FirstOrDefaultAsync(d => d.Id == docId);

            if (doctorEntity != null)
            {
                var timeSlotToRemove = doctorEntity.TimeSlots.FirstOrDefault(ts => ts.Id == timeSlotToDelete.Id);

                if (timeSlotToRemove != null)
                {
                    if (timeSlotToRemove.Appointment != null)
                    {
                        timeSlotToRemove.Appointment = null;
                    }

                    doctorEntity.TimeSlots.Remove(timeSlotToRemove);
                    await _DBContext.SaveChangesAsync();
                }
                else
                {
                    Console.WriteLine("TimeSlot not found for the given Doctor ID");
                }
            }
            else
            {
                Console.WriteLine("Can't delete a TimeSlot of a Doctor that doesn't exist in the DB");
            }
        }
    }
}