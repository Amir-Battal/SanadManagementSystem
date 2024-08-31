using SanadManagementSystem.Entites;

namespace SanadManagementSystem.Dtos.Users;

public class GetUserDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    
    // public Employee? Employee { get; set; }
    public bool isCoach { get; set; }
    public int Salary { get; set; }
    public int Hours { get; set; }
}