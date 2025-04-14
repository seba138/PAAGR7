using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaAcademico.Datos
{
    public class Estudiante
    {
        [Key]
        public int CedulaId { get; set; }  // CLAVE PRIMARIA PARA EL ESTUDIANTE
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string CorreoElectronico { get; set; }
        public string Telefono { get; set; }
        // Relación de uno a muchos con Notas
        public virtual ICollection<Notas> Notas { get; set; }

        // Relación con EstudianteCurso (ya la tenías)
        public virtual ICollection<EstudianteCurso> EstudiantesCursos { get; set; }
    }

}
