using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicaNegocioPresupuesto;

namespace PresentacionPresupuesto
{
    public class PresentacionPresupuesto
    {
        private LogicaNegocioPresupuesto.LogicaPresupuesto logica;

        public PresentacionPresupuesto(LogicaPresupuesto l)
        {
            this.logica = l;
        }
    }
}
