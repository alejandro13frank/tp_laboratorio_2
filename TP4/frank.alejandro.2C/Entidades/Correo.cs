using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Entidades
{
    public class Correo : IMostrar<List<Paquete>>
    {
        List<Thread> mockPaquetes;
        List<Paquete> paquetes;

        public List<Paquete> Paquetes
        {
            get
            {
                return this.paquetes;
            }
            set
            {
                this.paquetes = value;
            }
        }
        #region Metodos
        /// <summary>
        /// constructor del correo, inicializa las listas
        /// </summary>
        public Correo()
        {
            this.mockPaquetes = new List<Thread>();
            this.paquetes = new List<Paquete>();
        }
        /// <summary>
        /// aborta los hilos del mock
        /// </summary>
        public void FinEntregas()
        {
            foreach (Thread hilo in this.mockPaquetes)
            {
                hilo.Abort();
            }
        }
        /// <summary>
        /// implementa la interfas IMostrar
        /// </summary>
        /// <param name="elementos"></param>
        /// <returns></returns>
        public string MostrarDatos(IMostrar<List<Paquete>> elementos)
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (Paquete p in ((Correo)elementos).Paquetes)
            {
                stringBuilder.AppendLine(string.Format("{0} para {1} ({2})",p.TrackingID,p.DireccionDeEntrega,p.Estado.ToString()));
            }
            return stringBuilder.ToString();
        }
        /// <summary>
        /// sobrecarga operador +
        /// </summary>
        /// <param name="c"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        public static Correo operator +(Correo c,Paquete p)
        {
            foreach (Paquete paquete in c.paquetes)
            {
                if (paquete==p)
                {
                    throw new TrakingIdRepetidoException();
                }
            }
            c.paquetes.Add(p);
            Thread hilo = new Thread(p.MockCicloDeVida);
            c.mockPaquetes.Add(hilo);
            hilo.Start();
            return c;
        }
        #endregion
    }
}
