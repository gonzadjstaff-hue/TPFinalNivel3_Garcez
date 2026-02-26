using System;
using System.Data;
using System.Data.SqlClient;

namespace AccesoDatos
{
    public class AccesoDatos
    {
        private SqlConnection conexion;
        private SqlCommand comando;
        private SqlDataReader lector;

        public SqlDataReader Lector
        {
            get { return lector; }
        }

        public AccesoDatos()
        {
            conexion = new SqlConnection(
                "Data Source=.\\SQLEXPRESS;Initial Catalog=CATALOGO_WEB_DB;Integrated Security=True");
            comando = new SqlCommand();
        }

        public void setearConsulta(string consulta)
        {
            comando.CommandType = CommandType.Text;
            comando.CommandText = consulta;
        }

        public void setearParametro(string nombre, object valor)
        {
            comando.Parameters.AddWithValue(nombre, valor ?? DBNull.Value);
        }

        public void limpiarParametros()
        {
            comando.Parameters.Clear();
        }

        private void prepararConexion()
        {
            comando.Connection = conexion;
            if (conexion.State != ConnectionState.Open)
                conexion.Open();
        }

        public void ejecutarLectura()
        {
            prepararConexion();
            lector = comando.ExecuteReader();
        }

        public void ejecutarAccion()
        {
            prepararConexion();
            comando.ExecuteNonQuery();
        }

        public void cerrarConexion()
        {
            if (lector != null)
                lector.Close();

            if (conexion != null && conexion.State == ConnectionState.Open)
                conexion.Close();
        }
    }
}