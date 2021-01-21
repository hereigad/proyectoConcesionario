using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ModeloDominio;
using LogicaNegocioPresupuesto;
using LogicaNegocioCliente;
using LogicaNegocioVehiculo;

namespace PresentacionPresupuesto
{
    public class PresentacionPresupuesto
    {
        private Comercial comercial;
        private LogicaPresupuesto serviciosPresupuesto;

        public PresentacionPresupuesto(Comercial com)
        {
            this.comercial = com;
            this.serviciosPresupuesto = new LogicaPresupuesto(this.comercial);
        }

        public void addPresupuesto()
        {

        }
    }
}
