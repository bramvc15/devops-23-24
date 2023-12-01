using BlazorApp.Data;
using Microsoft.EntityFrameworkCore;
using Shared.Enums;
using Shared.DTO;
using Domain;

namespace Services.Core
{
    public class PatientService
    {
        private readonly DatabaseContext _DBContext;

        public PatientService(DatabaseContext databaseContext)
        {
            _DBContext = databaseContext;
        }

        public async Task<IEnumerable<PatientDTO>> GetPatients()
        {
            var patients = await _DBContext.Patients.ToListAsync();

            List<PatientDTO> response = new();

            foreach (var patient in patients)
            {
                PatientDTO convertedPatient = new PatientDTO 
                {
                    Id = patient.Id,
                    Name = patient.Name,
                    Email = patient.Email,
                    PhoneNumber = patient.PhoneNumber,
                    DateOfBirth = patient.DateOfBirth,
                    Gender = (Gender) patient.Gender,
                    BloodType = (BloodType) patient.BloodType,
                };

                response.Add(convertedPatient);
            }

            return response;
        }

        public async Task<PatientDTO> CreatePatient(PatientDTO patient)
        {
            PatientDTO response = new PatientDTO();

            try
            {
                Patient newDomainPatient = new Patient(patient.Name, patient.Email, patient.PhoneNumber, patient.DateOfBirth, (Gender) patient.Gender, (BloodType) patient.BloodType);

                _DBContext.Patients.Add(newDomainPatient);
                await _DBContext.SaveChangesAsync();

                response.Id = newDomainPatient.Id;
                response.Name = newDomainPatient.Name;
                response.Email = newDomainPatient.Email;
                response.PhoneNumber = newDomainPatient.PhoneNumber;
                response.DateOfBirth = newDomainPatient.DateOfBirth;
                response.Gender = (Gender) newDomainPatient.Gender;
                response.BloodType = (BloodType) newDomainPatient.BloodType;
            } catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return response;
        }

        public async Task<PatientDTO> UpdatePatient(PatientDTO patient)
        {
            PatientDTO response = new PatientDTO();

            try
            {
                var existingPatient = await _DBContext.Patients.FindAsync(patient.Id);

                if (existingPatient != null)
                {
                    existingPatient.UpdatePatient(patient.Name, patient.Email, patient.PhoneNumber, patient.DateOfBirth, (Gender) patient.Gender, (BloodType) patient.BloodType);
                    await _DBContext.SaveChangesAsync();

                    response = new PatientDTO 
                    { 
                        Id = existingPatient.Id,
                        Name = existingPatient.Name,
                        Email = existingPatient.Email,
                        PhoneNumber = existingPatient.PhoneNumber,
                        DateOfBirth = existingPatient.DateOfBirth,
                        Gender = (Gender) existingPatient.Gender,
                        BloodType = (BloodType) existingPatient.BloodType,
                    };
                }
                else
                {
                    Console.WriteLine("Can't update a Patient that doesn't exist in the DB");
                    response = new PatientDTO
                    {
                        Name = "Can't update a Patient that doesn't exist in the DB",
                    };
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return response;
        }
    }
}