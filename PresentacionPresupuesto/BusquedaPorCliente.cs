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
using PresentacionPresupuesto;

namespace PresentacionPresupuesto
{
    public partial class BusquedaPorCliente : Form
    {
        private LogicaNegocioPresupuesto.LogicaPresupuesto logicaP;
        private string dni;
        private List<Presupuesto> presupuestos;
        public BusquedaPorCliente()
        {
            InitializeComponent();
        }

        public BusquedaPorCliente(LogicaNegocioPresupuesto.LogicaPresupuesto lp, string dni): this()
        {
            this.logicaP = lp;
            this.dni = dni;
            this.devolverPresupuestos();
        }

        private void devolverPresupuestos()
        {
            this.presupuestos = this.logicaP.obtenerPresupuestosCliente(new Cliente(this.dni, "", "", Categoria.A));
            foreach(Presupuesto p in this.presupuestos)
            {
                this.listPresupuestos.Items.Add(p.ID);
            }
        }

        private void listPresupuestos_SelectedIndexChanged(object sender, EventArgs e)
        {
            Presupuesto p = this.presupuestos.ElementAt(this.listPresupuestos.SelectedIndex);
            this.vistaPresupuesto1 = new VistaPresupuesto(p);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
