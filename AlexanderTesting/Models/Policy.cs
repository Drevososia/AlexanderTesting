using System;
using System.Collections.Generic;

namespace AlexanderTesting.Models;

public partial class Policy
{
    public int Id { get; set; }

    public int? Type { get; set; }

    public string? Serial { get; set; }

    public string? Number { get; set; }

    public string? Enp { get; set; }

    public int? PersonId { get; set; }

    public virtual Person? Person { get; set; }

    public virtual PolycyType? TypeNavigation { get; set; }
}
