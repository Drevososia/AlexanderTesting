using System;
using System.Collections.Generic;

namespace AlexanderTesting.Models;

public partial class PolycyType
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Policy> Policies { get; set; } = new List<Policy>();
}
