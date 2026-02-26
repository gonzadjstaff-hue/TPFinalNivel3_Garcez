using  System;
using System.Collections.Generic;
using Dominio;

namespace AccesoDatos
{
    public class ArticuloDatos
    {
        public List<Articulo> Listar()
        {
            List<Articulo> lista = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta(
                    "SELECT A.Id, A.Codigo, A.Nombre, A.Descripcion, A.ImagenUrl, A.Precio, " +
                    "M.Id IdMarca, M.Descripcion Marca, " +
                    "C.Id IdCategoria, C.Descripcion Categoria " +
                    "FROM ARTICULOS A " +
                    "INNER JOIN MARCAS M ON A.IdMarca = M.Id " +
                    "INNER JOIN CATEGORIAS C ON A.IdCategoria = C.Id"
                );

                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Articulo aux = new Articulo();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Codigo = datos.Lector["Codigo"].ToString();
                    aux.Nombre = datos.Lector["Nombre"].ToString();
                    aux.Descripcion = datos.Lector["Descripcion"].ToString();
                    aux.Precio = (decimal)datos.Lector["Precio"];

                    aux.Marca = new Marca();
                    aux.Marca.Id = (int)datos.Lector["IdMarca"];
                    aux.Marca.Descripcion = datos.Lector["Marca"].ToString();

                    aux.Categoria = new Categoria();
                    aux.Categoria.Id = (int)datos.Lector["IdCategoria"];
                    aux.Categoria.Descripcion = datos.Lector["Categoria"].ToString();

                    if (!(datos.Lector["ImagenUrl"] is DBNull))
                        aux.ImagenUrl = datos.Lector["ImagenUrl"].ToString();

                    lista.Add(aux);
                }

                return lista;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public Articulo BuscarPorId(int id)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta(
                    "SELECT A.Id, A.Codigo, A.Nombre, A.Descripcion, A.ImagenUrl, A.Precio, " +
                    "M.Id IdMarca, M.Descripcion Marca, " +
                    "C.Id IdCategoria, C.Descripcion Categoria " +
                    "FROM ARTICULOS A " +
                    "INNER JOIN MARCAS M ON A.IdMarca = M.Id " +
                    "INNER JOIN CATEGORIAS C ON A.IdCategoria = C.Id " +
                    "WHERE A.Id = @id"
                );

                datos.limpiarParametros();
                datos.setearParametro("@id", id);

                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    Articulo aux = new Articulo();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Codigo = datos.Lector["Codigo"].ToString();
                    aux.Nombre = datos.Lector["Nombre"].ToString();
                    aux.Descripcion = datos.Lector["Descripcion"].ToString();
                    aux.Precio = (decimal)datos.Lector["Precio"];

                    aux.Marca = new Marca();
                    aux.Marca.Id = (int)datos.Lector["IdMarca"];
                    aux.Marca.Descripcion = datos.Lector["Marca"].ToString();

                    aux.Categoria = new Categoria();
                    aux.Categoria.Id = (int)datos.Lector["IdCategoria"];
                    aux.Categoria.Descripcion = datos.Lector["Categoria"].ToString();

                    if (!(datos.Lector["ImagenUrl"] is DBNull))
                        aux.ImagenUrl = datos.Lector["ImagenUrl"].ToString();

                    return aux;
                }

                return null;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void Agregar(Articulo a)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta(
                    "INSERT INTO ARTICULOS (Codigo, Nombre, Descripcion, IdMarca, IdCategoria, ImagenUrl, Precio) " +
                    "VALUES (@codigo, @nombre, @descripcion, @idMarca, @idCategoria, @imagenUrl, @precio)"
                );

                datos.limpiarParametros();
                datos.setearParametro("@codigo", a.Codigo);
                datos.setearParametro("@nombre", a.Nombre);
                datos.setearParametro("@descripcion", a.Descripcion);
                datos.setearParametro("@idMarca", a.Marca.Id);
                datos.setearParametro("@idCategoria", a.Categoria.Id);
                datos.setearParametro("@imagenUrl", a.ImagenUrl);
                datos.setearParametro("@precio", a.Precio);

                datos.ejecutarAccion();
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void Modificar(Articulo a)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta(
                    "UPDATE ARTICULOS SET " +
                    "Codigo=@codigo, Nombre=@nombre, Descripcion=@descripcion, " +
                    "IdMarca=@idMarca, IdCategoria=@idCategoria, ImagenUrl=@imagenUrl, Precio=@precio " +
                    "WHERE Id=@id"
                );

                datos.limpiarParametros();
                datos.setearParametro("@codigo", a.Codigo);
                datos.setearParametro("@nombre", a.Nombre);
                datos.setearParametro("@descripcion", a.Descripcion);
                datos.setearParametro("@idMarca", a.Marca.Id);
                datos.setearParametro("@idCategoria", a.Categoria.Id);
                datos.setearParametro("@imagenUrl", a.ImagenUrl);
                datos.setearParametro("@precio", a.Precio);
                datos.setearParametro("@id", a.Id);

                datos.ejecutarAccion();
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void Eliminar(int id)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("DELETE FROM ARTICULOS WHERE Id = @id");
                datos.limpiarParametros();
                datos.setearParametro("@id", id);

                datos.ejecutarAccion();
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
    }
}