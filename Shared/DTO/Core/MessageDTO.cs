using Shared.Enums;
namespace Shared.DTO.Core;

public class MessageDTO
{
    public int? Id { get; set; }
    public string Name { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public DateTime Birthdate { get; set; }
    public string Note { get; set; }

    public bool Read { get; set; }
}