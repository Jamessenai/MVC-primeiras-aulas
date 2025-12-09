using System;
using System.Collections.Generic;
using DevConnectTorloni.Models;
using Microsoft.EntityFrameworkCore;

namespace DevConnectTorloni.Contexts;

public partial class DevConnectContext : DbContext
{
    public DevConnectContext()
    {
    }

    public DevConnectContext(DbContextOptions<DevConnectContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Comentario> Comentario { get; set; }

    public virtual DbSet<Curtida> Curtida { get; set; }

    public virtual DbSet<Publicacao> Publicacao { get; set; }

    public virtual DbSet<Seguidor> Seguidor { get; set; }

    public virtual DbSet<Usuario> Usuario { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=DevCon_SA");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Comentario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Comentar__3213E83F1CAF93BF");

            entity.HasOne(d => d.Publicacao).WithMany(p => p.Comentario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Comentario_publicacao");

            entity.HasOne(d => d.Usuario).WithMany(p => p.Comentario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Comentario_usuario");
        });

        modelBuilder.Entity<Curtida>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Curtida__3213E83FE978E098");

            entity.HasOne(d => d.Publicacao).WithMany(p => p.Curtida)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Curtida_publicacao");

            entity.HasOne(d => d.Usuario).WithMany(p => p.Curtida)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Curtida_usuario");
        });

        modelBuilder.Entity<Publicacao>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Publicac__3213E83F41F652E9");

            entity.HasOne(d => d.Usuario).WithMany(p => p.Publicacao).HasConstraintName("fk_Publicacao_usuario");
        });

        modelBuilder.Entity<Seguidor>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Seguidor__3213E83F7EFF1580");

            entity.HasOne(d => d.SeguidorNavigation).WithMany(p => p.SeguidorSeguidorNavigation)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Seguidor_seguidorid");

            entity.HasOne(d => d.Usuario).WithMany(p => p.SeguidorUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Seguidor_usuarioid");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Usuario__3213E83FD9EB0520");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
