using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia
{
    public class TablaExtraVehiculo : KeyedCollection<Tuple<string, string>, ExtraVehiculoDato>
    {
        protected override Tuple<string, string> GetKeyForItem(ExtraVehiculoDato item)
        {
            return item.NumBastidor_Nombre;
        }
    }
}
