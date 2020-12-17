using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace Persistencia
{
    class TablaPresupuesto: KeyedCollection<string, PresupuestoDato>
    {
        protected override string GetKeyForItem(PresupuestoDato item)
        {
            return item.ID;
        }
    }
}
