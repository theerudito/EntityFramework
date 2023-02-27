using System;
using EF_SQL_Server.Models;
using Microsoft.EntityFrameworkCore;

namespace EF_SQL_Server.DBContext
{
  public class DB_Context : DbContext
  {
    public DB_Context(DbContextOptions<DB_Context> options) : base(options)
    {
    }
    public DbSet<Character> Characters => Set<Character>();
  }
}
