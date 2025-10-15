using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Task_12.Models;

namespace Task_12.Data;

public partial class ApplicationDbContext : DbContext
{
    public ApplicationDbContext()
    {
    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Brand> Brands { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderItem> OrderItems { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Staff> Staffs { get; set; }

    public virtual DbSet<Stock> Stocks { get; set; }

    public virtual DbSet<Store> Stores { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=BikeStore;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Brand>(entity =>
        {
            entity.HasKey(e => e.BrandId).HasName("PK__brands__5E5A8E2772D26FEE");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("PK__categori__D54EE9B4D7D8E269");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.CustomerId).HasName("PK__customer__CD65CB853398DE56");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("PK__orders__46596229CBA50D25");

            entity.HasOne(d => d.Customer).WithMany(p => p.Orders)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__orders__customer__46E78A0C");

            entity.HasOne(d => d.Staff).WithMany(p => p.Orders)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__orders__staff_id__48CFD27E");

            entity.HasOne(d => d.Store).WithMany(p => p.Orders).HasConstraintName("FK__orders__store_id__47DBAE45");
        });

        modelBuilder.Entity<OrderItem>(entity =>
        {
            entity.HasKey(e => new { e.OrderId, e.ItemId }).HasName("PK__order_it__837942D48C5B3E6E");

            entity.HasOne(d => d.Order).WithMany(p => p.OrderItems).HasConstraintName("FK__order_ite__order__4CA06362");

            entity.HasOne(d => d.Product).WithMany(p => p.OrderItems).HasConstraintName("FK__order_ite__produ__4D94879B");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PK__products__47027DF583DFA0CD");

            entity.HasOne(d => d.Brand).WithMany(p => p.Products).HasConstraintName("FK__products__brand___3B75D760");

            entity.HasOne(d => d.Category).WithMany(p => p.Products).HasConstraintName("FK__products__catego__3A81B327");
        });

        modelBuilder.Entity<Staff>(entity =>
        {
            entity.HasKey(e => e.StaffId).HasName("PK__staffs__1963DD9CCCBA4596");

            entity.HasOne(d => d.Manager).WithMany(p => p.InverseManager).HasConstraintName("FK__staffs__manager___440B1D61");

            entity.HasOne(d => d.Store).WithMany(p => p.Staff).HasConstraintName("FK__staffs__store_id__4316F928");
        });

        modelBuilder.Entity<Stock>(entity =>
        {
            entity.HasKey(e => new { e.StoreId, e.ProductId }).HasName("PK__stocks__E68284D35B22522E");

            entity.HasOne(d => d.Product).WithMany(p => p.Stocks).HasConstraintName("FK__stocks__product___5165187F");

            entity.HasOne(d => d.Store).WithMany(p => p.Stocks).HasConstraintName("FK__stocks__store_id__5070F446");
        });

        modelBuilder.Entity<Store>(entity =>
        {
            entity.HasKey(e => e.StoreId).HasName("PK__stores__A2F2A30C5AE9BAD9");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
