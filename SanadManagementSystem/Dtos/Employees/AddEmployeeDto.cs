namespace SanadManagementSystem.Dtos.Employees;

public class AddEmployeeDto
{
    public int Id { get; set; }

    // public DateTime StartDate { get; set; }
    // public DateTime EndDate { get; set; }
    public bool isCoach { get; set; }
    public int Salary { get; set; }
    public int Hours { get; set; }
    
    public int UserId { get; set; }

}