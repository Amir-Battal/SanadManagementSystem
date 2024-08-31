using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SanadManagementSystem.Data;
using SanadManagementSystem.Dtos.Users;
using SanadManagementSystem.Entites;

namespace SanadManagementSystem.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : Controller
{
    private readonly DataContext _context;

    public UserController(DataContext context)
    {
        _context = context;
    }
    
    
    [HttpGet]
    public async Task<ActionResult<List<GetUserDto>>> GetAllUsers()
    {
        var users = await _context.Users.ToListAsync();
        var usersDto = new List<GetUserDto>(users.Count);

        foreach (var user in users)
        {
            var employee = await _context.Employees.FirstOrDefaultAsync(m => m.UserId == user.Id);

            if (employee != null)
            {
                user.Employee = new Employee()
                {
                    isCoach = employee.isCoach,
                    Salary = employee.Salary,
                    Hours = employee.Hours
                };
            }

            var userDto = new GetUserDto()
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                isCoach = user.Employee?.isCoach ?? false,
                Salary = user.Employee?.Salary ?? 0,
                Hours = user.Employee?.Hours ?? 0
            };
            usersDto.Add(userDto);
        }
        return Ok(usersDto);
    }

    [HttpGet("GetAllBeneficiaries")]
    public async Task<ActionResult<GetBeneficiaryDto>> GetAllBeneficiaries()
    {
        var users = await _context.Users.ToListAsync();
        var beneficiariesDto = new List<GetBeneficiaryDto>();
        
        foreach (var user in users)
        {
            var employee = await _context.Employees.FirstOrDefaultAsync(m => m.UserId == user.Id);
            if (employee is null)
            {
                var beneficiary = new GetBeneficiaryDto()
                {
                    Id = user.Id,
                    Name = user.Name,
                    Email = user.Email,
                };
                beneficiariesDto.Add(beneficiary);
            }
        }

        return Ok(beneficiariesDto);
    }
    
    
    [HttpGet("id")]
    public async Task<ActionResult<GetUserDto>> GetUserById(int id)
    {
        var user = await _context.Users.FirstAsync(m => m.Id == id);
        var employee = await _context.Employees.FirstOrDefaultAsync(m => m.UserId == id);

        
        var userById = new GetUserDto()
        {
            Id = user.Id,
            Name = user.Name,
            Email = user.Email,
        };

        if (employee != null)
        {
            userById.isCoach = employee.isCoach;
            userById.Salary = employee.Salary;
            userById.Hours = employee.Hours;
        }
        
        
        return Ok(userById);
    }

    [HttpPost]
    public async Task<ActionResult<List<User>>> AddUser([FromForm] AddUserDto addUser)
    {
        
        var user = new User()
        {
            Id = addUser.Id,
            Name = addUser.Name,
            Email = addUser.Email,
            Password = addUser.Password,
            
            // BrithDate = addUser.BrithDate
        };
        
        _context.Users.Add(user);
        await _context.SaveChangesAsync();

        return Ok(await _context.Users.ToListAsync());
    }
}