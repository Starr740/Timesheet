using Microsoft.EntityFrameworkCore;

namespace AspNetCore {
  public class ApplicationDbContext : DbContext
  {
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    { }

    public DbSet<Timesheet> Timesheets { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Supervisor_Table> Supervisors { get; set; }
    public DbSet<Project> Projects { get; set; }
    public DbSet<ProjectSupervisor> ProjectSupervisors { get; set; }
  }
}