using BlazorApp.Data;
using BlazorApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp.Services.Core
{
    public class DoctorService
    {
        private readonly DatabaseContext _DBContext;

        public DoctorService(DatabaseContext databaseContext)
        {
            _DBContext = databaseContext;
        }

        public async Task<IEnumerable<Doctor>> GetAll()
        {
            return await _DBContext.Doctors.ToListAsync();
        }

        public async Task<Doctor> GetDoctorById(int id)
        {
            return await _DBContext.Doctors.FindAsync(id);
        }

        public async Task<IEnumerable<Doctor>> GetAllAsync()
        {
            return await _DBContext.Doctors.ToListAsync();
        }

        public async Task<Doctor> Create(Doctor newDoctor)
        {
            await _DBContext.Doctors.AddAsync(newDoctor);
            await _DBContext.SaveChangesAsync();

            return newDoctor;
        }

        public void DeleteById(int id)
        {
            var doctorToDelete = _DBContext.Doctors.Find(id);
            if (doctorToDelete is not null)
            {
                _DBContext.Doctors.Remove(doctorToDelete);
                _DBContext.SaveChanges();
            }
        }

        // public IEnumerable<Doctor> GetAllDoctorsAsync()
        // {
        //     return  _DBContext.Doctors.ToList();
        // }



        // public async Task<bool> InsertEmployeeAsync(Doctor doctor)
        // {
        //     await _DBContext.Doctors.AddAsync(doctor);
        //     await _DBContext.SaveChangesAsync();
        //     return true;
        // }



        // public async Task<Doctor> GetEmployeeAsync(int Id)
        // {
        //     Doctor doctor = await _DBContext.Doctors.FirstOrDefaultAsync(c => c.Id.Equals(Id));
        //     return doctor;
        // }


        // public async Task<bool> UpdateEmployeeAsync(Doctor doctor)
        // {
        //      _DBContext.Doctors.Update(doctor);
        //     await _DBContext.SaveChangesAsync();
        //     return true;
        // }


        // public async Task<bool> DeleteEmployeeAsync(Doctor doctor)
        // {
        //     _DBContext.Remove(doctor);
        //     await _DBContext.SaveChangesAsync();
        //     return true;
        // }
    }
}