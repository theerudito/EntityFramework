using EF_Postgres.Models;
using Microsoft.EntityFrameworkCore;

namespace EF_Postgres.DBContext
{
  public class DB_Context : DbContext
  {
    public DB_Context(DbContextOptions<DB_Context> options) : base(options)
    {
    }
    public DbSet<Character> Characters => Set<Character>();
  }
}
