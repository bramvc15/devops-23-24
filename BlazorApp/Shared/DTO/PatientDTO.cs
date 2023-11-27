namespace Domain
{
    public class PatientDTO
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Gender gender { get; set; }
        public BloodType bloodType { get; set; }
    }
}