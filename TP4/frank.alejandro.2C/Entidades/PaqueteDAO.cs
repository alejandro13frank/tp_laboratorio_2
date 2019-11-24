using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient; 

namespace Entidades
{
    public static class PaqueteDAO
    {
        private static SqlCommand comando;
        private static SqlConnection conexion;

        public static bool Insertar(Paquete p)
        {
            try
            {              
                string consulta = $"INSERT INTO dbo.Paquetes(direccionEntrega, trackingID, alumno) VALUES('{p.DireccionDeEntrega}', '{p.TrackingID}', 'Alejandro Frank')";
                comando.CommandText = consulta;
                conexion.Open();
                comando.ExecuteNonQuery();
            }
            catch (NullReferenceException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                conexion.Close();
            }
            return true;
        }
        static PaqueteDAO()
        {
            string connectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog =correo-sp-2017; Integrated Security = True";
            PaqueteDAO.conexion = new SqlConnection(connectionString);
            PaqueteDAO.comando = new SqlCommand();
            PaqueteDAO.comando.CommandType = System.Data.CommandType.Text;
            PaqueteDAO.comando.Connection = PaqueteDAO.conexion;

        }
    }
}
