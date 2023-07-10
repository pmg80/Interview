using System;
using System.Collections.Generic;

namespace Interview.Models;

public partial class User
{
    public long Id { get; set; }

    public DateTime InsDate { get; set; }

    public long RoleId { get; set; }

    public long PersonId { get; set; }

    public string UserName { get; set; } = null!;

    public string Password { get; set; } = null!;

    public virtual Person Person { get; set; } = null!;

    public virtual Role Role { get; set; } = null!;
}
