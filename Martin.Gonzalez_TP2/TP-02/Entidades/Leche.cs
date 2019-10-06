using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;

namespace Entidades_2018
{
    public class Leche : Producto
    {
        public enum ETipo
        {
            Entera,Descremada
        }

        private ETipo tipo;

        /// <summary>
        /// Las leches tienen 20 calorías
        /// </summary>
        protected override short CantidadCalorias
        {
            get
            {
                return 20;
            }
        }

        /// <summary>
        /// Por defecto, TIPO será ENTERA
        /// </summary>
        /// <param name="marca">Marca del Producto</param>
        /// <param name="codigo">Codigo de barrsa del producto</param>
        /// <param name="color">Color primario del Empaque del producto</param>
        public Leche(EMarca marca, string codigo, ConsoleColor color)
            : base(codigo, marca, color)
        {
            this.tipo = ETipo.Entera;
        }

        /// <summary>
        /// Constructor parametrizado de Leche
        /// </summary>
        /// <param name="codigo">Codigo de barrsa del producto</param>
        /// <param name="marca">Marca del producto</param>
        /// <param name="color">Color primario del Empaque del producto</param>
        /// <param name="tipo">Tipo de leche</param>
        public Leche(EMarca marca, string codigo, ConsoleColor color, ETipo tipo)
            : base(codigo, marca, color)
        {
            this.tipo = tipo;
        }

        /// <summary>
        /// Retornara un string con los datos de la clase Producto junto con los de la clase Leche
        /// </summary>
        /// <returns></returns>
        public sealed override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("LECHE");
            sb.AppendLine(base.Mostrar());
            sb.AppendFormat("CALORIAS : {0}", this.CantidadCalorias);
            sb.AppendFormat("TIPO : {0}" , this.tipo);
            sb.AppendLine("");
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
    }
}
