using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EntidadesAbstractas;
using Clases_Instanciables;

namespace Tests_Unitarios
{
    [TestClass]
    public class UnitTest1
    {
        /// <summary>
        /// Testea si al instanciar una persona esta tiene un dni que no concuerde con su nacionalidad
        /// </summary>
        [TestMethod]
        public void TestValorDni()
        {
            Profesor profesor = new Profesor(1, "Alberto", "Fiorentino", "94351310", Persona.ENacionalidad.Extranjero);
            Profesor profesorDos = new Profesor(1, "Albertito", "Milan", "56337292", Persona.ENacionalidad.Argentino);
            if (profesor.DNI < 90000000 || profesor.DNI > 99999999)
            {
                Assert.Fail("DNI extranjero incorrecto: {0}", profesor.DNI);
            }
            if (profesorDos.DNI >= 90000000 || profesorDos.DNI < 1)
            {
                Assert.Fail("DNI argentino incorrecto: {0}", profesor.DNI);
            }
        }
    }
}
