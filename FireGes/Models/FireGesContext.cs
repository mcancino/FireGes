using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace FireGes.Models
{
    public partial class FireGesContext : DbContext
    {
        public FireGesContext()
        {
        }

        public FireGesContext(DbContextOptions<FireGesContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cargo> Cargo { get; set; }
        public virtual DbSet<Citacion> Citacion { get; set; }
        public virtual DbSet<CitacionVoluntario> CitacionVoluntario { get; set; }
        public virtual DbSet<Compania> Compania { get; set; }
        public virtual DbSet<Comuna> Comuna { get; set; }
        public virtual DbSet<Cuerpo> Cuerpo { get; set; }
        public virtual DbSet<DireccionCompania> DireccionCompania { get; set; }
        public virtual DbSet<DireccionCuerpo> DireccionCuerpo { get; set; }
        public virtual DbSet<DireccionVoluntario> DireccionVoluntario { get; set; }
        public virtual DbSet<Disponibilidad> Disponibilidad { get; set; }
        public virtual DbSet<EstadoUsuario> EstadoUsuario { get; set; }
        public virtual DbSet<EstadoVoluntario> EstadoVoluntario { get; set; }
        public virtual DbSet<Funcionalidad> Funcionalidad { get; set; }
        public virtual DbSet<FuncionalidadPerfil> FuncionalidadPerfil { get; set; }
        public virtual DbSet<MarcaVoluntario> MarcaVoluntario { get; set; }
        public virtual DbSet<Perfil> Perfil { get; set; }
        public virtual DbSet<TipoCitacion> TipoCitacion { get; set; }
        public virtual DbSet<TipoMarca> TipoMarca { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }
        public virtual DbSet<Voluntario> Voluntario { get; set; }
        public virtual DbSet<VoluntarioCargo> VoluntarioCargo { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=localhost;Database=FireGes;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cargo>(entity =>
            {
                entity.HasKey(e => e.IdCargo);

                entity.Property(e => e.DescripcionCargo)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Citacion>(entity =>
            {
                entity.HasKey(e => e.IdCitacion);

                entity.Property(e => e.FechaCitacion).HasColumnType("datetime");

                entity.HasOne(d => d.IdTipoCitacionNavigation)
                    .WithMany(p => p.Citacion)
                    .HasForeignKey(d => d.IdTipoCitacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CitacionTipoCitacion");
            });

            modelBuilder.Entity<CitacionVoluntario>(entity =>
            {
                entity.HasKey(e => e.IdCitacionVoluntario);

                entity.Property(e => e.IdCitacionVoluntario).ValueGeneratedNever();

                entity.Property(e => e.IdVoluntario).ValueGeneratedOnAdd();

                entity.HasOne(d => d.IdCitacionNavigation)
                    .WithMany(p => p.CitacionVoluntario)
                    .HasForeignKey(d => d.IdCitacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CitacionVoluntarioCitacion");

                entity.HasOne(d => d.IdVoluntarioNavigation)
                    .WithMany(p => p.CitacionVoluntario)
                    .HasForeignKey(d => d.IdVoluntario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CitacionVoluntarioVoluntario");
            });

            modelBuilder.Entity<Compania>(entity =>
            {
                entity.HasKey(e => e.IdCompania);

                entity.Property(e => e.DenominacionCompania)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NombreFantasia)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdCuerpoNavigation)
                    .WithMany(p => p.Compania)
                    .HasForeignKey(d => d.IdCuerpo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CompaniaCuerpo");
            });

            modelBuilder.Entity<Comuna>(entity =>
            {
                entity.HasKey(e => e.IdComuna);

                entity.Property(e => e.NombreComuna)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Cuerpo>(entity =>
            {
                entity.HasKey(e => e.IdCuerpo);

                entity.Property(e => e.Denominacion)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DigitoVerificador)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.NombreFantasia)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<DireccionCompania>(entity =>
            {
                entity.HasKey(e => e.IdDireccionCompania);

                entity.Property(e => e.Calle)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Departamento)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Numero)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdCompaniaNavigation)
                    .WithMany(p => p.DireccionCompania)
                    .HasForeignKey(d => d.IdCompania)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DireccionCompaniaCompania");

                entity.HasOne(d => d.IdComunaNavigation)
                    .WithMany(p => p.DireccionCompania)
                    .HasForeignKey(d => d.IdComuna)
                    .HasConstraintName("FK_DireccionCompaniaComuna");
            });

            modelBuilder.Entity<DireccionCuerpo>(entity =>
            {
                entity.HasKey(e => e.IdDireccionCuerpo);

                entity.Property(e => e.Calle)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Departamento)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Numero)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdComunaNavigation)
                    .WithMany(p => p.DireccionCuerpo)
                    .HasForeignKey(d => d.IdComuna)
                    .HasConstraintName("FK_DireccionCuerpoComuna");

                entity.HasOne(d => d.IdCuerpoNavigation)
                    .WithMany(p => p.DireccionCuerpo)
                    .HasForeignKey(d => d.IdCuerpo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DireccionCuerpoCuerpo");
            });

            modelBuilder.Entity<DireccionVoluntario>(entity =>
            {
                entity.HasKey(e => e.IdDireccionVoluntario);

                entity.Property(e => e.Calle)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Departamento)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Numero)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdComunaNavigation)
                    .WithMany(p => p.DireccionVoluntario)
                    .HasForeignKey(d => d.IdComuna)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DireccionVoluntarioComuna");

                entity.HasOne(d => d.IdVoluntarioNavigation)
                    .WithMany(p => p.DireccionVoluntario)
                    .HasForeignKey(d => d.IdVoluntario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DireccionVoluntarioVoluntario");
            });

            modelBuilder.Entity<Disponibilidad>(entity =>
            {
                entity.HasKey(e => e.IdDisponibilidad);

                entity.HasOne(d => d.IdCompaniaNavigation)
                    .WithMany(p => p.Disponibilidad)
                    .HasForeignKey(d => d.IdCompania)
                    .HasConstraintName("FK_DisponibilidadCompania");

                entity.HasOne(d => d.IdVoluntarioNavigation)
                    .WithMany(p => p.Disponibilidad)
                    .HasForeignKey(d => d.IdVoluntario)
                    .HasConstraintName("FK_DisponibilidadVoluntario");
            });

            modelBuilder.Entity<EstadoUsuario>(entity =>
            {
                entity.HasKey(e => e.IdEstadoUsuario);

                entity.Property(e => e.DescripcionEstadoUsuario)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<EstadoVoluntario>(entity =>
            {
                entity.HasKey(e => e.IdEstadoVoluntario);

                entity.Property(e => e.DescripcionEstadoVoluntario)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Funcionalidad>(entity =>
            {
                entity.HasKey(e => e.IdFuncionalidad);

                entity.Property(e => e.Controller)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DescripcionFuncionalidad)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Metodo)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<FuncionalidadPerfil>(entity =>
            {
                entity.HasKey(e => e.IdFuncionalidadPerfil);

                entity.HasOne(d => d.IdFuncionalidadNavigation)
                    .WithMany(p => p.FuncionalidadPerfil)
                    .HasForeignKey(d => d.IdFuncionalidad)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKFuncionalidadPerfilFuncionalidad");

                entity.HasOne(d => d.IdPerfilNavigation)
                    .WithMany(p => p.FuncionalidadPerfil)
                    .HasForeignKey(d => d.IdPerfil)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKFuncionalidadPerfilPerfil");
            });

            modelBuilder.Entity<MarcaVoluntario>(entity =>
            {
                entity.HasKey(e => e.IdMarcaVoluntario);

                entity.Property(e => e.Fecha).HasColumnType("datetime");

                entity.HasOne(d => d.IdTipoMarcaNavigation)
                    .WithMany(p => p.MarcaVoluntario)
                    .HasForeignKey(d => d.IdTipoMarca)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MarcaVoluntarioTipoMarca");

                entity.HasOne(d => d.IdVoluntarioNavigation)
                    .WithMany(p => p.MarcaVoluntario)
                    .HasForeignKey(d => d.IdVoluntario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MarcaVoluntarioVoluntario");
            });

            modelBuilder.Entity<Perfil>(entity =>
            {
                entity.HasKey(e => e.IdPerfil);

                entity.Property(e => e.DescripcionPerfil)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TipoCitacion>(entity =>
            {
                entity.HasKey(e => e.IdTipoCitacion);

                entity.Property(e => e.DescripcionTipoCitacion)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TipoMarca>(entity =>
            {
                entity.HasKey(e => e.IdTipoMarca);

                entity.Property(e => e.DescripcionTipoMarca)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario);

                entity.Property(e => e.ApellidoMaterno)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ApellidoPaterno)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CorreoElectronico)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NombreUsuario)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Nombres)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('.')");

                entity.HasOne(d => d.IdEstadoUsuarioNavigation)
                    .WithMany(p => p.Usuario)
                    .HasForeignKey(d => d.IdEstadoUsuario)
                    .HasConstraintName("FKUsuarioEstadoUsuario");

                entity.HasOne(d => d.IdPerfilNavigation)
                    .WithMany(p => p.Usuario)
                    .HasForeignKey(d => d.IdPerfil)
                    .HasConstraintName("FKUsuarioPerfil");
            });

            modelBuilder.Entity<Voluntario>(entity =>
            {
                entity.HasKey(e => e.IdVoluntario);

                entity.Property(e => e.ApellidoMaterno)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ApellidoPaterno)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DigitoVerificador)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.FechaIncorporacion).HasColumnType("datetime");

                entity.Property(e => e.FechaNacimiento).HasColumnType("datetime");

                entity.Property(e => e.Nombres)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdCompaniaNavigation)
                    .WithMany(p => p.Voluntario)
                    .HasForeignKey(d => d.IdCompania)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_VoluntarioCompania");

                entity.HasOne(d => d.IdEstadoVoluntarioNavigation)
                    .WithMany(p => p.Voluntario)
                    .HasForeignKey(d => d.IdEstadoVoluntario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_VoluntarioEstadoVoluntario");
            });

            modelBuilder.Entity<VoluntarioCargo>(entity =>
            {
                entity.HasKey(e => e.IdVoluntarioCargo);

                entity.Property(e => e.FechaInicio).HasColumnType("datetime");

                entity.Property(e => e.FechaTermino).HasColumnType("datetime");

                entity.HasOne(d => d.IdCargoNavigation)
                    .WithMany(p => p.VoluntarioCargo)
                    .HasForeignKey(d => d.IdCargo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_VoluntarioCargoCargo");

                entity.HasOne(d => d.IdVoluntarioNavigation)
                    .WithMany(p => p.VoluntarioCargo)
                    .HasForeignKey(d => d.IdVoluntario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_VoluntarioCargoVoluntario");
            });
        }
    }
}
