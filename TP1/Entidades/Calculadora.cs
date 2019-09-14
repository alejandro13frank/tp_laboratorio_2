using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Calculadora
    {
        private static string ValidarOperador(string operador)
        {
            if (!(operador is null)&&
                (operador=="+" ||
                operador == "-" ||
                operador == "/" ||
                operador == "*"))
            {
                return operador;
            }
            else
            {
                return "+";
            }
        }
        public static double Operar(Numero numero1, Numero numero2, string operador)
        {
            string operadorEjecutado = Calculadora.ValidarOperador(operador);
            if (operadorEjecutado == "+")
            {
                return numero1 + numero2;
            }
            else if (operadorEjecutado == "-")
            {
                return numero1 - numero2;
            }
            else if (operadorEjecutado == "*")
            {
                return numero1 * numero2;
            }
            else
            {
                return numero1 / numero2;
            }
        }
    }
}
