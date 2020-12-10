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

        public ComercialDato(string cod, string nom, string appel)
        {
            this.codigo = cod;
            this.nombre = nom;
            this.apellido = appel;
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
