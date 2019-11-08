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
        /// <summary>
        /// Genera dos clases aleatorias para el profesor
        /// </summary>
        private void _randomClase()
        {
            System.Threading.Thread.Sleep(50);
            this.clasesDelDia.Enqueue((Universidad.EClases)random.Next(0,4));
            System.Threading.Thread.Sleep(50);
            this.clasesDelDia.Enqueue((Universidad.EClases)random.Next(0,4));
        }
        /// <summary>
        /// devuelve los datos de la clase
        /// </summary>
        /// <returns></returns>
        protected override string MostrarDatos()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"{base.MostrarDatos()}");
            stringBuilder.AppendLine(this.ParticiparEnClase());
            return stringBuilder.ToString();
        }
        /// <summary>
        ///  retorna la cadena "CLASES DEL DÍA" junto al nombre de la clases que da.
        /// </summary>
        /// <returns></returns>
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
        /// <summary>
        /// constructor
        /// </summary>
        public Profesor()
        {

        }
        /// <summary>
        /// constructor estatico
        /// </summary>
        static Profesor()
        {
            random=new Random();
        }
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad): base(id,nombre,apellido,dni,nacionalidad)
        {
            this.clasesDelDia = new Queue<Universidad.EClases>();
            this._randomClase();
        }
        /// <summary>
        /// hace publicos los datos de la clase
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }
        /// <summary>
        /// Un Profesor será igual a un EClase si da esa clase
        /// </summary>
        /// <param name="i"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Un Profesor será distinto a un EClase si no da esa clase
        /// </summary>
        /// <param name="i"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static bool operator !=(Profesor i, Universidad.EClases clase)
        {
            return !(i == clase);
        }
    }
}
