using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia
{
    class Presupuesto_VehiculosDato
    {
        private string id;
        private string dni;
        private string codigo;
        private string numBastidor;

        public Presupuesto_VehiculosDato(string id, string dni, string cod, string numBastidor)
        {
            this.id = id;
            this.dni = dni;
            this.codigo = cod;
            this.numBastidor = numBastidor;
        }

        public string ID
        {
            get
            {
                return this.id;
            }
        }
    }
}
