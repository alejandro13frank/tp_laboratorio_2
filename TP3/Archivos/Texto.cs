using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Excepciones;

namespace Archivos
{
    public class Texto : IArchivo<string>
    {
        public bool Guardar(string archivo, string datos)
        {
            try
            {
                StreamWriter stream = new StreamWriter(archivo,true);
                stream.Write(datos);
                stream.Close();
                return true;
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }
        }
        public bool Leer(string archivo, out string datos)
        {
            try
            {
                StreamReader stream = new StreamReader(archivo);
                datos = stream.ReadToEnd();
                stream.Close();
                return true;
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }
        }
    }
}
