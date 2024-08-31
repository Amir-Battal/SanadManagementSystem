namespace SanadManagementSystem.Entites;

public class UserActivity
{
    public int UserId { get; set; }
    public int ActivityId { get; set; }
    
    public int BucketMoney { get; set; }
    public bool isFavorite { get; set; }
    
    public User User { get; set; } // Navigation property to User
    public Activity Activity { get; set; } // Navigation property to Activity
}
