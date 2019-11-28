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
        private Correo correo;

        /// <summary>
        /// Constructor del formulario
        /// </summary>
        public FrmPpal()
        {
            InitializeComponent();
            this.correo = new Correo();
            PaqueteDao.ErrorBaseDeDatos += new EventHandler(this.ErrorBaseDeDatos);
        }

        /// <summary>
        /// Agrega un paquete al correo segun los valores informados por el usuario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string id;
            string direccion;
            if (this.mtxTrackingID.MaskFull)
            {
                id = this.mtxTrackingID.Text;
            }
            else
            {
                MessageBox.Show("El id no se ha completado", "INFORMACION INCOMPLETA");
                return;
            }
            direccion = this.txtDireccion.Text;
            if (!String.IsNullOrEmpty(id) && !String.IsNullOrEmpty(direccion))
            {
                Paquete paquete = new Paquete(direccion, id);
                paquete.InformaEstado += new Paquete.DelegadoEstado(this.paq_InformaEstado);
                try
                {
                    correo += paquete;
                }
                catch (TrackingIdRepetidoException exception)
                {
                    MessageBox.Show(exception.Message, "ID REPETIDO");
                }
                this.ActualizarEstados();
            }
            else
            {
                MessageBox.Show("Valores incompletos", "INFORMACION INCOMPLETA");
            }

        }

        /// <summary>
        /// Llama a el metodo mostrar informacion para publicar todos los paquetes del correo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMostrarTodos_Click(object sender, EventArgs e)
        {
            this.MostrarInformacion<List<Paquete>>((IMostrar<List<Paquete>>)correo);
        }

        /// <summary>
        /// Manejador del informe de estados de paquete
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void paq_InformaEstado(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                Paquete.DelegadoEstado d = new Paquete.DelegadoEstado(paq_InformaEstado);
                this.Invoke(d, new object[] { sender, e });
            }
            else
            {
                this.ActualizarEstados();
            }

        }

        /// <summary>
        /// Llama al metodo FinEntregas de correo al cerrar el formulario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmPpal_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.correo.FinEntregas();
        }

        /// <summary>
        /// Actualiza los list box para reflejar el estado de los paquetes de correo
        /// </summary>
        private void ActualizarEstados()
        {
            this.lstEstadoIngresado.Items.Clear();
            this.lstEstadoEnViaje.Items.Clear();
            this.lstEstadoEntregado.Items.Clear();
            foreach (Paquete paquete in this.correo.Paquetes)
            {
                switch (paquete.Estado)
                {
                    case Paquete.EEstado.Ingresado:
                        this.lstEstadoIngresado.Items.Add(paquete);
                        break;
                    case Paquete.EEstado.EnViaje:
                        this.lstEstadoEnViaje.Items.Add(paquete);
                        break;
                    case Paquete.EEstado.Entregado:
                        this.lstEstadoEntregado.Items.Add(paquete);
                        break;
                    default:
                        break;
                }
            }
        }

        /// <summary>
        /// Muestra la informacion del elemento y la agrega a un archivo de texto
        /// </summary>
        /// <typeparam name="T">Tipo del elemento</typeparam>
        /// <param name="elemento">Elemento</param>
        private void MostrarInformacion<T>(IMostrar<T> elemento)
        {
            if (!Object.Equals(elemento, null))
            {
                string datos = elemento.MostrarDatos(elemento);
                if (!String.IsNullOrEmpty(datos))
                {
                    this.rtbMostrar.Text = datos;
                    if (!datos.Guardar("salida.txt"))
                    {
                        MessageBox.Show("Error archivo de texto", "ERROR");
                    }
                }
            }
        }

        /// <summary>
        /// Llama al metodo MostrarInformacion para publicar la informacion del paquete seleccionado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mostrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.MostrarInformacion<Paquete>((IMostrar<Paquete>)lstEstadoEntregado.SelectedItem);
        }

        /// <summary>
        /// Muestra la informacion al producirse un error en la base de datos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ErrorBaseDeDatos(object sender, EventArgs e)
        {
            MessageBox.Show(sender.ToString(), "ERROR CON LA BASE DE DATOS");
        }
    }
}
