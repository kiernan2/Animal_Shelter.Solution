using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace Animal_Shelter.Models
{
  public class Animal
  {
    public string Description { get; set; }
    public int AnimalId { get; set; }
  }
}