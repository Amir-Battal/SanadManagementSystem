using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SanadManagementSystem.Data;
using SanadManagementSystem.Dtos.ActivityEmployees;
using SanadManagementSystem.Entites;

namespace SanadManagementSystem.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ActivityEmployeeController : Controller
{
    private readonly DataContext _context;

    public ActivityEmployeeController(DataContext context)
    {
        _context = context;
    }

    [HttpGet("{employeeId}")]
    public async Task<ActionResult<List<GetActivityEmployeeDto>>> GetActivityEmploees(int employeeId)
    {
        var activityEmployees = await _context.ActivityEmployees.ToListAsync();
        var employee = await _context.Employees.FirstOrDefaultAsync(e => e.Id == employeeId);
        var user = await _context.Users.FirstOrDefaultAsync(m => m.Id == employee.UserId);

        var activityEmployeesDto = new List<GetActivityEmployeeDto>();

        foreach (var activityEmployee in activityEmployees)
        {
            var activity = await _context.Activities.FirstOrDefaultAsync(e => e.Id == activityEmployee.ActivityId);

            var activityEmployeeDto = new GetActivityEmployeeDto()
            {
                Name = user.Name,
                Email = user.Email,
                Title = activity.Title,
                Description = activity.Description,
                Category = activity.Category,
                isCoach = employee.isCoach,
                Salary = employee.Salary,
                Hours = employee.Hours
            };
            activityEmployeesDto.Add(activityEmployeeDto);
        }

        if (activityEmployees.Count == 0)
        {
            return NotFound("No Activities found for the employee.");
        }

        return Ok(activityEmployeesDto);
    }

    [HttpPost]
    public async Task<ActionResult<ActivityEmployee>> AddActivityEmployee([FromForm] AddActivityEmployerDto activityEmployee)
    {
        var employee = await _context.Employees.FirstOrDefaultAsync(e => e.Id == activityEmployee.EmployeeId);
        var activity = await _context.Activities.FirstOrDefaultAsync(e => e.Id == activityEmployee.ActivityId);

        if (employee == null || activity == null)
        {
            return NotFound("Employee or Activity not found.");
        }

        var activityEmploye = new ActivityEmployee()
        {
            EmployeeId = activityEmployee.EmployeeId,
            ActivityId = activityEmployee.ActivityId
        };

        _context.ActivityEmployees.Add(activityEmploye);
        await _context.SaveChangesAsync();

        return Ok("Activity added to employee Successfully");
    }
}