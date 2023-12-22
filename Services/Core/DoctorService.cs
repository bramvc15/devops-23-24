using Microsoft.EntityFrameworkCore;
using Domain;
using Shared.DTO.Core;
using Persistence.Data;
using Auth0.ManagementApi;
using Auth0.ManagementApi.Models;
using System.Diagnostics;

namespace Services.Core
{
    public class DoctorService
    {
        private readonly DatabaseContext _DBContext;
        private readonly IManagementApiClient _managementApiClient;

        public DoctorService(DatabaseContext databaseContext, IManagementApiClient managementApiClient)
        {
            _DBContext = databaseContext;
            _doctors = databaseContext.Doctors;
            _managementApiClient = managementApiClient;
        }

        private readonly DbSet<Doctor> _doctors;

        public async Task<IEnumerable<DoctorDTO>> GetDoctors()
        {
            var doctors = await _doctors.ToListAsync();

            List<DoctorDTO> convertedDoctors = new();

            foreach (var doctor in doctors)
            {
                DoctorDTO convertedDoctor = new()
                {
                    Id = doctor.Id,
                    Name = doctor.Name,
                    Specialization = doctor.Specialization,
                    Gender = doctor.Gender,
                    Biograph = doctor.Biograph,
                    IsAvailable = doctor.IsAvailable,
                    ImageLink = doctor.ImageLink,
                    Auth0Id = doctor.Auth0Id
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
                Id = doctor.Id,
                Name = doctor.Name,
                Specialization = doctor.Specialization,
                Gender = doctor.Gender,
                Biograph = doctor.Biograph,
                IsAvailable = doctor.IsAvailable,
                ImageLink = doctor.ImageLink,
                Auth0Id = doctor.Auth0Id
            };

            return dto;
        }

        public async Task<string> CreateDoctorInAuth0(string username, string email, string password)
        {
            try
            {
                var auth0Request = new UserCreateRequest
                {
                    UserName = username,
                    Email = email,
                    Password = password,
                    Connection = "Username-Password-Authentication",
                };

                auth0Request.VerifyEmail = false;
                var createdUser = await _managementApiClient.Users.CreateAsync(auth0Request);
                Debug.WriteLine(createdUser);

                var allRoles = await _managementApiClient.Roles.GetAllAsync(new GetRolesRequest());
                var employeeRole = allRoles.First(x => x.Name == "Employee");

                var assignRoleRequest = new AssignRolesRequest
                {
                    Roles = new string[] { employeeRole.Id }
                };
                await _managementApiClient.Users.AssignRolesAsync(createdUser?.UserId, assignRoleRequest);

                Console.WriteLine(createdUser);

                return createdUser.UserId;
            } catch (Exception ex)
            {
                Console.WriteLine("===================================");
                Console.WriteLine(ex.Message);
                Console.WriteLine("===================================");
                Console.WriteLine(ex.StackTrace);
                Console.WriteLine("===================================");
                return "-1";
            }
        }

        public async Task<DoctorDTO> CreateDoctor(DoctorDTO newDoctor)
        {
            DoctorDTO response = new ();

            try
            {
                Doctor newDomainDoctor = new (newDoctor.Name, newDoctor.Specialization, newDoctor.Gender, newDoctor.Biograph);
                newDomainDoctor.Auth0Id = newDoctor.Auth0Id;

                _doctors.Add(newDomainDoctor);
                await _DBContext.SaveChangesAsync();

                response.Id = newDomainDoctor.Id;
                response.Name = newDomainDoctor.Name;
                response.Specialization = newDomainDoctor.Specialization;
                response.Gender = newDomainDoctor.Gender;
                response.Biograph = newDomainDoctor.Biograph;
                response.IsAvailable = newDomainDoctor.IsAvailable;
                response.ImageLink = newDomainDoctor.ImageLink;
                response.Auth0Id = newDomainDoctor.Auth0Id;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return response;
        }

        public async Task<DoctorDTO> UpdateDoctor(DoctorDTO updatedDoctor)
        {
            DoctorDTO response = new();

            try
            {
                var existingDoctor = await _doctors.FindAsync(updatedDoctor.Id);

                if (existingDoctor != null)
                {
                    existingDoctor.UpdateDoctor(updatedDoctor.Name, updatedDoctor.Specialization, updatedDoctor.Gender, updatedDoctor.Biograph);
                    existingDoctor.IsAvailable = updatedDoctor.IsAvailable;
                    existingDoctor.ImageLink = updatedDoctor.ImageLink;

                    await _DBContext.SaveChangesAsync();

                    response = new DoctorDTO
                    {
                        Id = existingDoctor.Id,
                        Name = existingDoctor.Name,
                        Specialization = existingDoctor.Specialization,
                        Gender = existingDoctor.Gender,
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
                Console.WriteLine("===================================");
                Console.WriteLine(ex.Message);
                Console.WriteLine("===================================");
                Console.WriteLine(ex.StackTrace);
                Console.WriteLine("===================================");
            }
            return response;
        }

        public async Task DeleteDoctor(DoctorDTO doctorToDelete)
        {
            try
            {
                await _managementApiClient.Users.DeleteAsync(doctorToDelete.Auth0Id);

                var existingDoctor = await _doctors
                    .Include(d => d.TimeSlots)
                        .ThenInclude(t => t.Appointment)
                    .Include(d => d.ScheduleTimeSlots)
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

                    foreach (var scheduleTimeSlot in existingDoctor.ScheduleTimeSlots)
                    {
                        _DBContext.Remove(scheduleTimeSlot);
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