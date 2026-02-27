using Dominio;
using System;
using System.Web.UI;

namespace WebApp_TPNivel3
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Usuario u = Session["usuario"] as Usuario;

            if (u == null)
            {
                pnlNoLogin.Visible = true;
                pnlLogin.Visible = false;
                phAdmin.Visible = false;
            }
            else
            {
                pnlNoLogin.Visible = false;
                pnlLogin.Visible = true;
                lblBienvenido.Text = "Bienvenido " + u.Email;
                phAdmin.Visible = u.Admin;
            }
        }
    }
}