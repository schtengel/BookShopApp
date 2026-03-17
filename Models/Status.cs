using System;
using System.Collections.Generic;

namespace BookShopApp.Models;

public partial class Status
{
    public string Status1 { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
