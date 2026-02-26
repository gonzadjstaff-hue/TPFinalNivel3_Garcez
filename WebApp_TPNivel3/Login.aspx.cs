using System;
using Dominio;
using Negocio;

namespace WebApp_TPNivel3
{
    public partial class Login : System.Web.UI.Page
    {
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string usuario = txtEmail.Text.Trim();
            string pass = txtPass.Text.Trim();

            UsuarioNegocio negocio = new UsuarioNegocio();
            Usuario user = negocio.Login(usuario, pass);

            if (user == null)
            {
                lblError.Text = "Usuario o contraseña incorrectos.";
                return;
            }

            Session["usuario"] = user;

            if (user.Admin)
                Response.Redirect("AdminArticulos.aspx");
            else
                Response.Redirect("Default.aspx");
        }
    }
}