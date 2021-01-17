using ModeloDominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia
{
    public class ExtraVehiculoDato
    {
        private Tuple<string, string> numBastidor_nombre;

        public ExtraVehiculoDato(Extra e, Vehiculo v)
        {
            this.numBastidor_nombre = new Tuple<string, string>(v.NumBastidor, e.Nombre);
        }

        public Tuple<string, string> NumBastidor_Nombre {
            get {
                return this.numBastidor_nombre;
            }
        }
    }
}
