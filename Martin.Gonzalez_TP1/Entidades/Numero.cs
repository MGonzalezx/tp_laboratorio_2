using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Numero
    {
        #region Variables
        private double numero;
        #endregion

        #region Constructores
        public Numero(): this(0)
        {
            
        }
        public Numero(double numero)
        {
            this.numero = numero;
        }
        public Numero(string strNumero)
        {
            this.SetNumero = strNumero;
        }
        #endregion

        #region Metodos

        private string SetNumero
        {
            set { numero = this.ValidarNumero(value); }
        }

        private double ValidarNumero(string strNumero)
        {
            double auxiliar;

            if(!double.TryParse(strNumero, out auxiliar))
            {
                auxiliar = 0;
            }
            return auxiliar;
        }

        public string BinarioDecimal(string binario)
        {
            string retorno = "Valor inválido";
            bool flag = true;
            int numeroAuxiliar;
            for (int i = 0; i < binario.Length; i++)
            {
                if (binario[i] != 1 || binario[i] != 0)
                {
                    flag = false;
                    break;
                }
            }
            if (flag)
            {
                numeroAuxiliar = Convert.ToInt32(binario, 10);
                retorno = numeroAuxiliar.ToString();
            }
            return retorno;
        }

        public static string DecimalBinario(double numero)
        {
            string retorno;
            int auxiliar;
            auxiliar = Convert.ToInt32(Math.Abs(numero));
            retorno = Convert.ToString(auxiliar, 2);
            return retorno;
        }

        public string DecimalBinario(string numero)
        {
            string retorno = "Valor invalido";
            double numeroAuxiliar;
            if (!Double.TryParse(numero, out numeroAuxiliar))
            {
                retorno = Numero.DecimalBinario(numeroAuxiliar);
            }
            return retorno;
        }

        #endregion

        #region Operadores
        public static double operator +(Numero n1, Numero n2)
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
            if(n2.numero != 0)
            {
                return n1.numero / n2.numero;
            }else
            {
                return double.MinValue;
            }
                        
        }
        #endregion

    }
}
