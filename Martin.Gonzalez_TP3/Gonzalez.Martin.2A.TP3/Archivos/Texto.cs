using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Excepciones;

namespace Archivos
{
    public class Texto : IArchivos<string>
    {
        /// <summary>
        /// Guarda datos en un archivo con formato .txt
        /// </summary>
        /// <param name="archivo">Lugar donde se van a guardar los datos</param>
        /// <param name="datos">Información a guardar</param>
        /// <returns>Devuelve TRUE si lo pudo guardar, FALSE si no pudo</returns>
        public bool Guardar(string archivo, string datos)
        {
            if (!string.IsNullOrEmpty(archivo) && !string.IsNullOrEmpty(datos))
            {
                try
                {
                    StreamWriter escritor = new StreamWriter(archivo);
                    foreach (char c in datos)
                    {
                        escritor.Write(c);
                        if (c == '\n')
                        {
                            escritor.WriteLine();
                           
                        }
                    }
                    escritor.Close();
                    
                     return true;
                }
                catch (Exception e)
                {
                    throw new ArchivosException(e);
                    
                }
                
            }
            return false;

        }

        /// <summary>
        /// Lee datos en un archivo con formato .txt
        /// </summary>
        /// <param name="archivo">Ruta del archivo</param>
        /// <param name="datos">Información que se lee</param>
        /// <returns>Devuelve TRUE si lo pudo leer, FALSE si no pudo</returns>
        public bool Leer(string archivo, out string datos)
        {
            if (!string.IsNullOrEmpty(archivo))
            {
                try
                {
                    string retorno = "";
                    StreamReader lector = new StreamReader(archivo);
                    while (!lector.EndOfStream)
                    {
                        retorno += lector.ReadLine();
                    }
                    lector.Close();
                    datos = retorno;
                    return true;
                }
                catch (Exception e)
                {
                    throw new ArchivosException(e);
                }
            }
            datos = "";
            return false;
        }
    }
}
