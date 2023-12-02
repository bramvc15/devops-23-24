using Microsoft.EntityFrameworkCore;
using Shared.Enums;
using Domain;
using Shared.DTO.Core;
using Persistence.Data;

namespace Services.Core
{
    public class DoctorService
    {
        private readonly DatabaseContext _DBContext;

        public DoctorService(DatabaseContext databaseContext)
        {
            _DBContext = databaseContext;
            _doctors = databaseContext.Doctors;
        }

        private readonly DbSet<Doctor> _doctors;

        public async Task<IEnumerable<DoctorDTO>> GetDoctors()
        {
            var doctors = await _doctors.ToListAsync();

            List<DoctorDTO> convertedDoctors = new();

            foreach (var doctor in doctors)
            {
                DoctorDTO convertedDoctor = new DoctorDTO
                {
                    Id = doctor.Id,
                    Name = doctor.Name,
                    Specialization = doctor.Specialization,
                    Gender = (Gender) doctor.Gender,
                    Biograph = doctor.Biograph,
                    IsAvailable = doctor.IsAvailable,
                    ImageLink = doctor.ImageLink,
                };

                convertedDoctors.Add(convertedDoctor);
            }

            return convertedDoctors;
        }

        public async Task<DoctorDTO> GetDoctor(int DoctorId)
        {
            var doctor = await _doctors.FindAsync(DoctorId);

            DoctorDTO dto = new()
            {
                Biograph = doctor.Biograph,
                IsAvailable = doctor.IsAvailable,
                ImageLink = doctor.ImageLink,
                Gender = (Gender)doctor.Gender,
                Id = doctor.Id,
                Name = doctor.Name,
                Specialization = doctor.Specialization,

            };

            return dto;
        }

        public async Task<DoctorDTO> CreateDoctor(DoctorDTO newDoctor)
        {
            DoctorDTO response = new DoctorDTO();

            try
            {
                Doctor newDomainDoctor = new Doctor(newDoctor.Name, newDoctor.Specialization, (Gender) newDoctor.Gender, newDoctor.Biograph);

                _doctors.Add(newDomainDoctor);
                await _DBContext.SaveChangesAsync();

                response.Id = newDomainDoctor.Id;
                response.Name = newDomainDoctor.Name;
                response.Specialization = newDomainDoctor.Specialization;
                response.Gender = (Gender) newDomainDoctor.Gender;
                response.Biograph = newDomainDoctor.Biograph;
                response.IsAvailable = newDomainDoctor.IsAvailable;
                response.ImageLink = newDomainDoctor.ImageLink;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return response;
        }

        public async Task<DoctorDTO> UpdateDoctor(DoctorDTO updatedDoctor)
        {
            DoctorDTO response = new DoctorDTO();

            try
            {
                var existingDoctor = await _doctors.FindAsync(updatedDoctor.Id);

                if (existingDoctor != null)
                {
                    existingDoctor.UpdateDoctor(updatedDoctor.Name, updatedDoctor.Specialization, (Gender)updatedDoctor.Gender, updatedDoctor.Biograph, updatedDoctor.IsAvailable, updatedDoctor.ImageLink);

                    await _DBContext.SaveChangesAsync();

                    response = new DoctorDTO
                    {
                        Id = existingDoctor.Id,
                        Name = existingDoctor.Name,
                        Specialization = existingDoctor.Specialization,
                        Gender = (Gender)existingDoctor.Gender,
                        Biograph = existingDoctor.Biograph,
                        IsAvailable = existingDoctor.IsAvailable,
                        ImageLink = existingDoctor.ImageLink,
                    };
                }
                else
                {
                    Console.WriteLine("Can't update a Doctor that doesn't exist in the DB");
                    response = new DoctorDTO
                    {
                        Name = "Can't update a Doctor that doesn't exist in the DB",
                    };
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return response;
        }

        public async Task DeleteDoctor(DoctorDTO doctorToDelete)
        {
            try
            {
                var existingDoctor = await _doctors
                    .Include(d => d.TimeSlots)
                        .ThenInclude(t => t.Appointment)
                    .FirstOrDefaultAsync(d => d.Id == doctorToDelete.Id);

                if (existingDoctor != null)
                {
                    foreach (var timeSlot in existingDoctor.TimeSlots)
                    {
                        var appointment = timeSlot.Appointment;
                        if (appointment != null)
                        {
                            _DBContext.Remove(appointment);
                        }
                        _DBContext.Remove(timeSlot);
                    }

                    _doctors.Remove(existingDoctor);
                    await _DBContext.SaveChangesAsync();
                }
                else
                {
                    Console.WriteLine("Can't delete a Doctor that doesn't exist in the DB");
                }
            } catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}