using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;
using System.Xml;
using Excepciones;

namespace Archivos
{
    public class Xml<T> : IArchivos<T>
    {
        /// <summary>
        /// Serializa los datos en un archivo xml
        /// </summary>
        /// <param name="archivo">Lugar donde se van a guardar los datos</param>
        /// <param name="datos">Información a serializar</param>
        /// <returns>Devuelve TRUE si lo pudo guardar, FALSE si no pudo</returns>
        public bool Guardar(string archivo, T datos)
        {
            if (!string.IsNullOrEmpty(archivo) && !Object.Equals(datos, null))
            {
                
                try
                {
                    XmlSerializer serializador = new XmlSerializer(typeof(T));
                    XmlTextWriter escritor = new XmlTextWriter(archivo, Encoding.UTF8);
                    serializador.Serialize(escritor, datos);
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
        /// Deserializa los datos en un archivo xml
        /// </summary>
        /// <param name="archivo">Ruta del archivo</param>
        /// <param name="datos">Información a deserializar</param>
        /// <returns>Devuelve TRUE si lo pudo leer, FALSE si no pudo</returns>
        public bool Leer(string archivo, out T datos)
        {
            datos = default(T);
            if (!string.IsNullOrEmpty(archivo))
            {
                try
                {
                    XmlSerializer desSerializador = new XmlSerializer(typeof(T));
                    XmlTextReader lector = new XmlTextReader(archivo);
                    datos = (T)desSerializador.Deserialize(lector);
                    lector.Close();
                    return true;
                }
                catch(Exception e)
                {
                    throw new ArchivosException(e);
                }
            }
            return false;
        }
    }
}
