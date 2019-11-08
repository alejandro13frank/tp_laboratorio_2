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

        /// <summary>
        /// Dos Universitario serán iguales si y sólo si son del mismo Tipo y su Legajo o DNI son iguales
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            return this.GetType()==obj.GetType() && (this.DNI==((Persona)obj).DNI || this.legajo==((Universitario)obj).legajo);
        }
        /// <summary>
        /// devuelve en modo string los datos de una persona
        /// </summary>
        /// <returns></returns>
        protected virtual string MostrarDatos()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"{base.ToString()}");
            stringBuilder.AppendLine($"LEGAJO: {this.legajo.ToString()}");
            return stringBuilder.ToString();
        }
        /// <summary>
        /// constructor
        /// </summary>
        public Universitario()
        {

        }
        /// <summary>
        /// costructor
        /// </summary>
        /// <param name="legajo"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        public Universitario(int legajo,string nombre,string apellido, string dni,ENacionalidad nacionalidad): base(nombre,apellido,dni,nacionalidad)
        {
            this.legajo = legajo;
        }
        /// <summary>
        /// metodo abstracto que sera implentado en las clases que lo hereden
        /// </summary>
        /// <returns></returns>
        protected abstract string ParticiparEnClase();
        /// <summary>
        /// devuelve si dos universitarios son iguales segun Tipo y Legajo o DNI son iguales
        /// </summary>
        /// <param name="u1"></param>
        /// <param name="u2"></param>
        /// <returns></returns>
        public static bool operator ==(Universitario u1,Universitario u2)
        {
            return u1.Equals(u2);
        }
        /// <summary>
        /// devuelve si dos universitarios son distintos segun  Tipo y Legajo o DNI son iguales
        /// </summary>
        /// <param name="u1"></param>
        /// <param name="u2"></param>
        /// <returns></returns>
        public static bool operator !=(Universitario u1, Universitario u2)
        {
            return !(u1==u2);
        }
    }
}
