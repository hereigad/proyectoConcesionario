using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicaNegocioCliente;
using LogicaNegocioPresupuesto;
using LogicaNegocioVehiculo;
using ModeloDominio;

namespace PresentacionPresupuesto
{
    public class PresentacionPresupuesto
    {
        private LogicaNegocioPresupuesto.LogicaPresupuesto logica;

        public PresentacionPresupuesto(LogicaPresupuesto l)
        {
            this.logica = l;
        }

        public void addPresupuesto()
        {
            AltaPresupuesto ap = new AltaPresupuesto(this.logica);
            ap.ShowDialog();
        }
    }
}
