using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;
using Archivos;

namespace ClasesInstanciables
{
    public class Universidad
    {
        public enum EClases
        {
            Programacion,
            Laboratorio,
            Legislacion,
            SPD
        }
        List<Alumno> alumnos;
        List<Jornada> jornadas;
        List<Profesor> instructores;

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
        public List<Jornada> Jornadas
        {
            get
            {
                return this.jornadas;
            }
            set
            {
                this.jornadas = value;
            }
        }
        public List<Profesor> Instructores
        {
            get
            {
                return this.instructores;
            }
            set
            {
                this.instructores = value;
            }
        }
        public Jornada this[int i]
        {
            get
            {
                return this.jornadas[i];
            }
            set
            {
                this.jornadas[i] = value;
            }       
        }
        /// <summary>
        /// Un Universidad será igual a un Alumno si el mismo está inscripto en él
        /// </summary>
        /// <param name="g"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool operator ==(Universidad g, Alumno a)
        {
            foreach (Alumno alumno in g.Alumnos)
            {
                if (alumno.Equals(a))
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// Un Universidad será igual a un Profesor si el mismo está dando clases en él
        /// </summary>
        /// <param name="g"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        public static bool operator ==(Universidad g, Profesor p)
        {
            foreach (Jornada jornada in g.Jornadas) 
            {
                if (jornada.Instructor.Equals(p))
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// La igualación entre un Universidad y una Clase retornará el primer Profesor capaz de dar esa clase.
        /// Sino, lanzará la Excepción SinProfesorException
        /// </summary>
        /// <param name="u"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static Profesor operator ==(Universidad u, EClases clase)
        {
            foreach (Profesor profesor in u.Instructores)
            {
                if (profesor==clase)
                {
                    return profesor;
                }
            }
            throw new SinProfesorException();
        }
        /// <summary>
        /// Un Universidad será distinto a un Alumno si el mismo no está inscripto en él
        /// </summary>
        /// <param name="g"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool operator !=(Universidad g, Alumno a)
        {
            return !(g == a);
        }
        /// <summary>
        /// Un Universidad será distinta a un Profesor si el mismo no está dando clases en él
        /// </summary>
        /// <param name="g"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        public static bool operator !=(Universidad g, Profesor p)
        {
            return !(g == p);
        }
        /// <summary>
        /// devuelve el primer profesor que no pueda dar la clase
        /// </summary>
        /// <param name="u"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static Profesor operator !=(Universidad u, EClases clase)
        {
            foreach (Profesor profesor in u.Instructores)
            {
                if (profesor!=clase)
                {
                    return profesor;    
                }
            }
            return null;
        }
        /// <summary>
        /// Al agregar una clase a un Universidad se genera y agregar una nueva Jornada indicando la
        /// clase, un Profesor que pueda darla(según su atributo ClasesDelDia) y la lista de alumnos que la
        /// toman(todos los que coincidan en su campo ClaseQueToma).
        /// </summary>
        /// <param name="g"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static Universidad operator +(Universidad g, EClases clase)
        {
            Jornada jornada = new Jornada(clase, g==clase);                         
            foreach (Alumno alumno in g.Alumnos)
            {                   
                if (alumno==clase)
                {
                    jornada += alumno;
                }
            }
            g.Jornadas.Add(jornada);
            return g;
        }
        /// <summary>
        /// Se agrega Alumnos mediante el operador +, validando que no estén previamente
        /// cargados.
        /// </summary>
        /// <param name="g"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static Universidad operator +(Universidad g, Alumno a)
        {
            foreach (Alumno alumno in g.Alumnos)
            {
                if (alumno.Equals(a))
                {
                    throw new AlumnoRepetidoException();
                }
            }
            g.Alumnos.Add(a);
            return g;
        }
        /// <summary>
        /// Se agregarán Profesores mediante el operador +, validando que no estén previamente
        /// cargados.
        /// </summary>
        /// <param name="g"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        public static Universidad operator +(Universidad g, Profesor p)
        {
            foreach (Profesor profesor in g.Instructores)
            {
                if (profesor.Equals(p))
                {
                    return g;
                }
            }
            g.Instructores.Add(p);
            return g;
        }
        /// <summary>
        /// Devuelve los datos de la univesidad
        /// </summary>
        /// <returns></returns>
        private string MostrarDatos()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("UNIVERIDAD");
            /*foreach (Alumno alumno in this.Alumnos)
            {
                stringBuilder.Append(alumno.ToString());
                stringBuilder.AppendLine("----------------------------------------");

            }
            foreach (Profesor profesor in this.Instructores)
            {
                stringBuilder.Append(profesor.ToString());
                stringBuilder.AppendLine("----------------------------------------");
            }*/
            foreach (Jornada jornada in this.Jornadas)
            {
                stringBuilder.Append(jornada.ToString());
                stringBuilder.AppendLine("----------------------------------------");
            }
            return stringBuilder.ToString();
        }
        /// <summary>
        /// hace publicos los datos de la univerdad
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }
        public Universidad()
        {
            this.alumnos = new List<Alumno>();
            this.instructores = new List<Profesor>();
            this.jornadas = new List<Jornada>();
        }
        /// <summary>
        /// guarda los datos de la universidad en formato xml "Universidad.xml" en el escritorio
        /// </summary>
        /// <param name="uni"></param>
        /// <returns></returns>
        public static bool Guardar(Universidad uni)
        {
            Xml<Universidad> nuevoXml = new Xml<Universidad>();
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\Universidad.xml";
            nuevoXml.Guardar(path, uni);
            return true;
        }
        /// <summary>
        /// lee los datos de la universidad en formato xml "Universidad.xml" del escritorio
        /// </summary>
        /// <returns></returns>
        public Universidad Leer()
        {
            Xml<Universidad> nuevoXml = new Xml<Universidad>();
            Universidad uni=null;
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\Universidad.xml";
            if (nuevoXml.Leer(path,out uni))
            {
                return uni;
            }
            return uni;
        }
    }
}
