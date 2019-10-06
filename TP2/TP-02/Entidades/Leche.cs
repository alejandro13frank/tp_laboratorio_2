using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;

namespace Entidades_2018
{
    public class Leche : Producto
    {
        public enum ETipo
        {
            Entera,
            Descremada
        }
        ETipo tipo;

        /// <summary>
        /// Por defecto, TIPO será ENTERA
        /// </summary>
        /// <param name="marca"></param>
        /// <param name="patente"></param>
        /// <param name="color"></param>
        public Leche(EMarca marca, string patente, ConsoleColor color)
            : this(marca,patente, color,Leche.ETipo.Entera)
        {
         
        }
        /// <summary>
        /// Crea un objeto de tipo Leche con los datos ingresados
        /// </summary>
        /// <param name="marca"></param>
        /// <param name="patente"></param>
        /// <param name="color"></param>
        /// <param name="tipoLeche"></param>
        public Leche(EMarca marca, string patente, ConsoleColor color,Leche.ETipo tipoLeche): base(marca, patente, color)
        {
            this.tipo = tipoLeche;
        }

        /// <summary>
        /// Las leches tienen 20 calorías
        /// </summary>
        protected override short CantidadCalorias
        {
            get
            {
                return 20;
            }
        }

        /// <summary>
        /// Publica todos los datos del Producto.
        /// </summary>
        /// <returns></returns>
        public new string Mostrar()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.Mostrar("LECHE", this.CantidadCalorias));
            sb.Append($"TIPO: {this.tipo.ToString()}");
            sb.AppendLine("");
            sb.AppendLine("---------------------");
            return sb.ToString();
        }
    }
}
