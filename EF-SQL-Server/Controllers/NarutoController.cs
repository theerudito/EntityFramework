using System;
using EF_SQL_Server.DBContext;
using EF_SQL_Server.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EF_SQL_Server.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class NarutoController : Controller
  {
    public readonly DB_Context context;

    public NarutoController(DB_Context context)
    {
      this.context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Character>>> GET_ALL_CHARACTER()
    {
      return await context.Characters.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Character>> GET_CHARACTER_BY_ID(int id)
    {
      var character = await context.Characters.FindAsync(id);

      if (character == null)
      {
        return Ok("the character not exist");
      }

      return character;
    }

    [HttpPost]
    public async Task<ActionResult<Character>> POST_CHARACTER([FromBody] Character character)
    {
      context.Characters.Add(character);
      await context.SaveChangesAsync();

      return Ok(character);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PUT_CHARACTER(int id, [FromBody] Character character)
    {
      if (id != character.Id)
      {
        return Ok("the character not exist");
      }

      context.Entry(character).State = EntityState.Modified;
      await context.SaveChangesAsync();

      return Ok(character);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DELETE_CHARACTER(int id)
    {
      var character = await context.Characters.FindAsync(id);

      if (character == null)
      {
        return Ok("the character not exist");
      }

      context.Characters.Remove(character);
      await context.SaveChangesAsync();

      return Ok("the character has been deleted");
    }
  }
}
