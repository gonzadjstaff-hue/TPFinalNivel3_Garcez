using System.Collections.Generic;
using Dominio;
using AccesoDatos;
using System;

namespace Negocio
{
    public class ArticuloNegocio
    {
        public List<Articulo> Listar()
        {
            ArticuloDatos datos = new ArticuloDatos();
            return datos.Listar();
        }

        public void Eliminar(int id)
        {
            ArticuloDatos datos = new ArticuloDatos();
            datos.Eliminar(id);
        }
    }
}
