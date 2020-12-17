using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModeloDominio;

namespace Persistencia
{
    class ClienteDatos
    {
        private string Dni;
        private string Nombre;
        private string Telefono;
        private int Categoria;


        public ClienteDatos(Cliente c) {
            this.Dni = c.DNI;
            this.Nombre = c.Nombre;
            this.Telefono = c.Telefono;
            this.Categoria = (int)c.Categoria;
        }
        public string DNI {
            get {
                return this.DNI;
            }
        }
    }
}
