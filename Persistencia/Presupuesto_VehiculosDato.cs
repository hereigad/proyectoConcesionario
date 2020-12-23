using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModeloDominio;

namespace Persistencia
{
    class Presupuesto_VehiculosDato
    {
        private string id;
        private string dni;
        private string codigo;
        private string numBastidor;

        public Presupuesto_VehiculosDato(Presupuesto presupuesto, Vehiculo vehiculo)
        {
            this.id = presupuesto.ID;
            this.dni = presupuesto.Cliente.DNI;
            this.codigo = presupuesto.Comercial.Codigo;
            this.numBastidor = vehiculo.NumBastidor;
        }

        public string ID
        {
            get
            {
                return this.id;
            }
        }

        public string DNICliente { get { return this.dni; } }
        public string CodigoComercial { get { return this.codigo; } }
        public string NumBastidor { get { return this.numBastidor; } }
    }
}
