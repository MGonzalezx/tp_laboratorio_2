using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data.SqlClient;
using System.Data;
using System.Threading;

namespace Entidades
{
    public static class PaqueteDao
    {
        private static SqlCommand comando;
        private static SqlConnection conexion;
        public static event EventHandler ErrorBaseDeDatos;

        /// <summary>
        /// Construcor, activa un evento en caso de error
        /// </summary>
        static PaqueteDao()
        {
            try
            {
                conexion = new SqlConnection(Properties.Settings.Default.conexion_db);
                comando = new SqlCommand();
            }
            catch (Exception e)
            {
                ErrorBaseDeDatos(e.Message, new EventArgs());
            }
        }

        /// <summary>
        /// Inserta un paquete en una base de datos, activa un evento en caso de error
        /// </summary>
        /// <param name="p">Paquete</param>
        /// <returns>TRUE si fue completado</returns>
        public static bool Insertar(Paquete p)
        {
            try
            {
                comando.Connection = conexion;
                comando.CommandType = CommandType.Text;
                comando.CommandText = "INSERT INTO[correo-sp-2017].[dbo].[Paquetes](direccionEntrega, trackingID, alumno) values('" +
                p.DireccionEntrega + "','" + p.TrackingID + "','Gonzalez Martin')";
                conexion.Open();
                if (comando.ExecuteNonQuery() > 0)
                {
                    return true;
                }
            }
            catch (Exception e)
            {
                ErrorBaseDeDatos(e.Message, new EventArgs());
            }
            finally
            {
                if (conexion.State.Equals(ConnectionState.Open))
                {
                    conexion.Close();
                }
            }
            return false;
        }
    }
}
