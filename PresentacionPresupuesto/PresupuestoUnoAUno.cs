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
            this.bindingNavigator.BindingSource = new BindingSource();
            
            if(this.presupuestos.Count > 0)
            {
                foreach (Presupuesto p in this.presupuestos)
                {
                    this.bindingNavigator.BindingSource.Add(p);
                }
                this.vistaPresupuesto.rellenarDatos(this.presupuestos.ElementAt(0));
                this.bindingNavigator.BindingSource.CurrentItemChanged += this.navegar;
            }
        }

        /// <summary>
        /// pre: -
        /// post: metodo para rellenar los datos del los presupuesto al recorrer uno a uno los presupuestos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void navegar(object sender, EventArgs e)
        {
            if(this.bindingNavigator.BindingSource.Current != null)
            {
                int i = this.bindingNavigator.BindingSource.IndexOf(this.bindingNavigator.BindingSource.Current);
                this.vistaPresupuesto.rellenarDatos(this.presupuestos.ElementAt(i));
            }
        }
    }
}
