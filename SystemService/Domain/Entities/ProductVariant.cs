using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class ProductVariant
{
    public int VariantId { get; set; }

    public int ProductId { get; set; }

    public string? Size { get; set; }

    public string? Color { get; set; }

    public decimal? Price { get; set; }

    public int? StockQuantity { get; set; }

    public string? ImageUrl { get; set; }

    public virtual ICollection<InventoryImportDetail> InventoryImportDetails { get; set; } = new List<InventoryImportDetail>();

    public virtual ICollection<InventoryTransactionDetail> InventoryTransactionDetails { get; set; } = new List<InventoryTransactionDetail>();

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

    public virtual Product Product { get; set; } = null!;
}
