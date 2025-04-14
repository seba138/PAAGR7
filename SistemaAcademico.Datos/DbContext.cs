using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaAcademico.Datos
{
    public class SistemaAcademicoDbContext : DbContext
    {
        public SistemaAcademicoDbContext()
            : base("name=SistemaAcademicoConnection") // NOMBRE DE LA CADENA DE CONEXION
        {
        }

        // Definicion de las tablas en la base de datos
        public DbSet<Estudiante> Estudiantes { get; set; }
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<EstudianteCurso> EstudiantesCursos { get; set; }
        public DbSet<Profesor> Profesores { get; set; }
        public DbSet<Notas> Notas { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Configurar la clave primaria compuesta para la tabla EstudianteCurso
            modelBuilder.Entity<EstudianteCurso>()
                .HasKey(ec => new { ec.CedulaId, ec.CursoId });

            // Relación Estudiante - EstudianteCurso
            modelBuilder.Entity<EstudianteCurso>()
                .HasRequired(ec => ec.Estudiante)
                .WithMany(e => e.EstudiantesCursos)
                .HasForeignKey(ec => ec.CedulaId);

            // Relación Curso - EstudianteCurso
            modelBuilder.Entity<EstudianteCurso>()
                .HasRequired(ec => ec.Curso)
                .WithMany(c => c.EstudiantesCursos)
                .HasForeignKey(ec => ec.CursoId);

            // Clave primaria NO autogenerada para Estudiante
            modelBuilder.Entity<Estudiante>()
                .Property(e => e.CedulaId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Clave primaria NO autogenerada para Curso
            modelBuilder.Entity<Curso>()
                .Property(c => c.CursoId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Clave primaria NO autogenerada para Profesor
            // 
            modelBuilder.Entity<Profesor>()
                .Property(p => p.CedulaId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);


            // Clave primaria compuesta para Notas (CedulaEstudiante, IdCurso)
            modelBuilder.Entity<Notas>()
     .HasKey(n => new { n.CedulaEstudiante, n.IdCurso });


            // Relación Curso - Profesor (Un curso lo imparte un profesor)
            modelBuilder.Entity<Curso>()
                .HasRequired(c => c.Profesor)
                .WithMany(p => p.Cursos)
                .HasForeignKey(c => c.CedulaProfesor);

            // Relación Nota - Estudiante
            modelBuilder.Entity<Notas>()
                .HasRequired(n => n.Estudiante)
                .WithMany(e => e.Notas)
                .HasForeignKey(n => n.CedulaEstudiante);

            // Relación Nota - Curso
            modelBuilder.Entity<Notas>()
                .HasRequired(n => n.Curso)
                .WithMany(c => c.Notas)
                .HasForeignKey(n => n.IdCurso);

            base.OnModelCreating(modelBuilder);
        }
    }
}
