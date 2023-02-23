using System;

namespace AspNetCore
{
  public class Timesheet
  {
    public int Id { get; set; }
    public int Project_Id { get; set; }
    public string? Task { get; set; }
    public string? SupervisorId { get; set; }
    public DateOnly Date { get; set; }
    
    public int Hours { get; set; }
    public int Minutes { get; set; }
    public string? Status { get; set; }

    public Employee Employees { get; set; }
    public Project Projects { get; set; }
    public Supervisor_Table Supervisors { get; set; }
  }
}