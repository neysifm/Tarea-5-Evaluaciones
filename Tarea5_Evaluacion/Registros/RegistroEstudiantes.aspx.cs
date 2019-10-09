using BLL;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Tarea5_Evaluacion.Registros
{
    public partial class RegistroEstudiantes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                FechaTextBox.Text = DateTime.Now.ToString();
                Limpiar();
                int id = Request.QueryString["EstudianteID"].ToInt();
                if (id > 0)
                {
                    using (RepositorioBase<Estudiantes> repositorio = new RepositorioBase<Estudiantes>())
                    {
                        Estudiantes estudiantes = repositorio.Buscar(id);
                        if (estudiantes == null)
                        {
                            MostrarMensajes.Text = "Registro No Encontrado!";
                            MostrarMensajes.CssClass = "alert-warning";
                            MostrarMensajes.Visible = true;
                        }
                        else
                            LlenaCampo(estudiantes);
                    }
                }
            }
        }
        private void Limpiar()
        {
            EstudianteIDTextBox.Text = 0.ToString();
            FechaTextBox.Text = DateTime.Now.ToString();
            NombreTextBox.Text = string.Empty;
            ApellidoTextBox.Text = string.Empty;
            PuntosPerdidosTextBox.Text = 0.ToString();
        }
        private void LlenaCampo(Estudiantes estudiantes)
        {
            EstudianteIDTextBox.Text = estudiantes.EstudianteID.ToString();
            FechaTextBox.Text = estudiantes.Fecha.ToString();
            NombreTextBox.Text = estudiantes.Nombre;
            ApellidoTextBox.Text = estudiantes.Apellido;
            PuntosPerdidosTextBox.Text = estudiantes.PuntosPerdidos.ToString();
        }
        private Estudiantes LlenaClase()
        {
            Estudiantes estudiantes = new Estudiantes();
            DateTime.TryParse(FechaTextBox.Text, out DateTime result);
            estudiantes.EstudianteID = EstudianteIDTextBox.Text.ToInt();
            estudiantes.Fecha = result;
            estudiantes.Nombre = NombreTextBox.Text;
            estudiantes.Apellido = ApellidoTextBox.Text;
            estudiantes.PuntosPerdidos = PuntosPerdidosTextBox.Text.ToDecimal();
            return estudiantes;
        }
        private bool Validar()
        {
            bool paso = true;
            if (string.IsNullOrWhiteSpace(NombreTextBox.Text))
                paso = false;
            if (string.IsNullOrWhiteSpace(ApellidoTextBox.Text))
                paso = false;
            return paso;
        }
        private bool ExisteEnLaBaseDeDatos()
        {
            RepositorioBase<Estudiantes> repositorio = new RepositorioBase<Estudiantes>();
            return !(repositorio.Buscar(EstudianteIDTextBox.Text.ToInt()) != null);
        }
        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            RepositorioBase<Estudiantes> repositorio = new RepositorioBase<Estudiantes>();
            if (!ExisteEnLaBaseDeDatos())
            {
                MostrarMensajes.Text = "Registro No Encontrado!";
                MostrarMensajes.CssClass = "alert-warning";
                MostrarMensajes.Visible = true;
                return;
            }
            else
            {
                Estudiantes estudiantes = repositorio.Buscar(EstudianteIDTextBox.Text.ToInt());
                if (estudiantes != null)
                    LlenaCampo(estudiantes);
                else
                    MostrarMensajes.Text = "Registro No Encontrado!";
                    MostrarMensajes.CssClass = "alert-warning";
                    MostrarMensajes.Visible = true;
            }
            repositorio.Dispose();
        }

        protected void NuevoButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        protected void GuadarButton_Click(object sender, EventArgs e)
        {
            if (!Validar())
            return;
            RepositorioBase<Estudiantes> repositorio = new RepositorioBase<Estudiantes>();
            Estudiantes estudiantes = LlenaClase();
            bool paso = false;
            MostrarMensajes.Text = "Registro No Encontrado!";
            MostrarMensajes.CssClass = "alert-warning";
            MostrarMensajes.Visible = true;

            if (estudiantes.EstudianteID == 0)
                paso = repositorio.Guardar(estudiantes);
            else
            {
                if (!ExisteEnLaBaseDeDatos())
                {
                    MostrarMensajes.Text = "Registro No Encontrado!";
                    MostrarMensajes.CssClass = "alert-warning";
                    MostrarMensajes.Visible = true;
                    return;
                }
                else
                    paso = repositorio.Modificar(estudiantes);
            }
            if (paso)
            {
                Limpiar();
                MostrarMensajes.Text = "Guardado Correctamente!";
                MostrarMensajes.CssClass = "alert-success";
                MostrarMensajes.Visible = true;
            }
                MostrarMensajes.Text = "El Registro No Se Pudo Guardar!!";
                MostrarMensajes.CssClass = "alert-warning";
                MostrarMensajes.Visible = true;
                repositorio.Dispose();
        }

        protected void EliminarButton_Click(object sender, EventArgs e)
        {
            RepositorioBase<Estudiantes> repositorio = new RepositorioBase<Estudiantes>();

            if (!ExisteEnLaBaseDeDatos())
            {
                MostrarMensajes.Visible = true;
                MostrarMensajes.Text = "Registro No encontrado";
                MostrarMensajes.CssClass = "alert-danger";
                return;
            }
            else
            {
                if (repositorio.Eliminar(EstudianteIDTextBox.Text.ToInt()))
                {
                    Limpiar();
                    MostrarMensajes.Visible = true;
                    MostrarMensajes.Text = "Eliminado Exitosamente!!";
                    MostrarMensajes.CssClass = "alert-danger";
                }
            }
            repositorio.Dispose();
        }
    }
}