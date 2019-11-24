using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class TrakingIdRepetidoException : Exception
    {
        public TrakingIdRepetidoException() : base()
        {

        }
        public TrakingIdRepetidoException(string mensaje) : base(mensaje)
        {

        }
        public TrakingIdRepetidoException(string mensaje, Exception inner) : base(mensaje, inner)
        {

        }
    }
}
