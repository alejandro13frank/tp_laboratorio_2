using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Excepciones;
using ClasesInstanciables;
using EntidadesAbstractas; 

namespace PruebasUnitarias
{
    [TestClass]
    public class UnitTest1
    {
        /// <summary>
        /// Pruebo agregar un alumno que ya esta agregado con el mismo dni
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(AlumnoRepetidoException))]
        public void TestAlumnoRepetidoException()
        {
            Universidad uni = new Universidad();
            Alumno a1 = new Alumno(1, "Juan", "Lopez", "12234456",
            EntidadesAbstractas.Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion,
            Alumno.EEstadoCuenta.Becado);
            uni += a1;
            Alumno a3 = new Alumno(3, "José", "Gutierrez", "12234456",
            EntidadesAbstractas.Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion,
            Alumno.EEstadoCuenta.Becado);
            uni += a3;
        }
        /// <summary>
        /// Pruebo agregar una clase sin profesores para darla
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(SinProfesorException))]
        public void TestSinProfesorException()
        {
            Universidad uni = new Universidad();
            Alumno a1 = new Alumno(1, "Juan", "Lopez", "12234456",
            EntidadesAbstractas.Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion,
            Alumno.EEstadoCuenta.Becado);
            uni += Universidad.EClases.SPD;
        }
        /// <summary>
        /// Pruebo que el dni ingresado se haya cargado correctamente
        /// </summary>
        [TestMethod]
        public void TestNumerico()
        {
            Alumno a1 = new Alumno(1, "Juan", "Lopez", "12234456",
            EntidadesAbstractas.Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion,
            Alumno.EEstadoCuenta.Becado);
            Assert.AreEqual(12234456, a1.DNI);
        }
        /// <summary>
        /// Pruebo que el el atributo nombre ingresado se haya cargado y no sea Null
        /// </summary>
        [TestMethod]
        public void TestAtributoNulo()
        {
            Alumno a1 = new Alumno(1, "Juan", "Lopez", "12234456",
            EntidadesAbstractas.Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion,
            Alumno.EEstadoCuenta.Becado);
            Assert.IsNotNull(a1.Nombre);
        }
    }
}
