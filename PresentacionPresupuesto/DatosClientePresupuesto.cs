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
using PresentacionCliente;


namespace PresentacionPresupuesto
{
    public partial class DatosClientePresupuesto : Form
    {
        private LogicaNegocioPresupuesto.LogicaPresupuesto lnp;
        private List<Presupuesto> presupuestos;
        public DatosClientePresupuesto()
        {
            InitializeComponent();
        }

        public DatosClientePresupuesto(LogicaNegocioPresupuesto.LogicaPresupuesto lp): this()
        {
            this.lnp = lp;
            this.presupuestos = this.lnp.obtenerTodosPresupuestos();
            foreach(Presupuesto p in this.presupuestos)
            {
                this.comboPresupuestos.Items.Add(p.ID);
            }
            if(this.comboPresupuestos.Items.Count > 0)
            {
                this.comboPresupuestos.SelectedItem = this.comboPresupuestos.Items[0];
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            if(this.comboPresupuestos.SelectedItem != null)
            {
                Presupuesto p = this.presupuestos[this.comboPresupuestos.SelectedIndex];

                Cliente c = p.Cliente;
                DatosCliente dc = new DatosCliente(c.DNI);
                dc.Nombre = c.Nombre;
                dc.Categoria = c.Categoria;
                dc.Tfno = c.Telefono;
                dc.todoReadOnly();
                dc.ShowDialog();
            }
        }
    }
}
