using Shared.Enums;
using System.ComponentModel;

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
        Assert.Equal("Dr. Smith", _doctor.Name);
        Assert.Equal("Straaloperatie", _doctor.Specialization);
        Assert.Equal(Gender.Male, _doctor.Gender);
        Assert.True(_doctor.IsAvailable);
    }

    [Fact]
    public void Doctor_Constructor_EmptyName_ThrowsException()
    {
        Assert.Throws<ArgumentException>(() => new Doctor("", "Evil-Specialization", Gender.Other));
    }

    [Fact]
    public void Doctor_Constructor_EmptySpecialization_ThrowsException()
    {
        Assert.Throws<ArgumentException>(() => new Doctor("Dr. Doofenshmirtz", "", Gender.Other));
    }

    [Fact]
    public void Doctor_Constructor_InvalidSpecialization_ThrowsException()
    {
        Assert.Throws<ArgumentNullException>(() => new Doctor("Dr. Smith", null, Gender.Male));
    }

    [Fact]
    public void Doctor_Constructor_InvalidGender_ThrowsException()
    {
        Assert.Throws<InvalidEnumArgumentException>(() => new Doctor("Dr. Smith", "Cardiology", (Gender)100));
    }
    #endregion

    #region Method tests
    [Fact]
    public void Doctor_MakeAppointmentForPatient()
    {
        Patient patient = new Patient("Rino Petereyns", "rinopetereyns@fakemail.com", "+1234567890", new DateTime(2001, 6, 28), Gender.Male, BloodType.OPositive);
        TimeSlot timeSlot = new TimeSlot(AppointmentType.Operation, new DateTime(2024, 4, 1, 16, 20, 0), 60);

        _doctor.AddTimeSlot(timeSlot);
        _doctor.CreateAppointment(patient, timeSlot, "Reason: Operation on both eyes", "Note: patient is known to act weird");

        TimeSlot fetchedTimeSlot = _doctor.TimeSlots.FirstOrDefault(x => x.DateTime == timeSlot.DateTime);
        Appointment fetchedAppointment = fetchedTimeSlot.Appointment;
        Patient fetchedPatient = fetchedAppointment.Patient;

        Assert.Single(_doctor.TimeSlots);
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
        ScheduleTimeSlot scheduleTimeSlot = new ScheduleTimeSlot(new DateTime(2024, 2, 17, 12, 0, 0), 60, DayOfWeek.Monday);

        _doctor.AddScheduleTimeSlot(scheduleTimeSlot);

        Assert.Contains(scheduleTimeSlot, _doctor.ScheduleTimeSlots);
    }

    [Fact]
    public void Doctor_UpdateScheduleTimeSlot()
    {
        ScheduleTimeSlot scheduleTimeSlot = new ScheduleTimeSlot(new DateTime(2024, 2, 18, 12, 0, 0), 60, DayOfWeek.Tuesday);
        _doctor.AddScheduleTimeSlot(scheduleTimeSlot);

        ScheduleTimeSlot newScheduleTimeSlot = new ScheduleTimeSlot(new DateTime(2024, 2, 19, 12, 0, 0), 60, DayOfWeek.Thursday);
        _doctor.UpdateScheduleTimeSlot(scheduleTimeSlot, new DateTime(2024, 2, 19, 12, 0, 0), 60, DayOfWeek.Thursday);

        ScheduleTimeSlot updatedScheduleTimeSlot = _doctor.ScheduleTimeSlots.FirstOrDefault(x => x.DateTime == newScheduleTimeSlot.DateTime);
        Assert.NotNull(updatedScheduleTimeSlot);
        Assert.Equal(newScheduleTimeSlot.Duration, updatedScheduleTimeSlot.Duration);
        Assert.Equal(newScheduleTimeSlot.DayOfWeek, updatedScheduleTimeSlot.DayOfWeek);
    }

    [Fact]
    public void Doctor_DeleteScheduleTimeSlot()
    {
        ScheduleTimeSlot scheduleTimeSlot = new ScheduleTimeSlot(new DateTime(2024, 2, 20, 12, 0, 0), 60, DayOfWeek.Friday);
        _doctor.AddScheduleTimeSlot(scheduleTimeSlot);

        _doctor.ScheduleTimeSlots.Remove(scheduleTimeSlot);

        Assert.DoesNotContain(scheduleTimeSlot, _doctor.ScheduleTimeSlots);
    }

    [Fact]
    public void Doctor_AddInvalidScheduleTimeSlot_SlotOverlapping()
    {
        ScheduleTimeSlot scheduleTimeSlot = new ScheduleTimeSlot(new DateTime(2024, 2, 17, 12, 0, 0), 60, DayOfWeek.Monday);

        _doctor.AddScheduleTimeSlot(scheduleTimeSlot);

        ScheduleTimeSlot overlappingScheduleTimeSlot = new ScheduleTimeSlot(new DateTime(2024, 2, 17, 12, 0, 0), 30, DayOfWeek.Monday);

        Assert.Throws<ArgumentException>(() => _doctor.AddScheduleTimeSlot(overlappingScheduleTimeSlot));
    }

    [Fact]
    public void Doctor_AddInvalidScheduleTimeSlot_StartTimeOverlapping()
    {
        ScheduleTimeSlot scheduleTimeSlot = new ScheduleTimeSlot(new DateTime(2024, 2, 17, 12, 0, 0), 60, DayOfWeek.Monday);

        _doctor.AddScheduleTimeSlot(scheduleTimeSlot);

        ScheduleTimeSlot overlappingScheduleTimeSlot = new ScheduleTimeSlot(new DateTime(2024, 2, 17, 12, 30, 0), 60, DayOfWeek.Monday);

        Assert.Throws<ArgumentException>(() => _doctor.AddScheduleTimeSlot(overlappingScheduleTimeSlot));
    }

    [Fact]
    public void Doctor_AddInvalidScheduleTimeSlot_EndTimeOverlapping()
    {
        ScheduleTimeSlot scheduleTimeSlot = new ScheduleTimeSlot(new DateTime(2024, 2, 17, 12, 0, 0), 60, DayOfWeek.Monday);

        _doctor.AddScheduleTimeSlot(scheduleTimeSlot);

        ScheduleTimeSlot overlappingScheduleTimeSlot = new ScheduleTimeSlot(new DateTime(2024, 2, 17, 11, 30, 0), 60, DayOfWeek.Monday);

        Assert.Throws<ArgumentException>(() => _doctor.AddScheduleTimeSlot(overlappingScheduleTimeSlot));
    }

    [Fact]
    public void Doctor_AddScheduleTimeSlot_StartTimeOnEndTimeExistingSlot()
    {
        Exception caughtException = Record.Exception(() =>
        {
            ScheduleTimeSlot scheduleTimeSlot = new ScheduleTimeSlot(new DateTime(2024, 2, 17, 12, 0, 0), 60, DayOfWeek.Monday);

            _doctor.AddScheduleTimeSlot(scheduleTimeSlot);

            ScheduleTimeSlot overlappingScheduleTimeSlot = new ScheduleTimeSlot(new DateTime(2024, 2, 17, 13, 0, 0), 60, DayOfWeek.Monday);

            _doctor.AddScheduleTimeSlot(overlappingScheduleTimeSlot);
        });
        Assert.Null(caughtException);
    }
    #endregion

    #region TimeSlot tests
    [Fact]
    public void Doctor_AddTimeSlot()
    {
        TimeSlot timeSlot = new TimeSlot(AppointmentType.Consultation, new DateTime(2024, 1, 20, 12, 0, 0), 60);

        _doctor.AddTimeSlot(timeSlot);

        Assert.Contains(timeSlot, _doctor.TimeSlots);
    }

    [Fact]
    public void Doctor_UpdateTimeSlot()
    {
        TimeSlot timeSlot = new TimeSlot(AppointmentType.Consultation, new DateTime(2024, 1, 21, 12, 0, 0), 60);
        _doctor.AddTimeSlot(timeSlot);

        TimeSlot newTimeSlot = new TimeSlot(AppointmentType.Operation, new DateTime(2024, 1, 22, 12, 0, 0), 40);
        _doctor.UpdateTimeSlot(timeSlot, AppointmentType.Operation, new DateTime(2024, 1, 22, 12, 0, 0), 40);

        TimeSlot updatedTimeSlot = _doctor.TimeSlots.FirstOrDefault(x => x.DateTime == newTimeSlot.DateTime);
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

        _doctor.TimeSlots.Remove(timeSlot);

        Assert.DoesNotContain(timeSlot, _doctor.TimeSlots);
    }

    [Fact]
    public void Doctor_AddInvalidTimeSlot_SlotOverlapping()
    {
        TimeSlot timeSlot = new TimeSlot(AppointmentType.Consultation, new DateTime(2024, 1, 20, 12, 0, 0), 60);

        _doctor.AddTimeSlot(timeSlot);

        TimeSlot overlappingTimeSlot = new TimeSlot(AppointmentType.Operation, new DateTime(2024, 1, 20, 12, 30, 0), 20);

        Assert.Throws<ArgumentException>(() => _doctor.AddTimeSlot(overlappingTimeSlot));
    }

    [Fact]
    public void Doctor_AddInvalidTimeSlot_StartTimeOverlapping()
    {
        TimeSlot timeSlot = new TimeSlot(AppointmentType.Consultation, new DateTime(2024, 1, 20, 12, 0, 0), 60);

        _doctor.AddTimeSlot(timeSlot);

        TimeSlot overlappingTimeSlot = new TimeSlot(AppointmentType.Operation, new DateTime(2024, 1, 20, 12, 30, 0), 60);

        Assert.Throws<ArgumentException>(() => _doctor.AddTimeSlot(overlappingTimeSlot));
    }

    [Fact]
    public void Doctor_AddInvalidTimeSlot_EndTimeOverlapping()
    {
        TimeSlot timeSlot = new TimeSlot(AppointmentType.Consultation, new DateTime(2024, 1, 20, 12, 0, 0), 60);

        _doctor.AddTimeSlot(timeSlot);

        TimeSlot overlappingTimeSlot = new TimeSlot(AppointmentType.Operation, new DateTime(2024, 1, 20, 11, 30, 0), 60);

        Assert.Throws<ArgumentException>(() => _doctor.AddTimeSlot(overlappingTimeSlot));
    }

    [Fact]
    public void Doctor_AddTimeSlot_StartTimeOnEndTimeExistingSlot()
    {
        Exception caughtException = Record.Exception(() =>
        {
            TimeSlot timeSlot = new TimeSlot(AppointmentType.Consultation, new DateTime(2024, 1, 20, 12, 0, 0), 60);

            _doctor.AddTimeSlot(timeSlot);

            TimeSlot overlappingTimeSlot = new TimeSlot(AppointmentType.Operation, new DateTime(2024, 1, 20, 13, 0, 0), 60);

            _doctor.AddTimeSlot(overlappingTimeSlot);
        });
        Assert.Null(caughtException);
    }
    #endregion
}