using Microsoft.EntityFrameworkCore;
using SanadManagementSystem.Entites;

namespace SanadManagementSystem.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Many-to-Many: User <-> Activity via UserActivity
        modelBuilder.Entity<UserActivity>()
            .HasKey(ua => new { ua.UserId, ua.ActivityId });
        modelBuilder.Entity<UserActivity>()
            .HasOne(ua => ua.User)
            .WithMany(u => u.Activities)
            .HasForeignKey(ua => ua.UserId);
        modelBuilder.Entity<UserActivity>()
            .HasOne(ua => ua.Activity)
            .WithMany(a => a.Users)
            .HasForeignKey(ua => ua.ActivityId);

        // Many-to-Many: Employee <-> Activity via ActivityEmployee
        modelBuilder.Entity<ActivityEmployee>()
            .HasKey(ae => new { ae.EmployeeId, ae.ActivityId });
        modelBuilder.Entity<ActivityEmployee>()
            .HasOne(ae => ae.Employee)
            .WithMany(e => e.Activities)
            .HasForeignKey(ae => ae.EmployeeId);
        modelBuilder.Entity<ActivityEmployee>()
            .HasOne(ae => ae.Activity)
            .WithMany(a => a.Employees)
            .HasForeignKey(ae => ae.ActivityId);
    }
    
    public DbSet<User> Users { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Activity> Activities { get; set; }
    
    public DbSet<UserActivity> UserActivities { get; set; } 
    public DbSet<ActivityEmployee> ActivityEmployees { get; set; } 

}