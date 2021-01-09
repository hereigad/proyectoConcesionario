using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia
{
    public class ColCliente:  KeyedCollection<string,ClienteDatos>
    {
        protected override string GetKeyForItem(ClienteDatos c) {
            return c.DNI;
        }
    }
}
