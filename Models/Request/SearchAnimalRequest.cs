using ZooManagement.Enums;

namespace ZooManagement.Models.Request;

public class SearchAnimalRequest
{
    public  string? Name { get; set; }
    public string? SpeciesName { get; set; }
 
  public string? ClassificationName { get; set; }

    public string? SexName { get; set; }
}
