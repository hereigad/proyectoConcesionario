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
    public partial class PresupuestosEnEstado : Form
    {
        private LogicaNegocioPresupuesto.LogicaPresupuesto lnp;
        public PresupuestosEnEstado()
        {
            InitializeComponent();
        }

        public PresupuestosEnEstado(LogicaNegocioPresupuesto.LogicaPresupuesto lp): this()
        {
            this.lnp = lp;
            this.comboEstados.Items.Add(EstadoPresupuesto.Aceptado);
            this.comboEstados.Items.Add(EstadoPresupuesto.Desestimado);
            this.comboEstados.Items.Add(EstadoPresupuesto.Pendiente);
            this.comboEstados.SelectedItem = this.comboEstados.Items[0];
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            EstadoPresupuesto ep = (EstadoPresupuesto)this.comboEstados.SelectedItem;
            List<Presupuesto> presupuestos = this.lnp.obtenerPresupuestosEnEstado(ep);
            ListadoPresupuestos lp = new ListadoPresupuestos(presupuestos);
            lp.ShowDialog();
            this.Close();
        }
    }
}
