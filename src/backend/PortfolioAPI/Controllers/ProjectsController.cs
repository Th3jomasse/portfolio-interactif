using Microsoft.AspNetCore.Mvc;
using PortfolioAPI.Models;

namespace PortfolioAPI.Controllers
{
    // Controllers/ProjectsController.cs
    [ApiController]
    [Route("api/[controller]")]
    public class ProjectsController : ControllerBase
    {
        private static readonly List<Project> _projects = new();

        [HttpGet]
        public ActionResult<IEnumerable<Project>> GetAll()
        {
            return Ok(_projects);
        }

        [HttpGet("{id}")]
        public ActionResult<Project> GetById(int id)
        {
            var project = _projects.FirstOrDefault(p => p.Id == id);
            if (project == null)
                return NotFound();
            return Ok(project);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult<Project> Create(Project project)
        {
            project.Id = _projects.Count + 1;
            project.CreatedDate = DateTime.UtcNow;
            _projects.Add(project);
            return CreatedAtAction(nameof(GetById), new { id = project.Id }, project);
        }
    }
}