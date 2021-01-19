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
        public string DNI {
            get {
                return this.tbDNI.Text;
            }
            set {
                this.tbDNI.Text = value;
            }
        
        
        }


        public String Nombre {
            get {
                return this.tbNombre.Text;
            }
            set {
                this.tbNombre.Text = value;
            }
        
        }
        public String Tfno {
            get {
                return this.tbTfno.Text;
            }
            set {
                this.tbTfno.Text = value;
            }
        
        }
        public Categoria Categoria {
            get {
                if (this.rbA.Checked) {
                    return Categoria.A;
                }
                if (this.rbB.Checked) {
                    return Categoria.B;
                }
                if (this.rbC.Checked) {
                    return Categoria.C;
                }
                return Categoria.A;
            
            }
            set {
                Categoria c = (Categoria)value;
                if (c == Categoria.A) {
                    this.rbA.Enabled = true;
                    this.rbB.Enabled = false;
                    this.rbC.Enabled = false;
                
                }
                if (c == Categoria.B)
                {
                    this.rbA.Enabled = false;
                    this.rbB.Enabled = true;
                    this.rbC.Enabled = false;

                }
                if (c == Categoria.C)
                {
                    this.rbA.Enabled = false;
                    this.rbB.Enabled = false;
                    this.rbC.Enabled = true;

                }
            }

        }
        public void todoReadOnly() {
            tbNombre.ReadOnly = true;
            tbTfno.ReadOnly = true;
            gbCategoria.Enabled = false;
        
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

        public void botonesCambio() {
            this.btCancelar.Enabled = false;
            this.btCancelar.Visible = false;
            this.btAceptar.Location = new Point(240,422);
        
        }
    }
}
