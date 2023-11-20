using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace RanchProject.Models
{
    public partial class RanchContext : DbContext
    {
        public RanchContext()
        {
        }

        public RanchContext(DbContextOptions<RanchContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Aranch> Aranches { get; set; } = null!;
        public virtual DbSet<Customer> Customers { get; set; } = null!;
        public virtual DbSet<Employee> Employees { get; set; } = null!;
        public virtual DbSet<Manager> Managers { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=MEHMETAKSOY\\SQLMHMT;Database=Ranch;Integrated Security=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Aranch>(entity =>
            {
                entity.HasKey(e => e.RanchID);

                entity.ToTable("ARanch");

                entity.Property(e => e.RanchID).HasColumnName("RanchID");

                entity.Property(e => e.ManagerID).HasColumnName("ManagerID");

                entity.Property(e => e.RanchAdress)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RanchGiro).HasColumnType("money");

                entity.Property(e => e.RanchName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RanchNoe).HasColumnName("RanchNOE");

                entity.HasOne(d => d.Manager)
                    .WithMany(p => p.Aranches)
                    .HasForeignKey(d => d.ManagerID)
                    .HasConstraintName("FK_ARanch_Manager");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("Customer");

                entity.Property(e => e.CustomerID).HasColumnName("CustomerID");

                entity.Property(e => e.CustomerName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CustomerSurname)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EmployeeID).HasColumnName("EmployeeID");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Customers)
                    .HasForeignKey(d => d.EmployeeID)
                    .HasConstraintName("FK_Customer_Employee");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("Employee");

                entity.Property(e => e.EmployeeID).HasColumnName("EmployeeID");

                entity.Property(e => e.EmployeeName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EmployeeSurname)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EmployeeWage)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ProductID).HasColumnName("ProductID");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.ProductID)
                    .HasConstraintName("FK_Employee_Product");
            });

            modelBuilder.Entity<Manager>(entity =>
            {
                entity.ToTable("Manager");

                entity.Property(e => e.ManagerID).HasColumnName("ManagerID");

                entity.Property(e => e.ManagerName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ManagerSurname)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Product");

                entity.Property(e => e.ProductID).HasColumnName("ProductID");

                entity.Property(e => e.ProductName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ProductPrice).HasColumnType("money");

                entity.Property(e => e.ProductType)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RanchID).HasColumnName("RanchID");

                entity.HasOne(d => d.Ranch)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.RanchID)
                    .HasConstraintName("FK_Product_ARanch");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
