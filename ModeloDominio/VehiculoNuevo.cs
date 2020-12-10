using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeloDominio
{
    class VehiculoNuevo : Vehiculo
    {
        private List<Extra> extras;

        public VehiculoNuevo(string numBastidor, string marca, string modelo, string potencia, int pvp, List<Extra> extras) : base(numBastidor, marca, modelo, potencia, pvp)
        {
            this.extras = extras;
        }
    }
}
