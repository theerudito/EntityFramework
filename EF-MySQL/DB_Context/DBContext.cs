using System;
using EF_MySQL.Models;
using Microsoft.EntityFrameworkCore;

namespace EF_MySQL.DB_Context
{
  public class DBContext : DbContext
  {
    public DBContext(DbContextOptions<DBContext> options) : base(options)
    {
    }
    public DbSet<Character> Characters => Set<Character>();
  }
}
