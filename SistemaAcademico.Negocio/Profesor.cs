using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using SistemaAcademico.Datos;

namespace SistemaAcademico.Negocio
{
    public class ProfesorNegocio
    {
        public void Agregar(Profesor profesor)
        {
            using (var context = new SistemaAcademicoDbContext())
            {
                context.Profesores.Add(profesor);
                context.SaveChanges();
            }
        }
       
        public List<Profesor> Listar()
        {
            using (var context = new SistemaAcademicoDbContext())
            {
                return context.Profesores.ToList();
            }
        }

        public Profesor ObtenerPorCedula(string cedulaId)
        {
            using (var context = new SistemaAcademicoDbContext())
            {
                return context.Profesores.Find(cedulaId);
            }
        }

        public void Actualizar(Profesor profesor)
        {
            using (var context = new SistemaAcademicoDbContext())
            {
                context.Entry(profesor).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void Eliminar(string cedulaId)
        {
            using (var context = new SistemaAcademicoDbContext())
            {
                var profesor = context.Profesores.Find(cedulaId);
                if (profesor != null)
                {
                    context.Profesores.Remove(profesor);
                    context.SaveChanges();
                }
            }
        }
    }

}
