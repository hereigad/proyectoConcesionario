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
        
        }
        public String Tfno {
            get {
                return this.tbTfno.Text;
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

        }
        public void todoReadOnly() {
            tbNombre.ReadOnly = true;
            tbTfno.ReadOnly = true;
            gbCategoria.Enabled = false;
        
        }
    }
}
