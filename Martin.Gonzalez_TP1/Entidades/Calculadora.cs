using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class Calculadora
    {
        #region Metodos
        private static string ValidarOperador(string operador)
        {
            if (String.Equals(operador, "+") || String.Equals(operador, "-") || String.Equals(operador, "/") || String.Equals(operador, "*"))
            {
                return operador;
            }
            else
            {
                return "+";
            }
        }

        public static double Operar(Numero num1, Numero num2, string operador)
        {
            string operadorAuxiliar = Calculadora.ValidarOperador(operador);
            double retorno = 0;

            switch (operadorAuxiliar)
            {
                case "+":
                    retorno = num1 + num2;
                    break;
                case "-":
                    retorno = num1 - num2;
                    break;
                case "/":
                    if (string.Equals(num2, 0))
                    {
                        retorno = Double.MinValue;
                    }
                    else
                    {
                        retorno = num1 / num2;
                    }
                    break;
                case "*":
                    retorno = num1 * num2;
                    break;
            }
            return retorno;

        }
        #endregion
    }
}
