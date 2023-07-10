using System;
using System.Collections.Generic;

namespace Interview.Models;

public partial class Role
{
    public long Id { get; set; }

    public DateTime InsDate { get; set; }

    public string Caption { get; set; } = null!;

    public string? Description { get; set; }

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
