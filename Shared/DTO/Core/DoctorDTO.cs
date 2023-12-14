using Shared.Enums;
namespace Shared.DTO.Core;

public class DoctorDTO
{
    public int? Id { get; set; }
    public string Name { get; set; }
    public string Specialization { get; set; }
    public Gender Gender { get; set; }
    public string Biograph { get; set; }
    public bool IsAvailable { get; set; }
    public string ImageLink { get; set; }
    public string Auth0Id { get; set; }
}