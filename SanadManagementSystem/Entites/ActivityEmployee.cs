namespace SanadManagementSystem.Entites;

public class ActivityEmployee
{
    public int EmployeeId { get; set; }
    public int ActivityId { get; set; }
    
    public Employee Employee { get; set; } // Navigation property to Employee
    public Activity Activity { get; set; } // Navigation property to Activity
}
