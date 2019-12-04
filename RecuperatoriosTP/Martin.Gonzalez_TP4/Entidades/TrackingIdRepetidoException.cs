using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class TrackingIdRepetidoException : Exception
    {
        /// <summary>
        /// Constructor de la exepcion en caso de id repetido
        /// </summary>
        /// <param name="mensaje">Mensaje</param>
        public TrackingIdRepetidoException(string mensaje) : base(mensaje)
        { }

        /// <summary>
        /// Constructor de la excepcion en caso de id repetido
        /// </summary>
        /// <param name="mensaje">Mensaje</param>
        /// <param name="inner">Excepcion interna</param>
        public TrackingIdRepetidoException(string mensaje, Exception inner) : base(mensaje, inner)
        { }
    }
}
