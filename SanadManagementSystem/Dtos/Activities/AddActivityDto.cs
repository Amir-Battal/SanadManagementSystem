namespace SanadManagementSystem.Dtos.Activities;

public class AddActivityDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Category { get; set; }
    public int Budget { get; set; }
    
}