using Domain;
using System;
using Xunit;

namespace Domain.Tests;

public class DoctorTest
{
    #region Fields
    private readonly Doctor _doctor;
    #endregion

    #region Init
    public DoctorTest()
    {
        _doctor = new Doctor("Dr. Smith", "Straaloperatie", Gender.Male);
    }
    #endregion

    #region Constructor tests
    [Fact]
    public void Doctor_Constructor_ValidParameters()
    {
        Doctor newDoctor = new Doctor("Dr. Doofenshmirtz", "Evil-Specialization", Gender.Other);

        Assert.Equal("Dr. Doofenshmirtz", newDoctor.Name);
        Assert.Equal("Evil-Specialization", newDoctor.Specialization);
        Assert.Equal(Gender.Other, newDoctor.Gender);
        Assert.True(newDoctor.IsDoctorAvailable());
    }

    [Fact]
    public void Doctor_Constructor_EmptyName_ThrowsException()
    {
        Assert.Throws<ArgumentNullException>(() => new Doctor("", "Evil-Specialization", Gender.Other));
    }

    [Fact]
    public void Doctor_Constructor_EmptySpecialization_ThrowsException()
    {
        Assert.Throws<ArgumentNullException>(() => new Doctor("Dr. Doofenshmirtz", "", Gender.Other));
    }

    [Fact]
    public void Doctor_Constructor_InvalidSpecialization_ThrowsException()
    {
        Assert.Throws<ArgumentNullException>(() => new Doctor("Dr. Smith", null, Gender.Male));
    }

    [Fact]
    public void Doctor_Constructor_InvalidGender_ThrowsException()
    {
        Assert.Throws<ArgumentException>(() => new Doctor("Dr. Smith", "Cardiology", (Gender)100));
    }
    #endregion

    #region Method tests
    [Fact]
    public void Doctor_InitialAvailability_IsTrue()
    {
        Assert.True(_doctor.IsDoctorAvailable());
    }

    [Fact]
    public void Doctor_MakeAppointmentForPatient()
    {
        Patient patient = new Patient("Rino Petereyns", "rinopetereyns@fakemail.com", "+1234567890", new DateTime(2001, 6, 28), Gender.Male, BloodType.OPositive);
        TimeSlot timeSlot = new TimeSlot(AppointmentType.Operation, new DateTime(2024, 4, 1, 16, 20, 0), 60);

        _doctor.AddTimeSlot(timeSlot);
        _doctor.CreateAppointmentForPatient(patient, timeSlot, "Reason: Operation on both eyes", "Note: patient is known to act weird");

        TimeSlot fetchedTimeSlot = _doctor.GetTimeSlots().FirstOrDefault(x => x.DateTime == timeSlot.DateTime);
        Appointment fetchedAppointment = fetchedTimeSlot.GetAppointment();
        Patient fetchedPatient = fetchedAppointment.GetPatient();

        Assert.Single(_doctor.GetTimeSlots());
        Assert.NotNull(fetchedTimeSlot);
        Assert.Equal(timeSlot.DateTime, fetchedTimeSlot.DateTime);
        Assert.Equal(timeSlot.AppointmentType, fetchedTimeSlot.AppointmentType);
        Assert.Equal(timeSlot.Duration, fetchedTimeSlot.Duration);

        Assert.NotNull(fetchedAppointment);
        Assert.Equal(patient, fetchedPatient);
        Assert.Equal(fetchedAppointment.Reason, "Reason: Operation on both eyes");
        Assert.Equal(fetchedAppointment.Note, "Note: patient is known to act weird");
    }

    [Fact]
    public void Doctor_HasAvailableTimeSlots()
    {
        TimeSlot timeSlot = new TimeSlot(AppointmentType.Consultation, new DateTime(2024, 4, 1, 11, 0, 0), 60);

        _doctor.AddTimeSlot(timeSlot);

        Assert.True(_doctor.HasAvailableTimeSlots());
    }
    #endregion

    #region ScheduleTimeSlot tests
    [Fact]
    public void Doctor_AddScheduleTimeSlot()
    {
        ScheduleTimeSlot scheduleTimeSlot = new ScheduleTimeSlot(AppointmentType.Consultation, new DateTime(2024, 2, 17, 12, 0, 0), 60, DayOfWeek.Monday);

        _doctor.AddScheduleTimeSlot(scheduleTimeSlot);

        Assert.Contains(scheduleTimeSlot, _doctor.GetScheduleTimeSlots());
    }

    [Fact]
    public void Doctor_UpdateScheduleTimeSlot()
    {
        ScheduleTimeSlot scheduleTimeSlot = new ScheduleTimeSlot(AppointmentType.Operation, new DateTime(2024, 2, 18, 12, 0, 0), 60, DayOfWeek.Tuesday);
        _doctor.AddScheduleTimeSlot(scheduleTimeSlot);

        ScheduleTimeSlot newScheduleTimeSlot = new ScheduleTimeSlot(AppointmentType.Consultation, new DateTime(2024, 2, 19, 12, 0, 0), 60, DayOfWeek.Thursday);
        _doctor.UpdateScheduleTimeSlot(scheduleTimeSlot, newScheduleTimeSlot);

        ScheduleTimeSlot updatedScheduleTimeSlot = _doctor.GetScheduleTimeSlots().FirstOrDefault(x => x.DateTime == newScheduleTimeSlot.DateTime);
        Assert.NotNull(updatedScheduleTimeSlot);
        Assert.Equal(newScheduleTimeSlot.AppointmentType, updatedScheduleTimeSlot.AppointmentType);
        Assert.Equal(newScheduleTimeSlot.Duration, updatedScheduleTimeSlot.Duration);
        Assert.Equal(newScheduleTimeSlot.DayOfWeek, updatedScheduleTimeSlot.DayOfWeek);
    }

    [Fact]
    public void Doctor_DeleteScheduleTimeSlot()
    {
        ScheduleTimeSlot scheduleTimeSlot = new ScheduleTimeSlot(AppointmentType.Operation, new DateTime(2024, 2, 20, 12, 0, 0), 60, DayOfWeek.Friday);
        _doctor.AddScheduleTimeSlot(scheduleTimeSlot);

        _doctor.DeleteScheduleTimeSlot(scheduleTimeSlot);

        Assert.DoesNotContain(scheduleTimeSlot, _doctor.GetScheduleTimeSlots());
    }
    #endregion

    #region TimeSlot tests
    [Fact]
    public void Doctor_AddTimeSlot()
    {
        TimeSlot timeSlot = new TimeSlot(AppointmentType.Consultation, new DateTime(2024, 1, 20, 12, 0, 0), 60);

        _doctor.AddTimeSlot(timeSlot);

        Assert.Contains(timeSlot, _doctor.GetTimeSlots());
    }

    [Fact]
    public void Doctor_UpdateTimeSlot()
    {
        TimeSlot timeSlot = new TimeSlot(AppointmentType.Consultation, new DateTime(2024, 1, 21, 12, 0, 0), 60);
        _doctor.AddTimeSlot(timeSlot);

        TimeSlot newTimeSlot = new TimeSlot(AppointmentType.Operation, new DateTime(2024, 1, 22, 12, 0, 0), 40);
        _doctor.UpdateTimeSlot(timeSlot, newTimeSlot);

        TimeSlot updatedTimeSlot = _doctor.GetTimeSlots().FirstOrDefault(x => x.DateTime == newTimeSlot.DateTime);
        Assert.NotNull(updatedTimeSlot);
        Assert.Equal(newTimeSlot.AppointmentType, updatedTimeSlot.AppointmentType);
        Assert.Equal(newTimeSlot.Duration, updatedTimeSlot.Duration);
        Assert.Equal(newTimeSlot.DateTime, updatedTimeSlot.DateTime);
    }

    [Fact]
    public void Doctor_DeleteTimeSlot()
    {
        TimeSlot timeSlot = new TimeSlot(AppointmentType.Consultation, new DateTime(2024, 1, 23, 12, 0, 0), 60);
        _doctor.AddTimeSlot(timeSlot);

        _doctor.DeleteTimeSlot(timeSlot);

        Assert.DoesNotContain(timeSlot, _doctor.GetTimeSlots());
    }
    #endregion
}