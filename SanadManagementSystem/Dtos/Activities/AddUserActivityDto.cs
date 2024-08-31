namespace SanadManagementSystem.Dtos.Activities;

public class AddUserActivityDto
{
    public int userId { get; set; }
    public int activityId { get; set; }
    
    public int bucketMoney { get; set; }
    public bool isFavorite { get; set; }
}