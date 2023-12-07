using Microsoft.EntityFrameworkCore;
using Shared.Enums;
using Domain;
using Shared.DTO.Core;
using Persistence.Data;

namespace Services.Core
{
    public class AppointmentService
    {
        private readonly DatabaseContext _DBContext;

        public AppointmentService(DatabaseContext databaseContext)
        {
            _DBContext = databaseContext;
        }

        public async Task<IEnumerable<AppointmentDTO>> GetAppointments(PatientDTO patient)
        {
            var patientEntity = await _DBContext.Patients
                .Include(p => p.Appointments)
                .FirstOrDefaultAsync(p => p.Id == patient.Id);

            if (patientEntity != null)
            {
                var appointmentDTOs = patientEntity.Appointments.Select(a => new AppointmentDTO
                {
                    Id = a.Id,
                    Reason = a.Reason,
                    Note = a.Note,
                    PatientDTO = new PatientDTO
                    {
                        Id = a.Patient.Id,
                        Name = a.Patient.Name,
                        Email = a.Patient.Email,
                        PhoneNumber = a.Patient.PhoneNumber,
                        DateOfBirth = a.Patient.DateOfBirth,
                        Gender = a.Patient.Gender,
                        BloodType = a.Patient.BloodType,
                    }
                });

                return appointmentDTOs;
            }
            else
            {
                Console.WriteLine("Can't get Appointments of a Patient that doesn't exist in the DB");
            }

            return Enumerable.Empty<AppointmentDTO>();
        }

        public async Task<AppointmentDTO> CreateAppointment(int timeSlotId, int patientId, string reason, string note)
        {
            var existingTimeSlot = await _DBContext.TimeSlots
                    .Include(ts => ts.Appointment)
                    .FirstOrDefaultAsync(ts => ts.Id == timeSlotId);

            if (existingTimeSlot != null && existingTimeSlot.Appointment == null)
            {
                var existingPatient = await _DBContext.Patients.FindAsync(patientId);

                if (existingPatient != null)
                {
                    existingTimeSlot.CreateAppointment(existingPatient, reason, note);
                    await _DBContext.SaveChangesAsync();

                    return new AppointmentDTO
                    {
                        Id = existingTimeSlot.Appointment.Id,
                        Reason = existingTimeSlot.Appointment.Reason,
                        Note = existingTimeSlot.Appointment.Note,
                    };
                }
                else
                {
                    Console.WriteLine("Can't create Appointment for a Patient who doesn't exist in the DB");
                    return new AppointmentDTO { };
                }
            }
            else
            {
                Console.WriteLine("Can't create Appointment for nonexistent TimeSlot");
                return new AppointmentDTO { };
            }
        }

        public async Task<AppointmentDTO> UpdateAppointment(AppointmentDTO updatedAppointment)
        {
            AppointmentDTO response = new();

            try
            {
                var existingAppointment = await _DBContext.Appointments.FirstOrDefaultAsync(a => a.Id == updatedAppointment.Id);

                if (existingAppointment != null)
                {
                    var existingPatient = await _DBContext.Patients.FirstOrDefaultAsync(p => p.Id == updatedAppointment.PatientDTO.Id);
                    Appointment updatedDomainAppointment = new(existingPatient, updatedAppointment.Reason, updatedAppointment.Note);
                    existingAppointment.UpdateAppointment(updatedDomainAppointment.Reason, updatedAppointment.Note);
                    existingAppointment.Patient = existingPatient;

                    await _DBContext.SaveChangesAsync();

                    response = new AppointmentDTO
                    {
                        Id = existingAppointment.Id,
                        Reason = existingAppointment.Reason,
                        Note = existingAppointment.Note,
                        PatientDTO = null
                    };
                }
                else
                {
                    Console.WriteLine("Cannot update a appointment that doesn't exist in the DB");
                    response = new AppointmentDTO { };
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return response;
        }

        public async Task DeleteAppointment(AppointmentDTO appointmentToDelete)
        {
            var existingAppointment = await _DBContext.Appointments.FirstOrDefaultAsync(a => a.Id == appointmentToDelete.Id);
            if (existingAppointment != null)
            {
                _DBContext.Appointments.Remove(existingAppointment);
                await _DBContext.SaveChangesAsync();
            }
            else
            {
                Console.WriteLine("Cannot delete a appointment that doesn't exist in the DB");
            }
        }
    }
}