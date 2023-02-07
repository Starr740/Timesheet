using System;

namespace AspNetCore
{
  public class Timesheet
  {
    public int Id { get; set; }
    public DateOnly Date { get; set; }
    public string? Task { get; set; }
    public string? Description { get; set; }
    public int Hours { get; set; }
    public int Minutes { get; set; }
  }
}