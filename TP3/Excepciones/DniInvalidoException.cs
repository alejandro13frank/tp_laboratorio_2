using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class DniInvalidoException : Exception
    {
        private const string mensajeBase="mensaje base de dni invalido";
        public DniInvalidoException(string message, Exception e):base(message,e)
        {

        }
        public DniInvalidoException(string message) : base(message)
        {

        }
        public DniInvalidoException(Exception e) : base(mensajeBase,e)
        {

        }
        public DniInvalidoException() : base()
        {

        }

    }
}
