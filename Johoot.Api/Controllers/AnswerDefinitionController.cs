﻿using Johoot.Api.DataDto;
using Johoot.Data;
using Johoot.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Johoot.Api.Controllers
{
  [ApiController]
  [Route(nameof(Answer))]
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

    [HttpGet("find/{questionId}")]
    public async Task<ActionResult<IList<Answer>>> GetByQuestionId(long questionId)
    {
      return Ok(await _repository.FindByQuestionId(questionId));
    }

    [HttpPost]
    public async Task<ActionResult<Answer>> Create(AnswerDto item, long questionId)
    {
      //do some conversion from dto? no we use shared model for now
      var na = new Answer
      {
        Id = item.Id,
        IsCorrect = item.IsCorrect,
        Text = item.Text
      };

      var created = await _repository.Create(na, questionId);
      return CreatedAtAction(
          nameof(Answer),
          new { id = created.Id },
          created);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(long id, AnswerDto item)
    {
      if (id != item.Id)
      {
        return BadRequest();
      }

      var na = new Answer
      {
        Id = item.Id,
        IsCorrect = item.IsCorrect,
        Text = item.Text
      };

      var updated = await _repository.Update(na, id);
      if (updated == null)
      {
        return NotFound();
      }

      return NoContent();
    }
  }
}
