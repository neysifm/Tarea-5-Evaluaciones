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
    public partial class RegistroCategorias : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                FechaTextBox.Text = DateTime.Now.ToString();
                Limpiar();
                int id = Request.QueryString["CategoriaID"].ToInt();
                if (id > 0)
                {
                    using (RepositorioBase<Categorias> repositorio = new RepositorioBase<Categorias>())
                    {
                        Categorias Categoria = repositorio.Buscar(id);
                        if (Categoria == null)
                        {
                            MostrarMensajes.Text = "Registro No Encontrado!";
                            MostrarMensajes.CssClass = "alert-warning";
                            MostrarMensajes.Visible = true;
                        }
                        else
                            LlenaCampo(Categoria);
                    }
                }
            }
        }
        private void Limpiar()
        {
            CategoriaID.Text = 0.ToString();
            FechaTextBox.Text = DateTime.Now.ToString();
            DescripcionTextBox.Text = string.Empty;
            PromedioTextBox.Text = string.Empty;
            MostrarMensajes.Visible = false;
            MostrarMensajes.Text = string.Empty;
        }

        private bool Validar()
        {
            bool paso = true;
            if (string.IsNullOrEmpty(DescripcionTextBox.Text))
                paso = false;
            return paso;
        }

        private Categorias LlenaClase()
        {
            Categorias categorias = new Categorias();
            DateTime.TryParse(FechaTextBox.Text, out DateTime result);
            categorias.CategoriaID = CategoriaID.Text.ToInt();
            categorias.Fecha = result;
            categorias.Descripcion = DescripcionTextBox.Text;
            return categorias;
        }

        private void LlenaCampo(Categorias categorias)
        {
            CategoriaID.Text = categorias.CategoriaID.ToString();
            FechaTextBox.Text = categorias.Fecha.ToString();
            DescripcionTextBox.Text = categorias.Descripcion.ToString();
            PromedioTextBox.Text = categorias.PromedioPerdida.ToString();
        }

        protected void NuevoButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }
        protected void GuadarButton_Click(object sender, EventArgs e)
        {
            if (!Validar())
                return;
            RepositorioBase<Categorias> repositorio = new RepositorioBase<Categorias>();
            Categorias categorias = LlenaClase();
            bool paso = false;
            MostrarMensajes.Text = "Registro No Encontrado!";
            MostrarMensajes.CssClass = "alert-warning";
            MostrarMensajes.Visible = true;

            if (categorias.CategoriaID == 0)
                paso = repositorio.Guardar(categorias);
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
                    paso = repositorio.Modificar(categorias);
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

        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            RepositorioBase<Categorias> repositorio = new RepositorioBase<Categorias>();
            if (!ExisteEnLaBaseDeDatos())
            {
                MostrarMensajes.Text = "Registro No Encontrado!";
                MostrarMensajes.CssClass = "alert-warning";
                MostrarMensajes.Visible = true;
                return;
            }
            else
            {
                Categorias categorias = repositorio.Buscar(CategoriaID.Text.ToInt());
                if (categorias != null)
                    LlenaCampo(categorias);
                else
                    MostrarMensajes.Text = "Registro No Encontrado!";
                    MostrarMensajes.CssClass = "alert-warning";
                    MostrarMensajes.Visible = true;
            }
            repositorio.Dispose();
        }

        protected void EliminarButton_Click(object sender, EventArgs e)
        {
            RepositorioBase<Categorias> repositorio = new RepositorioBase<Categorias>();

            if (!ExisteEnLaBaseDeDatos())
            {
                MostrarMensajes.Visible = true;
                MostrarMensajes.Text = "No encontrado";
                MostrarMensajes.CssClass = "alert-danger";
                return;
            }
            else
            {
                if (repositorio.Eliminar(CategoriaID.Text.ToInt()))
                {
                    Limpiar();
                    MostrarMensajes.Visible = true;
                    MostrarMensajes.Text = "Eliminado";
                    MostrarMensajes.CssClass = "alert-danger";
                }
            }
            repositorio.Dispose();
        }

        public bool ExisteEnLaBaseDeDatos()
        {
            using (RepositorioBase<Categorias> repositorio = new RepositorioBase<Categorias>())
            {
                return !(repositorio.Buscar(CategoriaID.Text.ToInt()) == null);
            }
        }
    }
}