using System;

namespace AspNetCore
{
  public class Super
  {
    public int Id { get; set; }
    public int Supervisor_TableId { get; set; }    
    public int SuperviseeId { get; set; }    

    public Supervisor_Table Supervisor_Table { get; set; }
    public Supervisee Supervisee { get; set; }
  }
}