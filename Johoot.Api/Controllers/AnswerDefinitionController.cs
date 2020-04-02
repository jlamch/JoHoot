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
    public class AnswerDefinitionController : ControllerBase
    {
        private readonly ILogger<AnswerDefinitionController> _logger;
        private readonly IAnswerRepository _repository;

        public AnswerDefinitionController(
            ILogger<AnswerDefinitionController> logger,
            IAnswerRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IList<Answer>>> GetAll()
        {
            return Ok(await _repository.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Answer>> Get(long id)
        {
            return Ok(await _repository.FindById(id));
        }


        [HttpPost]
        public async Task<ActionResult<Answer>> Create(Answer item)
        {
            //do some conversion from dto? no we use shared model for now

            var created = await _repository.Create(item);
            return CreatedAtAction(
                nameof(Answer),
                new { id = created.Id },
                created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(long id, Answer item)
        {
            if (id != item.Id)
            {
                return BadRequest();
            }

            var updated = await _repository.Update(item);
            if (updated == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
