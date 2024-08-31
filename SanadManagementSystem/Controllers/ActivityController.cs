using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SanadManagementSystem.Data;
using SanadManagementSystem.Dtos.Activities;
using SanadManagementSystem.Entites;

namespace SanadManagementSystem.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ActivityController : Controller
{
    private readonly DataContext _context;

    public ActivityController(DataContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<List<Activity>>> GetAllActivity()
    {
        var activities = await _context.Activities.ToListAsync();

        return Ok(activities);
    }

    [HttpGet("id")]
    public async Task<ActionResult<GetActivityDto>> GetActivityById(int id)
    {
        var activity = await _context.Activities.FirstAsync(m => m.Id == id);

        var activityById = new GetActivityDto()
        {
            Id = activity.Id,
            Title = activity.Title,
            Description = activity.Description,
            Category = activity.Category
        };

        return Ok(activityById);
    }

    [HttpPost]
    public async Task<ActionResult<List<Activity>>> AddActivity([FromForm] AddActivityDto addActivity)
    {
        var activity = new Activity()
        {
            Id = addActivity.Id,
            Title = addActivity.Title,
            Description = addActivity.Description,
            Category = addActivity.Category,
            Budget = addActivity.Budget
        };

        _context.Activities.Add(activity);
        await _context.SaveChangesAsync();

        return Ok(await _context.Activities.ToListAsync());
    }
    
}