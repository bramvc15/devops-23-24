using BlazorApp.Data;
using BlazorApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp.Services
{
    public class DoctorService
    {
     
        private readonly DatabaseContext _DBContext;
  

      
        public DoctorService(DatabaseContext databaseContext)
        {
            _DBContext = databaseContext;
        }
  
         public IEnumerable<Doctor> GetAll()
    {
        return _DBContext.Doctors
            .ToList();
    }


     public async Task<IEnumerable<Doctor>> GetAllAsync()
    {
        return await _DBContext.Doctors.ToListAsync();
    }
  

    public Doctor Create(Doctor newDoctor)
    {
        _DBContext.Doctors.Add(newDoctor);
        _DBContext.SaveChanges();

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