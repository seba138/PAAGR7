using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaAcademico.Datos
{
    public class Curso
    {
        [Key]
        public int CursoId { get; set; }

        public string NombreCurso { get; set; }
        public string Descripcion { get; set; }

        // Relación con Profesor
        public string CedulaProfesor { get; set; }
        [ForeignKey("CedulaProfesor")]
        public virtual Profesor Profesor { get; set; }

        public virtual ICollection<EstudianteCurso> EstudiantesCursos { get; set; }
        public virtual ICollection<Notas> Notas { get; set; }
    }


}
