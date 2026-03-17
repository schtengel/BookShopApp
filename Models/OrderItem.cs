using System;
using System.Collections.Generic;

namespace BookShopApp.Models;

public partial class OrderItem
{
    public string Articule { get; set; } = null!;

    public int? Count { get; set; }

    public int Id { get; set; }

    public virtual Product ArticuleNavigation { get; set; } = null!;

    public virtual Order IdNavigation { get; set; } = null!;
}
