using Enums;
namespace Shared;

public class DoctorDTO
{
    public int? Id { get; set; }
    public string Name { get; set; }
    public string Specialization { get; set; }
    public Gender Gender { get; set; }
    public string Biograph { get; set; }
    public bool IsAvailable { get; set; }
    public string ImageLink { get; set; }
}