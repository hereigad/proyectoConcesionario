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
    public partial class UnoaUno : Form
    {
        private List<Cliente> lista;
        LogicaCliente log;
        public UnoaUno(LogicaCliente ln)
        {
            this.log = ln;
            this.lista = log.totalClientes();
            InitializeComponent();
        }

        private void bindingNavigatorMoveNextItem_Click(object sender, EventArgs e)
        {

        }
    }
}
