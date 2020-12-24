﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace Persistencia
{
    class Tabla_VehiculoVendido: KeyedCollection<string, Vehiculos_VendidosDato>
    {
        protected override string GetKeyForItem(Vehiculos_VendidosDato item)
        {
            return item.NumeroBastidor;
        }
    }
}