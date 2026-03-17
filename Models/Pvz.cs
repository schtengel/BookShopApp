using System;
using System.Collections.Generic;

namespace BookShopApp.Models;

public partial class Pvz
{
    public string? Address { get; set; }

    public double Id { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
