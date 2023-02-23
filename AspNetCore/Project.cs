using System;

namespace AspNetCore
{
  public class Project
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public string Funder { get; set; }
    public int Duration { get; set; }
    public DateOnly Start { get; set; }
    public DateOnly End { get; set; }
    public string? Status { get; set; }
  }
}