using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModeloDominio;

namespace Persistencia
{
    public class VehiculoDato
    {
        private string numBastidor;
        private string marca;
        private string modelo;
        private string potencia;
        private int pvp;

        public VehiculoDato(Vehiculo v)
        {
            this.numBastidor = v.NumBastidor;
            this.marca = v.Marca;
            this.modelo = v.Modelo;
            this.potencia = v.Potencia;
            this.pvp = v.Pvp;
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
