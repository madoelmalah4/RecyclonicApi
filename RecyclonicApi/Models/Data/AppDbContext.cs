using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace RecyclonicApi.Models.Data;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<EwasteItem> EwasteItems { get; set; }

    public virtual DbSet<Marketplace> Marketplaces { get; set; }

    public virtual DbSet<RecyclingCompany> RecyclingCompanies { get; set; }

    public virtual DbSet<Transaction> Transactions { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=Recyclonic;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<EwasteItem>(entity =>
        {
            entity.HasKey(e => e.ItemId).HasName("PK__EWasteIt__52020FDDE923E499");

            entity.Property(e => e.Status).HasDefaultValue("pending");
            entity.Property(e => e.SubmissionDate).HasDefaultValueSql("(sysutcdatetime())");

            entity.HasOne(d => d.User).WithMany(p => p.EwasteItems).HasConstraintName("FK__EWasteIte__user___2A4B4B5E");
        });

        modelBuilder.Entity<Marketplace>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PK__Marketpl__47027DF58B4EE75D");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(sysutcdatetime())");
            entity.Property(e => e.Stock).HasDefaultValue(1);

            entity.HasOne(d => d.Company).WithMany(p => p.Marketplaces).HasConstraintName("FK__Marketpla__compa__3B75D760");

            entity.HasOne(d => d.Item).WithMany(p => p.Marketplaces).HasConstraintName("FK__Marketpla__item___3A81B327");
        });

        modelBuilder.Entity<RecyclingCompany>(entity =>
        {
            entity.HasKey(e => e.CompanyId).HasName("PK__Recyclin__3E26723538B0FDB3");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(sysutcdatetime())");
            entity.Property(e => e.PartnershipLevel).HasDefaultValue("basic");
        });

        modelBuilder.Entity<Transaction>(entity =>
        {
            entity.HasKey(e => e.TransactionId).HasName("PK__Transact__85C600AF77C46795");

            entity.Property(e => e.Date).HasDefaultValueSql("(sysutcdatetime())");
            entity.Property(e => e.Type).HasDefaultValue("reward");

            entity.HasOne(d => d.User).WithMany(p => p.Transactions).HasConstraintName("FK__Transacti__user___403A8C7D");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__B9BE370F63812FB1");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(sysutcdatetime())");
            entity.Property(e => e.RewardPoints).HasDefaultValue(0L);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
