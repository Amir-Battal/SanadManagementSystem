namespace SanadManagementSystem.Entites;

public class Activity
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Category { get; set; }
    // public DateTime StartDate { get; set; }
    // public DateTime EndDate { get; set; }
    public int Budget { get; set; }

    public List<UserActivity>? Users { get; } = [];
    
    public List<ActivityEmployee>? Employees { get; } = [];
}