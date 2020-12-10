using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia
{
    class Vehiculos_VendidosDato
    {
        private string codigo;
        private string numBastidor;

        public Vehiculos_VendidosDato(string cod, string numB)
        {
            this.codigo = cod;
            this.numBastidor = numB;
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
