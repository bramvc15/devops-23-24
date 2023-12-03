using Ardalis.GuardClauses;
using Shared.Enums;
using System.Text.RegularExpressions;

namespace Domain;

public class Patient : Entity
{
    #region Properties
    private string name;
    private string email;
    private string phoneNumber;
    private DateTime dateOfBirth;
    private Gender gender;
    private BloodType bloodType;

    public string Name {
        get => name;
        private set => name = Guard.Against.NullOrWhiteSpace(value, nameof(Name));
    }
    public string Email {
        get => email;
        private set
        {
            if (!IsValidEmail(value))
            {
                throw new ArgumentException("Invalid email format");
            }

            email = Guard.Against.NullOrWhiteSpace(value, nameof(Email));
        }
    }
    public string PhoneNumber {
        get => phoneNumber;
        private set
        {
            if (!IsValidPhoneNumber(value))
            {
                throw new ArgumentException("Invalid phonenumber format");
            }
            
            phoneNumber = Guard.Against.NullOrWhiteSpace(value, nameof(PhoneNumber));
        }
    }
    public DateTime DateOfBirth { 
        get => dateOfBirth;
        private set
        {
            Guard.Against.Default(value, nameof(DateOfBirth));
            Guard.Against.OutOfRange(value, nameof(DateOfBirth), DateTime.Now.AddYears(-150), DateTime.Now);
            dateOfBirth = value;
        }
    }
    public Gender Gender {
        get => gender;
        private set => gender = Guard.Against.EnumOutOfRange(value, nameof(Gender));
    }
    public BloodType BloodType { 
        get => bloodType;
        private set => bloodType = Guard.Against.EnumOutOfRange(value, nameof(BloodType));
    }
    public List<Appointment> Appointments { get; set; }
    #endregion

    #region Constructors
    // Database Constructor
    private Patient() { }

    public Patient(string name, string email, string phoneNumber, DateTime dateOfBirth, Gender gender, BloodType bloodType) {
        Name = name;
        Email = email;
        PhoneNumber = phoneNumber;
        DateOfBirth = dateOfBirth;
        Gender = gender;
        BloodType = bloodType;
    }
    #endregion

    #region Methods
    public void UpdatePatient(string name, string email, string phoneNumber, DateTime dateOfBirth, Gender gender, BloodType bloodType)
    {
        Name = name;
        Email = email;
        PhoneNumber = phoneNumber;
        DateOfBirth = dateOfBirth;
        Gender = gender;
        BloodType = bloodType;
        Appointments = new List<Appointment>();
    }
    #endregion

    #region ValidationMethods
    private static bool IsValidEmail(string email)
    {
        // checks whether the email has the structure of 'username@domain.extension' where:
        // 'username' can include letters, digits, dots ('.'), underscores ('_'), and hyphens ('-')
        // 'domain' can include letters, digits, dots ('.'), and hyphens ('-')
        // 'extension' should have at least two letters
        string emailRegex = @"^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
        Regex regex = new(emailRegex);
        return regex.IsMatch(email);
    }

    private static bool IsValidPhoneNumber(string phoneNumber)
    {
        // check whether the provided phone number consists only of digits and, optionally, starts with a plus sign ('+')
        string phoneRegex = @"^\+?[0-9]*$";
        Regex regex = new(phoneRegex);
        return regex.IsMatch(phoneNumber);
    }
    #endregion
}