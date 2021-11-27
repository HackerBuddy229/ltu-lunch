using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public class Lunch
{
    [Key]
    public readonly string Id = Guid.NewGuid().ToString();
    
    public string Title { get; set; }
    public string Description { get; set; }
    public Resturant Resturant { get; init; }
    
    public DateTime When { get; set; }

    public IList<string> Tags { get; set; } = new List<string>();
    public float Price { get; set; }
}