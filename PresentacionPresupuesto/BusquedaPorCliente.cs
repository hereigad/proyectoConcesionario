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
        private LogicaNegocioPresupuesto.LogicaPresupuesto logicaP;
        private LogicaNegocioCliente.LogicaCliente logicaC;
        private string dni;
        private List<Presupuesto> presupuestos;
        public BusquedaPorCliente()
        {
            InitializeComponent();
        }

        public BusquedaPorCliente(LogicaNegocioPresupuesto.LogicaPresupuesto lp, LogicaNegocioCliente.LogicaCliente lc, string dni): this()
        {
            this.logicaP = lp;
            this.logicaC = lc;
            this.dni = dni;
        }

        private void devolverPresupuestos()
        {
            Cliente cli = this.logicaC.selCliente(new Cliente(this.dni, "", "", Categoria.A));
            this.presupuestos = this.logicaP.obtenerPresupuestosCliente(cli);
        }
    }
}
