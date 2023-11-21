namespace BlazorApp.Models;

public class Patient
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public Gender Gender { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public BloodGroup? BloodGroup { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Email { get; set; }
    public string? Allergies { get; set; }
}
