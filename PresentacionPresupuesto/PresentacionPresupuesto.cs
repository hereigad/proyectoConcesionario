using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LogicaNegocioCliente;
using LogicaNegocioPresupuesto;
using LogicaNegocioVehiculo;
using ModeloDominio;

namespace PresentacionPresupuesto
{
    public class PresentacionPresupuesto
    {
        private LogicaNegocioPresupuesto.LogicaPresupuesto logicaP;
        private LogicaNegocioCliente.LogicaCliente logicaC;
        private LogicaNegocioVehiculo.LogicaVehiculo logicaV;

        public PresentacionPresupuesto(LogicaPresupuesto lp, LogicaVehiculo lv, LogicaCliente lc)
        {
            this.logicaP = lp;
            this.logicaC = lc;
            this.logicaV = lv;
        }

        public void altaPresupuesto()
        {
            AltaPresupuesto ap = new AltaPresupuesto(this.logicaP);
            ap.ShowDialog();
        }

        public void busquedaPorVehiculo()
        {

        }

        public void recorridoUnoAUno()
        {

        }

        public void listarTodosLosPresupuestos()
        {

        }
    }
}
