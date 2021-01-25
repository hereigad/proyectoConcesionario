using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentacionPresupuesto
{
    public partial class BusquedaPorCliente : Form
    {
        private LogicaNegocioPresupuesto.LogicaPresupuesto logicaP;
        private LogicaNegocioCliente.LogicaCliente logicaC;
        private string dni;
        public BusquedaPorCliente(LogicaNegocioPresupuesto.LogicaPresupuesto lp, LogicaNegocioCliente.LogicaCliente lc, string dni)
        {
            this.logicaP = lp;
            this.logicaC = lc;
            this.dni = dni;
            InitializeComponent();
        }
    }
}
