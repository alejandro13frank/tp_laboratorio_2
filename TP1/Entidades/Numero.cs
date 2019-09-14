using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Numero
    {
        private double numero;
        private string  SetNumero
        {
            set
            {
                this.numero = ValidarNumero(value);
            }
        }
        public Numero(string strNumero)
        {
            this.SetNumero = strNumero;
        }
        public Numero(double numero):this(numero.ToString())
        {
   
        }
        public Numero(): this(0)
        {

        }
        private static double ValidarNumero(string strNumero)
        {
            double resultado;
            try
            {
                resultado = Convert.ToDouble(strNumero);
                return resultado;
            }
            catch (FormatException)
            {
                return 0;
            }
            catch (OverflowException)
            {
                return 0;
            }
        }

        public static string BinarioDecimal(string binario)
        {
            char[] arrayDeChar = binario.ToCharArray();
            Array.Reverse(arrayDeChar);
            int resultado = 0;
            { 
                for (int i = 0; i < arrayDeChar.Length; i++)
                {
                    if (arrayDeChar[i] != '0' && arrayDeChar[i] != '1')
                    {
                        return "valor invalido";
                    }
                    if (arrayDeChar[i] == '1')
                    {
                        resultado += (int)Math.Pow(2, i);
                    }
                }
            }
            return resultado.ToString();
        }
        public static string DecimalBinario(double numero)
        {
            string resto = "";
            string binario = "";
 
            int numeroEntero = (int)Math.Abs(numero);

            while ((numeroEntero >= 2))
            {
                resto = resto + (numeroEntero % 2).ToString();
                numeroEntero = numeroEntero / 2;
            }
            resto = resto + numeroEntero.ToString();

            for (int i = resto.Length; i >= 1; i += -1)
            {
                binario = binario + resto.Substring(i - 1, 1);
            }
            return binario;
        }

        public static string DecimalBinario(string strNumero)
        {
            double numero;
            string resultado;
            if (double.TryParse(strNumero,out numero))
            {
                resultado = DecimalBinario(numero);
            }
            else
            {
                resultado = "Valor invalido";
            }
            return resultado;
        }
        public static double operator +(Numero n1,Numero n2)
        {
            return n1.numero + n2.numero;
        }
        public static double operator -(Numero n1, Numero n2)
        {
            return n1.numero - n2.numero;
        }
        public static double operator *(Numero n1, Numero n2)
        {
            return n1.numero * n2.numero;
        }
        public static double operator /(Numero n1, Numero n2)
        {
            if (n2.numero==0)
            {
                return double.MinValue;
            }
            return n1.numero / n2.numero;
        }
    }
}
