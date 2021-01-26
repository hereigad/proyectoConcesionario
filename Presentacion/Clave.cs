using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class Clave : Form
    {
        private String clave;
        public Clave(String cla)
        {
            this.clave = cla;
            InitializeComponent();
            this.lbClave.Text = cla;
        }

        private void btCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btAceptar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            
        }
        public String ClaveO{
            get {
                return this.clave;
            }
        }
    }
}
