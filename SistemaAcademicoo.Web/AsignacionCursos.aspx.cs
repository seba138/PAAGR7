using SistemaAcademico.Datos;
using System;
using System.Linq;
using System.Web.UI.WebControls;

namespace SistemaAcademicoo.Web
{
    public partial class AsignacionCursos : System.Web.UI.Page
    {
        SistemaAcademicoDbContext db = new SistemaAcademicoDbContext();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarCursos();
            }
        }

        private void CargarCursos()
        {
            var cursos = db.Cursos.ToList();
            if (cursos.Any())
            {
                // Limpiar items actuales del DropDownList
                ddlCursos.Items.Clear();

                // Añadir el primer item vacío
                ddlCursos.Items.Add(new ListItem("Seleccione un curso", ""));

                // Agregar los cursos al DropDownList sin usar DataBind()
                foreach (var curso in cursos)
                {
                    ddlCursos.Items.Add(new ListItem(curso.NombreCurso, curso.CursoId.ToString()));
                }
            }
            else
            {
                lblMensaje.Text = "<br>No se encontraron cursos disponibles.";
                lblMensaje.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void btnAsignar_Click(object sender, EventArgs e)
        {
            // Validar cédula
            if (!int.TryParse(txtCedula.Text.Trim(), out int cedulaId))
            {
                lblMensaje.Text = "<br> Ingrese una cédula válida.";
                lblMensaje.ForeColor = System.Drawing.Color.Red;
                return;
            }

            int cursoId = int.Parse(ddlCursos.SelectedValue);

            // Buscar estudiante por cédula
            var estudiante = db.Estudiantes.FirstOrDefault(ex => ex.CedulaId == cedulaId);
            if (estudiante == null)
            {
                lblMensaje.Text = "<br> Estudiante no encontrado con esa cédula.";
                lblMensaje.ForeColor = System.Drawing.Color.Red;
                return;
            }

            // Verificar si el estudiante ya está asignado al curso
            bool yaAsignado = db.EstudiantesCursos
                .Any(ec => ec.CedulaId == cedulaId && ec.CursoId == cursoId);

            if (yaAsignado)
            {
                lblMensaje.Text = "<br>  El curso ya está asignado a este estudiante.";
                lblMensaje.ForeColor = System.Drawing.Color.Red;
                return;
            }

            // Crear la asignación de curso a estudiante
            var asignacion = new EstudianteCurso
            {
                CedulaId = cedulaId,
                CursoId = cursoId
            };

            db.EstudiantesCursos.Add(asignacion);
            db.SaveChanges();

            lblMensaje.Text = "<br> Curso asignado exitosamente.";
            lblMensaje.ForeColor = System.Drawing.Color.Green;
        }

        protected void btnSalir_Click(object sender, EventArgs e)
        {
            Response.Redirect("Inicio.aspx");
        }
    }
}
