using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AspNetCore.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class ProjectSupervisorController : ControllerBase
  {
    private readonly ApplicationDbContext _dbContext;

    public ProjectSupervisorController(ApplicationDbContext dbContext)
    {
      _dbContext = dbContext;
    }

    // GET api/projectsupervisors
    [HttpGet]
    public async Task<ActionResult<List<ProjectSupervisor>>> Get()
    {
      return await _dbContext.ProjectSupervisors.ToListAsync();
    }

    // GET api/projectsupervisor/5
    [HttpGet("task/{id}")]
    public async Task<ActionResult<ProjectSupervisor>> Get(int id)
    {
      return await _dbContext.ProjectSupervisors.FindAsync(id);
    }

    // POST api/projectsupervisors
    [HttpPost]
    public async Task Post(ProjectSupervisor model)
    {
      await _dbContext.AddAsync(model);
      
      await _dbContext.SaveChangesAsync();
    }

    // PUT api/projectsupervisor/5
    [HttpPut("editTask/{id}")]
    public async Task<ActionResult> Put_edit_tasks(int id, ProjectSupervisor model)
    {
      var exists = await _dbContext.ProjectSupervisors.AnyAsync(f => f.Id == id);
      if (!exists)
      {
        return NotFound();
      }

      _dbContext.ProjectSupervisors.Update(model);
      
      await _dbContext.SaveChangesAsync();

      return Ok();

    }

    // DELETE api/projectsupervisor/5
    [HttpDelete("remove/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
      var entity = await _dbContext.ProjectSupervisors.FindAsync(id);

      _dbContext.ProjectSupervisors.Remove(entity);
      
      await _dbContext.SaveChangesAsync();
      
      return Ok();
    }
  }
}
