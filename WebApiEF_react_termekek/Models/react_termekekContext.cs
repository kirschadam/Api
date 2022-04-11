using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace WebApiEF_react_termekek.Models
{
    public partial class react_termekekContext : DbContext
    {
        public react_termekekContext()
        {
        }

        public react_termekekContext(DbContextOptions<react_termekekContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Megrendelesek> Megrendeleseks { get; set; }
        public virtual DbSet<Megrendelok> Megrendeloks { get; set; }
        public virtual DbSet<Termekek> Termekeks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySQL("server=localhost;database=react_termekek;user=root;password=;SSL mode=none;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Megrendelesek>(entity =>
            {
                entity.ToTable("megrendelesek");

                entity.HasIndex(e => e.TermekId, "megrendelesek_termekId_fk");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.ArOsszesen)
                    .HasColumnType("int(11)")
                    .HasColumnName("ar_osszesen");

                entity.Property(e => e.Db)
                    .HasColumnType("int(11)")
                    .HasColumnName("db");

                entity.Property(e => e.MegrendeloId)
                    .HasColumnType("int(11)")
                    .HasColumnName("megrendeloId");

                entity.Property(e => e.TermekId)
                    .HasColumnType("int(11)")
                    .HasColumnName("termekId");

                entity.HasOne(d => d.Termek)
                    .WithMany(p => p.Megrendeleseks)
                    .HasForeignKey(d => d.TermekId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("megrendelesek_termekId_fk");
            });

            modelBuilder.Entity<Megrendelok>(entity =>
            {
                entity.ToTable("megrendelok");

                entity.HasIndex(e => e.TermekId, "megrendelok_termekId_fk");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Cim)
                    .IsRequired()
                    .HasMaxLength(150)
                    .HasColumnName("cim");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("email");

                entity.Property(e => e.EmeletAjto)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("emelet_ajto");

                entity.Property(e => e.Hsz)
                    .IsRequired()
                    .HasMaxLength(4)
                    .HasColumnName("hsz");

                entity.Property(e => e.Irsz)
                    .IsRequired()
                    .HasMaxLength(4)
                    .HasColumnName("irsz");

                entity.Property(e => e.Megjegyzes)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("megjegyzes");

                entity.Property(e => e.Nev)
                    .IsRequired()
                    .HasMaxLength(150)
                    .HasColumnName("nev");

                entity.Property(e => e.Telefon)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("telefon");

                entity.Property(e => e.TermekId)
                    .HasColumnType("int(11)")
                    .HasColumnName("termekId");

                entity.HasOne(d => d.Termek)
                    .WithMany(p => p.Megrendeloks)
                    .HasForeignKey(d => d.TermekId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("megrendelok_termekId_fk");
            });

            modelBuilder.Entity<Termekek>(entity =>
            {
                entity.ToTable("termekek");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Ar)
                    .HasColumnType("int(11)")
                    .HasColumnName("ar");

                entity.Property(e => e.Keplink)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("keplink");

                entity.Property(e => e.Leiras)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("leiras");

                entity.Property(e => e.Nev)
                    .IsRequired()
                    .HasMaxLength(150)
                    .HasColumnName("nev");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
