using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;
namespace ClasesInstanciables
{
    public sealed class Profesor : Universitario
    {
        private Queue<Universidad.EClases> clasesDelDia;
        private static Random random;

        private void _randomClase()
        {
            this.clasesDelDia.Enqueue((Universidad.EClases)random.Next(0,3));
            this.clasesDelDia.Enqueue((Universidad.EClases)random.Next(0, 3));
        }
        protected override string MostrarDatos()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"{base.ToString()}");
            foreach (Universidad.EClases clase  in this.clasesDelDia)
            {
                stringBuilder.AppendLine($"CLASE: {clase.ToString()}");
            }
            return stringBuilder.ToString();
        }
        protected override string ParticiparEnClase()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("CLASES DEL DIA");
            foreach (Universidad.EClases clase in this.clasesDelDia)
            {
                stringBuilder.AppendLine($"{clase.ToString()}");   
            }
            return stringBuilder.ToString();
        }
        public Profesor()
        {

        }
        static Profesor()
        {
            random=new Random();
        }
        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad): base(id,nombre,apellido,dni,nacionalidad)
        {
            this.clasesDelDia = new Queue<Universidad.EClases>();
            this._randomClase();
        }
        public override string ToString()
        {
            return this.MostrarDatos();
        }
        public static bool operator ==(Profesor i,Universidad.EClases clase)
        {
            foreach (Universidad.EClases auxClase in i.clasesDelDia)
            {
                if (clase == auxClase)
                {
                    return true;
                }
            }
            return false;
        }
        public static bool operator !=(Profesor i, Universidad.EClases clase)
        {
            return !(i == clase);
        }
    }
}
