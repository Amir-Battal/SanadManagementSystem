using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SanadManagementSystem.Data;
using SanadManagementSystem.Dtos.Activities;
using SanadManagementSystem.Entites;

namespace SanadManagementSystem.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserActivityController : Controller
{
    private readonly DataContext _context;

    public UserActivityController(DataContext context)
    {
        _context = context;
    }
        
    [HttpGet("{userId}")]
    public async Task<ActionResult<List<GetUserActivityDto>>> GetUserActivities(int userId)
    {
        var userActivities = await _context.UserActivities.ToListAsync();
        var user = await _context.Users.FirstOrDefaultAsync(e => e.Id == userId);

        var userActivitiesDto = new List<GetUserActivityDto>();

        foreach (var userActivity in userActivities)
        {
            if (userActivity.UserId == userId)
            {
                var activity = await _context.Activities.FirstOrDefaultAsync(e => e.Id == userActivity.ActivityId);

                var userActivityDto = new GetUserActivityDto()
                {
                    Name = user.Name,
                    Email = user.Email,
                    Title = activity.Title,
                    Description = activity.Description,
                    Category = activity.Category
                };
                userActivitiesDto.Add(userActivityDto);
            }
        }
        if (userActivitiesDto.Count == 0  )
        {
            return NotFound("No activities found for the user.");
                
        }
        return Ok(userActivitiesDto);
    }

    [HttpGet("GetUserFavActivity")]
    public async Task<ActionResult<GetUserActivityDto>> GetUserFavActivity(int userId)
    {
        var userActivities = await _context.UserActivities.ToListAsync();
        var user = await _context.Users.FirstOrDefaultAsync(e => e.Id == userId);

        var userActivitiesDto = new List<GetUserActivityDto>();

        foreach (var userActivity in userActivities)
        {
            if (userActivity.UserId == userId && userActivity.isFavorite == true)
            {
                var activity = await _context.Activities.FirstOrDefaultAsync(e => e.Id == userActivity.ActivityId);

                
                var userActivityDto = new GetUserActivityDto()
                {
                    Name = user.Name,
                    Email = user.Email,
                    Title = activity.Title,
                    Description = activity.Description,
                    Category = activity.Category
                };
                userActivitiesDto.Add(userActivityDto);
            }
        }
        if (userActivitiesDto.Count == 0  )
        {
            return NotFound("No activities found for the user.");
                
        }
        return Ok(userActivitiesDto);
    }
    
    [HttpPost]
    public async Task<ActionResult<UserActivity>> AddUserActivity([FromForm] AddUserActivityDto userActivityDto)
    {
        var user = await _context.Users.FirstOrDefaultAsync(e => e.Id == userActivityDto.userId);
        var activity = await _context.Activities.FirstOrDefaultAsync(e => e.Id == userActivityDto.activityId);

        if (user == null || activity == null)
        {
            return NotFound("User or Activity not found.");
        }
        

        var userActivity = new UserActivity()
        {
            UserId = userActivityDto.userId,
            ActivityId = userActivityDto.activityId,
            BucketMoney = userActivityDto.bucketMoney,
            isFavorite = userActivityDto.isFavorite
        };

        _context.UserActivities.Add(userActivity);
        await _context.SaveChangesAsync();

        return Ok("Activity added to user Successfully");
    }

    
}