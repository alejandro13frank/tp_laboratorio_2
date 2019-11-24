using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;
namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        /// <summary>
        /// testea que se haya inicializado la lista de paquetes
        /// </summary>
        [TestMethod]
        public void TestMethod1()
        {
            Correo correo = new Correo();

            Assert.IsNotNull(correo.Paquetes);
        }
        /// <summary>
        /// testea que lance la excepcion cuando agrego dos paquetes iguales
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(TrakingIdRepetidoException))]
        public void TestMethod2 ()
        {
            Paquete p1 = new Paquete("hola", "123");
            Paquete p2 = new Paquete("hola", "123");
            Correo c1 = new Correo();

            c1 += p1;
            c1 += p2;         
        }


    }
}
