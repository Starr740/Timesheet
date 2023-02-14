using System;

namespace AspNetCore
{
  public class Supervisee
  {
    public int Id { get; set; }
    public int Employee_Id { get; set; }

    public Employee Employees { get; set; }
  }
}