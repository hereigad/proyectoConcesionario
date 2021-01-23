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

        private void btCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btDNI_Click(object sender, EventArgs e)
        {
            diccio = log.OrdenarCliente(LogicaNegocioCliente.ComparadoresCliente.ComparaDNI);
            lbDNI.Refresh();
            lbImporte.Refresh();
            lbNombre.Refresh();
        }

        private void btNombre_Click(object sender, EventArgs e)
        {
            diccio = log.OrdenarCliente(LogicaNegocioCliente.ComparadoresCliente.ComparaNombre);
            lbDNI.Refresh();
            lbImporte.Refresh();
            lbNombre.Refresh();

        }

        private void btImporte_Click(object sender, EventArgs e)
        {
            diccio = log.OrdenarCliente(LogicaNegocioCliente.ComparadoresCliente.ComparaImporte);
            lbDNI.Refresh();
            lbImporte.Refresh();
            lbNombre.Refresh();
        }
    }
}
