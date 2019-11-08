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
                if (ValidarNombreApellido(value)!="")
                {
                    this.apellido =value;
                }        
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
        /// <summary>
        /// constructor
        /// </summary>
        public Persona()
        {

        }
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="nacionalidad"></param>
        public Persona(string nombre, string apellido, ENacionalidad nacionalidad)
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Nacionalidad = nacionalidad;
        }
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad):this(nombre,apellido,dni.ToString(),nacionalidad) 
        {

        }
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad): this(nombre, apellido, nacionalidad)
        {
            this.StringToDNI = dni;
        }
        /// <summary>
        /// valida que el DNI sea correcto, teniendo en cuenta su nacionalidad  
        /// </summary>
        /// <param name="nacionalidad"></param>
        /// <param name="dni"></param>
        /// <returns></returns>
        private int ValidarDNI(ENacionalidad nacionalidad, int dni)
        {
            if (nacionalidad == ENacionalidad.Argentino && dni>=1 && dni<=89999999 || nacionalidad == ENacionalidad.Extranjero && dni>89999999 && dni<= 99999999)
            {
                return dni;
            }
            throw new NacionalidadInvalidaException();
            
        }
        /// <summary>
        ///  valida que el DNI sea correcto, teniendo en cuenta el formato (más caracteres de los permitidos, letras, etc.)
        /// </summary>
        /// <param name="nacionalidad"></param>
        /// <param name="dni"></param>
        /// <returns></returns>
        private int ValidarDNI(ENacionalidad nacionalidad, string dni)
        {
            int auxDni;
            if (int.TryParse(dni,out auxDni) && dni.Length < 9 && auxDni >= 1 && auxDni <= 99999999 )
            {
                return ValidarDNI(nacionalidad, auxDni);
            }
            throw new DniInvalidoException();
        }
        /// <summary>
        /// Valida que los nombres sean cadenas con caracteres válidos para nombres.
        /// </summary>
        /// <param name="dato"></param>
        /// <returns></returns>
        private string ValidarNombreApellido(string dato)
        {
            if (Regex.IsMatch(dato, "^[a-zA-Z]+$"))
            {
                return dato;
            }
            return "";
        }
        /// <summary>
        /// hace publicos los datos de la persona
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"NOMBRE COMPLETO: {this.Apellido},{this.Nombre}");
            //stringBuilder.AppendLine($"DNI:{(this.DNI).ToString()}");
            stringBuilder.AppendLine($"NACIONALIDA:{this.Nacionalidad.ToString()}");
            return stringBuilder.ToString();
        }
    }
}
