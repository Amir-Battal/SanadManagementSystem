using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SanadManagementSystem.Data;
using SanadManagementSystem.Dtos.Employees;
using SanadManagementSystem.Entites;

namespace SanadManagementSystem.Controllers;


[Route("api/[controller]")]
[ApiController]
public class EmployeeController : Controller
{
    private readonly DataContext _context;

    public EmployeeController(DataContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<List<Activity>>> GetAllEmployees()
    {
        var employees = await _context.Employees.ToListAsync();
        var employeesDto = new List<GetEmployeeDto>(employees.Count);

        foreach (var employee in employees)
        {
            var user = await _context.Users.FirstOrDefaultAsync(m => m.Id == employee.UserId);

            var employeeDto = new GetEmployeeDto()
            {
                Id = employee.Id,
                Name = user.Name,
                Email = user.Email,
                isCoach = employee.isCoach,
                Salary = employee.Salary,
                Hours = employee.Hours  
            };
            employeesDto.Add(employeeDto);
        }

        return Ok(employeesDto);
    }

    [HttpGet("id")]
    public async Task<ActionResult<GetEmployeeDto>> GetEmployeeById(int id)
    {
        var employee = await _context.Employees.FirstOrDefaultAsync(m => m.Id == id);

        if (employee is null) return BadRequest("Employee not exist!");
        
        var user = await _context.Users.FirstAsync(m => m.Id == employee.UserId);


        var employeeById = new GetEmployeeDto()
        {
            Id = employee.Id,
            Name = user.Name,
            Email = user.Email,
            isCoach = employee.isCoach,
            Salary = employee.Salary,
            Hours = employee.Hours
        };

        return Ok(employeeById);
    }

    [HttpPost]
    public async Task<ActionResult<List<Employee>>> AddEmployee([FromForm] AddEmployeeDto addEmployee)
    {
        
        var employee = new Employee()
        {
            Id = addEmployee.Id,
            isCoach = addEmployee.isCoach,
            Salary = addEmployee.Salary,
            Hours = addEmployee.Hours,
            UserId = addEmployee.UserId
        };
        
        _context.Employees.Add(employee);
        await _context.SaveChangesAsync();

        return Ok(await _context.Employees.ToListAsync());
    }  
}