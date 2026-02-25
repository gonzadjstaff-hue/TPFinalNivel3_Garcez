using System.Collections.Generic;
using Dominio;
using AccesoDatos;

namespace Negocio
{
    public class CategoriaNegocio
    {
        public List<Categoria> Listar()
        {
            CategoriaDatos datos = new CategoriaDatos();
            return datos.Listar();
        }
    }
}
