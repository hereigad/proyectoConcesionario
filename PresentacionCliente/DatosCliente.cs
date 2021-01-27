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
        /// <summary>
        /// pre: 
        /// post: obtiene o modifica el DNI del cliente
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public string DNI {
            get {
                return this.tbDNI.Text;
            }
            set {
                this.tbDNI.Text = value;
            }
        
        
        }

        /// <summary>
        /// pre: 
        /// post: devuelve o actualiza el nombre del cliente
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public String Nombre {
            get {
                return this.tbNombre.Text;
            }
            set {
                this.tbNombre.Text = value;
            }
        
        }

        /// <summary>
        /// pre: 
        /// post: obtiene o modifica el telefono del cliente
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public String Tfno {
            get {
                return this.tbTfno.Text;
            }
            set {
                this.tbTfno.Text = value;
            }
        
        }

        /// <summary>
        /// pre: 
        /// post: obtiene o modifica la categoria de un cliente
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
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

        /// <summary>
        /// pre: 
        /// post: pone todos los campos del formulario en modo solo lectura
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public void todoReadOnly() {
            tbNombre.ReadOnly = true;
            tbTfno.ReadOnly = true;
            rbA.Enabled = false;
            rbB.Enabled = false;
            rbC.Enabled = false;
        
        }

        /// <summary>
        /// pre:
        /// post: Cierra el formulario
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        private void btCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        /// <summary>
        /// pre: 
        /// post: coloca el DialogResult en OK
        /// 
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        private void btAceptar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        /// <summary>
        /// pre: 
        /// post: Cambia los botones para que seolo quede un unico boton central
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public void botonesCambio() {
            this.btCancelar.Enabled = false;
            this.btCancelar.Visible = false;
            this.btAceptar.Location = new Point(240,422);
        
        }
    }
}
