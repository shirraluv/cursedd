using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace cursedd;

public partial class CurseContext : DbContext
{
    public CurseContext()
    {
    }

    public CurseContext(DbContextOptions<CurseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ClientBuyer> ClientBuyers { get; set; }

    public virtual DbSet<ClientSeller> ClientSellers { get; set; }

    public virtual DbSet<Estateoffice> Estateoffices { get; set; }

    public virtual DbSet<Realty> Realties { get; set; }

    public virtual DbSet<Rieltor> Rieltors { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;user=root;password=1234512345;database=curse", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.32-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<ClientBuyer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("client_buyer");

            entity.HasIndex(e => e.RieltorId, "FK_client_buyer_rieltor_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.Passport)
                .HasMaxLength(255)
                .HasColumnName("passport");
            entity.Property(e => e.Patronymic)
                .HasMaxLength(255)
                .HasColumnName("patronymic");
            entity.Property(e => e.Phone)
                .HasMaxLength(255)
                .HasColumnName("phone");
            entity.Property(e => e.RieltorId).HasColumnName("rieltor_id");
            entity.Property(e => e.Surname)
                .HasMaxLength(255)
                .HasColumnName("surname");

            entity.HasOne(d => d.Rieltor).WithMany(p => p.ClientBuyers)
                .HasForeignKey(d => d.RieltorId)
                .HasConstraintName("FK_client_buyer_rieltor_id");
        });

        modelBuilder.Entity<ClientSeller>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("client_seller");

            entity.HasIndex(e => e.RieltorId, "FK_client_seller_rieltor_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.Passport)
                .HasMaxLength(255)
                .HasColumnName("passport");
            entity.Property(e => e.Patronymic)
                .HasMaxLength(255)
                .HasColumnName("patronymic");
            entity.Property(e => e.Phone)
                .HasMaxLength(255)
                .HasColumnName("phone");
            entity.Property(e => e.RieltorId).HasColumnName("rieltor_id");
            entity.Property(e => e.Surname)
                .HasMaxLength(255)
                .HasColumnName("surname");

            entity.HasOne(d => d.Rieltor).WithMany(p => p.ClientSellers)
                .HasForeignKey(d => d.RieltorId)
                .HasConstraintName("FK_client_seller_rieltor_id");
        });

        modelBuilder.Entity<Estateoffice>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("estateoffice");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Realty>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("realty");

            entity.HasIndex(e => e.ClientSellerId, "FK_realty_client_seller_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Address)
                .HasMaxLength(255)
                .HasColumnName("address");
            entity.Property(e => e.ClientSellerId).HasColumnName("client_seller_id");
            entity.Property(e => e.Price)
                .HasMaxLength(255)
                .HasColumnName("price");
            entity.Property(e => e.RealtyType)
                .HasMaxLength(50)
                .HasColumnName("realty_type");
            entity.Property(e => e.Rooms)
                .HasMaxLength(255)
                .HasColumnName("rooms");

            entity.HasOne(d => d.ClientSeller).WithMany(p => p.Realties)
                .HasForeignKey(d => d.ClientSellerId)
                .HasConstraintName("FK_realty_client_seller_id");
        });

        modelBuilder.Entity<Rieltor>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("rieltor");

            entity.HasIndex(e => e.EstateofficeId, "FK_city_company_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.EstateofficeId).HasColumnName("estateoffice_id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.Patronymic)
                .HasMaxLength(255)
                .HasColumnName("patronymic");
            entity.Property(e => e.Percent)
                .HasMaxLength(255)
                .HasColumnName("percent");
            entity.Property(e => e.Phone)
                .HasMaxLength(255)
                .HasColumnName("phone");
            entity.Property(e => e.Surname)
                .HasMaxLength(255)
                .HasColumnName("surname");

            entity.HasOne(d => d.Estateoffice).WithMany(p => p.Rieltors)
                .HasForeignKey(d => d.EstateofficeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_city_company_id");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
