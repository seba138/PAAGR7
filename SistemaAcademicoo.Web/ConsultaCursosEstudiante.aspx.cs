using SistemaAcademico.Datos;
using System;
using System.Linq;

namespace SistemaAcademicoo.Web
{
    public partial class ConsultaCursosEstudiante : System.Web.UI.Page
    {
        private readonly SistemaAcademicoDbContext db = new SistemaAcademicoDbContext();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Inicialización si se necesita
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            lblMensaje.Text = "";
            gvCursos.DataSource = null;

            if (!int.TryParse(txtCedula.Text, out int cedulaId))
            {
                lblMensaje.Text = "Ingrese una cédula válida.";
                gvCursos.DataBind(); // Safe, ahora está enlazando fuente nula
                return;
            }

            var estudiante = db.Estudiantes.FirstOrDefault(ex => ex.CedulaId == cedulaId);
            if (estudiante == null)
            {
                lblMensaje.Text = "Estudiante no encontrado.";
                gvCursos.DataBind();
                return;
            }

            var cursos = db.EstudiantesCursos
                .Where(ec => ec.CedulaId == cedulaId)
                .Select(ec => new
                {
                    ec.Curso.CursoId,
                    ec.Curso.NombreCurso,
                    ec.Curso.Descripcion
                })
                .ToList();

            if (cursos.Count == 0)
            {
                lblMensaje.Text = "El estudiante no tiene cursos asignados.";
            }
            else
            {
                lblMensaje.Text = $"Cursos asignados a: {estudiante.Nombre} {estudiante.Apellido}";
                lblMensaje.CssClass = "success";
            }

            gvCursos.DataSource = cursos;
            gvCursos.DataBind();
        }

        protected void btnSalir_Click(object sender, EventArgs e)
        {
            Response.Redirect("Inicio.aspx");
        }
    }
}
