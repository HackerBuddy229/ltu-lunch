using System.ComponentModel.DataAnnotations;

namespace LtuLunch.Shared.Models;

public class Resturant
{
    [Key] public readonly string Id = Guid.NewGuid().ToString();


    public string Name { get; set; }
    public string Description { get; set; }

    public IList<Lunch> Menu { get; set; }
    public IList<OpeningHours> OpeningHours { get; set; } = new List<OpeningHours>();
}

