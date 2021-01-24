using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ModeloDominio;
using LogicaNegocioCliente;

namespace PresentacionCliente
{
    public partial class listado : Form
    {
        private Dictionary<Cliente, double> diccio;
        LogicaCliente log;
        public listado(LogicaNegocioCliente.LogicaCliente ln)
        {

            this.log = ln;
            InitializeComponent();
            diccio = ln.OrdenarCliente(LogicaNegocioCliente.ComparadoresCliente.ComparaDNI);
            BindingSource bd = new BindingSource();
            bd.DataSource = diccio;
            this.lbDNI.DisplayMember = "DNI";
            this.lbNombre.DataSource = bd;
            this.lbNombre.DisplayMember = "Nombre";
            this.lbImporte.DataSource = bd;
            this.lbImporte.DisplayMember = "Importe";

        }

        /// <summary>
        /// pre: 
        /// post: Cierra el formulario
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        private void btCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        /// <summary>
        /// pre: 
        /// post: Ordena la lista por DNI
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        private void btDNI_Click(object sender, EventArgs e)
        {
            diccio = log.OrdenarCliente(LogicaNegocioCliente.ComparadoresCliente.ComparaDNI);
            lbDNI.Refresh();
            lbImporte.Refresh();
            lbNombre.Refresh();
        }


        /// <summary>
        /// pre: 
        /// post: Ordena la lista por nombre
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        private void btNombre_Click(object sender, EventArgs e)
        {
            diccio = log.OrdenarCliente(LogicaNegocioCliente.ComparadoresCliente.ComparaNombre);
            lbDNI.Refresh();
            lbImporte.Refresh();
            lbNombre.Refresh();

        }

        /// <summary>
        /// pre: 
        /// post: Ordena la lista por importe
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        private void btImporte_Click(object sender, EventArgs e)
        {
            diccio = log.OrdenarCliente(LogicaNegocioCliente.ComparadoresCliente.ComparaImporte);
            lbDNI.Refresh();
            lbImporte.Refresh();
            lbNombre.Refresh();
        }
    }
}
