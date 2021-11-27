using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public class Resturant
{
    [Key] public string Id = Guid.NewGuid().ToString();


    public string Name { get; set; }
    public string Description { get; set; }

    public IList<Lunch> Menu { get; set; }
    
    public TimeOnly OpensWhen { get; set; }
    public TimeSpan OpenFor { get; set; }
}

