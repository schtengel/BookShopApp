using System;
using System.Collections.Generic;

namespace BookShopApp.Models;

public partial class Order
{
    public int Id { get; set; }

    public DateTime? DataZakaz { get; set; }

    public DateTime? DataDeliver { get; set; }

    public double? Address { get; set; }

    public string Fio { get; set; } = null!;

    public double? Code { get; set; }

    public string Status { get; set; } = null!;

    public virtual Pvz? AddressNavigation { get; set; }

    public virtual User FioNavigation { get; set; } = null!;

    public virtual Status StatusNavigation { get; set; } = null!;
}
