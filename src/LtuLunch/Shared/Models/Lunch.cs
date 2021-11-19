using System.ComponentModel.DataAnnotations;

namespace LtuLunch.Shared.Models;

public class Lunch
{
    [Key]
    public readonly string Id = Guid.NewGuid().ToString();
    
    public string Title { get; set; }
    public string Description { get; set; }
    public string Resturant { get; init; }
    
    public DateTime When { get; set; }

    public IList<string> Tags { get; set; } = new List<string>();
    public float Price { get; set; }
}