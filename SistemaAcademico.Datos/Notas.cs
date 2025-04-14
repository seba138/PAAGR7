using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaAcademico.Datos
{
    public class Notas
    {

        [Key, Column(Order = 0)]
        public int CedulaEstudiante { get; set; }
        [ForeignKey("CedulaEstudiante")]
        public virtual Estudiante Estudiante { get; set; }

        [Key, Column(Order = 1)]
        public int IdCurso { get; set; }
        [ForeignKey("IdCurso")]
        public virtual Curso Curso { get; set; }

        public string ValorNota { get; set; }

    }


}
