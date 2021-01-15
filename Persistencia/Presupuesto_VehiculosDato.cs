using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModeloDominio;

namespace Persistencia
{
    public class Presupuesto_VehiculosDato
    {
        //private string id;
        private string dni;
        private string codigo;
        private string numBastidor;
        private Tuple<string, string> clave;

        public Presupuesto_VehiculosDato(Presupuesto presupuesto, Vehiculo vehiculo)
        {
            this.dni = presupuesto.Cliente.DNI;
            this.codigo = presupuesto.Comercial.Codigo;
            this.numBastidor = vehiculo.NumBastidor;
            this.clave = new Tuple<string, string>(presupuesto.ID, vehiculo.NumBastidor);
        }

        public Tuple<string, string> Clave
        {
            get
            {
                return this.clave;
            }
        }

        public string DNICliente { get { return this.dni; } }
        public string CodigoComercial { get { return this.codigo; } }
        public string NumBastidor { get { return this.numBastidor; } }
    }
}
