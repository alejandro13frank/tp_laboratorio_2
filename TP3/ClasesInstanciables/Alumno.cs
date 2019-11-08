using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;

namespace ClasesInstanciables
{
    public sealed class Alumno : Universitario
    {
        private Universidad.EClases claseQueToma;
        private EEstadoCuenta estadoCuenta;

        public enum EEstadoCuenta
        {
            AlDia,
            Deudor,
            Becado
        }
        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public Alumno()
        {

        }
        /// <summary>
        /// constructor 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        /// <param name="claseQueToma"></param>
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma):base(id,nombre,apellido,dni,nacionalidad)
        {
            this.claseQueToma = claseQueToma;
        }
        /// <summary>
        /// constructor 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        /// <param name="claseQueToma"></param>
        /// <param name="estadoCuenta"></param>
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma, EEstadoCuenta estadoCuenta) : this (id, nombre, apellido, dni,nacionalidad,claseQueToma)
        {
            this.estadoCuenta = estadoCuenta;
        }
        /// <summary>
        /// devuelve los datos de la clase
        /// </summary>
        /// <returns></returns>
        protected override string MostrarDatos()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"{base.MostrarDatos()}");
            stringBuilder.AppendLine($"ESTADO DE CUENTA: {this.estadoCuenta.ToString()}");
            stringBuilder.AppendLine(this.ParticiparEnClase());
            
            return stringBuilder.ToString();
        }
        /// <summary>
        /// retorna la cadena "TOMA CLASE DE " junto al nombre de la clase que toma.
        /// </summary>
        /// <returns></returns>
        protected override string ParticiparEnClase()
        {
            return $"TOMA CLASE DE {this.claseQueToma.ToString()}";
        }
        /// <summary>
        /// hace públicos los datos del Alumno
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }
        /// <summary>
        /// Un Alumno será igual a un EClase si toma esa clase y su estado de cuenta no es Deudor
        /// </summary>
        /// <param name="a"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static bool operator ==(Alumno a, Universidad.EClases clase)
        {
            return a.estadoCuenta!=EEstadoCuenta.Deudor && a.claseQueToma==clase;
        }
        /// <summary>
        /// Un Alumno será distinto a un EClase sólo si no toma esa clase.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static bool operator !=(Alumno a, Universidad.EClases clase)
        {
            return !(a.claseQueToma==clase);
        }
    }
}
