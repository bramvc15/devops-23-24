namespace Domain;

public class Patient
{
    #region Fields
    private string _name;
    private string _email;
    private string _phoneNumber;
    private DateTime _dateOfBirth;
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
            // TODO additional email validation
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
            _phoneNumber = value;
            // TODO additional phone number validation
        }
    }
    public DateTime DateOfBirth {
        get 
        {
            return _dateOfBirth;
        }
        private set
        { 
            if(value == null) throw new ArgumentNullException("Date of birth cannot be empty");
            // TODO additional date of birth validation
            _dateOfBirth = value;
        }
    }
    public Gender Gender { get; private set; }
    public BloodType BloodType { get; private set; }
    #endregion

    #region Constructors
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
    public IEnumerable<Appointment> getAppointments()
    {
        return _appointments;
    }
        public void MakeAppointment()
    {
        // TODO implement
    }
    #endregion
}