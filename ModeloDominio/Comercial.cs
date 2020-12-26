using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeloDominio
{
    public class Comercial
    {
        private string codigo;
        private string nombre;
        private string apellido;
        private List<string> vehiculos;

        public Comercial(string codigo, string nombre, string apellido, List<string> v)
        {
            this.codigo = codigo;
            this.nombre = nombre;
            this.apellido = apellido;
            this.vehiculos = v;
        }

        public string Codigo
        {
            get
            {
                return this.codigo;
            }
        }

        public String Nombre
        {
            get
            {
                return this.nombre;
            }
        }

        public string Apellido
        {
            get
            {
                return this.apellido;
            }
        }

        public List<string> Vehiculos { get { return this.vehiculos; } }
    }
}
