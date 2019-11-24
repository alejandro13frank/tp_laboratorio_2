using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace MainCorreo
{
    public partial class FrmPpal : Form
    {
        Correo correo;
        public FrmPpal()
        {
            InitializeComponent();
            this.correo = new Correo();
        }
        /// <summary>
        /// actualiza el forms
        /// </summary>
        private void ActualizarEstados()
        {
            lstEstadoEntregado.Items.Clear();
            lstEstadoEnViaje.Items.Clear();
            lstEstadoIngresado.Items.Clear();
            foreach (Paquete paquete in this.correo.Paquetes)
            {
                switch(paquete.Estado)
                {
                    case Paquete.EEstado.Entregado:
                        lstEstadoEntregado.Items.Add(paquete);
                        break;
                    case Paquete.EEstado.EnViaje:
                        lstEstadoEnViaje.Items.Add(paquete);
                        break;
                    case Paquete.EEstado.Ingresado:
                        lstEstadoIngresado.Items.Add(paquete);
                        break;
                }
            }
        }
        /// <summary>
        /// agrega el paqueta que ingresaron por el forms
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            Paquete paquete = new Paquete(lblDireccion.Text,mtxtTrackingID.Text);
            paquete.InformarEstado += paq_InformarEstado;
            try
            {
                this.correo += paquete;
            }
            catch (TrakingIdRepetidoException)
            {
                MessageBox.Show($"El tracking ID {paquete.TrackingID} ya figura en la lista de invios","Paquete repetido", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.ActualizarEstados();
        }
        /// <summary>
        /// infoma a traves del richtextbox todos los paquetes 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnMostrarTodos_Click(object sender, EventArgs e)
        {
            this.MostrarInformacion<List<Paquete>>((IMostrar<List<Paquete>>)correo);
        }
        /// <summary>
        /// aborta todos los hilos en el closing del forms
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmPpal_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.correo.FinEntregas();
        }
        /// <summary>
        /// guarda en un txt la informacion de un paquete
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="elemento"></param>
        private void MostrarInformacion<T>(IMostrar<T> elemento)
        {
            if (!(elemento is null))
            {
                rtbMostrar.Text = elemento.MostrarDatos(elemento);
                rtbMostrar.Text.Guardar("salida.txt");
            }
        }
        /// <summary>
        /// ....
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mostrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.MostrarInformacion<Paquete>((IMostrar<Paquete>)lstEstadoEntregado.SelectedItem);
        }
        /// <summary>
        /// llama al hilo principal para poder actualizar los estados
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void paq_InformarEstado(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                Paquete.DelegadoEstado d = new Paquete.DelegadoEstado(paq_InformarEstado);
                this.Invoke(d, new object[] { sender, e });
            }
            else
            { 
                this.ActualizarEstados();
            }
        }
    }
}
