using BlazorApp.Data;
using BlazorApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp.Services.Core
{
    public class PatientService
    {
        private readonly DatabaseContext _ctx;

        public PatientService(DatabaseContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<IEnumerable<Patient>> GetContent()
        {
            return await _ctx.Patients.ToListAsync();
        }

        public void UpdatePatient(int Id, string Name, string Email, string PhoneNumber)
        {
            Patient patient = _ctx.Patients.Find(Id);
            patient.Name = Name;
            patient.Email = Email;
            patient.PhoneNumber = PhoneNumber;
            _ctx.Patients.Update(patient);
            _ctx.SaveChanges();
        }
    }
}