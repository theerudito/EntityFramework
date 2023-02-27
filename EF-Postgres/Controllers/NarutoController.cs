using EF_Postgres.DBContext;
using EF_Postgres.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EF_Postgres.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class NarutoController : Controller
  {
    private readonly DB_Context context;

    public NarutoController(DB_Context context)
    {
      this.context = context;
    }

    [HttpGet]
    public async Task<ActionResult<List<Character>>> GET_ALL_CHARACTER()
    {
      return await context.Characters.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Character>> GET_CHARACTER_BYID(int id)
    {
      var character = await context.Characters.FirstOrDefaultAsync(x => x.Id == id);

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
    public async Task<IActionResult> PUT_CHARACTER([FromBody] Character character, int id)
    {
      if (character.Id != id)
      {
        return BadRequest();
      }
      context.Entry(character).State = EntityState.Modified;
      await context.SaveChangesAsync();
      return Ok(character);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DELETE_CHARACTER(int id)
    {
      var character = await context.Characters.FirstOrDefaultAsync(x => x.Id == id);

      if (character == null)
      {
        return Ok("the character not exist");
      }

      context.Characters.Remove(character);
      await context.SaveChangesAsync();

      return Ok("the character was deleted");
    }
  }
}
