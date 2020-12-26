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
        private string numBastidor;
        private string nombre;

        public ExtraVehiculoDato(Extra e, Vehiculo v)
        {
            this.numBastidor = v.NumBastidor;
            this.nombre = e.Nombre;
        }

        public string NumBastidor
        {
            get
            {
                return this.numBastidor;
            }
        }
    }
}
