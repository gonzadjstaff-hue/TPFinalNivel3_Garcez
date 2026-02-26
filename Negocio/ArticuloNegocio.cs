using System.Collections.Generic;
using Dominio;
using AccesoDatos;

namespace Negocio
{
    public class ArticuloNegocio
    {
        public List<Articulo> Listar()
        {
            ArticuloDatos datos = new ArticuloDatos();
            return datos.Listar();
        }

        public Articulo BuscarPorId(int id)
        {
            ArticuloDatos datos = new ArticuloDatos();
            return datos.BuscarPorId(id);
        }

        public void Agregar(Articulo a)
        {
            ArticuloDatos datos = new ArticuloDatos();
            datos.Agregar(a);
        }

        public void Modificar(Articulo a)
        {
            ArticuloDatos datos = new ArticuloDatos();
            datos.Modificar(a);
        }

        public void Eliminar(int id)
        {
            ArticuloDatos datos = new ArticuloDatos();
            datos.Eliminar(id);
        }
    }
}