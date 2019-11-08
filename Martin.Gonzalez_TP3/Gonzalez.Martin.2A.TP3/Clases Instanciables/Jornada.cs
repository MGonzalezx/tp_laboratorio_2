using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Archivos;
using Excepciones;

namespace Clases_Instanciables
{
    [Serializable]
    public class Jornada
    {
        #region Variables
        private List<Alumno> alumnos;
        private Universidad.EClases clase;
        private Profesor instructor;
        #endregion

        #region Propiedades
        /// <summary>
        /// Establece o retorna el valor de la lista de alumnos
        /// </summary>
        public List<Alumno> Alumnos
        {
            get
            {
                return this.alumnos;
            }
            set
            {
                this.alumnos = value;
            }
        }

        /// <summary>
        /// Establece o retorna el valor de la clase
        /// </summary>
        public Universidad.EClases Clase
        {
            get
            {
                return this.clase;
            }
            set
            {
                this.clase = value;
            }
        }

        /// <summary>
        /// Establece o retorna el valor del instructor
        /// </summary>
        public Profesor Instructor
        {
            get
            {
                return this.instructor;
            }
            set
            {
                this.instructor = value;
            }
        }
        #endregion


        #region Constructores
        /// <summary>
        /// Constructor default de Jornada, inicializa la lista de alumnos
        /// </summary>
        private Jornada()
        {
            this.alumnos = new List<Alumno>();
        }

        /// <summary>
        /// Constructor con parametros de Jornada
        /// </summary>
        /// <param name="clase">Clase de la jornada</param>
        /// <param name="instructor">Profesor de la jornada</param>
        public Jornada(Universidad.EClases clase, Profesor instructor) : this()
        {
            this.clase = clase;
            this.instructor = instructor;
        }
        #endregion

        #region Metodos

        /// <summary>
        /// Hace publicos los datos de la jornada como string
        /// </summary>
        /// <returns>Devuelve los datos en forma de string</returns>
        public override string ToString()
        {
            string retorno = "";
            retorno += "CLASE DE " + this.clase.ToString() + " POR " + this.instructor.ToString() + "\n";
            retorno += "ALUMNOS:\n";
            foreach (Alumno alumno in this.alumnos)
            {
                retorno += alumno.ToString() + "\n";
            }
            retorno += "<------------------------------------------------>";
            return retorno;
        }

        /// <summary>
        /// Guarda los datos de la jornada en un archivo de formato .txt en el escritorio
        /// </summary>
        /// <param name="jornada">Jornada a guardar</param>
        /// <returns>TRUE si lo completo</returns>
        public static bool Guardar(Jornada jornada)
        {
            bool retorno = false;
            if (!Object.Equals(jornada, null))
            {
                string informacion = jornada.ToString();
                Texto miTexto = new Texto();
                miTexto.Guardar(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\Jornada.txt", informacion);
                retorno = true;
            }
            return retorno;
        }

        /// <summary>
        /// Lee datos de una jornada de un archivo de formato .txt en el escritorio y los devuelve
        /// <returns>Los datos de la jornada en forma de string</returns>
        public static string Leer()
        {
            string informacion = "";
            Texto miTexto = new Texto();
            miTexto.Leer(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\Jornada.txt", out informacion);
            return informacion;
        }

        #endregion

        #region Operadores

        /// <summary>
        /// Una Jornada será igual a un Alumno si el mismo participa de la clase.
        /// </summary>
        /// <param name="j">Jornada a comparar</param>
        /// <param name="a">Alumno a comparar</param>
        /// <returns>TRUE si el alumno esta en la lista de alumnos de la jornada, FALSE en cualquier otro caso</returns>
        public static bool operator ==(Jornada j, Alumno a)
        {
            if (!(Object.Equals(j, null)) && !(Object.Equals(j.alumnos, null)))
            {
                return j.alumnos.Contains(a);
            }
            return false;
        }

        /// <summary>
        /// Una Jornada no será igual a un Alumno si el mismo no participa de la clase.
        /// </summary>
        /// <param name="j">Jornada a comparar</param>
        /// <param name="a">Alumno a comparar</param>
        /// <returns>FALSE si el alumno esta en la lista de alumnos de la jornada, TRUE en cualquier otro caso</returns>
        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }

        /// <summary>
        /// Agrega un alumno a la lista de alumnos de la jornada, si este ya se encuentra incluido ocurre una excepcion
        /// </summary>
        /// <param name="j">Jornada</param>
        /// <param name="a">Alumno a agregar</param>
        /// <returns>Devuelve la jornada con el alumno incluido si lo pudo agregar</returns>
        public static Jornada operator +(Jornada j, Alumno a)
        {
            if (!(Object.Equals(j, null)) && !(Object.Equals(j.alumnos, null)))
            {
                if (j != a)
                {
                    j.alumnos.Add(a);
                }
                else
                {
                    throw new AlumnoRepetidoException();
                }
            }
            return j;
        }

        #endregion

    }
}
