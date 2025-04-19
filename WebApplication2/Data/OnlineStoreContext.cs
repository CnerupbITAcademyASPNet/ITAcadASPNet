using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Models;

namespace WebApplication2.Data;

public partial class OnlineStoreContext : DbContext
{
    public OnlineStoreContext()
    {
    }

    public OnlineStoreContext(DbContextOptions<OnlineStoreContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ActiveUser> ActiveUsers { get; set; }

    public virtual DbSet<AdminLog> AdminLogs { get; set; }

    public virtual DbSet<Cart> Carts { get; set; }

    public virtual DbSet<CartItem> CartItems { get; set; }

    public virtual DbSet<ContentType> ContentTypes { get; set; }

    public virtual DbSet<Group> Groups { get; set; }

    public virtual DbSet<GroupPermission> GroupPermissions { get; set; }

    public virtual DbSet<Migration> Migrations { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderProduct> OrderProducts { get; set; }

    public virtual DbSet<OrderSummary> OrderSummaries { get; set; }

    public virtual DbSet<Permission> Permissions { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductStock> ProductStocks { get; set; }

    public virtual DbSet<Session> Sessions { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserPermission> UserPermissions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ActiveUser>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("ActiveUsers");

            entity.Property(e => e.Email).HasMaxLength(250);
            entity.Property(e => e.PasswordHash).HasMaxLength(250);
            entity.Property(e => e.UserId)
                .ValueGeneratedOnAdd()
                .HasColumnName("UserID");
            entity.Property(e => e.Username).HasMaxLength(50);
        });

        modelBuilder.Entity<AdminLog>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__AdminLog__5E5499A80D61BA50");

            entity.ToTable("AdminLog");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Action).HasMaxLength(100);
            entity.Property(e => e.Timestamp).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.User).WithMany(p => p.AdminLogs)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__AdminLog__UserID__5441852A");
        });

        modelBuilder.Entity<Cart>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Cart__51BCD797173590A7");

            entity.ToTable("Cart");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.User).WithMany(p => p.Carts)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Cart__UserID__5BE2A6F2");
        });

        modelBuilder.Entity<CartItem>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__CartItem__9AFC1BF95CD9EC98");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.CartId).HasColumnName("CartID");
            entity.Property(e => e.ProductId).HasColumnName("ProductID");
            entity.Property(e => e.Quantity).HasDefaultValue(1);

            entity.HasOne(d => d.Cart).WithMany(p => p.CartItems)
                .HasForeignKey(d => d.CartId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CartItems__CartI__6EF57B66");

            entity.HasOne(d => d.Product).WithMany(p => p.CartItems)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CartItems__Produ__6FE99F9F");
        });

        modelBuilder.Entity<ContentType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ContentT__2026066AD0C21EDA");

            entity.ToTable("ContentType");

            entity.HasIndex(e => e.TypeName, "UQ__ContentT__D4E7DFA8D941A4A7").IsUnique();

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("ID");
            entity.Property(e => e.PermissionId).HasColumnName("PermissionID");
            entity.Property(e => e.TypeName).HasMaxLength(100);

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.ContentType)
                .HasForeignKey<ContentType>(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ContentType_Permissions");
        });

        modelBuilder.Entity<Group>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Group__149AF30AF88539D0");

            entity.ToTable("Group");

            entity.HasIndex(e => e.Name, "UQ__Group__737584F67003E52A").IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Description).HasMaxLength(255);
            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<GroupPermission>(entity =>
        {
            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.GroupId).HasColumnName("GroupID");
            entity.Property(e => e.PermissionId).HasColumnName("PermissionID");

            entity.HasOne(d => d.Group).WithMany(p => p.GroupPermissions)
                .HasForeignKey(d => d.GroupId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GroupPermissions_Group");

            entity.HasOne(d => d.Permission).WithMany(p => p.GroupPermissions)
                .HasForeignKey(d => d.PermissionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GroupPermissions_Permissions");
        });

        modelBuilder.Entity<Migration>(entity =>
        {
            entity.HasKey(e => e.MigrationId).HasName("PK__Migratio__E5D3571BD7C7D102");

            entity.Property(e => e.MigrationId).HasColumnName("MigrationID");
            entity.Property(e => e.AppliedAt).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Name).HasMaxLength(255);
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Order__C3905BAF7DFC6219");

            entity.ToTable("Order");

            entity.HasIndex(e => e.Status, "IX_Order_Status");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreateDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.User).WithMany(p => p.Orders)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Order__UserID__6754599E");
        });

        modelBuilder.Entity<OrderProduct>(entity =>
        {
            entity.ToTable("OrderProduct");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.OrderId).HasColumnName("OrderID");
            entity.Property(e => e.ProductId).HasColumnName("ProductID");

            entity.HasOne(d => d.Order).WithMany(p => p.OrderProducts)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrderProduct_Order");

            entity.HasOne(d => d.Product).WithMany(p => p.OrderProducts)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrderProduct_Products");
        });

        modelBuilder.Entity<OrderSummary>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("OrderSummary");

            entity.Property(e => e.Email).HasMaxLength(250);
            entity.Property(e => e.OrderId).HasColumnName("OrderID");
            entity.Property(e => e.Status).HasMaxLength(50);
            entity.Property(e => e.TotalAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Username).HasMaxLength(50);
        });

        modelBuilder.Entity<Permission>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Permissi__EFA6FB0F90BF16F5");

            entity.HasIndex(e => e.Name, "UQ__Permissi__737584F60743A941").IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Description).HasMaxLength(255);
            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Products__B40CC6ED13F2B33D");

            entity.HasIndex(e => e.Name, "IX_Products_Name");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");
        });

        modelBuilder.Entity<ProductStock>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("ProductStock");

            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.ProductId)
                .ValueGeneratedOnAdd()
                .HasColumnName("ProductID");
        });

        modelBuilder.Entity<Session>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Session__C9F492707A618572");

            entity.ToTable("Session");

            entity.HasIndex(e => e.Token, "UQ__Session__1EB4F81754F21031").IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Token).HasMaxLength(255);
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.User).WithMany(p => p.Sessions)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Session__UserID__5FB337D6");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__User__1788CCAC6B96F509");

            entity.ToTable("User");

            entity.HasIndex(e => e.Email, "IX_User_Email");

            entity.HasIndex(e => e.Username, "UQ__User__536C85E49277AA7D").IsUnique();

            entity.HasIndex(e => e.Email, "UQ__User__A9D10534F2892B11").IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Email).HasMaxLength(250);
            entity.Property(e => e.PasswordHash).HasMaxLength(250);
            entity.Property(e => e.RegistrationDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Username).HasMaxLength(50);
        });

        modelBuilder.Entity<UserPermission>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__UserPerm__F972A31C805B5F86");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.PermissionId).HasColumnName("PermissionID");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.Permission).WithMany(p => p.UserPermissions)
                .HasForeignKey(d => d.PermissionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__UserPermi__Permi__6B24EA82");

            entity.HasOne(d => d.User).WithMany(p => p.UserPermissions)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__UserPermi__UserI__6A30C649");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
