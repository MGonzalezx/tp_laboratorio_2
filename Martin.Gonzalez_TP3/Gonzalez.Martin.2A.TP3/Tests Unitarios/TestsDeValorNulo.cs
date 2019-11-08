using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Clases_Instanciables;

namespace Tests_Unitarios
{
    [TestClass]
    public class TestsDeValorNulo
    {
        /// <summary>
        /// Testea si al instanciar una persona esta tiene el nombre nulo.
        /// </summary>
        [TestMethod]
        public void TestNombreValorNulo()
        {
            Alumno alumno = new Alumno(3, "Ricardo", "Juarez", "47641909", EntidadesAbstractas.Persona.ENacionalidad.Argentino,
            Universidad.EClases.Legislacion, Alumno.EEstadoCuenta.Becado);
            Assert.IsNotNull(alumno.Nombre);
        }
    }
}
