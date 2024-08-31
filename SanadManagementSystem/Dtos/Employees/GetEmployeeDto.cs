namespace SanadManagementSystem.Dtos.Employees;

public class GetEmployeeDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    
    // public DateTime StartDate { get; set; }
    // public DateTime EndDate { get; set; }
    
    // public Employee? Employee { get; set; }
    public bool isCoach { get; set; }
    public int Salary { get; set; }
    public int Hours { get; set; }

    
}