using System;
using System.Linq;
using Negocio;

namespace WebApp_TPNivel3
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarFiltros();
                CargarCards();
            }
        }

        private void CargarFiltros()
        {
            MarcaNegocio marcaNegocio = new MarcaNegocio();
            ddlMarcaFiltro.DataSource = marcaNegocio.Listar();
            ddlMarcaFiltro.DataTextField = "Descripcion";
            ddlMarcaFiltro.DataValueField = "Id";
            ddlMarcaFiltro.DataBind();
            ddlMarcaFiltro.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Todas", "0"));

            CategoriaNegocio categoriaNegocio = new CategoriaNegocio();
            ddlCategoriaFiltro.DataSource = categoriaNegocio.Listar();
            ddlCategoriaFiltro.DataTextField = "Descripcion";
            ddlCategoriaFiltro.DataValueField = "Id";
            ddlCategoriaFiltro.DataBind();
            ddlCategoriaFiltro.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Todas", "0"));
        }

        private void CargarCards()
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            var lista = negocio.Listar();
            rptArticulos.DataSource = lista;
            rptArticulos.DataBind();
            lblInfo.Text = lista.Count + " productos";
        }

        protected void btnFiltrar_Click(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            var lista = negocio.Listar();

            string texto = txtBuscar.Text.Trim().ToLower();
            int idMarca = int.Parse(ddlMarcaFiltro.SelectedValue);
            int idCategoria = int.Parse(ddlCategoriaFiltro.SelectedValue);

            if (!string.IsNullOrEmpty(texto))
                lista = lista.Where(x => (x.Nombre ?? "").ToLower().Contains(texto) || (x.Descripcion ?? "").ToLower().Contains(texto)).ToList();

            if (idMarca != 0)
                lista = lista.Where(x => x.Marca != null && x.Marca.Id == idMarca).ToList();

            if (idCategoria != 0)
                lista = lista.Where(x => x.Categoria != null && x.Categoria.Id == idCategoria).ToList();

            rptArticulos.DataSource = lista;
            rptArticulos.DataBind();
            lblInfo.Text = lista.Count + " productos";
        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtBuscar.Text = "";
            ddlMarcaFiltro.SelectedValue = "0";
            ddlCategoriaFiltro.SelectedValue = "0";
            CargarCards();
        }
    }
}