using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AspNetCore.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class ProjectController : ControllerBase
  {
    private readonly ApplicationDbContext _dbContext;

    public ProjectController(ApplicationDbContext dbContext)
    {
      _dbContext = dbContext;
    }

    // GET api/projects
    [HttpGet]
    public async Task<ActionResult<List<Project>>> Get()
    {
      return await _dbContext.Projects.ToListAsync();
    }

    // GET api/projects/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Project>> Get(int id)
    {
      return await _dbContext.Projects.FindAsync(id);
    }

    // POST api/projects
    [HttpPost]
    public async Task Post(Project model)
    {
      await _dbContext.AddAsync(model);
      
      await _dbContext.SaveChangesAsync();
    }

    // PUT api/projects/5
    [HttpPut("{id}")]
    public async Task<ActionResult> Put_edit_tasks(int id, Project model)
    {
      var exists = await _dbContext.Projects.AnyAsync(f => f.Id == id);
      if (!exists)
      {
        return NotFound();
      }

      _dbContext.Projects.Update(model);
      
      await _dbContext.SaveChangesAsync();

      return Ok();

    }

    // DELETE api/projects/5
    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
      var entity = await _dbContext.Projects.FindAsync(id);

      _dbContext.Projects.Remove(entity);
      
      await _dbContext.SaveChangesAsync();
      
      return Ok();
    }
  }
}
