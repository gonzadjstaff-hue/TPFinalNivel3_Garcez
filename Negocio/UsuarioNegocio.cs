using Dominio;
using AccesoDatos;

namespace Negocio
{
    public class UsuarioNegocio
    {
        public Usuario Login(string email, string pass)
        {
            UsuarioDatos datos = new UsuarioDatos();
            return datos.Login(email, pass);
        }
    }
}