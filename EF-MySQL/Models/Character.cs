using System;
using System.ComponentModel.DataAnnotations;

namespace EF_MySQL.Models
{
  public class Character
  {
    [Key]
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public string Clan { get; set; } = "";
    public int Age { get; set; }
  }
}
