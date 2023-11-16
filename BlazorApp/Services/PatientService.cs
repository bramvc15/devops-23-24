using BlazorApp.Data;
using BlazorApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp.Services
{
    public class PatientService
    {
        private readonly DatabaseContext _ctx;

        public PatientService(DatabaseContext ctx)
        {
            _ctx = ctx;
        }

        public IEnumerable<Patient> GetContent()
        {
            return _ctx.Patients.ToList();
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