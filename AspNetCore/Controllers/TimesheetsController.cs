using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AspNetCore.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class TimesheetsController : ControllerBase
  {
    private readonly ApplicationDbContext _dbContext;

    public TimesheetsController(ApplicationDbContext dbContext)
    {
      _dbContext = dbContext;
    }

    // GET api/foodrecords
    [HttpGet]
    public async Task<ActionResult<List<Timesheet>>> Get()
    {
      return await _dbContext.Timesheets.ToListAsync();
    }

    // GET api/foodrecords/5
    [HttpGet("task/{id}")]
    public async Task<ActionResult<Timesheet>> Get(int id)
    {
      return await _dbContext.Timesheets.FindAsync(id);
    }

       // public ActionResult Gettask()
// {
//    return Content("string task");
// }

     // GET api/foodrecords/5
    [HttpGet("s/{task}")]
    public async Task<ActionResult<Timesheet>> Get_tasks(string task)
    {
      return await _dbContext.Timesheets.FindAsync(task);
    }

    // POST api/foodrecords
    [HttpPost]
    public async Task Post(Timesheet model)
    {
      await _dbContext.AddAsync(model);
      
      await _dbContext.SaveChangesAsync();
    }

    // PUT api/foodrecords/5
    [HttpPut("editTask/{id}")]
    public async Task<ActionResult> Put_edit_tasks(int id, Timesheet model)
    {
      var exists = await _dbContext.Timesheets.AnyAsync(f => f.Id == id);
      if (!exists)
      {
        return NotFound();
      }

      _dbContext.Timesheets.Update(model);
      
      await _dbContext.SaveChangesAsync();

      return Ok();

    }

    // DELETE api/foodrecords/5
    [HttpDelete("remove/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
      var entity = await _dbContext.Timesheets.FindAsync(id);

      _dbContext.Timesheets.Remove(entity);
      
      await _dbContext.SaveChangesAsync();
      
      return Ok();
    }
  }
}
