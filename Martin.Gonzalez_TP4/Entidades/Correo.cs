using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Entidades
{
    public class Correo : IMostrar<List<Paquete>>
    {
        private List<Thread> mockPaquetes;
        private List<Paquete> paquetes;

        /// <summary>
        /// Establece o devuelve el valor de la lista de paquetes
        /// </summary>
        public List<Paquete> Paquetes
        {
            get
            {
                return this.paquetes;
            }
            set
            {
                this.paquetes = value;
            }
        }

        /// <summary>
        /// Constructor de correo
        /// </summary>
        public Correo()
        {
            this.mockPaquetes = new List<Thread>();
            this.paquetes = new List<Paquete>();
        }

        /// <summary>
        /// Devuelve los datos del elemento recibido
        /// </summary>
        /// <param name="elemento">Elemento</param>
        /// <returns>Datos segun formato</returns>
        public string MostrarDatos(IMostrar<List<Paquete>> elemento)
        {
            string retorno = "";
            if (!Object.Equals(null, elemento))
            {
                foreach (Paquete paquete in ((Correo)elemento).Paquetes)
                {
                    retorno += string.Format("{0} para {1} ({2})\n", paquete.TrackingID, paquete.DireccionEntrega, paquete.Estado);
                }
            }
            return retorno;
        }

        /// <summary>
        /// Finaliza todos los hilos activos de la lista
        /// </summary>
        public void FinEntregas()
        {
            foreach (Thread thread in this.mockPaquetes)
            {
                if (thread.IsAlive)
                {
                    thread.Abort();
                }
            }

        }

        /// <summary>
        /// Agrega un paquete al correo si este no esta incluido y agrega un hilo con su Mock a la lista
        /// </summary>
        /// <param name="c">Correo</param>
        /// <param name="p">Paquete</param>
        /// <returns>EL correo con el paquete agregado o no</returns>
        public static Correo operator +(Correo c, Paquete p)
        {
            if (!Object.Equals(c, null) && !Object.Equals(p, null))
            {
                if (!Object.Equals(c.paquetes, null) && !Object.Equals(c.mockPaquetes, null))
                {
                    foreach (Paquete paquete in c.paquetes)
                    {
                        if (paquete == p)
                        {
                            throw new TrackingIdRepetidoException("El paquete ya se encuentra en el correo");
                        }
                    }
                    c.paquetes.Add(p);
                    Thread thread = new Thread(p.MockCicloDeVida);
                    c.mockPaquetes.Add(thread);
                    thread.Start();
                }
            }
            return c;
        }
    }
}
