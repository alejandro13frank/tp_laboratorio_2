using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Archivos;

namespace ClasesInstanciables
{
    public class Jornada
    {
        private List<Alumno> alumnos;
        private Universidad.EClases clase;
        private Profesor instructor;
        public List<Alumno> Alumnos
        {
            get
            {
                return this.alumnos;
            }
            set
            {
                this.alumnos = value;
            }
        }
        public Universidad.EClases Clase
        {
            get
            {
                return this.clase;
            }
            set
            {
                this.clase = value;
            }
        }
        public Profesor Instructor
        {
            get
            {
                return this.instructor;
            }
            set
            {
                this.instructor = value;
            }
        }
        /// <summary>
        /// Guarda los datos de la jornada en el escritorio en un archivo de texto "\Jornada.txt"
        /// </summary>
        /// <param name="jornada"></param>
        /// <returns></returns>
        public static bool Guardar(Jornada jornada)
        {
            Texto texto = new Texto();
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)+"\\Jornada.txt";
            texto.Guardar(path, jornada.ToString());
            return true;
        }
        /// <summary>
        /// lee los datos de un archivo text "\Jornada.txt" de una jornada desde el escritorio
        /// </summary>
        /// <returns></returns>
        public string Leer()
        {
            Texto texto = new Texto();
            string datos;
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\Jornada.txt";
            texto.Leer(path, out datos);
            return datos;
        }
        /// <summary>
        /// Constructor por defecto, inicializa lista de alumnos.
        /// </summary>
        private Jornada()
        {
            this.Alumnos = new List<Alumno>();
        }
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="clase"></param>
        /// <param name="instructor"></param>
        public Jornada(Universidad.EClases clase, Profesor instructor):this()
        {
            this.Clase = clase;
            this.Instructor = instructor;
        }
        /// <summary>
        /// Una Jornada será igual a un Alumno si el mismo participa de la clase.
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool operator ==(Jornada j, Alumno a)
        {
            return a == j.Clase;
        }
        /// <summary>
        /// Una Jornada será distinta a un Alumno si el mismo no participa de la clase.
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }
        /// <summary>
        /// Agregar Alumnos a la clase validando que no estén previamente
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static Jornada operator +(Jornada j, Alumno a)
        {
            foreach(Alumno alumno in j.Alumnos)
            {
                if (alumno.Equals(a))
                {
                    return j;
                }
            }
            j.Alumnos.Add(a);
            return j;
        }
        /// <summary>
        /// hace publicos los datos de la clase
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("JORNADA:");
            stringBuilder.AppendLine($"CLASE DE {this.Clase.ToString()} POR {this.Instructor.ToString()}");
            stringBuilder.AppendLine("ALUMNOS: ");
            foreach (Alumno alumno in this.Alumnos)
            {
                stringBuilder.AppendLine($"{alumno.ToString()}");
                stringBuilder.AppendLine();
            }
            return stringBuilder.ToString();
        }

    }
}
