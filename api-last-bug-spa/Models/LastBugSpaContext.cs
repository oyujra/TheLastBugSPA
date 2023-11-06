using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace api_last_bug_spa.Models;

public partial class LastBugSpaContext : DbContext
{
    public LastBugSpaContext()
    {
    }

    public LastBugSpaContext(DbContextOptions<LastBugSpaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AsignacionesAyudaSocial> AsignacionesAyudaSocials { get; set; }

    public virtual DbSet<AyudasSociale> AyudasSociales { get; set; }

    public virtual DbSet<Comuna> Comunas { get; set; }

    public virtual DbSet<Paise> Paises { get; set; }

    public virtual DbSet<Persona> Personas { get; set; }

    public virtual DbSet<Regione> Regiones { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost; Database=LastBugSpa; Integrated Security=True; TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AsignacionesAyudaSocial>(entity =>
        {
            entity.HasKey(e => e.AsignacionId).HasName("PK__Asignaci__D82B5BB779AAC7E7");

            entity.ToTable("AsignacionesAyudaSocial");

            entity.Property(e => e.AsignacionId).HasColumnName("AsignacionID");
            entity.Property(e => e.AyudaSocialId).HasColumnName("AyudaSocialID");
            entity.Property(e => e.Fecha).HasColumnType("date");
            entity.Property(e => e.PersonaId).HasColumnName("PersonaID");

            entity.HasOne(d => d.AyudaSocial).WithMany(p => p.AsignacionesAyudaSocials)
                .HasForeignKey(d => d.AyudaSocialId)
                .HasConstraintName("FK__Asignacio__Ayuda__6477ECF3");

            entity.HasOne(d => d.Persona).WithMany(p => p.AsignacionesAyudaSocials)
                .HasForeignKey(d => d.PersonaId)
                .HasConstraintName("FK__Asignacio__Perso__6383C8BA");
        });

        modelBuilder.Entity<AyudasSociale>(entity =>
        {
            entity.HasKey(e => e.AyudaSocialId).HasName("PK__AyudasSo__7D00E50B75A2B8BC");

            entity.Property(e => e.AyudaSocialId).HasColumnName("AyudaSocialID");
            entity.Property(e => e.ComunaId).HasColumnName("ComunaID");
            entity.Property(e => e.Nombre).HasMaxLength(255);

            entity.HasOne(d => d.Comuna).WithMany(p => p.AyudasSociales)
                .HasForeignKey(d => d.ComunaId)
                .HasConstraintName("FK__AyudasSoc__Comun__534D60F1");
        });

        modelBuilder.Entity<Comuna>(entity =>
        {
            entity.HasKey(e => e.ComunaId).HasName("PK__Comunas__4F2DF61F9FCCE07E");

            entity.Property(e => e.ComunaId).HasColumnName("ComunaID");
            entity.Property(e => e.Nombre).HasMaxLength(255);
            entity.Property(e => e.RegionId).HasColumnName("RegionID");

            entity.HasOne(d => d.Region).WithMany(p => p.Comunas)
                .HasForeignKey(d => d.RegionId)
                .HasConstraintName("FK__Comunas__RegionI__5070F446");
        });

        modelBuilder.Entity<Paise>(entity =>
        {
            entity.HasKey(e => e.PaisId).HasName("PK__Paises__B501E1A51F3A2921");

            entity.Property(e => e.PaisId).HasColumnName("PaisID");
            entity.Property(e => e.Nombre).HasMaxLength(255);
        });

        modelBuilder.Entity<Persona>(entity =>
        {
            entity.HasKey(e => e.PersonaId).HasName("PK__Persona__7C34D32343A2447F");

            entity.ToTable("Persona");

            entity.Property(e => e.PersonaId).HasColumnName("PersonaID");
            entity.Property(e => e.ComunaId).HasColumnName("ComunaID");
            entity.Property(e => e.CorreoElectronico).HasMaxLength(255);
            entity.Property(e => e.Nombre).HasMaxLength(255);

            entity.HasOne(d => d.Comuna).WithMany(p => p.Personas)
                .HasForeignKey(d => d.ComunaId)
                .HasConstraintName("FK__Persona__ComunaI__5CD6CB2B");
        });

        modelBuilder.Entity<Regione>(entity =>
        {
            entity.HasKey(e => e.RegionId).HasName("PK__Regiones__ACD8444387C680EB");

            entity.Property(e => e.RegionId).HasColumnName("RegionID");
            entity.Property(e => e.Nombre).HasMaxLength(255);
            entity.Property(e => e.PaisId).HasColumnName("PaisID");

            entity.HasOne(d => d.Pais).WithMany(p => p.Regiones)
                .HasForeignKey(d => d.PaisId)
                .HasConstraintName("FK__Regiones__PaisID__4D94879B");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.UsuarioId).HasName("PK__Usuarios__2B3DE7984F66467B");

            entity.Property(e => e.UsuarioId).HasColumnName("UsuarioID");
            entity.Property(e => e.Contrasena).HasMaxLength(255);
            entity.Property(e => e.CorreoElectronico).HasMaxLength(255);
            entity.Property(e => e.Nombre).HasMaxLength(255);
            entity.Property(e => e.Rol).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
