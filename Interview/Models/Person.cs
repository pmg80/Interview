using System;
using System.Collections.Generic;

namespace Interview.Models;

public partial class Person
{
    public long Id { get; set; }

    public DateTime InsDate { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string NationalCode { get; set; } = null!;

    public long PhoneNumber { get; set; }

    public string? Email { get; set; }

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
