using Dominio;

namespace AccesoDatos
{
    public class UsuarioDatos
    {
        public Usuario Login(string usuario, string pass)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SELECT Id, email, pass, admin FROM USERS WHERE email = @email AND pass = @pass");
                datos.limpiarParametros();
                datos.setearParametro("@email", usuario);
                datos.setearParametro("@pass", pass);

                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    Usuario u = new Usuario();
                    u.Id = (int)datos.Lector["Id"];
                    u.Email = datos.Lector["email"].ToString();
                    u.Pass = datos.Lector["pass"].ToString();
                    u.Admin = (bool)datos.Lector["admin"];
                    return u;
                }

                return null;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
    }
}