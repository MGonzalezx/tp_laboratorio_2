using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EntidadesAbstractas;
using Excepciones;
using Clases_Instanciables;

namespace Tests_Unitarios
{
    [TestClass]
    public class TestsDeExcepciones
    {
        /// <summary>
        /// Testea si se produce la excepcion y esta es del tipo correcto al agregar un alumno repetido
        /// </summary>
        [TestMethod]
        public void TestExcepcionAlumnoRepetido()
        {
            Alumno alumnoUno = new Alumno(12, "Enrique", "Marambio", "79342886", EntidadesAbstractas.Persona.ENacionalidad.Argentino,
            Universidad.EClases.Programacion, Alumno.EEstadoCuenta.Deudor);
            Profesor profesor = new Profesor(5, "Martin", "Gonzalez", "97345660", Persona.ENacionalidad.Extranjero);
            Alumno alumnoDos = new Alumno(12, "Enrique", "Enrique", "79342886", EntidadesAbstractas.Persona.ENacionalidad.Argentino,
            Universidad.EClases.Programacion, Alumno.EEstadoCuenta.Deudor);
            Jornada jornada = new Jornada(Universidad.EClases.Programacion, profesor);
            jornada += alumnoUno;
            try
            {
                jornada += alumnoDos;
                Assert.Fail("El alumno agregado es igual a uno ya ingresado");
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(AlumnoRepetidoException));
            }


        }
        /// <summary>
        /// Testea si se produce la excepcion y esta es del tipo correcto al instanciar una persona con formato de dni invalido
        /// </summary>
        [TestMethod]
        public void TestExcepcionDniInvalido()
        {
            try
            {
                Profesor profesor = new Profesor(2, "Manuel", "Vega", "palabra", Persona.ENacionalidad.Extranjero);
                Assert.Fail("El tipo de DNI es invalido");
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(DniInvalidoException));
            }
        }
    }
}
