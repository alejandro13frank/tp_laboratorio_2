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
            Programacion=0,
            Laboratorio=1,
            Legislacion=2,
            SPD=3
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
        public static bool operator !=(Universidad g, Alumno a)
        {
            return !(g == a);
        }
        public static bool operator !=(Universidad g, Profesor p)
        {
            return !(g == p);
        }
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
        public static Universidad operator +(Universidad g, EClases clase)
        {

            Jornada jornada = null;
            foreach (Profesor profesor in g.Instructores)
            {
                if (profesor==clase)
                {
                    jornada = new Jornada(clase, profesor);
                    break;
                }
            }
            if (!(jornada is null))
            {               
                foreach (Alumno alumno in g.Alumnos)
                {
                    
                    if (alumno==clase)
                    {
                        jornada += alumno;
                    }
                }
                g.Jornadas.Add(jornada);
            }
            return g;
        }
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
        private string MostrarDatos()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("UNIVERIDAD");
            foreach (Alumno alumno in this.Alumnos)
            {
                stringBuilder.Append(alumno.ToString());
                stringBuilder.AppendLine("----------------------------------------");

            }
            foreach (Profesor profesor in this.Instructores)
            {
                stringBuilder.Append(profesor.ToString());
                stringBuilder.AppendLine("----------------------------------------");
            }
            foreach (Jornada jornada in this.Jornadas)
            {
                stringBuilder.Append(jornada.ToString());
                stringBuilder.AppendLine("----------------------------------------");
            }
            return stringBuilder.ToString();
        }
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
        public static bool Guardar(Universidad uni)
        {
            Xml<Universidad> nuevoXml = new Xml<Universidad>();
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\Universidad.xml";
            nuevoXml.Guardar(path, uni);
            return true;
        }
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
