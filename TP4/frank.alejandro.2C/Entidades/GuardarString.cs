using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Entidades
{
    public static class GuardarString
    {
        public static bool Guardar(this string texto, string archivo)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            StreamWriter sw = new StreamWriter(path+$"\\{archivo}",true);
            sw.WriteLine(texto);
            sw.Close();
            return true;
        }
    }
}
