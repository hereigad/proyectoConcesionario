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
    public partial class PresupuestoUnoAUno : Form
    {
        private List<Presupuesto> presupuestos;
        private LogicaNegocioPresupuesto.LogicaPresupuesto lnp;
        public PresupuestoUnoAUno()
        {
            InitializeComponent();
        }

        public PresupuestoUnoAUno(LogicaNegocioPresupuesto.LogicaPresupuesto lp): this()
        {
            this.lnp = lp;
            this.presupuestos = this.lnp.obtenerTodosPresupuestos();
            this.bindingNavigator.BindingSource.DataSource = this.presupuestos;
            this.bindingNavigator.BindingSource.CurrentItemChanged += new EventHandler(this.navegar);
        }

        private void navegar(object sender, EventArgs e)
        {
            Presupuesto p = this.bindingNavigator.BindingSource.Current as Presupuesto;
            if(p != null)
            {
                this.vistaPresupuesto = new VistaPresupuesto(p);
            }
        }
    }
}
