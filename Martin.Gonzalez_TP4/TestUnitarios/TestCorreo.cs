using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;

namespace TestUnitarios
{
    [TestClass]
    public class TestCorreo
    {
        /// <summary>
        /// Testea si la lista de paquetes no es nula al instanciar un correo
        /// </summary>
        [TestMethod]
        public void TestListaInstanciada()
        {
            Correo correo = new Correo();
            Assert.IsNotNull(correo.Paquetes);
        }

        /// <summary>
        /// Testea si se produce una excepcion al agregar un paquete al correo con el mismo TrackingID de otro
        /// </summary>
        [TestMethod]
        public void TestMismoTrackingID()
        {
            Correo correo = new Correo();
            Paquete paqueteUno = new Paquete("aaaa", "1234");
            Paquete paqueteDos = new Paquete("bbbb", "1234");
            correo += paqueteUno;
            try
            {
                correo += paqueteDos;
                Assert.Fail("Se agrego un paquete con el mismo trackingID");
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(TrackingIdRepetidoException));
            }
        }
    }
}
