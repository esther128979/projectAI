using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DAL.Models;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AgeGroup> AgeGroups { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<EmailLink> EmailLinks { get; set; }

    public virtual DbSet<EmailLinkClick> EmailLinkClicks { get; set; }

    public virtual DbSet<EmailTracking> EmailTrackings { get; set; }

    public virtual DbSet<Movie> Movies { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderItem> OrderItems { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<User> Users { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\215551524\\Desktop\\projectAI\\projectAI\\adminScreen_DB.mdf;Integrated Security=True;Connect Timeout=30");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AgeGroup>(entity =>
        {
            entity.HasKey(e => e.AgeCode).HasName("PK__AgeGroup__5B97C6189522A6E4");

            entity.ToTable("AgeGroup");

            entity.Property(e => e.AgeCode).ValueGeneratedNever();
            entity.Property(e => e.AgeDescription).HasMaxLength(50);
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.CategoryCode).HasName("PK__Category__371BA954161E6948");

            entity.ToTable("Category");

            entity.Property(e => e.CategoryCode).ValueGeneratedNever();
            entity.Property(e => e.CategoryDescription).HasMaxLength(50);
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Customer__1788CC4CA2F6AA3C");

            entity.Property(e => e.UserId).ValueGeneratedNever();
            entity.Property(e => e.FullName).HasMaxLength(255);
            entity.Property(e => e.Gender)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Phone).HasMaxLength(15);

            entity.HasOne(d => d.AgeGroupNavigation).WithMany(p => p.Customers)
                .HasForeignKey(d => d.AgeGroup)
                .HasConstraintName("FK__Customers__AgeGr__12FDD1B2");

            entity.HasOne(d => d.User).WithOne(p => p.Customer)
                .HasForeignKey<Customer>(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Customers__UserI__1209AD79");
        });

        modelBuilder.Entity<EmailLink>(entity =>
        {
            entity.HasKey(e => e.LinkId).HasName("PK__EmailLin__2D12215556B5F683");

            entity.ToTable(tb => tb.HasTrigger("trg_LimitViewCount"));

            entity.HasIndex(e => e.UniqueToken, "IX_EmailLinks_UniqueToken");

            entity.HasIndex(e => e.UserId, "IX_EmailLinks_UserID");

            entity.HasIndex(e => e.UniqueToken, "UQ__EmailLin__64D6B76BBD003BDE").IsUnique();

            entity.Property(e => e.LinkId).HasColumnName("LinkID");
            entity.Property(e => e.DateCreated)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.EmailType).HasMaxLength(50);
            entity.Property(e => e.ExpirationDate).HasColumnType("datetime");
            entity.Property(e => e.MovieId).HasColumnName("MovieID");
            entity.Property(e => e.UniqueToken).HasMaxLength(100);
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.Movie).WithMany(p => p.EmailLinks)
                .HasForeignKey(d => d.MovieId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__EmailLink__Movie__29E1370A");

            entity.HasOne(d => d.User).WithMany(p => p.EmailLinks)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__EmailLink__UserI__28ED12D1");
        });

        modelBuilder.Entity<EmailLinkClick>(entity =>
        {
            entity.HasKey(e => e.ClickId).HasName("PK__EmailLin__F8E74E2EAC1007D4");

            entity.HasIndex(e => e.LinkId, "IX_EmailLinkClicks_LinkID");

            entity.Property(e => e.ClickId).HasColumnName("ClickID");
            entity.Property(e => e.ClickDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Converted).HasDefaultValue(false);
            entity.Property(e => e.Ipaddress)
                .HasMaxLength(50)
                .HasColumnName("IPAddress");
            entity.Property(e => e.LinkId).HasColumnName("LinkID");
            entity.Property(e => e.UserAgent).HasMaxLength(500);

            entity.HasOne(d => d.Link).WithMany(p => p.EmailLinkClicks)
                .HasForeignKey(d => d.LinkId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__EmailLink__LinkI__2EA5EC27");
        });

        modelBuilder.Entity<EmailTracking>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__EmailTra__3214EC07BD40BFD7");

            entity.ToTable("EmailTracking");

            entity.Property(e => e.DateClicked).HasColumnType("datetime");
            entity.Property(e => e.DateSent)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Email).HasMaxLength(100);
        });

        modelBuilder.Entity<Movie>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Movies__3214EC07627911D3");

            entity.Property(e => e.BasePrice).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Description).HasMaxLength(255);
            entity.Property(e => e.ExtraViewPrice).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.ExtraViewerPrice).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Name).HasMaxLength(255);

            entity.HasOne(d => d.AgeCodeNavigation).WithMany(p => p.Movies)
                .HasForeignKey(d => d.AgeCode)
                .HasConstraintName("FK__Movies__AgeCode__16CE6296");

            entity.HasOne(d => d.CategoryCodeNavigation).WithMany(p => p.Movies)
                .HasForeignKey(d => d.CategoryCode)
                .HasConstraintName("FK__Movies__Category__15DA3E5D");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.IdOrder).HasName("PK__Orders__C38F300988E32713");

            entity.Property(e => e.DateOrder)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.TotalAmount)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.IdCustomerNavigation).WithMany(p => p.Orders)
                .HasForeignKey(d => d.IdCustomer)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Orders__IdCustom__1C873BEC");
        });

        modelBuilder.Entity<OrderItem>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__OrderIte__3214EC070C2FAC08");

            entity.ToTable(tb =>
                {
                    tb.HasTrigger("trg_CalculateSubTotal_AfterInsertUpdate");
                    tb.HasTrigger("trg_UpdateOrderTotalAmount");
                });

            entity.Property(e => e.SubTotal).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.ViewCount).HasDefaultValue(1);
            entity.Property(e => e.ViewerCount).HasDefaultValue(1);

            entity.HasOne(d => d.Movie).WithMany(p => p.OrderItems)
                .HasForeignKey(d => d.MovieId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__OrderItem__Movie__22401542");

            entity.HasOne(d => d.Order).WithMany(p => p.OrderItems)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__OrderItem__Order__214BF109");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Role__3214EC0769967814");

            entity.ToTable("Role");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Users__3214EC07AFEFEC21");

            entity.HasIndex(e => e.Email, "UQ__Users__A9D10534957378DF").IsUnique();

            entity.Property(e => e.DateCreated)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.Password).HasMaxLength(255);

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Users__RoleId__0E391C95");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
