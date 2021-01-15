using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia
{
    public class Tabla_ClientePresupuesto : KeyedCollection<Tuple<String, String>, ClientePresupuesto>
    {
        protected override Tuple<String, String> GetKeyForItem(ClientePresupuesto item)
        {
            return item.Clave;
        }
    }
}
