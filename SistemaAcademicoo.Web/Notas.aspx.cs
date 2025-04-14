using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using SistemaAcademico.Datos;

namespace SistemaAcademicoo.Web
{
    public partial class Notas : System.Web.UI.Page
    {
        private SistemaAcademicoDbContext context = new SistemaAcademicoDbContext();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Nada aquí porque se cargan cursos al hacer clic en el botón
            }
        }

        protected void btnBuscarCursos_Click(object sender, EventArgs e)
        {
            string cedulaProfesor = txtCedulaProfesor.Text;
            CargarCursosProfesor(cedulaProfesor);
        }

        private void CargarCursosProfesor(string cedulaProfesor)
        {
            var cursos = context.Cursos
                                .Where(c => c.Profesor.CedulaId == cedulaProfesor)
                                .ToList();  // Materializa la consulta en una lista

            ddlCursos.DataSource = cursos;
            ddlCursos.DataTextField = "NombreCurso";  // Asume que esta propiedad existe en la clase Curso
            ddlCursos.DataValueField = "CursoId";    // Cambiado a "CursoId" ya que esa es la propiedad correcta
            ddlCursos.DataBind();

            ddlCursos.Items.Insert(0, new ListItem("-- Selecciona un curso --", "0"));
        }

        protected void ddlCursos_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idCurso;
            if (int.TryParse(ddlCursos.SelectedValue, out idCurso) && idCurso > 0)
            {
                CargarEstudiantes(idCurso);
            }
        }

        private void CargarEstudiantes(int idCurso)
        {
            var estudiantes = context.EstudiantesCursos
                .Where(ec => ec.CursoId == idCurso)
                .Select(ec => ec.Estudiante)
                .ToList();

            gvEstudiantes.DataSource = estudiantes;
            gvEstudiantes.DataBind();
        }

        protected void gvEstudiantes_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                var estudiante = (SistemaAcademico.Datos.Estudiante)e.Row.DataItem;

                Label lblCedulaId = (Label)e.Row.FindControl("lblCedulaId");
                Label lblIdCurso = (Label)e.Row.FindControl("lblIdCurso");

                lblCedulaId.Text = estudiante.CedulaId.ToString();
                lblIdCurso.Text = ddlCursos.SelectedValue;
            }
        }

        protected void btnGuardarNotas_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (GridViewRow row in gvEstudiantes.Rows)
                {
                    TextBox txtNota = (TextBox)row.FindControl("txtNota");
                    Label lblCedulaId = (Label)row.FindControl("lblCedulaId");
                    Label lblIdCurso = (Label)row.FindControl("lblIdCurso");

                    if (txtNota != null && !string.IsNullOrEmpty(txtNota.Text))
                    {
                        var cedula = Convert.ToInt32(lblCedulaId.Text);
                        var idCurso = Convert.ToInt32(lblIdCurso.Text);

                        // Verificar si ya existe una nota previa
                        var notaExistente = context.Notas
                            .FirstOrDefault(n => n.CedulaEstudiante == cedula && n.IdCurso == idCurso);

                        if (notaExistente != null)
                        {
                            notaExistente.ValorNota = txtNota.Text;
                        }
                        else
                        {
                            var nuevaNota = new SistemaAcademico.Datos.Notas
                            {
                                CedulaEstudiante = cedula,
                                IdCurso = idCurso,
                                ValorNota = txtNota.Text
                            };
                            context.Notas.Add(nuevaNota);
                        }
                    }
                }

                // Guardar los cambios en la base de datos
                context.SaveChanges();

                // Mostrar mensaje de éxito
                lblMensaje.Text = "✅ Las notas se registraron correctamente.";
                lblMensaje.ForeColor = System.Drawing.Color.Green;
            }
            catch (Exception ex)
            {
                // Mostrar mensaje de error si ocurre una excepción
                lblMensaje.Text = "❌ Error al registrar las notas: " + ex.Message;
                lblMensaje.ForeColor = System.Drawing.Color.Red;
            }
        }


        protected void btnSalir_Click(object sender, EventArgs e)
        {
            Response.Redirect("Inicio.aspx"); // Asegúrate que el nombre coincide con tu página de inicio
        }

    }
}
