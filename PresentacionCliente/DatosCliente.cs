using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentacionCliente
{
    public partial class DatosCliente : Form
    {
        public DatosCliente(String dni)
        {
            InitializeComponent();
            tbDNI.Text = dni;
        }

        private void gbCategoria_Enter(object sender, EventArgs e)
        {

        }
        public void todoReadOnly() {
            tbNombre.ReadOnly = true;
            tbTfno.ReadOnly = true;
            gbCategoria.Enabled = false;
        
        }
    }
}
