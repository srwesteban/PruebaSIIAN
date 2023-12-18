using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Tienda2.Models;

public partial class TiendaContext : DbContext
{
    public TiendaContext()
    {
    }

    public TiendaContext(DbContextOptions<TiendaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Movimiento> Movimientos { get; set; }

    public virtual DbSet<Tercero> Terceros { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseNpgsql("Host=localhost;Database=Tienda;Username=postgres;Password=1234;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Movimiento>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("movimientos_pkey");

            entity.ToTable("movimientos");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Cantidad).HasColumnName("cantidad");
            entity.Property(e => e.Detalle)
                .HasMaxLength(255)
                .HasColumnName("detalle");
            entity.Property(e => e.gasto).HasColumnName("esgasto");
            entity.Property(e => e.ingreso).HasColumnName("esingreso");
            entity.Property(e => e.Fecha).HasColumnName("fecha");
            entity.Property(e => e.Idtercero).HasColumnName("idtercero");
            entity.Property(e => e.Valortotal)
                .HasPrecision(10, 2)
                .HasColumnName("valortotal");
            entity.Property(e => e.Valorunitario)
                .HasPrecision(10, 2)
                .HasColumnName("valorunitario");

            entity.HasOne(d => d.IdCliente).WithMany(p => p.Movimientos)
                .HasForeignKey(d => d.Idtercero)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("movimientos_idtercero_fkey");
        });

        modelBuilder.Entity<Tercero>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("terceros_pkey");

            entity.ToTable("terceros");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Apellido1)
                .HasMaxLength(50)
                .HasColumnName("apellido1");
            entity.Property(e => e.Apellido2)
                .HasMaxLength(50)
                .HasColumnName("apellido2");
            entity.Property(e => e.Edad).HasColumnName("edad");
            entity.Property(e => e.Identificacion)
                .HasMaxLength(20)
                .HasColumnName("identificacion");
            entity.Property(e => e.Nombre1)
                .HasMaxLength(50)
                .HasColumnName("nombre1");
            entity.Property(e => e.Nombre2)
                .HasMaxLength(50)
                .HasColumnName("nombre2");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
