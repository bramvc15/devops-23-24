using Shared.Enums;

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
		_appointment = new Appointment(_patient, "Reason: Operation on both eyes", "Note: patient is known to act weird");
	}
	#endregion

	#region Constructor tests
	[Fact]
	public void Appointment_Constructor_ValidParameters()
	{
		Assert.Equal(_appointment.Reason, "Reason: Operation on both eyes");
		Assert.Equal(_appointment.Note, "Note: patient is known to act weird");
		Assert.Equal(_appointment.Patient, _patient);
	}

	[Fact]
	public void Appointment_Constructor_EmptyReason_ThrowsException()
	{
		Patient newPatient = new Patient("New Patient", "patient@fakemail.com", "+1234567890", new DateTime(2001, 6, 28), Gender.Male, BloodType.OPositive);
		Assert.Throws<ArgumentException>(() => new Appointment(newPatient, "", "Note: this is a note."));
	}

	[Fact]
	public void Appointment_Constructor_PatientNull_ThrowsException()
	{
		Assert.Throws<ArgumentNullException>(() => new Appointment((Patient) null, "Reason: new reason", ""));
	}
	#endregion

	#region Method Tests
	[Fact]
	public void Appointment_UpdateAppointment()
	{
		_appointment.UpdateAppointment("New String", "New Note");
		Assert.Equal(_appointment.Reason, "New String");
        Assert.Equal(_appointment.Note, "New Note");
    }
    #endregion
}