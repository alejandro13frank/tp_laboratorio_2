using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Excepciones;

namespace Archivos
{
    public class Xml<T> : IArchivo<T>
    {
        public bool Guardar(string archivo, T dato)
        {
            try
            { 
                XmlTextWriter writer = new XmlTextWriter(archivo,null);
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                serializer.Serialize(writer, dato);
                writer.Close();
                return true;
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }

        }
        public bool Leer(string archivo, out T dato)
        {
            try
            {
                XmlTextReader reader = new XmlTextReader(archivo);
                XmlSerializer serializar = new XmlSerializer(typeof(T));
                dato = (T)serializar.Deserialize(reader);
                reader.Close();
                return true;
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }
        }
    }
}
