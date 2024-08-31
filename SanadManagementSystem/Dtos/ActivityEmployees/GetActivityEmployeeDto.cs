namespace SanadManagementSystem.Dtos.ActivityEmployees;

public class GetActivityEmployeeDto
{
    public string Name { get; set; }
    public string Email { get; set; }
    
    public string Title { get; set; }
    public string Description { get; set; }
    public string Category { get; set; }
    
    public bool isCoach { get; set; }
    public int Salary { get; set; }
    public int Hours { get; set; }  
}