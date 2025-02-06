using System;
using System.Collections.Generic;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Entities;

public partial class FtownContext : DbContext
{
    public FtownContext()
    {
    }

    public FtownContext(DbContextOptions<FtownContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Account> Accounts { get; set; }

    public virtual DbSet<AccountInterest> AccountInterests { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<CustomerDetail> CustomerDetails { get; set; }

    public virtual DbSet<DeliveryTracking> DeliveryTrackings { get; set; }

    public virtual DbSet<Document> Documents { get; set; }

    public virtual DbSet<Feedback> Feedbacks { get; set; }

    public virtual DbSet<Interest> Interests { get; set; }

    public virtual DbSet<InventoryImport> InventoryImports { get; set; }

    public virtual DbSet<InventoryImportDetail> InventoryImportDetails { get; set; }

    public virtual DbSet<InventoryTransaction> InventoryTransactions { get; set; }

    public virtual DbSet<InventoryTransactionDetail> InventoryTransactionDetails { get; set; }

    public virtual DbSet<Notification> Notifications { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderDetail> OrderDetails { get; set; }

    public virtual DbSet<Payment> Payments { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductVariant> ProductVariants { get; set; }

    public virtual DbSet<ReplyFeedback> ReplyFeedbacks { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Sale> Sales { get; set; }

    public virtual DbSet<Store> Stores { get; set; }

  

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>(entity =>
        {
            entity.HasKey(e => e.AccountId).HasName("PK__Account__349DA586422999BF");

            entity.ToTable("Account");

            entity.HasIndex(e => e.Email, "UQ__Account__A9D10534A4A7C52E").IsUnique();

            entity.Property(e => e.AccountId).HasColumnName("AccountID");
            entity.Property(e => e.Address).HasMaxLength(255);
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Email).HasMaxLength(255);
            entity.Property(e => e.FullName).HasMaxLength(255);
            entity.Property(e => e.ImageUrl).HasColumnName("ImageURL");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.PasswordHash).HasMaxLength(255);
            entity.Property(e => e.PhoneNumber).HasMaxLength(15);
            entity.Property(e => e.RoleId).HasColumnName("RoleID");

            entity.HasOne(d => d.Role).WithMany(p => p.Accounts)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Account__RoleID__3D5E1FD2");
        });

        modelBuilder.Entity<AccountInterest>(entity =>
        {
            entity.HasKey(e => e.AccountInterestId).HasName("PK__AccountI__E2B286B12862E304");

            entity.Property(e => e.AccountInterestId).HasColumnName("AccountInterestID");
            entity.Property(e => e.AccountId).HasColumnName("AccountID");
            entity.Property(e => e.InteractionCount).HasDefaultValue(0);
            entity.Property(e => e.InterestId).HasColumnName("InterestID");
            entity.Property(e => e.LastInteractionDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.Account).WithMany(p => p.AccountInterests)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__AccountIn__Accou__5165187F");

            entity.HasOne(d => d.Interest).WithMany(p => p.AccountInterests)
                .HasForeignKey(d => d.InterestId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__AccountIn__Inter__52593CB8");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("PK__Category__19093A2B2C0D5BA9");

            entity.ToTable("Category");

            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            entity.Property(e => e.Description).HasMaxLength(255);
            entity.Property(e => e.ImageUrl).HasColumnName("ImageURL");
            entity.Property(e => e.Name).HasMaxLength(255);
        });

        modelBuilder.Entity<CustomerDetail>(entity =>
        {
            entity.HasKey(e => e.CustomerDetailId).HasName("PK__Customer__D04B36FE4C0571B3");

            entity.ToTable("CustomerDetail");

            entity.Property(e => e.CustomerDetailId).HasColumnName("CustomerDetailID");
            entity.Property(e => e.AccountId).HasColumnName("AccountID");
            entity.Property(e => e.LoyaltyPoints).HasDefaultValue(0);
            entity.Property(e => e.MembershipLevel)
                .HasMaxLength(50)
                .HasDefaultValue("Basic");

            entity.HasOne(d => d.Account).WithMany(p => p.CustomerDetails)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CustomerD__Accou__403A8C7D");
        });

        modelBuilder.Entity<DeliveryTracking>(entity =>
        {
            entity.HasKey(e => e.TrackingId).HasName("PK__Delivery__3C19EDD111D136A7");

            entity.ToTable("DeliveryTracking");

            entity.Property(e => e.TrackingId).HasColumnName("TrackingID");
            entity.Property(e => e.CurrentLocation).HasMaxLength(255);
            entity.Property(e => e.LastUpdated)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.OrderId).HasColumnName("OrderID");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .HasDefaultValue("In Transit");

            entity.HasOne(d => d.Order).WithMany(p => p.DeliveryTrackings)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__DeliveryT__Order__02084FDA");
        });

        modelBuilder.Entity<Document>(entity =>
        {
            entity.HasKey(e => e.DocumentId).HasName("PK__Document__1ABEEF6F6CD29FF7");

            entity.ToTable("Document");

            entity.Property(e => e.DocumentId).HasColumnName("DocumentID");
            entity.Property(e => e.TransactionId).HasColumnName("TransactionID");
            entity.Property(e => e.UploadedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.Transaction).WithMany(p => p.Documents)
                .HasForeignKey(d => d.TransactionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Document__Transa__6EF57B66");

            entity.HasOne(d => d.UploadedByNavigation).WithMany(p => p.Documents)
                .HasForeignKey(d => d.UploadedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Document__Upload__6FE99F9F");
        });

        modelBuilder.Entity<Feedback>(entity =>
        {
            entity.HasKey(e => e.FeedbackId).HasName("PK__Feedback__6A4BEDF6464B085D");

            entity.ToTable("Feedback");

            entity.Property(e => e.FeedbackId).HasColumnName("FeedbackID");
            entity.Property(e => e.AccountId).HasColumnName("AccountID");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.ImageUrl).HasColumnName("ImageURL");
            entity.Property(e => e.ProductId).HasColumnName("ProductID");

            entity.HasOne(d => d.Account).WithMany(p => p.Feedbacks)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Feedback__Accoun__06CD04F7");

            entity.HasOne(d => d.Product).WithMany(p => p.Feedbacks)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Feedback__Produc__07C12930");
        });

        modelBuilder.Entity<Interest>(entity =>
        {
            entity.HasKey(e => e.InterestId).HasName("PK__Interest__20832C0739F97575");

            entity.Property(e => e.InterestId).HasColumnName("InterestID");
            entity.Property(e => e.Name).HasMaxLength(255);
        });

        modelBuilder.Entity<InventoryImport>(entity =>
        {
            entity.HasKey(e => e.ImportId).HasName("PK__Inventor__8697678AED69BFA5");

            entity.ToTable("InventoryImport");

            entity.Property(e => e.ImportId).HasColumnName("ImportID");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .HasDefaultValue("Pending");
            entity.Property(e => e.StoreId).HasColumnName("StoreID");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.InventoryImports)
                .HasForeignKey(d => d.CreatedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Inventory__Creat__5CD6CB2B");

            entity.HasOne(d => d.Store).WithMany(p => p.InventoryImports)
                .HasForeignKey(d => d.StoreId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Inventory__Store__5BE2A6F2");
        });

        modelBuilder.Entity<InventoryImportDetail>(entity =>
        {
            entity.HasKey(e => e.ImportDetailId).HasName("PK__Inventor__CDFBBA51F461AE9F");

            entity.Property(e => e.ImportDetailId).HasColumnName("ImportDetailID");
            entity.Property(e => e.ImportId).HasColumnName("ImportID");
            entity.Property(e => e.ProductVariantId).HasColumnName("ProductVariantID");

            entity.HasOne(d => d.Import).WithMany(p => p.InventoryImportDetails)
                .HasForeignKey(d => d.ImportId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Inventory__Impor__619B8048");

            entity.HasOne(d => d.ProductVariant).WithMany(p => p.InventoryImportDetails)
                .HasForeignKey(d => d.ProductVariantId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Inventory__Produ__628FA481");
        });

        modelBuilder.Entity<InventoryTransaction>(entity =>
        {
            entity.HasKey(e => e.TransactionId).HasName("PK__Inventor__55433A4B34BB86AF");

            entity.ToTable("InventoryTransaction");

            entity.Property(e => e.TransactionId).HasColumnName("TransactionID");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .HasDefaultValue("Pending");
            entity.Property(e => e.StoreId).HasColumnName("StoreID");
            entity.Property(e => e.TransactionType).HasMaxLength(50);

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.InventoryTransactions)
                .HasForeignKey(d => d.CreatedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Inventory__Creat__66603565");

            entity.HasOne(d => d.Store).WithMany(p => p.InventoryTransactions)
                .HasForeignKey(d => d.StoreId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Inventory__Store__656C112C");
        });

        modelBuilder.Entity<InventoryTransactionDetail>(entity =>
        {
            entity.HasKey(e => e.TransactionDetailId).HasName("PK__Inventor__F2B27FE6DDB426A7");

            entity.Property(e => e.TransactionDetailId).HasColumnName("TransactionDetailID");
            entity.Property(e => e.ProductVariantId).HasColumnName("ProductVariantID");
            entity.Property(e => e.TransactionId).HasColumnName("TransactionID");

            entity.HasOne(d => d.ProductVariant).WithMany(p => p.InventoryTransactionDetails)
                .HasForeignKey(d => d.ProductVariantId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Inventory__Produ__6C190EBB");

            entity.HasOne(d => d.Transaction).WithMany(p => p.InventoryTransactionDetails)
                .HasForeignKey(d => d.TransactionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Inventory__Trans__6B24EA82");
        });

        modelBuilder.Entity<Notification>(entity =>
        {
            entity.HasKey(e => e.NotificationId).HasName("PK__Notifica__20CF2E327AF57D82");

            entity.ToTable("Notification");

            entity.Property(e => e.NotificationId).HasColumnName("NotificationID");
            entity.Property(e => e.AccountId).HasColumnName("AccountID");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.IsRead).HasDefaultValue(false);

            entity.HasOne(d => d.Account).WithMany(p => p.Notifications)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Notificat__Accou__114A936A");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("PK__Order__C3905BAFAADC7144");

            entity.ToTable("Order");

            entity.Property(e => e.OrderId).HasColumnName("OrderID");
            entity.Property(e => e.AccountId).HasColumnName("AccountID");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .HasDefaultValue("Pending");
            entity.Property(e => e.StoreId).HasColumnName("StoreID");

            entity.HasOne(d => d.Account).WithMany(p => p.Orders)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Order__AccountID__73BA3083");

            entity.HasOne(d => d.Store).WithMany(p => p.Orders)
                .HasForeignKey(d => d.StoreId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Order__StoreID__74AE54BC");
        });

        modelBuilder.Entity<OrderDetail>(entity =>
        {
            entity.HasKey(e => e.OrderDetailId).HasName("PK__OrderDet__D3B9D30C130CF015");

            entity.Property(e => e.OrderDetailId).HasColumnName("OrderDetailID");
            entity.Property(e => e.OrderId).HasColumnName("OrderID");
            entity.Property(e => e.ProductVariantId).HasColumnName("ProductVariantID");

            entity.HasOne(d => d.Order).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__OrderDeta__Order__797309D9");

            entity.HasOne(d => d.ProductVariant).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.ProductVariantId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__OrderDeta__Produ__7A672E12");
        });

        modelBuilder.Entity<Payment>(entity =>
        {
            entity.HasKey(e => e.PaymentId).HasName("PK__Payment__9B556A582D602BF4");

            entity.ToTable("Payment");

            entity.Property(e => e.PaymentId).HasColumnName("PaymentID");
            entity.Property(e => e.Amount).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.OrderId).HasColumnName("OrderID");
            entity.Property(e => e.PaymentMethod).HasMaxLength(50);
            entity.Property(e => e.PaymentStatus)
                .HasMaxLength(50)
                .HasDefaultValue("Pending");
            entity.Property(e => e.TransactionDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.Order).WithMany(p => p.Payments)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Payment__OrderID__7D439ABD");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PK__Product__B40CC6EDC398458E");

            entity.ToTable("Product");

            entity.Property(e => e.ProductId).HasColumnName("ProductID");
            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            entity.Property(e => e.ImageUrl).HasColumnName("ImageURL");
            entity.Property(e => e.Name).HasMaxLength(255);

            entity.HasOne(d => d.Category).WithMany(p => p.Products)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("FK__Product__Categor__46E78A0C");
        });

        modelBuilder.Entity<ProductVariant>(entity =>
        {
            entity.HasKey(e => e.VariantId).HasName("PK__ProductV__0EA233E40E197CEB");

            entity.ToTable("ProductVariant");

            entity.Property(e => e.VariantId).HasColumnName("VariantID");
            entity.Property(e => e.Color).HasMaxLength(50);
            entity.Property(e => e.ImageUrl).HasColumnName("ImageURL");
            entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.ProductId).HasColumnName("ProductID");
            entity.Property(e => e.Size).HasMaxLength(5);

            entity.HasOne(d => d.Product).WithMany(p => p.ProductVariants)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ProductVa__Produ__49C3F6B7");
        });

        modelBuilder.Entity<ReplyFeedback>(entity =>
        {
            entity.HasKey(e => e.ReplyId).HasName("PK__ReplyFee__C25E4629CBF82F27");

            entity.ToTable("ReplyFeedback");

            entity.Property(e => e.ReplyId).HasColumnName("ReplyID");
            entity.Property(e => e.AccountId).HasColumnName("AccountID");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.FeedbackId).HasColumnName("FeedbackID");

            entity.HasOne(d => d.Account).WithMany(p => p.ReplyFeedbacks)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ReplyFeed__Accou__0D7A0286");

            entity.HasOne(d => d.Feedback).WithMany(p => p.ReplyFeedbacks)
                .HasForeignKey(d => d.FeedbackId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ReplyFeed__Feedb__0C85DE4D");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PK__Role__8AFACE3A45CF14F3");

            entity.ToTable("Role");

            entity.HasIndex(e => e.RoleName, "UQ__Role__8A2B61602FE35135").IsUnique();

            entity.Property(e => e.RoleId).HasColumnName("RoleID");
            entity.Property(e => e.Description).HasMaxLength(255);
            entity.Property(e => e.RoleName).HasMaxLength(255);
        });

        modelBuilder.Entity<Sale>(entity =>
        {
            entity.HasKey(e => e.SaleId).HasName("PK__Sale__1EE3C41FC68C171E");

            entity.ToTable("Sale");

            entity.Property(e => e.SaleId).HasColumnName("SaleID");
            entity.Property(e => e.BannerImageUrl).HasColumnName("BannerImageURL");
            entity.Property(e => e.DiscountRate).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.EndDate).HasColumnType("datetime");
            entity.Property(e => e.SaleName).HasMaxLength(255);
            entity.Property(e => e.StartDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<Store>(entity =>
        {
            entity.HasKey(e => e.StoreId).HasName("PK__Store__3B82F0E1F8AF3E52");

            entity.ToTable("Store");

            entity.HasIndex(e => e.ManagerId, "UQ__Store__3BA2AA80D2754E49").IsUnique();

            entity.Property(e => e.StoreId).HasColumnName("StoreID");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.ImageUrl).HasColumnName("ImageURL");
            entity.Property(e => e.Location).HasMaxLength(255);
            entity.Property(e => e.ManagerId).HasColumnName("ManagerID");
            entity.Property(e => e.StoreName).HasMaxLength(255);

            entity.HasOne(d => d.Manager).WithOne(p => p.Store)
                .HasForeignKey<Store>(d => d.ManagerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Store__ManagerID__5812160E");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
