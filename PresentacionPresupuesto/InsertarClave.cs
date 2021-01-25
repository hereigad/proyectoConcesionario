using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentacionPresupuesto
{
    public partial class InsertarClave : Form
    {
        private string marcador;
        public InsertarClave(string marca)
        {
            this.marcador = marca;
            this.Name = "Insertar " + this.marcador;
            this.myLabel.Text = this.marcador;
            InitializeComponent();
        }

        public string Clave
        {
            get
            {
                return this.txtClave.Text;
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
