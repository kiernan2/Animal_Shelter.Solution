using System.Collections.Generic;

namespace  Animal_Shelter.Models
{
  public class Species
  {
    private static List<Species> _instances = new List<Species>();
    public string Name { get; set; }
    public int Id { get; }
    public List<Animal> Animals { get; set; }

    public Species(string speciesName)
    {
      Name = speciesName;
      _instances.Add(this);
      Id = _instances.Count;
      Items = new List<Animal>();
    }

    public static void ClearAll()
    {
      _instances.Clear();
    }

    public static List<Species> GetAll()
    {
      return _instances;
    }

    public static Category Find(int searchId)
    {
      return _instances[searchId - 1];
    }

    public static Category Find(int searchId)
    {
      return _instances[searchId - 1];
    }

    public void AddSpecies(Species species)
    {
      Species.Add(species);
    }
  }
}