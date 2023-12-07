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
        _scheduleTimeSlot = new ScheduleTimeSlot(new DateTime(2024, 2, 17, 12, 0, 0), 60, DayOfWeek.Monday);
    }
    #endregion

    #region Constructor tests
    [Fact]
    public void ScheduleTimeSlot_Constructor_ValidParameters()
    {
        Assert.Equal(_scheduleTimeSlot.DateTime, new DateTime(2024, 2, 17, 12, 0, 0));
        Assert.Equal(_scheduleTimeSlot.DayOfWeek, DayOfWeek.Monday);
        Assert.Equal(_scheduleTimeSlot.Duration, 60);
    }

    [Fact]
    public void ScheduleTimeSlot_Constructor_EmptyDuration_ThrowsException()
    {
        Assert.Throws<ArgumentException>(() => new ScheduleTimeSlot(new DateTime(2024, 2, 17, 12, 0, 0), 0, DayOfWeek.Monday));
    }

    [Fact]
    public void ScheduleTimeSlot_Constructor_NegativeDuration_ThrowsException()
    {
        Assert.Throws<ArgumentException>(() => new ScheduleTimeSlot(new DateTime(2024, 2, 17, 12, 0, 0), -60, DayOfWeek.Monday));
    }

    [Fact]
    public void ScheduleTimeSlot_Constructor_TooLargeDuration_ThrowsException()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => new ScheduleTimeSlot(new DateTime(2024, 2, 17, 12, 0, 0), 3000, DayOfWeek.Monday));
    }
    #endregion

    #region Method tests
    [Fact]
    public void ScheduleTimeSlot_UpdateScheduleTimeSlot()
    {
        ScheduleTimeSlot updatedScheduleTimeSlot = new ScheduleTimeSlot(new DateTime(2024, 2, 18, 12, 0, 0), 40, DayOfWeek.Friday);
        _scheduleTimeSlot.UpdateScheduleTimeSlot(new DateTime(2024, 2, 18, 12, 0, 0), DayOfWeek.Friday, 40);

        Assert.Equal(updatedScheduleTimeSlot.Duration, _scheduleTimeSlot.Duration);
        Assert.Equal(updatedScheduleTimeSlot.DateTime, _scheduleTimeSlot.DateTime);
        Assert.Equal(updatedScheduleTimeSlot.DayOfWeek, _scheduleTimeSlot.DayOfWeek);
    }
    #endregion
}