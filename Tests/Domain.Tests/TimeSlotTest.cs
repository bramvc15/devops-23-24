using Domain;
using System;
using Xunit;

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
        _timeSlot = new TimeSlot(AppointmentType.Consultation, new DateTime(2024, 2, 17, 12, 0, 0), 60, "Dr. Smith");
        Patient patient = new Patient("Rino Petereyns", "rinopetereyns@fakemail.com", "+1234567890", new DateTime(2001, 6, 28), Gender.Male, BloodType.OPositive);
        _appointment = new Appointment(patient, new DateTime(2024, 2, 17, 12, 0, 0), "Reason: Operation on both eyes", "Note: patient is known to act weird");
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
        Assert.Throws<ArgumentException>(() => new TimeSlot(AppointmentType.Consultation, new DateTime(2024, 2, 17, 12, 0, 0), 0, "Dr. Smith"));
    }

    [Fact]
    public void TimeSlot_Constructor_NegativeDuration_ThrowsException()
    {
        Assert.Throws<ArgumentException>(() => new TimeSlot(AppointmentType.Consultation, new DateTime(2024, 2, 17, 12, 0, 0), -60, "Dr. Smith"));
    }

    [Fact]
    public void TimeSlot_Constructor_TooLargeDuration_ThrowsException()
    {
        Assert.Throws<ArgumentException>(() => new TimeSlot(AppointmentType.Consultation, new DateTime(2024, 2, 17, 12, 0, 0), 3000, "Dr. Smith"));
    }

    [Fact]
    public void TimeSlot_Constructor_DateTimeInPast_ThrowsException()
    {
        Assert.Throws<ArgumentException>(() => new TimeSlot(AppointmentType.Consultation, new DateTime(2020, 2, 17, 12, 0, 0), 60, "Dr. Smith"));
    }

    [Fact]
    public void TimeSlot_Constructor_EmptyNameDoctor_ThrowsException()
    {
        Assert.Throws<ArgumentException>(() => new TimeSlot(AppointmentType.Consultation, new DateTime(2020, 2, 17, 12, 0, 0), 60, ""));
    }

    [Fact]
    public void TimeSlot_Constructor_EmptyNameDoctor_ThrowsException()
    {
        Assert.Throws<ArgumentException>(() => new TimeSlot(AppointmentType.Consultation, new DateTime(2020, 2, 17, 12, 0, 0), 60));
    }
    #endregion

    #region Method tests
    [Fact]
    public void TimeSlot_UpdateTimeSlot()
    {
        TimeSlot updatedTimeSlot = new TimeSlot(AppointmentType.Operation, new DateTime(2024, 2, 18, 12, 0, 0), 40, "Dr. Smith");
        _timeSlot.UpdateTimeSlot(updatedTimeSlot);

        Assert.Equal(updatedTimeSlot.AppointmentType, _timeSlot.AppointmentType);
        Assert.Equal(updatedTimeSlot.Duration, _timeSlot.Duration);
        Assert.Equal(updatedTimeSlot.DateTime, _timeSlot.DateTime);
        Assert.Equal(updatedTimeSlot.NameDoctor, _timeSlot.NameDoctor);
    }

    [Fact]
    public void TimeSlot_CreateAppointment()
    {
        Patient newPatient = new Patient("New Patient", "newPatient@fakemail.com", "+1234567890", new DateTime(2001, 6, 28), Gender.Male, BloodType.OPositive);
        _timeSlot.CreateAppointment(newPatient, new DateTime(2024, 2, 17, 12, 0, 0), "Reason: Operation on both eyes", "Note: patient is known to act weird");
        Assert.Equal(_timeSlot.GetAppointment().GetPatient(), newPatient);
        Assert.Equal(_timeSlot.GetAppointment().Reason, "Reason: Operation on both eyes");
        Assert.Equal(_timeSlot.GetAppointment().Note, "Note: patient is known to act weird");
        Assert.Equal(_timeSlot.GetAppointment().DateTime, new DateTime(2024, 2, 17, 12, 0, 0));
    }

    [Fact]
    public void TimeSlot_UpdateAppointment()
    {
        Patient newPatient = new Patient("New Patient", "newPatient@fakemail.com", "+1234567890", new DateTime(2001, 6, 28), Gender.Male, BloodType.OPositive);
        Appointment newAppointment = new Appointment(newPatient, new DateTime(2024, 2, 17, 12, 0, 0), "New Reason", "New Note");
        _timeSlot.UpdateAppointment(newAppointment);
        Assert.Equal(_timeSlot.GetAppointment().GetPatient(), newPatient);
        Assert.Equal(_timeSlot.GetAppointment().Reason, "New Reason");
        Assert.Equal(_timeSlot.GetAppointment().Note, "New Note");
    }

    [Fact]
    public void TimeSlot_DeleteAppointment()
    {
        Patient newPatient = new Patient("New Patient", "newPatient@fakemail.com", "+1234567890", new DateTime(2001, 6, 28), Gender.Male, BloodType.OPositive);
        _timeSlot.CreateAppointment(newPatient, new DateTime(2024, 2, 17, 12, 0, 0), "Reason: Operation on both eyes", "Note: patient is known to act weird");
        _timeSlot.DeleteAppointment();
        Assert.Equal(_timeSlot.GetAppointment(), null);
    }

    [Fact]
    public void TimeSlot_IsTimeSlotAvailable()
    {
        Assert.Equal(_timeSlot.IsTimeSlotAvailable(), true);
    }
    #endregion
}