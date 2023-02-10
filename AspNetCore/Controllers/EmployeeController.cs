using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AspNetCore.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class EmployeeController : ControllerBase
  {
    private readonly ApplicationDbContext _dbContext;

    public EmployeeController(ApplicationDbContext dbContext)
    {
      _dbContext = dbContext;
    }

    // GET api/employees
    [HttpGet]
    public async Task<ActionResult<List<Employee>>> Get()
    {
      return await _dbContext.Employees.ToListAsync();
    }

    // GET api/employees/5
    [HttpGet("task/{id}")]
    public async Task<ActionResult<Employee>> Get(int id)
    {
      return await _dbContext.Employees.FindAsync(id);
    }

    // POST api/employees
    [HttpPost]
    public async Task Post(Employee model)
    {
      await _dbContext.AddAsync(model);
      
      await _dbContext.SaveChangesAsync();
    }

    // PUT api/employees/5
    [HttpPut("editTask/{id}")]
    public async Task<ActionResult> Put_edit_tasks(int id, Employee model)
    {
      var exists = await _dbContext.Employees.AnyAsync(f => f.Id == id);
      if (!exists)
      {
        return NotFound();
      }

      _dbContext.Employees.Update(model);
      
      await _dbContext.SaveChangesAsync();

      return Ok();

    }

    // DELETE api/employees/5
    [HttpDelete("remove/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
      var entity = await _dbContext.Employees.FindAsync(id);

      _dbContext.Employees.Remove(entity);
      
      await _dbContext.SaveChangesAsync();
      
      return Ok();
    }
  }
}
