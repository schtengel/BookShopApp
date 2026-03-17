using System;
using System.Collections.Generic;

namespace BookShopApp.Models;

public partial class Product
{
    public string Articule { get; set; } = null!;

    public string? Title { get; set; }

    public string? EdIzm { get; set; }

    public double? Price { get; set; }

    public string? Supplier { get; set; }

    public string? Proizvoditel { get; set; }

    public string? Category { get; set; }

    public double? Sale { get; set; }

    public int? Count { get; set; }

    public string? Description { get; set; }

    public string? Photo { get; set; }

    public virtual Category? CategoryNavigation { get; set; }
}
