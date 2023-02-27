using System;

namespace EF_Postgres.Models
{
  public class Character
  {
    [System.ComponentModel.DataAnnotations.Key]
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public string Clan { get; set; } = "";
    public int Age { get; set; }
  }
}
