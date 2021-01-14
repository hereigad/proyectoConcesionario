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
        private List<string> nombre;

        public ExtraVehiculoDato(List<Extra> e, Vehiculo v)
        {
            this.numBastidor = v.NumBastidor;
            foreach(Extra i in e)
            {
                nombre.Add(i.Nombre);
            }
        }

        public string NumBastidor
        {
            get
            {
                return this.numBastidor;
            }
        }

        public List<string> Nombre
        {
            get
            {
                return this.nombre;
            }
        }
    }
}
