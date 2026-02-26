using Dominio;
using Negocio;
using System;
using System.Globalization;

namespace WebApp_TPNivel3
{
    public partial class ArticuloForm : System.Web.UI.Page
    {
        private bool ModoEdicion => !string.IsNullOrEmpty(Request.QueryString["id"]);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarCombos();

                if (ModoEdicion)
                {
                    int id = int.Parse(Request.QueryString["id"]);
                    CargarArticulo(id);
                }
            }
        }

        private void CargarCombos()
        {
            // Usamos tus Negocio actuales de Marca/Categoria (ya existen en tu solución)
            MarcaNegocio marcaNegocio = new MarcaNegocio();
            ddlMarca.DataSource = marcaNegocio.Listar();
            ddlMarca.DataTextField = "Descripcion";
            ddlMarca.DataValueField = "Id";
            ddlMarca.DataBind();

            CategoriaNegocio categoriaNegocio = new CategoriaNegocio();
            ddlCategoria.DataSource = categoriaNegocio.Listar();
            ddlCategoria.DataTextField = "Descripcion";
            ddlCategoria.DataValueField = "Id";
            ddlCategoria.DataBind();
        }

        private void CargarArticulo(int id)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            Articulo a = negocio.BuscarPorId(id);

            if (a == null)
            {
                lblError.Text = "No se encontró el artículo.";
                btnGuardar.Enabled = false;
                return;
            }

            txtCodigo.Text = a.Codigo;
            txtNombre.Text = a.Nombre;
            txtDescripcion.Text = a.Descripcion;
            txtImagenUrl.Text = a.ImagenUrl;
            txtPrecio.Text = a.Precio.ToString("0.##", CultureInfo.InvariantCulture);

            ddlMarca.SelectedValue = a.Marca.Id.ToString();
            ddlCategoria.SelectedValue = a.Categoria.Id.ToString();
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                // Validaciones mínimas (obligatorio)
                if (string.IsNullOrWhiteSpace(txtCodigo.Text) ||
                    string.IsNullOrWhiteSpace(txtNombre.Text) ||
                    string.IsNullOrWhiteSpace(txtDescripcion.Text) ||
                    string.IsNullOrWhiteSpace(txtPrecio.Text))
                {
                    lblError.Text = "Completá Código, Nombre, Descripción y Precio.";
                    return;
                }

                if (!decimal.TryParse(txtPrecio.Text.Replace(",", "."), NumberStyles.Any, CultureInfo.InvariantCulture, out decimal precio))
                {
                    lblError.Text = "Precio inválido.";
                    return;
                }

                Articulo a = new Articulo
                {
                    Codigo = txtCodigo.Text.Trim(),
                    Nombre = txtNombre.Text.Trim(),
                    Descripcion = txtDescripcion.Text.Trim(),
                    ImagenUrl = txtImagenUrl.Text.Trim(),
                    Precio = precio,
                    Marca = new Marca { Id = int.Parse(ddlMarca.SelectedValue) },
                    Categoria = new Categoria { Id = int.Parse(ddlCategoria.SelectedValue) }
                };

                ArticuloNegocio negocio = new ArticuloNegocio();

                if (ModoEdicion)
                {
                    a.Id = int.Parse(Request.QueryString["id"]);
                    negocio.Modificar(a);
                }
                else
                {
                    negocio.Agregar(a);
                }

                Response.Redirect("AdminArticulos.aspx");
            }
            catch (Exception ex)
            {
                lblError.Text = "Error al guardar: " + ex.Message;
            }
        }
    }
}