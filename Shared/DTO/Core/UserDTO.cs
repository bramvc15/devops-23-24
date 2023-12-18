namespace Shared.DTO.Core;

public static class UserDTO
{
    public class Index
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool Blocked { get; set; }
    }
}