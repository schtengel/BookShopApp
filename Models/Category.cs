using System;
using System.Collections.Generic;

namespace BookShopApp.Models;

public partial class Category
{
    public string Category1 { get; set; } = null!;

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
