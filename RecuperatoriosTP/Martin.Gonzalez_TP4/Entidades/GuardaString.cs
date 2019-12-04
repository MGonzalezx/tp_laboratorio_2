using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Entidades
{
    public static class GuardaString
    {
        /// <summary>
        /// Agrega la informacion a un archivo de texto en el Escritorio
        /// </summary>
        /// <param name="texto">Informacio</param>
        /// <param name="archivo">Ruta del archivo</param>
        /// <returns>TRUE si completado, FALSE en caso de error</returns>
        public static bool Guardar(this string texto, string archivo)
        {
            try
            {
                string path = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
                path += "\\" + archivo;
                StreamWriter streamWriter = new StreamWriter(path, true);
                string[] arrayDatos = texto.Split("\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                foreach (string dato in arrayDatos)
                {
                    streamWriter.WriteLine(dato);
                }
                streamWriter.Close();
                return true;

            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
