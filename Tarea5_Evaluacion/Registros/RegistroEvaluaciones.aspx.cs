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
    public partial class RegistroEvaluaciones : System.Web.UI.Page
    {
        readonly string KeyViewState = "Evaluacion";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ViewState[KeyViewState] = new Evaluaciones();
            }
        }

        private void Limpiar()
        {
            EvaluacionIDTextBox.Text = 0.ToString();
            FechaTextBox.Text = DateTime.Now.ToString();
            EstudianteTextBox.Text = string.Empty;
            CategoriaTextBox.Text = string.Empty;
            ValorTextBox.Text = 0.ToString();
            LogradoTextBox.Text = 0.ToString();
            TotalPerdidoTextBox.Text = 0.ToString();
            MostrarMensajes.Visible = false;
            MostrarMensajes.Text = string.Empty;
            ViewState[KeyViewState] = new Evaluaciones();
            ActualizarGrid();
        }

        private bool Validar()
        {
            bool paso = true;
            if (string.IsNullOrEmpty(EstudianteTextBox.Text))
                paso = false;
            if (string.IsNullOrEmpty(FechaTextBox.Text))
                paso = false;
            if (DetalleGridView.Rows.Count <= 0)
                paso = false;
            return paso;
        }

        private Evaluaciones LlenaClase()
        {
            Evaluaciones evaluaciones = new Evaluaciones();
            DateTime.TryParse(FechaTextBox.Text, out DateTime result);
            evaluaciones = (Evaluaciones)ViewState[KeyViewState];
            evaluaciones.EvaluacionID = EvaluacionIDTextBox.Text.ToInt();
            evaluaciones.Fecha = result;
            evaluaciones.EstudianteID = EstudianteDropdownList.SelectedValue.ToInt();
            evaluaciones.TotalPerdido = TotalPerdidoTextBox.Text.ToDecimal();
            evaluaciones.DetalleEvaluaciones.ForEach(x => evaluaciones.TotalPerdido += x.Perdido);
            return evaluaciones;
        }

        private void LlenaCampo(Evaluaciones evaluaciones)
        {
            Limpiar();
            EvaluacionIDTextBox.Text = evaluaciones.EvaluacionID.ToString();
            FechaTextBox.Text = evaluaciones.Fecha.ToString();
            EstudianteDropdownList.SelectedValue = evaluaciones.EstudianteID.ToString();
            TotalPerdidoTextBox.Text = evaluaciones.TotalPerdido.ToString();
            ViewState[KeyViewState] = evaluaciones;
            ActualizarGrid();
        }

        public bool ExisteEnLaBaseDeDatos()
        {
            RepositorioEvaluacion repositorio = new RepositorioEvaluacion();
            return repositorio.Buscar(EvaluacionIDTextBox.Text.ToInt()) != null; ;
        }

        protected void NuevoButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }
        protected void GuadarButton_Click(object sender, EventArgs e)
        {
            if (!Validar())
                return;
            bool paso = false;
            Evaluaciones evaluacion = LlenaClase();
            RepositorioEvaluacion repositorio = new RepositorioEvaluacion();
            if (evaluacion.EvaluacionID == 0)
                paso = repositorio.Guardar(evaluacion);
            else
            {
                if (!ExisteEnLaBaseDeDatos())
                {
                    return;
                }
                paso = repositorio.Modificar(evaluacion);
            }
            if (paso)
            {
                Limpiar();
                MostrarMensajes.Text = "Guardado";
                MostrarMensajes.CssClass = "alert-success";
                MostrarMensajes.Visible = true;
            }
            else
            {
                MostrarMensajes.Text = "No guardo";
                MostrarMensajes.CssClass = "alert-warning";
                MostrarMensajes.Visible = true;
            }
        }

        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            RepositorioEvaluacion repositorio = new RepositorioEvaluacion();
            Evaluaciones evaluaciones = repositorio.Buscar(EvaluacionIDTextBox.Text.ToInt());
            if (evaluaciones != null)
            {
                Limpiar();
                LlenaCampo(evaluaciones);
            }
        }

        protected void EliminarButton_Click(object sender, EventArgs e)
        {
            RepositorioEvaluacion repositorio = new RepositorioEvaluacion();
            int id = EvaluacionIDTextBox.Text.ToInt();
            if (!ExisteEnLaBaseDeDatos())
            {
                MostrarMensajes.Visible = true;
                MostrarMensajes.Text = "No encontrado";
                MostrarMensajes.CssClass = "alert-danger";
                return;
            }
            else
            {
                if (repositorio.Eliminar(id))
                {
                    Limpiar();
                    MostrarMensajes.Visible = true;
                    MostrarMensajes.Text = "Eliminado";
                    MostrarMensajes.CssClass = "alert-danger";
                }
            }
        }

        protected void AgregarButton_Click(object sender, EventArgs e)
        {
            Evaluaciones evaluacion = ((Evaluaciones)ViewState[KeyViewState]);
            decimal Valor = ValorTextBox.Text.ToDecimal();
            decimal Logrado = LogradoTextBox.Text.ToDecimal();
            evaluacion.AgregarDetalle(0, evaluacion.EvaluacionID, CategoriaDropDownList.SelectedValue.ToInt(), Valor, Logrado, Valor - Logrado);
            ViewState[KeyViewState] = evaluacion;
            Calcular();
            CategoriaTextBox.Text = string.Empty;
            ValorTextBox.Text = string.Empty;
            LogradoTextBox.Text = string.Empty;
            ActualizarGrid();
        }

        private void Calcular()
        {
            decimal TotalPerdido = 0;
            Evaluaciones evaluacion = ((Evaluaciones)ViewState[KeyViewState]);
            foreach (var item in evaluacion.DetalleEvaluaciones.ToList())
            {
                TotalPerdido += item.Perdido;
            }
            TotalPerdidoTextBox.Text = TotalPerdido.ToString();
        }

        private void ActualizarGrid()
        {
            Calcular();
            Evaluaciones evaluacion = (Evaluaciones)ViewState[KeyViewState];
            evaluacion.DetalleEvaluaciones.ForEach(x => x.Categoria = new RepositorioBase<Categorias>().Buscar(x.CategoriaID).Descripcion);
            DetalleGridView.DataSource = evaluacion.DetalleEvaluaciones;
            DetalleGridView.DataBind();
        }

        protected void RemoverDetalleClick_Click(object sender, EventArgs e)
        {
            Evaluaciones evaluacion = (Evaluaciones)ViewState[KeyViewState];
            GridViewRow row = (sender as Button).NamingContainer as GridViewRow;
            evaluacion.RemoverDetalle(row.RowIndex);
            ViewState[KeyViewState] = evaluacion;
            ActualizarGrid();
        }

        private void LlenarCombo()
        {
            RepositorioBase<Estudiantes> repositorio = new RepositorioBase<Estudiantes>();
            LlenarCombo<Estudiantes>(EstudianteDropdownList, repositorio.GetList(x => true), "NombreCompleto", "EstudianteID");
            repositorio.Dispose();

            RepositorioBase<Categorias> repositorioCategorias = new RepositorioBase<Categorias>();
            LlenarCombo<Categorias>(CategoriaDropDownList, repositorioCategorias.GetList(x => true), "Descripcion", "CategoriaID");
            repositorioCategorias.Dispose();
        }

        public static void LlenarCombo<T>(DropDownList dropDownList, List<T> lista, string DataTextField, string DataValueField)
        {
            dropDownList.Items.Clear();
            dropDownList.DataSource = lista;
            dropDownList.DataTextField = DataTextField;
            dropDownList.DataValueField = DataValueField;
            dropDownList.DataBind();
        }

    }
}