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
    public partial class BusquedaPorVehiculo : Form
    {
        private string numBastidor;
        private LogicaNegocioPresupuesto.LogicaPresupuesto lnp;
        private List<Presupuesto> presupuestos;

        public BusquedaPorVehiculo()
        {
            InitializeComponent();
        }

        public BusquedaPorVehiculo(string numBastidor, LogicaNegocioPresupuesto.LogicaPresupuesto lp): this()
        {
            this.numBastidor = numBastidor;
            this.lnp = lp;
            this.rellenarDatos();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// pre: -
        /// post: rellena la lista de presupuestos con el identificador de los presupuestos del vehiculo
        /// </summary>
        private void rellenarDatos()
        {
            this.presupuestos = this.lnp.obtenerPresupuestosVehiculo(new Vehiculo(this.numBastidor, "", "", "", 0.0d));
            if(this.presupuestos.Count > 0)
            {
                foreach(Presupuesto p in this.presupuestos)
                {
                    this.listPresupuestos.Items.Add(p.ID);
                }
                this.listPresupuestos.SelectedIndex = 0;
            }
        }

        private void listPresupuestos_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i = this.listPresupuestos.SelectedIndex;
            Presupuesto p = this.presupuestos.ElementAt(i);
            this.vistaPresupuesto.rellenarDatos(p);
        }
    }
}
