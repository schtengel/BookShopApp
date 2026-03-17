using System;
using System.Collections.Generic;

namespace BookShopApp.Models;

public partial class User
{
    public string? Role { get; set; }

    public string? Fio { get; set; }

    public string Login { get; set; } = null!;

    public string? Password { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual Role? RoleNavigation { get; set; }
}
