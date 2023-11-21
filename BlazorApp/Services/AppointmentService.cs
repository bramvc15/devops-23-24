using BlazorApp.Data;
using BlazorApp.Models;
using Blazorise;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp.Services
{
    public class AppointmentService
    {
        private readonly DatabaseContext _ctx;

        public AppointmentService(DatabaseContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<IEnumerable<Appointment>> GetContent()
        {
            return await _ctx.Appointments.ToListAsync();
        }

        public async Task<Appointment> GetAppointmentById(int id)
        {
            var appointment =  await _ctx.Appointments.FindAsync(id);

            if (appointment == null)
            {
                throw new InvalidOperationException($"There is no appointment with id '{id}'");
            }

            return appointment;
        }

        public async Task<IEnumerable<Appointment>> GetAppointmentsByDoctorId(int doctorId)
        {
            var appointmantsOfDoctor = await _ctx.Appointments
                .Where(app => app.DoctorId == doctorId)
                .ToListAsync();

            if (appointmantsOfDoctor == null)
            {
                throw new InvalidOperationException($"The doctor with id '{doctorId}' does not have any appointments");
            }

            return appointmantsOfDoctor;
        }

        public async Task<IEnumerable<Appointment>> GetAppointmentsByPatientId(int patientId)
        {
            var appointmantsOfPatient = await _ctx.Appointments
                .Where(app => app.PatientId == patientId)
                .ToListAsync();

            if (appointmantsOfPatient == null)
            {
                throw new InvalidOperationException($"The patient with id '{patientId}' does not have any appointments");
            }

            return appointmantsOfPatient;
        }

        public async Task<Appointment> UpdateAppointmentById(int id, int doctorId, string reason, string note)
        {
/*            var appointment = new Appointment
            {
                Id = id,
                DoctorId = doctorId,
                Reason = reason,
                Note = note
            };

            _ctx.Appointments.Update(appointment);
            await _ctx.SaveChangesAsync();
            return appointment;*/



            var appOld = await _ctx.Appointments.FindAsync(id);

            if (appOld == null)
            {
                throw new InvalidOperationException($"There is no appointment with id '{id}'");
            }

            var appointment = new Appointment
            {
                Id = appOld.Id,
                PatientId = appOld.PatientId,
                Location = appOld.Location,
                DoctorId = doctorId,
                Reason = reason,
                Note = note
            };

            _ctx.Appointments.Update(appointment);
            await _ctx.SaveChangesAsync();
            return appointment;
        }

        public async Task<Appointment> DeleteAppointmentById(int id)
        {
            var appointmentToDelete = await _ctx.Appointments.FindAsync(id);

            if (appointmentToDelete != null)
            {
                _ctx.Appointments.Remove(appointmentToDelete);
                await _ctx.SaveChangesAsync();
            }
            else throw new InvalidOperationException($"The appointment with id '{id}' does not exist");

            return appointmentToDelete;
        }
    }
}