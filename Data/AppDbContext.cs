using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using BookShopApp.Models;

namespace BookShopApp.Data;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderItem> OrderItems { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Pvz> Pvzs { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Status> Statuses { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=BookShop;Trusted_Connection=true;TrustServerCertificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Category1);

            entity.ToTable("Category");

            entity.Property(e => e.Category1)
                .HasMaxLength(100)
                .HasColumnName("Category");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.ToTable("Order");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.DataDeliver).HasColumnType("datetime");
            entity.Property(e => e.DataZakaz).HasColumnType("datetime");
            entity.Property(e => e.Fio).HasMaxLength(150);
            entity.Property(e => e.Status).HasMaxLength(50);

            entity.HasOne(d => d.AddressNavigation).WithMany(p => p.Orders)
                .HasForeignKey(d => d.Address)
                .HasConstraintName("FK_Order_Pvz");

            entity.HasOne(d => d.FioNavigation).WithMany(p => p.Orders)
                .HasForeignKey(d => d.Fio)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Order_User");

            entity.HasOne(d => d.StatusNavigation).WithMany(p => p.Orders)
                .HasForeignKey(d => d.Status)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Order_Status");
        });

        modelBuilder.Entity<OrderItem>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.Articule).HasMaxLength(25);

            entity.HasOne(d => d.ArticuleNavigation).WithMany()
                .HasForeignKey(d => d.Articule)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrderItems_Product");

            entity.HasOne(d => d.IdNavigation).WithMany()
                .HasForeignKey(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrderItems_Order");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Articule);

            entity.ToTable("Product");

            entity.Property(e => e.Articule).HasMaxLength(25);
            entity.Property(e => e.Category).HasMaxLength(100);
            entity.Property(e => e.EdIzm).HasMaxLength(5);
            entity.Property(e => e.Photo).HasMaxLength(255);
            entity.Property(e => e.Proizvoditel).HasMaxLength(100);
            entity.Property(e => e.Supplier).HasMaxLength(100);
            entity.Property(e => e.Title).HasMaxLength(150);

            entity.HasOne(d => d.CategoryNavigation).WithMany(p => p.Products)
                .HasForeignKey(d => d.Category)
                .HasConstraintName("FK_Product_Category");
        });

        modelBuilder.Entity<Pvz>(entity =>
        {
            entity.ToTable("Pvz");

            entity.Property(e => e.Address).HasMaxLength(255);
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Role1);

            entity.ToTable("Role");

            entity.Property(e => e.Role1)
                .HasMaxLength(50)
                .HasColumnName("Role");
        });

        modelBuilder.Entity<Status>(entity =>
        {
            entity.HasKey(e => e.Status1);

            entity.ToTable("Status");

            entity.Property(e => e.Status1)
                .HasMaxLength(50)
                .HasColumnName("Status");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Login);

            entity.ToTable("User");

            entity.Property(e => e.Login).HasMaxLength(150);
            entity.Property(e => e.Fio).HasMaxLength(150);
            entity.Property(e => e.Password).HasMaxLength(150);
            entity.Property(e => e.Role).HasMaxLength(50);

            entity.HasOne(d => d.RoleNavigation).WithMany(p => p.Users)
                .HasForeignKey(d => d.Role)
                .HasConstraintName("FK_User_Role");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
