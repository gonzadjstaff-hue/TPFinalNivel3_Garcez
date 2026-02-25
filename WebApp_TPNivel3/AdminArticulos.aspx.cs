using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;


namespace WebApp_TPNivel3
{
    public partial class AdminArticulos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
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
            {
                Response.Redirect("ArticuloForm.aspx?id=" + id);
            }
            else if (e.CommandName == "Eliminar")
            {
                ArticuloNegocio negocio = new ArticuloNegocio();
                negocio.Eliminar(id); 
                CargarGrilla();
            }
        }
    }
}