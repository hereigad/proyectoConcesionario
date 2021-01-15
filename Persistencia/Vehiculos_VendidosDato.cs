using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModeloDominio;

namespace Persistencia
{
    public class Vehiculos_VendidosDato
    {
        private string codigo;
        private string numBastidor;
        private Tuple<string, string> clave;

        public Vehiculos_VendidosDato(Comercial comercial, Vehiculo vehiculo)
        {
            this.codigo = comercial.Codigo;
            this.numBastidor = vehiculo.NumBastidor;
            this.clave = new Tuple<string, string>(comercial.Codigo, vehiculo.NumBastidor);
        }

        public Tuple<string, string> Clave { get { return this.clave; } }

        public string NumeroBastidor
        {
            get
            {
                return this.numBastidor;
            }
        }

        public string Codigo { get { return this.codigo; } }
    }
}
