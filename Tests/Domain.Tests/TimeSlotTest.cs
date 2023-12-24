using Shared.Enums;
namespace Domain.Tests;

public class TimeSlotTest
{
    #region Fields
    private readonly TimeSlot _timeSlot;
    private readonly Appointment _appointment;
    #endregion

    #region Init
    public TimeSlotTest()
    {
        _timeSlot = new TimeSlot(AppointmentType.Consultation, new DateTime(2024, 2, 17, 12, 0, 0), 60);
        Patient patient = new Patient("Rino Petereyns", "rinopetereyns@fakemail.com", "+1234567890", new DateTime(2001, 6, 28), Gender.Male, BloodType.OPositive);
        _appointment = new Appointment(patient, "Reason: Operation on both eyes", "Note: patient is known to act weird");
    }
    #endregion

    #region Constructor tests
    [Fact]
    public void TimeSlot_Constructor_ValidParameters()
    {
        Assert.Equal(_timeSlot.AppointmentType, AppointmentType.Consultation);
        Assert.Equal(_timeSlot.DateTime, new DateTime(2024, 2, 17, 12, 0, 0));
        Assert.Equal(_timeSlot.Duration, 60);
    }

    [Fact]
    public void TimeSlot_Constructor_EmptyDuration_ThrowsException()
    {
        Assert.Throws<ArgumentException>(() => new TimeSlot(AppointmentType.Consultation, new DateTime(2024, 2, 17, 12, 0, 0), 0));
    }

    [Fact]
    public void TimeSlot_Constructor_NegativeDuration_ThrowsException()
    {
        Assert.Throws<ArgumentException>(() => new TimeSlot(AppointmentType.Consultation, new DateTime(2024, 2, 17, 12, 0, 0), -60));
    }

    [Fact]
    public void TimeSlot_Constructor_TooLargeDuration_ThrowsException()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => new TimeSlot(AppointmentType.Consultation, new DateTime(2024, 2, 17, 12, 0, 0), 3000));
    }

    [Fact]
    public void TimeSlot_Constructor_DateTimeInPast_ThrowsNoException()
    {
        new TimeSlot(AppointmentType.Consultation, new DateTime(2020, 2, 17, 12, 0, 0), 15);
    }
    #endregion

    #region Method tests
    [Fact]
    public void TimeSlot_UpdateTimeSlot()
    {
        TimeSlot updatedTimeSlot = new TimeSlot(AppointmentType.Operation, new DateTime(2024, 2, 18, 12, 0, 0), 40);
        _timeSlot.UpdateTimeSlot(AppointmentType.Operation, new DateTime(2024, 2, 18, 12, 0, 0), 40);

        Assert.Equal(updatedTimeSlot.AppointmentType, _timeSlot.AppointmentType);
        Assert.Equal(updatedTimeSlot.Duration, _timeSlot.Duration);
        Assert.Equal(updatedTimeSlot.DateTime, _timeSlot.DateTime);
    }

    [Fact]
    public void TimeSlot_CreateAppointment()
    {
        Patient newPatient = new Patient("New Patient", "newPatient@fakemail.com", "+1234567890", new DateTime(2001, 6, 28), Gender.Male, BloodType.OPositive);
        _timeSlot.CreateAppointment(newPatient, "Reason: Operation on both eyes", "Note: patient is known to act weird");
        Assert.Equal(_timeSlot.Appointment.Patient, newPatient);
        Assert.Equal(_timeSlot.Appointment.Reason, "Reason: Operation on both eyes");
        Assert.Equal(_timeSlot.Appointment.Note, "Note: patient is known to act weird");
    }

    [Fact]
    public void TimeSlot_DeleteAppointment()
    {
        Patient newPatient = new Patient("New Patient", "newPatient@fakemail.com", "+1234567890", new DateTime(2001, 6, 28), Gender.Male, BloodType.OPositive);
        _timeSlot.CreateAppointment(newPatient, "Reason: Operation on both eyes", "Note: patient is known to act weird");
        _timeSlot.Appointment = null;
        Assert.Equal(_timeSlot.Appointment, null);
    }

    [Fact]
    public void TimeSlot_IsTimeSlotAvailable()
    {
        Assert.Equal(_timeSlot.Appointment == null, true);
    }
    #endregion
}