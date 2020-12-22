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

        public Comercial(string codigo, string nombre, string apellido)
        {
            this.codigo = codigo;
            this.nombre = nombre;
            this.apellido = apellido;
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
    }
}
