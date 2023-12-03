using Shared.Enums;
using System.ComponentModel;

namespace Domain.Tests;

public class PatientTest
{
    #region Fields
    private readonly Patient _patient;
    #endregion

    #region Init
    public PatientTest()
    {
        _patient = new Patient("Rino Petereyns", "rinopetereyns@fakemail.com", "+1234567890", new DateTime(2001, 6, 28), Gender.Male, BloodType.OPositive);
    }
    #endregion

    #region Constructor tests
    [Fact]
    public void Patient_Constructor_ValidParameters()
    {
        Assert.Equal("Rino Petereyns", _patient.Name);
        Assert.Equal("rinopetereyns@fakemail.com", _patient.Email);
        Assert.Equal("+1234567890", _patient.PhoneNumber);
        Assert.Equal(new DateTime(2001, 6, 28), _patient.DateOfBirth);
        Assert.Equal(Gender.Male, _patient.Gender);
        Assert.Equal(BloodType.OPositive, _patient.BloodType);
    }

    [Fact]
    public void Patient_Constructor_EmptyName_ThrowsException()
    {
        Assert.Throws<ArgumentException>(() => new Patient("", "rinopetereyns@fakemail.com", "+1234567890", new DateTime(2001, 6, 28), Gender.Male, BloodType.OPositive));
    }

    [Fact]
    public void Patient_Constructor_EmptyEmail_ThrowsException()
    {
        Assert.Throws<ArgumentException>(() => new Patient("Rino Petereyns", "", "+1234567890", new DateTime(2001, 6, 28), Gender.Male, BloodType.OPositive));
    }

    [Fact]
    public void Patient_Constructor_InvalidPhoneNumber_ThrowsException()
    {
        Assert.Throws<ArgumentException>(() => new Patient("Rino Petereyns", "rinopetereyns@fakemail.com", "1a56z15", new DateTime(2001, 6, 28), Gender.Male, BloodType.OPositive));
    }

    [Fact]
    public void Patient_Constructor_InvalidBirthDate_ThrowsException()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => new Patient("Rino Petereyns", "rinopetereyns@fakemail.com", "+1234567890", new DateTime(1000, 6, 28), Gender.Male, BloodType.OPositive));
    }

    [Fact]
    public void Patient_Constructor_InvalidGender_ThrowsException()
    {
        Assert.Throws<InvalidEnumArgumentException>(() => new Patient("Rino Petereyns", "rinopetereyns@fakemail.com", "+1234567890", new DateTime(2001, 6, 28), (Gender)100, BloodType.OPositive));
    }

    [Fact]
    public void Patient_Constructor_InvalidBloodType_ThrowsException()
    {
        Assert.Throws<InvalidEnumArgumentException>(() => new Patient("Rino Petereyns", "rinopetereyns@fakemail.com", "+1234567890", new DateTime(2001, 6, 28), Gender.Male, (BloodType)100));
    }
    #endregion
}