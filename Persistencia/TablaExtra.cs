using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia
{
    public class TablaExtra : KeyedCollection<string, ExtraDato>
    {
        protected override string GetKeyForItem(ExtraDato item)
        {
            return item.Nombre;
        }
    }
}
