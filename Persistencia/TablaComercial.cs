using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace Persistencia
{
    class TablaComercial: KeyedCollection<string, ComercialDato>
    {
        protected override string GetKeyForItem(ComercialDato item)
        {
            return item.Codigo;
        }
    }
}
