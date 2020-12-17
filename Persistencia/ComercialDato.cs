using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia
{
    class ComercialDato
    {
        private string codigo;
        private string nombre;
        private string apellido;

        public ComercialDato(string c, string n, string a)
        {
            this.codigo = c;
            this.nombre = n;
            this.apellido = a;
        }

        public string Codigo
        {
            get
            {
                return this.codigo;
            }
        }
    }
}
