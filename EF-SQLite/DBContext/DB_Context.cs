using System;
using EF_SQLite.Models;
using Microsoft.EntityFrameworkCore;

namespace EF_SQLite.DBContext
{
  public class DB_Context : DbContext
  {

    public DB_Context(DbContextOptions<DB_Context> options) : base(options)
    {
    }
    public DbSet<Naruto> Characters => Set<Naruto>();
  }
}
