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
        //private LogicaNegocioPresupuesto.LogicaPresupuesto lnp;
        private List<Presupuesto> presupuestos;
        public ListadoPresupuestos()
        {
            InitializeComponent();
        }

        public ListadoPresupuestos(List<Presupuesto> presupuestos): this()
        {
            /*this.lnp = lp;
            List<Presupuesto> presupuestos = this.lnp.obtenerTodosPresupuestos();*/
            this.presupuestos = presupuestos;
            List<object> listado = new List<object>();
            foreach(Presupuesto p in this.presupuestos)
            {
                object fila = new { p.ID, p.Cliente.DNI, p.Comercial.Codigo, p.FechaRealizacion, p.Estado};
                listado.Add(fila);
            }

            this.dataGridView.DataSource = listado;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
