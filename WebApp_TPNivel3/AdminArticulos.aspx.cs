using System;
using Dominio;
using Negocio;
using System.Web.UI.WebControls;

namespace WebApp_TPNivel3
{
    public partial class AdminArticulos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] == null || !((Usuario)Session["usuario"]).Admin)
            {
                Response.Redirect("Login.aspx");
                return;
            }

            if (!IsPostBack)
                CargarGrilla();
        }

        private void CargarGrilla()
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            gvAdmin.DataSource = negocio.Listar();
            gvAdmin.DataBind();
        }

        protected void gvAdmin_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int id = int.Parse(e.CommandArgument.ToString());

            if (e.CommandName == "Editar")
                Response.Redirect("ArticuloForm.aspx?id=" + id);

            if (e.CommandName == "Eliminar")
            {
                ArticuloNegocio negocio = new ArticuloNegocio();
                negocio.Eliminar(id);
                CargarGrilla();
            }
        }
    }
}