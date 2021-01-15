using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace Persistencia
{
    public class Tabla_PresupuestoVehiculo: KeyedCollection<Tuple<string, string>, Presupuesto_VehiculosDato>
    {
        protected override Tuple<string, string> GetKeyForItem(Presupuesto_VehiculosDato item)
        {
            return item.Clave;
        }
    }
}
