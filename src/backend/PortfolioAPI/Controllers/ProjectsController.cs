using Microsoft.AspNetCore.Mvc;
using PortfolioAPI.Models;

namespace PortfolioAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProjectsController : ControllerBase
    {
        private static readonly List<Project> _projects = new();

        [HttpGet]
        public ActionResult<IEnumerable<Project>> Get()
        {
            return Ok(_projects);
        }

        [HttpPost]
        public ActionResult<Project> Post([FromBody] Project project)
        {
            project.Id = _projects.Count + 1;
            project.CreatedDate = DateTime.UtcNow;
            _projects.Add(project);
            return CreatedAtAction(nameof(Get), new { id = project.Id }, project);
        }
    }
}