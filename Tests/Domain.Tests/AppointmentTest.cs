using Domain;
using System;
using Xunit;

namespace Domain.Tests;

public class AppointmentTest
{
	#region Fields
	private readonly Appointment _appointment;
	private readonly Patient _patient;
	#endregion

	#region Init
	public AppointmentTest()
	{
		_patient = new Patient("Rino Petereyns", "rinopetereyns@fakemail.com", "+1234567890", new DateTime(2001, 6, 28), Gender.Male, BloodType.OPositive);
		_appointment = new Appointment(_patient, "Dr. Smith", new DateTime(2024, 2, 17, 12, 0, 0), "Reason: Operation on both eyes", "Note: patient is known to act weird");
	}
	#endregion

	#region Constructor tests
	[Fact]
	public void Appointment_Constructor_ValidParameters()
	{
		Assert.Equal(_appointment.Reason, "Reason: Operation on both eyes");
		Assert.Equal(_appointment.Note, "Note: patient is known to act weird");
		Assert.Equal(_appointment.GetPatient(), _patient);
		Assert.Equal(_appointment.DateTime, new DateTime(2024, 2, 17, 12, 0, 0));
		Assert.Equal(_appointment.NameDoctor, "Dr. Smith");
	}

	[Fact]
	public void Appointment_Constructor_EmptyReason_ThrowsException()
	{
		Patient newPatient = new Patient("New Patient", "patient@fakemail.com", "+1234567890", new DateTime(2001, 6, 28), Gender.Male, BloodType.OPositive);
		Assert.Throws<ArgumentNullException>(() => new Appointment(newPatient, "Dr. Smith", new DateTime(2024, 2, 17, 12, 0, 0), "", "Note: this is a note."));
	}

	[Fact]
	public void Appointment_Constructor_ValidParametersWithoutNote()
	{
		Patient newPatient = new Patient("New Patient", "patient@fakemail.com", "+1234567890", new DateTime(2001, 6, 28), Gender.Male, BloodType.OPositive);
		Appointment newAppointment = new Appointment(newPatient, "Dr. Smith", new DateTime(2024, 2, 17, 12, 0, 0), "Reason: new reason", "");
		Assert.Equal(newAppointment.Note, "This appointment has no additional note.");
	}

	[Fact]
	public void Appointment_Constructor_PatientNull_ThrowsException()
	{
		Assert.Throws<ArgumentNullException>(() => new Appointment((Patient) null, "Reason: new reason", ""));
	}
    #endregion

    #region Method tests
    [Fact]
	public void Appointment_HasPatient_IsTrue()
	{
		Assert.True(_appointment.HasPatient());
	}

	[Fact]
	public void Appointment_ChangePatient()
	{
		Patient newPatient = new Patient("New Patient", "patient@fakemail.com", "+1234567890", new DateTime(2001, 6, 28), Gender.Male, BloodType.OPositive);
		_appointment.ChangePatient(newPatient);
		Assert.Equal(_appointment.GetPatient(), newPatient);
	}

	[Fact]
	public void Appointment_ChangeInvalidPatient_ThrowsException()
	{
		Assert.Throws<ArgumentNullException>(() => _appointment.ChangePatient(null));
	}
	#endregion
}