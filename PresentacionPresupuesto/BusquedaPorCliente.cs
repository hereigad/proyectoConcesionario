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

namespace PresentacionPresupuesto
{
    public partial class BusquedaPorCliente : Form
    {
        private LogicaNegocioPresupuesto.LogicaPresupuesto lnp;
        private string dni;
        private List<Presupuesto> presupuestos;
        public BusquedaPorCliente()
        {
            InitializeComponent();
        }

        public BusquedaPorCliente(string d, LogicaNegocioPresupuesto.LogicaPresupuesto lp): this()
        {
            this.dni = d;
            this.lnp = lp;
            this.rellenarDatos();
        }

        /// <summary>
        /// pre: -
        /// post: rellena la lista de presupuestos con el identificador de los presupuestos del cliente
        /// </summary>
        private void rellenarDatos()
        {
            this.presupuestos = this.lnp.obtenerPresupuestosCliente(new Cliente(this.dni, "", "", Categoria.A));
            if(this.presupuestos.Count > 0)
            {
                foreach (Presupuesto p in this.presupuestos)
                {
                    this.listPresupuestos.Items.Add(p.ID);
                }
                this.listPresupuestos.SelectedIndex = 0;
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void listPresupuestos_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i = this.listPresupuestos.SelectedIndex;
            Presupuesto p = this.presupuestos.ElementAt(i);
            this.vistaPresupuesto.rellenarDatos(p);
        }
    }
}
