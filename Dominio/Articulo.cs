using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    public class Articulo
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }


        public Marca Marca { get; set; } = new Marca();
        public Categoria Categoria { get; set; } = new Categoria();

        public string ImagenUrl { get; set; } = "";
        public decimal Precio { get; set; }


    }
}
