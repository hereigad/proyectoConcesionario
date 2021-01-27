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
           
            this.bnCod.BindingSource = new BindingSource();
            this.bnCod.BindingSource.CurrentItemChanged+= bindingNavigatorMoveNextItem_Click;
            if (this.lista.Count > 0)
            {
                foreach (Cliente c in this.lista)
                {
                    this.bnCod.BindingSource.Add(c);
                }
                this.rellenar(this.lista.ElementAt(0));
                
            }
        }

        private void bindingNavigatorMoveNextItem_Click(object sender, EventArgs e)
        {
            int i = this.bnCod.BindingSource.IndexOf(this.bnCod.BindingSource.Current);
            Cliente c = this.lista.ElementAt(i);

            this.tbDNI.Text = c.DNI;
            this.tbApellidos.Text = c.Nombre.Substring(0, c.Nombre.IndexOf(','));
            this.tbNombre.Text = c.Nombre.Remove(0, c.Nombre.IndexOf(',') + 1);
            this.tbImporte.Text = "" + LogicaCliente.obtieneImporte(c);
        }
        private void rellenar(Cliente c) {
            this.tbDNI.Text =c.DNI;
            this.tbApellidos.Text = c.Nombre.Substring(0, c.Nombre.IndexOf(','));
            this.tbNombre.Text = c.Nombre.Remove(0,c.Nombre.IndexOf(',')+1);
            this.tbImporte.Text = ""+LogicaCliente.obtieneImporte(c);
        
        }

        private void bindingNavigatorMoveLastItem_Click(object sender, EventArgs e)
        {
           
        }
    }
}
