using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia
{
    class ClienteDatos
    {
        private string Dni;
        private string Nombre;
        private string Telefono;
        private string Categoria;
        private double Descuento;

        protected ClienteDatos(string dni,string nombre,string telefono,string categoria,double descuento) {
            this.Dni = dni;
            this.Nombre = nombre;
            this.Telefono = telefono;
            this.Categoria = categoria;
            this.Descuento = descuento;
        }
        public string DNI {
            get {
                return this.DNI;
            }
        }
    }
}
