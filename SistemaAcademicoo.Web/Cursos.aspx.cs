using System;
using SistemaAcademico.Negocio;
using SistemaAcademico.Datos;
using System.Collections.Generic;

namespace SistemaAcademicoo.Web
{
    public partial class Cursos : System.Web.UI.Page
    {
        CursoManager cursoNegocio = new CursoManager();
        ProfesorNegocio profesorNegocio = new ProfesorNegocio();  // Usar ProfesorNegocio

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarCursos();
            }
        }

        // Método para cargar los cursos en el GridView
        private void CargarCursos()
        {
            gvCursos.DataSource = cursoNegocio.ObtenerTodos();  // Obtener todos los cursos desde la capa de negocio
            gvCursos.DataBind();  // Vinculamos los datos al GridView
        }

        // Método para registrar un nuevo curso
        protected void btnRegistrarCurso_Click(object sender, EventArgs e)
        {
            try
            {
                string cedulaProfesor = txtCedulaProfesor.Text.Trim();

                // Verificar que la cédula ingresada corresponda a un profesor válido
                Profesor profesor = profesorNegocio.ObtenerPorCedula(cedulaProfesor);

                if (profesor == null)
                {
                    lblMensaje.Text = "Error: No se encontró un profesor con esa cédula.";
                    return;
                }
                Curso nuevoCurso = new Curso
                {
                    CursoId = int.Parse(txtCursoId.Text),
                    NombreCurso = txtCursoNombre.Text,
                    Descripcion = txtCursoDescripcion.Text,
                    CedulaProfesor = cedulaProfesor  // Usamos la cédula ingresada
                };

                string resultado = cursoNegocio.RegistrarCurso(nuevoCurso);  // Registrar el curso
                lblMensaje.Text = resultado;
                CargarCursos();  // Recargar los cursos
                LimpiarCampos();  // Limpiar campos
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error: " + ex.Message;  // Manejar errores
            }
        }

        // Método para manejar la eliminación de un curso
        protected void gvCursos_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
        {
            if (e.CommandName == "EliminarCurso")
            {
                int cursoId = Convert.ToInt32(e.CommandArgument);  // Obtener el ID del curso
                string resultado = cursoNegocio.EliminarCurso(cursoId);  // Eliminar el curso
                lblMensaje.Text = resultado;
                CargarCursos();  // Recargar la lista de cursos
            }
        }

        // Método para limpiar los campos del formulario
        private void LimpiarCampos()
        {
            txtCursoId.Text = "";
            txtCursoNombre.Text = "";
            txtCursoDescripcion.Text = "";
            txtCedulaProfesor.Text = "";  // Limpiar el campo de cédula
        }

        // Método para redirigir a la página de inicio
        protected void btnSalir_Click(object sender, EventArgs e)
        {
            Response.Redirect("Inicio.aspx");  // Redirigir al inicio
        }
    }
}
