using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Paquete : IMostrar<Paquete>
    {
        public delegate void DelegadoEstado(object sender, EventArgs e);

        private string direccionDeEntrega;
        private EEstado estado;
        private string trackingID;
        public event DelegadoEstado InformarEstado;

        #region Propiedades
        public enum EEstado
        {
            Ingresado,
            EnViaje,
            Entregado
        }

        public string DireccionDeEntrega
        {
            get
            {
                return this.direccionDeEntrega;
            }
            set
            {
                this.direccionDeEntrega = value;
            }
        }
        public string TrackingID
        {
            get
            {
                return this.trackingID;
            }
            set
            {
                this.trackingID = value;
            }
        }
        public EEstado Estado
        {
            get
            {
                return this.estado;
            }
            set
            {
                this.estado = value;
            }
        }
        #endregion
        #region Metodos
        /// <summary>
        /// cambia el estado del paquete cada 4 seg
        /// </summary>
        public void MockCicloDeVida()
        {
            while (this.estado != Paquete.EEstado.Entregado)
            {
                System.Threading.Thread.Sleep(4000);
                this.estado += 1;
                this.InformarEstado.Invoke(this, null);
            }
            PaqueteDAO.Insertar(this);
        }
        /// <summary>
        /// implementa la interfas IMostrar
        /// </summary>
        /// <param name="elemento"></param>
        /// <returns></returns>
        public string MostrarDatos(IMostrar<Paquete> elemento)
        {
            return string.Format("{0} para {1}", ((Paquete)elemento).TrackingID, ((Paquete)elemento).DireccionDeEntrega);
        }
        /// <summary>
        /// sobrecarga operador ==
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
        public static bool operator ==(Paquete p1,Paquete p2)
        {
            return p1.TrackingID == p2.TrackingID;       
        }
        /// <summary>
        /// sobrecarga operador !=
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
        public static bool operator !=(Paquete p1, Paquete p2)
        {
            return !(p1 == p2);
        }
        /// <summary>
        /// constructor de instancia
        /// </summary>
        /// <param name="direccionEntrega"></param>
        /// <param name="trackingID"></param>
        public Paquete(string direccionEntrega, string trackingID)
        {
            this.direccionDeEntrega = direccionEntrega;
            this.trackingID = trackingID;
            this.estado = 0;
        }
        /// <summary>
        /// sobrecarga to string
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.MostrarDatos(this)+$"estado: {this.estado}";
        }

        #endregion



    }
}