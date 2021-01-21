using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicaNegocioPresupuesto;
using LogicaNegocioCliente;
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
            // crear un  presupuesto nuevo desde la interfaz y añadirlo a la base de datos
        }
    }
}
