using EF_SQLite.DBContext;
using EF_SQLite.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EF_SQLite.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class NarutoController : Controller
  {
    private readonly DB_Context context;

    public NarutoController(DB_Context context)
    {
      this.context = context;
    }

    [HttpGet]
    public async Task<ActionResult<List<Naruto>>> Get()
    {
      return await context.Characters.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Naruto>> Get(int id)
    {
      var character = await context.Characters.FirstOrDefaultAsync(x => x.Id == id);

      if (character == null)
      {
        return Ok("the character not exist");
      }
      return character;
    }

    [HttpPost]
    public async Task<ActionResult> Post([FromBody] Naruto value)
    {
      context.Characters.Add(value);
      await context.SaveChangesAsync();
      return Ok("the character was added");
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Put(int id, [FromBody] Naruto value)
    {
      if (value.Id == id)
      {
        context.Entry(value).State = EntityState.Modified;
        await context.SaveChangesAsync();
        return Ok("the character was updated");
      }
      else
      {
        return BadRequest("the id does not match");
      }
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
      var character = await context.Characters.FirstOrDefaultAsync(x => x.Id == id);
      if (character != null)
      {
        context.Characters.Remove(character);
        await context.SaveChangesAsync();
        return Ok("the character was deleted");
      }
      else
      {
        return BadRequest("the character was not found");
      }
    }
  }
}
