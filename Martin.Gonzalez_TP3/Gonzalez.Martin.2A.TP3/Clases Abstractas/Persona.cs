﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;

namespace EntidadesAbstractas
{
    public abstract class Persona
    {
        public enum ENacionalidad
        {
            Argentino,
            Extranjero
        }
        #region Variables
        private string apellido;
        private int dni;
        private ENacionalidad nacionalidad;
        private string nombre;
        #endregion

        #region Propiedades
        /// <summary>
        /// Establece o retorna el valor del apellido validando que tenga caracteres alfabeticos
        /// </summary>
        public string Apellido
        {
            get
            {
                return this.apellido;
            }
            set
            {
                this.apellido = this.ValidarNombreApellido(value);
            }
        }

        /// <summary>
        /// Establece o retorna el valor del DNI 
        /// </summary>
        public int DNI
        {
            get
            {
                return this.dni;
            }
            set
            {
                this.StringToDNI = value.ToString();
            }
        }

        /// <summary>
        /// Establece o retorna el valor de la nacionalidad
        /// </summary>
        public ENacionalidad Nacionalidad
        {
            get
            {
                return this.nacionalidad;
            }
            set
            {
                this.nacionalidad = value;
            }
        }

        /// <summary>
        /// Establece o retorna el valor del nombre validando que tenga caracteres alfabeticos
        /// </summary>
        public string Nombre
        {
            get
            {
                return this.nombre;
            }
            set
            {
                this.nombre = this.ValidarNombreApellido(value);
            }
        }

        /// <summary>
        /// Establece el valor del DNI y se valida que su valor sea numerico y correspondiente con la nacionalidad 
        /// </summary>
        public string StringToDNI
        {
            set
            {
                this.dni = this.ValidarDni(this.nacionalidad, value);
            }
        }
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor default de persona
        /// </summary>
        public Persona()
        {

        }

        /// <summary>
        /// Constructor con parametros de persona
        /// </summary>
        /// <param name="nombre">Nombre de la persona</param>
        /// <param name="apellido">Apellido de la persona</param>
        /// <param name="nacionalidad">Nacionalidad de la persona</param>
        public Persona(string nombre, string apellido, ENacionalidad nacionalidad)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.nacionalidad = nacionalidad;
        }

        /// <summary>
        /// Constructor con parametros de persona
        /// </summary>
        /// <param name="nombre">Nombre de la persona</param>
        /// <param name="apellido">Apellido de la persona</param>
        /// <param name="dni">DNI de la persona, debe ser correspondiente a nu nacionalidad</param>
        /// <param name="nacionalidad">Nacionalidad de la persona</param>
        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad) : this(nombre, apellido, nacionalidad)
        {
            this.StringToDNI = dni;
        }


        /// <summary>
        /// Constructor con parametros de persona
        /// </summary>
        /// <param name="nombre">Nombre de la persona</param>
        /// <param name="apellido">Apellido de la persona</param>
        /// <param name="dni">DNI de la persona, debe ser correspondiente a nu nacionalidad</param>
        /// <param name="nacionalidad">Nacionalidad de la persona</param>
        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad) : this(nombre, apellido, dni.ToString(), nacionalidad)
        {

        }
        #endregion

        #region Metodos

        /// <summary>
        /// Valida que el dni sea menor a 9000000 para argentinos y mayor a 9000000 y menor a 99999999 para extranjeros
        /// </summary>
        /// <param name="nacionalidad">Nacionalidad a comparar</param>
        /// <param name="dato">El DNI</param>
        /// <returns></returns>
        private int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            if (nacionalidad == ENacionalidad.Argentino)
            {
                if (dato < 90000000)
                {
                    return dato;
                }
            }else if (nacionalidad == ENacionalidad.Extranjero)
            {
                if (dato > 89999999 && dato < 100000000)
                {
                    return dato;
                }
            }
            throw new NacionalidadInvalidaException("La nacionalidad no coincide con el numero de DNI");
        }

        /// <summary>
        /// Valida que el dni recibido como string sea numerico y menor a 9000000 para argentinos y mayor a 9000000 y menor a 99999999 para extranjeros
        /// </summary>
        /// <param name="nacionalidad">Nacionalidad a comparar</param>
        /// <param name="dato">El DNI</param>
        /// <returns></returns>
        private int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            int retorno = 0;
            int resultado = 0;
            bool flag;
            if (!(String.IsNullOrEmpty(dato)))
            {
                flag = int.TryParse(dato, out resultado);
                if (!flag)
                {
                    throw new DniInvalidoException();
                }
                else
                {
                    if (resultado < 1 || resultado > 99999999)
                    {
                        throw new DniInvalidoException();
                    }
                    else
                    {
                        retorno = this.ValidarDni(nacionalidad, resultado);
                    }
                }
            }
            return retorno;
        }

        /// <summary>
        /// Valida que el string recibido tenga solo caracteres alfabeticos
        /// </summary>
        /// <param name="dato">Nombre o apellido a validad</param>
        /// <returns>El string con los datos o vacio si es invalido </returns>
        private string ValidarNombreApellido(string dato)
        {
            string retorno = "";
            if (!(String.IsNullOrEmpty(dato)))
            {
                foreach (char caracteres in dato)
                {
                    if (!Char.IsLetter(caracteres))
                    {
                        return retorno;
                    }
                }
                retorno = dato;
            }
            return retorno;
        }

        /// <summary>
        /// Hace publicos el nombre y apellido de la persona como string
        /// </summary>
        /// <returns>Los datos de la persona</returns>
        public override string ToString()
        {
            return "NOMBRE COMPLETO: " + this.nombre + ", " + this.apellido + "\nNACIONALIDAD: " + this.nacionalidad.ToString();
        }
        #endregion
    }
}
