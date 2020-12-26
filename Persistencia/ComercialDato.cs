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
        private bool borrado = false;
        private List<string> vehiculos;

        public ComercialDato(Comercial c)
        {
            this.codigo = c.Codigo;
            this.nombre = c.Nombre;
            this.apellido = c.Apellido;
            this.vehiculos = c.Vehiculos;
        }

        public string Codigo
        {
            get
            {
                return this.codigo;
            }
        }

        public string Nombre { get { return this.nombre; } }
        public string Apellido { get { return this.apellido; } }
        public List<string> Vehiculos { get { return this.vehiculos; } }
        public bool Borrado
        {
            get { return this.borrado; }
            set { this.borrado = value; }
        }
        public Comercial PasoAComercial() {
            return new Comercial(this.Codigo, this.Nombre, this.Apellido, this.Vehiculos);
        }
    }
}
