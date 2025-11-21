using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Autos_Narla_Salvador_Urroz.Models;

public partial class AutoNarlaContext : DbContext
{
    public AutoNarlaContext()
    {
    }

    public AutoNarlaContext(DbContextOptions<AutoNarlaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Combustible> Combustibles { get; set; }

    public virtual DbSet<Empleado> Empleados { get; set; }

    public virtual DbSet<Marca> Marcas { get; set; }

    public virtual DbSet<TipoVehiculo> TipoVehiculos { get; set; }

    public virtual DbSet<Vehiculo> Vehiculos { get; set; }

    public virtual DbSet<VehiculoFoto> VehiculoFotos { get; set; }

    public virtual DbSet<Ventum> Venta { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-FQALIRL;Database=Auto_Narla_SJUM;User ID=SJUM_autos_narla;Password=Autos_NarlaPG25;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.ClienteId).HasName("PK__Cliente__71ABD087D283C793");
        });

        modelBuilder.Entity<Combustible>(entity =>
        {
            entity.HasKey(e => e.CombustibleId).HasName("PK__Combusti__EA82AB3BEAEDD88A");
        });

        modelBuilder.Entity<Empleado>(entity =>
        {
            entity.HasKey(e => e.EmpleadoId).HasName("PK__Empleado__958BE9103EC77B3B");
        });

        modelBuilder.Entity<Marca>(entity =>
        {
            entity.HasKey(e => e.MarcaId).HasName("PK__Marca__D5B1CD8B9E0C8E09");
        });

        modelBuilder.Entity<TipoVehiculo>(entity =>
        {
            entity.HasKey(e => e.TipoVehiculoId).HasName("PK__TipoVehi__1EA21D0DD9D4BC36");
        });

        modelBuilder.Entity<Vehiculo>(entity =>
        {
            entity.HasKey(e => e.VehiculoId).HasName("PK__Vehiculo__AA088600EB8E7117");

            entity.Property(e => e.Estado).HasDefaultValue("Disponible");
            entity.Property(e => e.FechaIngreso).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.Combustible).WithMany(p => p.Vehiculos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Vehiculo__Combus__4AB81AF0");

            entity.HasOne(d => d.Marca).WithMany(p => p.Vehiculos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Vehiculo__MarcaI__48CFD27E");

            entity.HasOne(d => d.TipoVehiculo).WithMany(p => p.Vehiculos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Vehiculo__TipoVe__49C3F6B7");
        });

        modelBuilder.Entity<VehiculoFoto>(entity =>
        {
            entity.HasKey(e => e.FotoId).HasName("PK__Vehiculo__4EA1C11901C8BC10");

            entity.HasOne(d => d.Vehiculo).WithMany(p => p.VehiculoFotos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__VehiculoF__Vehic__4F7CD00D");
        });

        modelBuilder.Entity<Ventum>(entity =>
        {
            entity.HasKey(e => e.VentaId).HasName("PK__Venta__5B4150AC2DB3947B");

            entity.Property(e => e.FechaVenta).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.Cliente).WithMany(p => p.Venta)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Venta__ClienteId__571DF1D5");

            entity.HasOne(d => d.Empleado).WithMany(p => p.Venta)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Venta__EmpleadoI__5812160E");

            entity.HasOne(d => d.Vehiculo).WithMany(p => p.Venta)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Venta__VehiculoI__5629CD9C");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
