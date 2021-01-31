using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeloDominio
{
    public class VehiculoNuevo : Vehiculo
    {
        private List<Extra> extras;

        public VehiculoNuevo(string numBastidor, string marca, string modelo, string potencia, double pvp, List<Extra> extras) : base(numBastidor, marca, modelo, potencia, pvp)
        {
            this.extras = extras;
            foreach(Extra e in extras)
            {
                base.Pvp = base.Pvp + e.Pvp;
            }
        }

        public List<Extra> Extras
        {
            get
            {
                return this.extras;
            }
        }
    }
}
