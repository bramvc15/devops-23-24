using Domain;
using System;
using Xunit;

namespace Domain.Tests;

public class ScheduleTimeSlotTest
{
    #region Fields
    private readonly ScheduleTimeSlot _scheduleTimeSlot;
    #endregion

    #region Init
    public ScheduleTimeSlotTest()
    {
        _scheduleTimeSlot = new ScheduleTimeSlot(AppointmentType.Consultation, new DateTime(2024, 2, 17, 12, 0, 0), 60, DayOfWeek.Monday, "Dr. Doofenshmirtz");
    }
    #endregion

    #region Constructor tests
    [Fact]
    public void ScheduleTimeSlot_Constructor_ValidParameters()
    {
        Assert.Equal(_scheduleTimeSlot.AppointmentType, AppointmentType.Consultation);
        Assert.Equal(_scheduleTimeSlot.DateTime, new DateTime(2024, 2, 17, 12, 0, 0));
        Assert.Equal(_scheduleTimeSlot.DayOfWeek, DayOfWeek.Monday);
        Assert.Equal(_scheduleTimeSlot.Duration, 60);
        Assert.Equal(_scheduleTimeSlot.NameDoctor, "Dr. Doofenshmirtz");
    }

    [Fact]
    public void ScheduleTimeSlot_Constructor_EmptyDuration_ThrowsException()
    {
        Assert.Throws<ArgumentException>(() => new ScheduleTimeSlot(AppointmentType.Consultation, new DateTime(2024, 2, 17, 12, 0, 0), 0, DayOfWeek.Monday, "Dr. Doofenshmirtz"));
    }

    [Fact]
    public void ScheduleTimeSlot_Constructor_NegativeDuration_ThrowsException()
    {
        Assert.Throws<ArgumentException>(() => new ScheduleTimeSlot(AppointmentType.Consultation, new DateTime(2024, 2, 17, 12, 0, 0), -60, DayOfWeek.Monday, "Dr. Doofenshmirtz"));
    }

    [Fact]
    public void ScheduleTimeSlot_Constructor_TooLargeDuration_ThrowsException()
    {
        Assert.Throws<ArgumentException>(() => new ScheduleTimeSlot(AppointmentType.Consultation, new DateTime(2024, 2, 17, 12, 0, 0), 3000, DayOfWeek.Monday, "Dr. Doofenshmirtz"));
    }

    [Fact]
    public void ScheduleTimeSlot_Constructor_EmptyNameDoctor_ThrowsException()
    {
        Assert.Throws<ArgumentNullException>(() => new ScheduleTimeSlot(AppointmentType.Consultation, new DateTime(2024, 2, 17, 12, 0, 0), 60, DayOfWeek.Monday, ""));
    }
    #endregion

    #region Method tests
    [Fact]
    public void ScheduleTimeSlot_UpdateScheduleTimeSlot()
    {
        ScheduleTimeSlot updatedScheduleTimeSlot = new ScheduleTimeSlot(AppointmentType.Operation, new DateTime(2024, 2, 18, 12, 0, 0), 40, DayOfWeek.Friday, "Dr. Doofenshmirtz");
        _scheduleTimeSlot.UpdateScheduleTimeSlot(updatedScheduleTimeSlot);

        Assert.Equal(updatedScheduleTimeSlot.AppointmentType, _scheduleTimeSlot.AppointmentType);
        Assert.Equal(updatedScheduleTimeSlot.Duration, _scheduleTimeSlot.Duration);
        Assert.Equal(updatedScheduleTimeSlot.DateTime, _scheduleTimeSlot.DateTime);
        Assert.Equal(updatedScheduleTimeSlot.DayOfWeek, _scheduleTimeSlot.DayOfWeek);
        Assert.Equal(updatedScheduleTimeSlot.NameDoctor, _scheduleTimeSlot.NameDoctor);
    }
    #endregion
}