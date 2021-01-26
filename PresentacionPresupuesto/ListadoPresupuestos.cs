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
    public partial class ListadoPresupuestos : Form
    {
        private LogicaNegocioPresupuesto.LogicaPresupuesto lnp;
        public ListadoPresupuestos()
        {
            InitializeComponent();
        }

        public ListadoPresupuestos(LogicaNegocioPresupuesto.LogicaPresupuesto lp): this()
        {
            this.lnp = lp;
            List<Presupuesto> presupuestos = this.lnp.obtenerTodosPresupuestos();
            this.dataGridView.DataSource = presupuestos;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
