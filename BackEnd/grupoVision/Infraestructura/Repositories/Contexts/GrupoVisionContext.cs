using System;
using System.Collections.Generic;
using Infraestructura.Interfaces;
using Infraestructura.Repositories.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infraestructura.Repositories.Contexts;

public partial class GrupoVisionContext : DbContext,IUserContex
{
    public GrupoVisionContext()
    {
    }

    public GrupoVisionContext(DbContextOptions<GrupoVisionContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Usuariotbl> Usuarios { get; set; }

    public DbContext Instance => this;
    public DbSet<PassView> PassViews { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.; Database=grupoVision; Trusted_Connection=true; TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Usuariotbl>(entity =>
        {
            entity.ToTable("Usuario");

            entity.HasIndex(e => e.UserName, "UQ__Usuario__C9F284560CEADC57").IsUnique();

            entity.Property(e => e.UserName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });
        modelBuilder.Entity<PassView>(entity => {
            entity.HasNoKey();
            });
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
