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

namespace MiCalculadora
{
    public partial class FormCalculadora : Form
    {
        public FormCalculadora()
        {
            InitializeComponent();
            this.cmbOperador.Items.Add("+");
            this.cmbOperador.Items.Add("-");
            this.cmbOperador.Items.Add("*");
            this.cmbOperador.Items.Add("/");
        }
        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnConvertirABinario_click(object sender, EventArgs e)
        {
            string conversion= Numero.DecimalBinario(this.lblResultado.Text);
            if (conversion=="Valor invalido")
            {
                MessageBox.Show(conversion);
            }
            else
            {
                this.lblResultado.Text = conversion;
            }
           
        }

        private void BtnConvertirADecimal_Click(object sender, EventArgs e)
        {
            string conversion = Numero.BinarioDecimal(this.lblResultado.Text);
            if (conversion == "Valor invalido")
            {
                MessageBox.Show(conversion);
            }
            else
            {
                this.lblResultado.Text = conversion;
            }
        }

        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void BtnOperar_Click(object sender, EventArgs e)
        {
            this.lblResultado.Text = FormCalculadora.Operar(this.txtNumero1.Text, this.txtNumero2.Text, this.cmbOperador.Text).ToString();
        }
        
        private void Limpiar()
        {
            this.txtNumero1.Clear();
            this.txtNumero2.Clear();
            this.cmbOperador.ResetText();
            this.lblResultado.ResetText();
        }

        private static double Operar(string numero1, string numero2, string operador)
        {
            Numero n1 = new Numero(numero1);
            Numero n2 = new Numero(numero2);
            return Calculadora.Operar(n1, n2, operador);
        }
    }
}
