using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Entidades
{
    public class Paquete : IMostrar<Paquete>
    {
        public delegate void DelegadoEstado(object sender, EventArgs args);
        public enum EEstado
        {
            Ingresado,
            EnViaje,
            Entregado
        }

        public event DelegadoEstado InformaEstado;

        private string direccionEntrega;
        private EEstado estado;
        private string trackingID;

        /// <summary>
        /// Establece o devuelve el valor de la direccion de entrega
        /// </summary>
        public string DireccionEntrega
        {
            get
            {
                return this.direccionEntrega;
            }
            set
            {
                this.direccionEntrega = value;
            }
        }

        /// <summary>
        /// Establece o devuelve el valor del estado
        /// </summary>
        public EEstado Estado
        {
            get
            {
                return this.estado;
            }
            set
            {
                this.estado = value;
            }
        }

        /// <summary>
        /// Establece o devuelve el valor del id
        /// </summary>
        public string TrackingID
        {
            get
            {
                return this.trackingID;
            }
            set
            {
                this.trackingID = value;
            }
        }

        /// <summary>
        /// Constructor de paquete
        /// </summary>
        /// <param name="direccionEntrega">La direccion</param>
        /// <param name="trackingID">El id</param>
        public Paquete(string direccionEntrega, string trackingID)
        {
            this.direccionEntrega = direccionEntrega;
            this.trackingID = trackingID;
        }

        /// <summary>
        /// Devuelve los datos del elemento recibido
        /// </summary>
        /// <param name="elemento"></param>
        /// <returns>Los datos</returns>
        public string MostrarDatos(IMostrar<Paquete> elemento) //  CAMBIAR
        {
            string retorno = "";
            if (!Object.Equals(null, elemento))
            {
                retorno = string.Format("{0} para {1}", ((Paquete)elemento).trackingID,
                          ((Paquete)elemento).direccionEntrega);
            }
            return retorno;
        }

        /// <summary>
        /// Publica los datos del elemento recibido
        /// </summary>
        /// <returns>Datos</returns>
        public override string ToString()
        {
            return this.MostrarDatos(this);
        }

        /// <summary>
        /// Demora, cambia de estado, lo informa y finalmente sube el paquete a una base de datos
        /// </summary>
        public void MockCicloDeVida()
        {
            while (this.estado != EEstado.Entregado)
            {
                System.Threading.Thread.Sleep(4000);
                int numeroDeEstado = (int)this.estado;
                this.estado = (EEstado)(numeroDeEstado + 1);
                this.InformaEstado(this.estado, new EventArgs());
            }
            PaqueteDao.Insertar(this);
        }

        /// <summary>
        /// Compara dos paquetes segun trackingID
        /// </summary>
        /// <param name="p1">Paquete a comparar</param>
        /// <param name="p2">Segundo paquete a comparar</param>
        /// <returns>TRUE si los ID son iguales, FALSE en el resto de los casos</returns>
        public static bool operator ==(Paquete p1, Paquete p2)
        {
            if (!Object.Equals(p1, null) && !Object.Equals(p2, null))
            {
                if (p1.trackingID == p2.trackingID)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Compara dos paquetes segun trackingID
        /// </summary>
        /// <param name="p1">Paquete a comparar</param>
        /// <param name="p2">Segundo paquete a comparar</param>
        /// <returns>FALSE si los ID son iguales, TRUE en el resto de los casos</returns>
        public static bool operator !=(Paquete p1, Paquete p2)
        {
            return !(p1 == p2);
        }
    }
}
