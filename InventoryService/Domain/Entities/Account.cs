using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Account
{
    public int AccountId { get; set; }

    public string FullName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public string? PhoneNumber { get; set; }

    public string? Address { get; set; }

    public string? ImageUrl { get; set; }

    public DateTime? CreatedDate { get; set; }

    public bool? IsActive { get; set; }

    public int RoleId { get; set; }

    public virtual ICollection<AccountInterest> AccountInterests { get; set; } = new List<AccountInterest>();

    public virtual ICollection<CustomerDetail> CustomerDetails { get; set; } = new List<CustomerDetail>();

    public virtual ICollection<Document> Documents { get; set; } = new List<Document>();

    public virtual ICollection<Feedback> Feedbacks { get; set; } = new List<Feedback>();

    public virtual ICollection<InventoryImport> InventoryImports { get; set; } = new List<InventoryImport>();

    public virtual ICollection<InventoryTransaction> InventoryTransactions { get; set; } = new List<InventoryTransaction>();

    public virtual ICollection<Notification> Notifications { get; set; } = new List<Notification>();

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual ICollection<ReplyFeedback> ReplyFeedbacks { get; set; } = new List<ReplyFeedback>();

    public virtual Role Role { get; set; } = null!;

    public virtual Store? Store { get; set; }
}
