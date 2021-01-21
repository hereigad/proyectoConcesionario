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
        public listado(LogicaNegocioCliente.LogicaCliente ln)
        {


            InitializeComponent();

            BindingSource bd = new BindingSource();
            bd.DataSource = ln.totalClientes();
            this.lbDNI.DataSource = bd;
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
    }
}
