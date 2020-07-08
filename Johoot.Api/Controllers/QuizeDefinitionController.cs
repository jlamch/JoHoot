using Johoot.Api.DataDto;
using Johoot.Data;
using Johoot.Infrastructure.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Johoot.Api.Controllers
{
  [ApiController]
  [Route(nameof(Quize))]
  public class QuizeDefinitionController : ControllerBase
  {
    private readonly ILogger<QuizeDefinitionController> _logger;
    private readonly IQuizeRepository _repository;

    public QuizeDefinitionController(
        ILogger<QuizeDefinitionController> logger,
        IOptions<JLSettingsOption> options,
        IQuizeRepository repository)
    {
      _logger = logger;
      _repository = repository;
    }

    [HttpGet]
    public async Task<ActionResult<IList<Quize>>> GetAll(bool includeAll = true)
    {
      return Ok(await _repository.GetAll(includeAll));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Quize>> Get(long id)
    {
      return Ok(await _repository.FindById(id));
    }


    [HttpPost]
    public async Task<ActionResult<Quize>> CreateAsync(QuizeDto item)
    {
      var q = new Quize
      {
        Id = item.Id,
        Description = item.Description,
        Name = item.Name
      };

      var created = await _repository.Create(q);

      return CreatedAtAction(
          nameof(this.Get),
          new { id = created.Id },
          created);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(long id, QuizeDto item)
    {
      if (id != item.Id)
      {
        return BadRequest();
      }

      var up = new Quize
      {
        Id = item.Id,
        Description = item.Description,
        Name = item.Name
      };

      var updated = await _repository.Update(up, id);
      if (updated == null)
      {
        return NotFound();
      }

      return NoContent();
    }
  }
}
