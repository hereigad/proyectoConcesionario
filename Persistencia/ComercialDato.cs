using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModeloDominio;

namespace Persistencia
{
    class ComercialDato
    {
        private string codigo;
        private string nombre;
        private string apellido;

        public ComercialDato(Comercial c)
        {
            this.codigo = c.Codigo;
            this.nombre = c.Nombre;
            this.apellido = c.Apellido;
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
