using System.Text.RegularExpressions;

namespace Domain;

public class Patient
{
    #region Fields
    private string _name;
    private string _email;
    private string _phoneNumber;
    private DateTime _dateOfBirth;
    private Gender _gender;
    private BloodType _bloodType;
    private readonly List<Appointment> _appointments = new();
    #endregion

    #region Properties
    public string Name {
        get 
        {
            return _name;
        }
        private set
        {
            if(string.IsNullOrWhiteSpace(value)) throw new ArgumentNullException("Name cannot be empty"); 
            _name = value;
        }
    }
    public string Email {
        get 
        {
            return _email;
        }
        private set
        { 
            if(string.IsNullOrWhiteSpace(value)) throw new ArgumentNullException("Email cannot be empty");

            if (!IsValidEmail(value))
            {
                throw new ArgumentException("Invalid email format");
            }

            _email = value;
        }
    }
    public string PhoneNumber {
        get 
        {
            return _phoneNumber;
        }
        private set
        { 
            if(string.IsNullOrWhiteSpace(value)) throw new ArgumentNullException("Phone number cannot be empty");

            if (!IsValidPhoneNumber(value))
            {
                throw new ArgumentException("Invalid phone number format");
            }

            _phoneNumber = value;
        }
    }
    public DateTime DateOfBirth {
        get 
        {
            return _dateOfBirth;
        }
        private set
        { 
            if (value == default(DateTime)) throw new ArgumentNullException("Date of birth cannot be empty");

            if (value > DateTime.Now)
            {
                throw new ArgumentException("Date of birth cannot be in the future");
            }

            if (DateTime.Now.Year - value.Year > 150)
            {
                throw new ArgumentException("Date of birth is too far in the past");
            }

            _dateOfBirth = value;
        }
    }
    public Gender Gender
    {
        get
        {
            return _gender;
        }
        private set
        {
            if (!Enum.IsDefined(typeof(Gender), value))
            {
                throw new ArgumentException("Invalid Gender value");
            }

            _gender = value;
        }
    }
    public BloodType BloodType
    {
        get
        {
            return _bloodType;
        }
        private set
        {
            if (!Enum.IsDefined(typeof(Gender), value))
            {
                throw new ArgumentException("Invalid BloodType value");
            }

            _bloodType = value;
        }
    }
    #endregion

    #region Constructors
    public Patient(string name, string email, string phoneNumber, DateTime dateOfBirth, Gender gender, BloodType bloodType) {
        if (string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException("Name cannot be empty");
        _name = name;

        if (string.IsNullOrWhiteSpace(email)) throw new ArgumentNullException("Email cannot be empty");

        if (!IsValidEmail(email))
        {
            throw new ArgumentException("Invalid email format");
        }
        _email = email;

        if (string.IsNullOrWhiteSpace(phoneNumber)) throw new ArgumentNullException("Phone number cannot be empty");

        if (!IsValidPhoneNumber(phoneNumber))
        {
            throw new ArgumentException("Invalid phone number format");
        }
        _phoneNumber = phoneNumber;

        if (dateOfBirth == default(DateTime)) throw new ArgumentNullException("Date of birth cannot be empty");

        if (dateOfBirth > DateTime.Now)
        {
            throw new ArgumentException("Date of birth cannot be in the future");
        }

        if (DateTime.Now.Year - dateOfBirth.Year > 150)
        {
            throw new ArgumentException("Date of birth is too far in the past");
        }
        _dateOfBirth = dateOfBirth;

        if (!Enum.IsDefined(typeof(Gender), gender))
        {
            throw new ArgumentException("Invalid Gender value");
        }
        _gender = gender;

        if (!Enum.IsDefined(typeof(BloodType), bloodType))
        {
            throw new ArgumentException("Invalid BloodType value");
        }
        _bloodType = bloodType;
    }
    #endregion

    #region Methods
    public IEnumerable<Appointment> getAppointments()
    {
        return _appointments;
    }

    public void MakeAppointment(string reason, string note, Doctor doctor, TimeSlot timeSlot)
    {
        Appointment appointment = doctor.GetTimeSlots().FirstOrDefault(timeSlot).CreateAppointment(this, reason, note);
        _appointments.Add(appointment);
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