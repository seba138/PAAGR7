using SistemaAcademico.Datos;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SistemaAcademico.Negocio
{
    public class NotasManager
    {
        // Método para guardar una nota para varios estudiantes
        public void GuardarNotasParaVariosEstudiantes(List<int> estudiantes, int idCurso, string valorNota)
        {
            try
            {
                using (var db = new SistemaAcademicoDbContext())
                {
                    // Crear una lista de objetos de tipo Notas para agregar
                    List<Notas> listaNotas = new List<Notas>();

                    // Recorrer la lista de estudiantes
                    foreach (var cedulaEstudiante in estudiantes)
                    {
                        // Crear una nueva instancia de Notas para cada estudiante
                        listaNotas.Add(new Notas
                        {
                            CedulaEstudiante = cedulaEstudiante,
                            IdCurso = idCurso,
                            ValorNota = valorNota
                        });
                    }

                    // Agregar todas las notas al DbContext de una sola vez
                    db.Notas.AddRange(listaNotas);

                    // Guardar los cambios en la base de datos
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                // Manejar cualquier error que ocurra durante el proceso
                throw new Exception("Error al guardar las notas: " + ex.Message);
            }
        }

        // Método para obtener todas las notas de un curso específico
        public List<Notas> ObtenerNotasPorCurso(int idCurso)
        {
            using (var db = new SistemaAcademicoDbContext())
            {
                return db.Notas.Where(n => n.IdCurso == idCurso).ToList();
            }
        }
    }
}
