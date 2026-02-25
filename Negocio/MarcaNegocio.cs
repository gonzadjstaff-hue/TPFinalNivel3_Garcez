using AccesoDatos;
using Dominio;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Negocio
{
    public class MarcaNegocio
    {
        public List<Marca> Listar()
        {
            MarcaDatos datos = new MarcaDatos();
            return datos.Listar();
        }
    }
}
