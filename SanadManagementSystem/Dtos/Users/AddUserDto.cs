using SanadManagementSystem.Entites;

namespace SanadManagementSystem.Dtos.Users;

public class AddUserDto 
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    // public DateTime BrithDate { get; set; }
}