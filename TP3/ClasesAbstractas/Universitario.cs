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

        public override bool Equals(object obj)
        {
            return this.GetType()==obj.GetType() && (this.DNI==((Persona)obj).DNI || this.legajo==((Universitario)obj).legajo);
        }
        protected virtual string MostrarDatos()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"{base.ToString()}");
            stringBuilder.AppendLine($"LEGAJO: {this.legajo.ToString()}");
            return stringBuilder.ToString();
        }
        public Universitario()
        {

        }
        public Universitario(int legajo,string nombre,string apellido, string dni,ENacionalidad nacionalidad): base(nombre,apellido,dni,nacionalidad)
        {
            this.legajo = legajo;
        }
        protected abstract string ParticiparEnClase();
        public static bool operator ==(Universitario u1,Universitario u2)
        {
            return u1.Equals(u2);
        }
        public static bool operator !=(Universitario u1, Universitario u2)
        {
            return u1.Equals(u2);
        }
    }
}
