using Dominio;
using Negocio;
using System;
using System.Globalization;

namespace WebApp_TPNivel3
{
    public partial class Detalle : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;

            if (string.IsNullOrEmpty(Request.QueryString["id"]))
            {
                MostrarError("Falta el id del artículo.");
                return;
            }

            if (!int.TryParse(Request.QueryString["id"], out int id))
            {
                MostrarError("Id inválido.");
                return;
            }

            ArticuloNegocio negocio = new ArticuloNegocio();
            Articulo a = negocio.BuscarPorId(id);

            if (a == null)
            {
                MostrarError("No se encontró el artículo.");
                return;
            }

            pnlOk.Visible = true;
            lblNombre.Text = a.Nombre;
            lblCodigo.Text = a.Codigo;
            lblDescripcion.Text = a.Descripcion;
            lblMarca.Text = a.Marca != null ? a.Marca.Descripcion : "";
            lblCategoria.Text = a.Categoria != null ? a.Categoria.Descripcion : "";
            lblPrecio.Text = a.Precio.ToString("N2", CultureInfo.GetCultureInfo("es-AR"));
            imgArticulo.Src = string.IsNullOrWhiteSpace(a.ImagenUrl) ? "/img/no-image.png" : a.ImagenUrl;
        }

        private void MostrarError(string mensaje)
        {
            pnlError.Visible = true;
            lblError.Text = mensaje;
        }
    }
}