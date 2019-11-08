using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using Excepciones;
namespace EntidadesAbstractas
{
    public abstract class Persona
    {
        public enum ENacionalidad
        {
            Argentino,
            Extranjero
        }
        string nombre;
        string apellido;
        int dni;
        ENacionalidad nacionalidad;
        public string Nombre
        {
            get
            {
                return this.nombre;
            }
            set
            {
                this.nombre = ValidarNombreApellido(value);
            }
        }
        public string Apellido
        {
            get
            {
                return this.apellido;
            }
            set
            {
                this.apellido = ValidarNombreApellido(value);
            }
        }
        public int DNI
        {
            get
            {
                return this.dni;
            }
            set
            {
                this.dni = ValidarDNI(this.nacionalidad,value);
            }
        }
        public ENacionalidad Nacionalidad
        {
            get
            {
                return this.nacionalidad;
            }
            set
            {
                this.nacionalidad = value;
            }
        }
        public string StringToDNI
        {
            set
            {
                this.dni = ValidarDNI(this.nacionalidad, value);
            }
        }
        public Persona()
        {

        }
        public Persona(string nombre, string apellido, ENacionalidad nacionalidad)
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Nacionalidad = nacionalidad;
        }
        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad):this(nombre,apellido,dni.ToString(),nacionalidad) 
        {

        }
        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad): this(nombre, apellido, nacionalidad)
        {
            this.StringToDNI = dni;
        }
        private int ValidarDNI(ENacionalidad nacionalidad, int dni)
        {
            if (nacionalidad == ENacionalidad.Argentino && dni>=1 && dni<=89999999 || nacionalidad == ENacionalidad.Extranjero && dni>89999999 && dni<= 99999999)
            {
                return dni;
            }
            throw new NacionalidadInvalidaException();
            
        }
        private int ValidarDNI(ENacionalidad nacionalidad, string dni)
        {
            int auxDni;
            if (int.TryParse(dni,out auxDni) && dni.Length < 9 && auxDni >= 1 && auxDni <= 99999999 )
            {
                return ValidarDNI(nacionalidad, auxDni);
            }
            throw new DniInvalidoException();
        }
        private string ValidarNombreApellido(string dato)
        {
            if (Regex.IsMatch(dato, "^[a-zA-Z]+$"))
            {
                return dato;
            }
            return "";
        }
        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"NOMBRE COMPLETO: {this.Apellido},{this.Nombre}");
            stringBuilder.AppendLine($"DNI:{(this.DNI).ToString()}");
            stringBuilder.AppendLine($"NACIONALIDA:{this.Nacionalidad.ToString()}");
            return stringBuilder.ToString();
        }
    }
}
