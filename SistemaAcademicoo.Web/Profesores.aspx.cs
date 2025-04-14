using System;
using System.Data.Entity;
using System.Web.UI;
using SistemaAcademico.Datos;

namespace SistemaAcademicoo.Web
{
    public partial class Profesores : Page
    {
        // Declaramos el contexto aquí, asegurándonos de que se inicializa al inicio de la página
        private readonly SistemaAcademicoDbContext dbContext;

        // En este caso, no es necesario usar un constructor para el DbContext,
        // lo inicializamos directamente en la propiedad.
        public Profesores()
        {
            dbContext = new SistemaAcademicoDbContext(); // Tu DbContext
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            // Código adicional si es necesario en el Page_Load
        }

        // Método que maneja la acción de agregar un profesor
        protected void btnAgregarProfesor_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                // Crear un nuevo objeto Profesor con los datos ingresados
                var profesor = new Profesor
                {
                    CedulaId = txtCedula.Text,
                    Nombre = txtNombre.Text,
                    Correo = txtCorreo.Text
                };

                try
                {
                    // Agregar el profesor al contexto de la base de datos
                    dbContext.Profesores.Add(profesor);  // 'Profesores' es el DbSet<Profesor>
                    dbContext.SaveChanges();  // Guardar los cambios en la base de datos

                    // Mostrar mensaje de éxito
                    lblMensaje.Text = "Profesor registrado correctamente.";
                    lblMensaje.CssClass = "message-container"; // Clase para mensaje de éxito

                    // Limpiar los campos después de agregar el profesor
                    LimpiarCampos();
                }
                catch (Exception ex)
                {
                    // En caso de error, mostrar el mensaje de error
                    lblMensaje.Text = $"Error al registrar el profesor: {ex.Message}";
                    lblMensaje.CssClass = "message-container error"; // Clase para mensaje de error
                }
            }
            else
            {
                // Mostrar mensaje de error si no se valida la página
                lblMensaje.Text = "Hubo un error al registrar el profesor.";
                lblMensaje.CssClass = "message-container error"; // Clase para mensaje de error
            }
        }

        // Método para limpiar los campos de texto después de la inserción
        private void LimpiarCampos()
        {
            txtCedula.Text = string.Empty;
            txtNombre.Text = string.Empty;
            txtCorreo.Text = string.Empty;
        }

        // Método que maneja la acción de salir, redirigiendo al inicio
        protected void btnSalir_Click(object sender, EventArgs e)
        {
            Response.Redirect("Inicio.aspx"); // Redirige a la página de inicio
        }
    }
}
