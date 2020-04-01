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
    public class QuizeDefinitionController : ControllerBase
    {
        private readonly ILogger<QuizeDefinitionController> _logger;
        private readonly IQuizeRepository _repository;

        public QuizeDefinitionController(
            ILogger<QuizeDefinitionController> logger,
            IQuizeRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IList<Quize>>> GetAll()
        {
            return Ok(await _repository.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Quize>> Get(long id)
        {
            return Ok(await _repository.GetQuize(id));
        }


        [HttpPost]
        public async Task<ActionResult<Quize>> Create(Quize item)
        {
            //do some conversion from dto? no we use shared model for now

            var created = await _repository.CreateQuize(item);
            return CreatedAtAction(
                nameof(Quize),
                new { id = created.Id },
                created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(long id, Quize item)
        {
            if (id != item.Id)
            {
                return BadRequest();
            }

            var updated = await _repository.UpdateQuize(item);
            if (updated == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
