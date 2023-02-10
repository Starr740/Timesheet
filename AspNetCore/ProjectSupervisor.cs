using System;

namespace AspNetCore
{
  public class ProjectSupervisor
  {
    public int Id { get; set; }
    public int Project_Id { get; set; }
    public int Supervisor_Id { get; set; }

    public Project Projects { get; set; }
    public Supervisor_Table Supervisors { get; set; }
  }
}