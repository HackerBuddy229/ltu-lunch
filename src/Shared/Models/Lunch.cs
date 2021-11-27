using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public class Lunch
{
    [Key]
    public string Id = Guid.NewGuid().ToString();
    
    public string Title { get; set; }
    public string Description { get; set; }
    public Resturant Resturant { get; set; }
    
    public DateOnly When { get; set; }

    public IList<string> Tags { get; set; } = new List<string>();
    public float Price { get; set; }
}