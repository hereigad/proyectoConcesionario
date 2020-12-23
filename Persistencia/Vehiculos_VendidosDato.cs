using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModeloDominio;

namespace Persistencia
{
    class Vehiculos_VendidosDato
    {
        private string codigo;
        private string numBastidor;

        public Vehiculos_VendidosDato(Comercial comercial, Vehiculo vehiculo)
        {
            this.codigo = comercial.Codigo;
            this.numBastidor = vehiculo.NumBastidor;
        }

        public string NumeroBastidor
        {
            get
            {
                return this.numBastidor;
            }
        }
    }
}
