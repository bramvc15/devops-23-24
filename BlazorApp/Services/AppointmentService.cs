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

        public async Task<Appointment> CreateAppointment(Appointment appointment)
        {
            if (appointment == null)
            {
                throw new InvalidOperationException($"The appointment is null");
            }
            if (appointment.PatientId == null)
            {
                throw new InvalidOperationException($"The patient id is null");
            }
            if (appointment.Location == null || string.IsNullOrWhiteSpace(appointment.Location))
            {
                throw new InvalidOperationException($"The location is null or empty");
            }
            if (appointment.DoctorId == null)
            {
                throw new InvalidOperationException($"The doctor id is null");
            }
            if (appointment.Reason == null || string.IsNullOrWhiteSpace(appointment.Reason))
            {
                throw new InvalidOperationException($"The reason is null or empty");
            }

            var newAppointment = new Appointment
            {
                PatientId = appointment.PatientId,
                Location = appointment.Location,
                DoctorId = appointment.DoctorId,
                Reason = appointment.Reason,
                Note = appointment.Note
            };

            _ctx.Appointments.Add(newAppointment);
            await _ctx.SaveChangesAsync();
            return newAppointment;
        }

        public void UpdateAppointmentById(int id, Appointment appointment)
        {
            if (appointment == null)
            {
                throw new InvalidOperationException($"The appointment is null");
            }

            var existingAppointment = _ctx.Appointments.Find(id);
            if (existingAppointment == null)
            {
                throw new InvalidOperationException($"There is no appointment with id '{id}'");
            }

            existingAppointment.DoctorId = appointment.DoctorId;
            existingAppointment.Reason = appointment.Reason;
            existingAppointment.Note = appointment.Note;

            _ctx.SaveChanges();
        }

        public void DeleteAppointmentById(int id)
        {
            var appointmentToDelete = _ctx.Appointments.Find(id);

            if (appointmentToDelete != null)
            {
                _ctx.Appointments.Remove(appointmentToDelete);
                _ctx.SaveChanges();
            }
            else throw new InvalidOperationException($"The appointment with id '{id}' does not exist");
        }
    }
}