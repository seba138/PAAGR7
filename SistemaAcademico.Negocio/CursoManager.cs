using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaAcademico.Datos; // Asegúrate de que esta ruta coincida con tu proyecto
using System.Data.Entity; // Necesario para Include()

namespace SistemaAcademico.Negocio
{
    public class CursoManager
    {
        private SistemaAcademicoDbContext db = new SistemaAcademicoDbContext();

        // Registrar un nuevo curso
        public string RegistrarCurso(Curso curso)
        {
            try
            {
                if (db.Cursos.Any(c => c.CursoId == curso.CursoId))
                    return "Ya existe un curso con ese ID. Verifique el ID.";

                db.Cursos.Add(curso);
                db.SaveChanges();
                return "Curso registrado con éxito.";
            }
            catch (Exception ex)
            {
                return "Error al registrar el curso: " + ex.Message;
            }
        }

        // Obtener todos los cursos incluyendo datos del profesor
        public List<Curso> ObtenerTodos()
        {
            try
            {
                return db.Cursos.Include(c => c.Profesor).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener la lista de cursos. " + ex.Message);
            }
        }

        // Obtener un curso por ID
        public Curso ObtenerPorId(int cursoId)
        {
            try
            {
                var curso = db.Cursos.Include(c => c.Profesor).FirstOrDefault(c => c.CursoId == cursoId);
                if (curso == null)
                    throw new Exception("Curso no encontrado. Verifique el Curso.");
                return curso;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al buscar el curso. " + ex.Message);
            }
        }

        // Actualizar curso
        public string ActualizarCurso(Curso cursoActualizado)
        {
            try
            {
                var cursoExistente = db.Cursos.FirstOrDefault(c => c.CursoId == cursoActualizado.CursoId);

                if (cursoExistente == null)
                    return "El curso no existe. Verifique el Curso.";

                cursoExistente.NombreCurso = cursoActualizado.NombreCurso;
                cursoExistente.Descripcion = cursoActualizado.Descripcion;
                cursoExistente.CedulaProfesor = cursoActualizado.CedulaProfesor; // NUEVO

                db.SaveChanges();
                return "Curso actualizado con éxito.";
            }
            catch (Exception ex)
            {
                return "Error al actualizar el curso: " + ex.Message;
            }
        }

        // Eliminar curso
        public string EliminarCurso(int cursoId)
        {
            try
            {
                var curso = db.Cursos.FirstOrDefault(c => c.CursoId == cursoId);

                if (curso == null)
                    return "El curso no existe. Verifique el Curso.";

                db.Cursos.Remove(curso);
                db.SaveChanges();
                return "Curso eliminado con éxito.";
            }
            catch (Exception ex)
            {
                return "Error al eliminar el curso: " + ex.Message;
            }
        }
    }
}
