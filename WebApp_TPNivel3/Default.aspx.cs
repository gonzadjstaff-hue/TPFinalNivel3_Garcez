using System;
using Negocio;

namespace WebApp_TPNivel3
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ArticuloNegocio negocio = new ArticuloNegocio();
                gvArticulos.DataSource = negocio.Listar();
                gvArticulos.DataBind();
            }
        }
    }
}