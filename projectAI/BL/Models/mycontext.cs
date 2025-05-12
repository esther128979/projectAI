using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BL.Models;

public partial class mycontext : DbContext
{
    public mycontext()
    {
    }

    public mycontext(DbContextOptions<mycontext> options)
        : base(options)
    {
    }

    public virtual DbSet<BLAgeGroup> AgeGroups { get; set; }

    public virtual DbSet<BLCategory> Categories { get; set; }

    public virtual DbSet<BLCustomer> Customers { get; set; }

    public virtual DbSet<BLMovie> Movies { get; set; }

    public virtual DbSet<BLOrder> Orders { get; set; }

    public virtual DbSet<BLOrderDetail> OrderDetails { get; set; }

    public virtual DbSet<BLPaymentMethod> PaymentMethods { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename='F:\\לימודים\\פרויקט גמר\\OrderManagementSystem\\adminScreen_DB.mdf';Integrated Security=True;Connect Timeout=30");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BLAgeGroup>(entity =>
        {
            entity.HasKey(e => e.AgeCode).HasName("PK__AgeGroup__5B97C6185CF52A96");

            entity.ToTable("AgeGroup");

            entity.Property(e => e.AgeCode).ValueGeneratedNever();
            entity.Property(e => e.AgeDescrepition)
                .HasMaxLength(50)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
        });

        modelBuilder.Entity<BLCategory>(entity =>
        {
            entity.HasKey(e => e.CategoryCode).HasName("PK__Category__371BA95438898540");

            entity.ToTable("Category");

            entity.Property(e => e.CategoryCode).ValueGeneratedNever();
            entity.Property(e => e.CategoryDescreption)
                .HasMaxLength(50)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
        });

        modelBuilder.Entity<BLCustomer>(entity =>
        {
            entity.HasKey(e => e.CustomerId).HasName("PK__tmp_ms_x__A4AE64D801215C93");

            entity.HasIndex(e => e.CustomerNumber, "UQ__tmp_ms_x__48D47E1E8014A696").IsUnique();

            entity.Property(e => e.CustomerName)
                .HasMaxLength(255)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.CustomerNumber)
                .HasMaxLength(9)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.Gender)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.Phone)
                .HasMaxLength(15)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");

            //entity.HasOne(d => d.AgeGroupNavigation).WithMany(p => p.Customers)
            //    .HasForeignKey(d => d.AgeGroup)
            //    .HasConstraintName("FK_Customers_ToTable");
        });

        modelBuilder.Entity<BLMovie>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Movies__3214EC07E9C62AF3");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.AgeCodeNavigation).WithMany(p => p.Movies)
                .HasForeignKey(d => d.ageGroup)
                .HasConstraintName("FK_Movies_ToTable");

            entity.HasOne(d => d.CodeCategoryNavigation).WithMany(p => p.Movies)
                .HasForeignKey(d => d.CodeCategory)
                .HasConstraintName("FK_Movies_ToTable_2");
        });

        modelBuilder.Entity<BLOrder>(entity =>
        {
            entity.HasKey(e => e.IdOrder).HasName("PK__Orders__C38F3009AD086D48");

            entity.Property(e => e.IdOrder).ValueGeneratedOnAdd();
            entity.Property(e => e.DateOrder)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.TotalAmount).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.IdOrderNavigation).WithOne(p => p.Order)
                .HasForeignKey<BLOrder>(d => d.IdOrder)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Orders_ToTable");
        });

        modelBuilder.Entity<BLOrderDetail>(entity =>
        {
            entity.HasKey(e => e.OrderCode).HasName("PK__OrderDet__999B5228E05C59B5");

            entity.Property(e => e.OrderCode).ValueGeneratedNever();
        });

        modelBuilder.Entity<BLPaymentMethod>(entity =>
        {
            entity.HasKey(e => e.OrderCode).HasName("PK__PaymentM__999B5228428F94AB");

            entity.Property(e => e.OrderCode).ValueGeneratedNever();
            entity.Property(e => e.CreditCardCompany)
                .HasMaxLength(50)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.CreditCardNumber)
                .HasMaxLength(19)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
