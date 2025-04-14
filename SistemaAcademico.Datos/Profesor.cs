using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaAcademico.Datos
{
    public class Profesor
    {
        [Key] // CLAVE PRIMARIA
        public string CedulaId { get; set; } // CLAVE PRIMARIA PARA QUE EL ENTITY FRAMEWORK SEPA QUE ES LA CLAVE PRIMARIA
        public string Nombre { get; set; }
        public string Correo { get; set; }

        // Relación con Cursos
        public virtual ICollection<Curso> Cursos { get; set; } // Relación con Curso
    }

}
