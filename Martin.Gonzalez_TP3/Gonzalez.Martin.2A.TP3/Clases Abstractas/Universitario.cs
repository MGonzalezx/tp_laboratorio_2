using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesAbstractas
{
    public abstract class Universitario : Persona
    {
        private int legajo;

        #region Constructores

        /// <summary>
        /// Constructor default de Universitario
        /// </summary>
        public Universitario() : base()
        {

        }

        /// <summary>
        /// Constructor con parametros de Universitario
        /// </summary>
        /// <param name="legajo">Numero del legajo del universitario</param>
        /// <param name="nombre">Nombre del Universitario</param>
        /// <param name="apellido">Apellido del universitario</param>
        /// <param name="dni">DNI del universitario</param>
        /// <param name="nacionalidad">Nacionalidad del universitario</param>
        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad) : base(nombre,apellido,dni,nacionalidad)
        {
            this.legajo = legajo;
        }
        #endregion

        #region Metodos

        /// <summary>
        /// Compara la instancia con un objeto
        /// </summary>
        /// <param name="obj">Objeto a comparar</param>
        /// <returns>TRUE si el objeto es del tipo universitario y es igual a la instancia, FALSE en en el resto de casos</returns>
        public override bool Equals(object obj)
        {
            if (obj is Universitario)
            {
                return (Universitario)obj == this;
            }
            return false;
        }

        /// <summary>
        ///  Devuelve los datos del univesitario
        /// </summary>
        /// <returns>Los datos en forma de string</returns>
        protected virtual string MostrarDatos()
        {
            string retorno = "";
            retorno += base.ToString() + "\n";
            retorno += "\nLEGAJO NUMERO: " + this.legajo.ToString();
            return retorno;
        }

        protected abstract string ParticiparEnClase();

        #endregion

        #region Operadores

        /// <summary>
        /// Compara dos universitarios segun sus DNIs y legajos para saber si son iguales
        /// </summary>
        /// <param name="pg1">Universitario a comparar</param>
        /// <param name="pg2">Universitario a comparar</param>
        /// <returns>Devuelve TRUE si ambos tienen el mismo dni y legajo o si ambos son null, FALSE en cualquier otro caso</returns>
        public static bool operator ==(Universitario pg1, Universitario pg2)
        {
            bool retorno = false;
            if (Object.Equals(pg1, null) && Object.Equals(pg2, null))
            {
                retorno = true;
            }
            else if (!(Object.Equals(pg1, null)) && !(Object.Equals(pg2, null)))
            {
                if (pg1.DNI == pg2.DNI || pg1.legajo == pg2.legajo)
                {
                    retorno = true;
                }
            }
            return retorno;
        }

        /// <summary>
        /// Compara dos universitarios segun sus DNIs y legajos para saber si son distintos
        /// </summary>
        /// <param name="pg1">Universitario a comparar</param>
        /// <param name="pg2">Universitario a comparar</param>
        /// <returns>Devuelve FALSE si ambos tienen el mismo dni y legajo o si ambos son null, TRUE en cualquier otro caso</returns>
        public static bool operator !=(Universitario pg1, Universitario pg2)
        {
            return !(pg1 == pg2);
        }
        #endregion
    }
}
