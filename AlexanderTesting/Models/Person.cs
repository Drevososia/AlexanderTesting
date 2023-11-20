using System;
using System.Collections.Generic;

namespace AlexanderTesting.Models;

public partial class Person
{
    public int Id { get; set; }

    public string? Firstname { get; set; }

    public string? Name { get; set; }

    public string? Patronymic { get; set; }

    public int? Age { get; set; }

    public DateTime? DateOfBirth { get; set; }

    public int? Gender { get; set; }

    public Policy? Policy { get; set; }
    public virtual Gender? GenderNavigation { get; set; }
}
