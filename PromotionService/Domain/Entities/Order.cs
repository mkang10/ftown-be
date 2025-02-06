using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Order
{
    public int OrderId { get; set; }

    public int AccountId { get; set; }

    public int StoreId { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? Status { get; set; }

    public virtual Account Account { get; set; } = null!;

    public virtual ICollection<DeliveryTracking> DeliveryTrackings { get; set; } = new List<DeliveryTracking>();

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();

    public virtual Store Store { get; set; } = null!;
}
