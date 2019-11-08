using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archivos
{
    public interface IArchivo<T>
    {   
        /// <summary>
        /// Interfas para ser implementada en otras clases con el finde Guardar un archivo generico
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="dato"></param>
        /// <returns></returns>
        bool Guardar(string archivo, T dato);
        /// <summary>
        /// Interfas para ser implementada en otras clases con el finde leer un archivo generico
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="dato"></param>
        /// <returns></returns>
        bool Leer(string archivo, out T dato);
    }
}
