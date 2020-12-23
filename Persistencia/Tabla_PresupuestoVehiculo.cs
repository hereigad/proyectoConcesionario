using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace Persistencia
{
    class Tabla_PresupuestoVehiculo: KeyedCollection<string, Presupuesto_VehiculosDato>
    {
        protected override string GetKeyForItem(Presupuesto_VehiculosDato item)
        {
            return item.ID;
        }
    }
}
