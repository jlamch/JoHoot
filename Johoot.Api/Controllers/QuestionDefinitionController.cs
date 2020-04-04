using Johoot.Data;
using Johoot.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Johoot.Api.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class QuestionDefinitionController : ControllerBase
  {
    private readonly ILogger<QuestionDefinitionController> _logger;
    private readonly IQuestionRepository _repository;

    public QuestionDefinitionController(
        ILogger<QuestionDefinitionController> logger,
        IQuestionRepository repository)
    {
      _logger = logger;
      _repository = repository;
    }

    [HttpGet]
    public async Task<ActionResult<IList<Question>>> GetAll()
    {
      return Ok(await _repository.GetAll());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Question>> Get(long id)
    {
      return Ok(await _repository.FindById(id));
    }


    [HttpPost]
    public async Task<ActionResult<Question>> Create(Question item)
    {
      //do some conversion from dto? no we use shared model for now

      var created = await _repository.Create(item);
      return CreatedAtAction(
          nameof(Question),
          new { id = created.Id },
          created);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(long id, Question item)
    {
      if (id != item.Id)
      {
        return BadRequest();
      }

      var updated = await _repository.Update(item, id);
      if (updated == null)
      {
        return NotFound();
      }

      return NoContent();
    }
  }
}
