using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using NodaTime;

public class Resturant
{
    [Key] public string Id = Guid.NewGuid().ToString();


    public string Name { get; set; }
    public string Description { get; set; }

    public IList<Lunch> Menu { get; set; }
    
    public LocalTime OpensWhen { get; set; }
    public Period OpenFor { get; set; }
}

