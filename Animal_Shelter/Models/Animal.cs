using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace Animal_Shelter.Models
{
  public class Animal
  {
    public string Description { get; set; }
    public int Id { get; set; }

    public Animal(string description)
    {
      Description = description;
    }

    public Animal(string description, int id)
    {
      Description = description;
      Id = id;
    }

    public static List<Animal> GetAll()
    {
      List<Animal> allAnimal = new List<Animal>();
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = "SELECT * FROM items;";
      MySqlDataReader rdr = cmd.ExecuteReader();

      while (rdr.Read())
      {
        int animalId = rdr.GetInt32(0);
        string animalDescription = rdr.GetString(1);
        Animal newAnimal = new Animal(animalDescription, animalId);
        allAnimal.Add(newAnimal);
      }

      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return allAnimal;
    }

    public override bool Equals(System.Object otherAnimal)
    {
      if (!(otherAnimal is Animal))
      {
        return false;
      }
      else
      {
        Animal newAnimal = (Animal) otherAnimal;
        bool idEquality = (this.Id == newAnimal.Id);
        bool descriptionEquality = (this.Description == newAnimal.Description);
        return (idEquality && descriptionEquality);
      }
    }

    public static void ClearAll()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = "DELETE FROM animals;";
      cmd.ExecuteNonQuery();
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }
  }
}