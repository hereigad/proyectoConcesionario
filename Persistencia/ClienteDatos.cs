using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModeloDominio;

namespace Persistencia
{
    public class ClienteDatos
    {
        private string Dni;
        private string Nombre;
        private string Telefono;
        private int Categoria;
        private bool borrado = false;

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

        public string NombreCliente { get { return this.Nombre; } }
        public string TlfCliente { get { return this.Telefono; } }
        public int CategoriaCliente { get { return this.Categoria; } }
        public bool Borrado { get { return this.borrado; }
            set { this.borrado = value; }
        }
        public Cliente PasoACliente() {
            if (this.Categoria == 5) { 
                return new Cliente(this.DNI, this.Nombre, this.Telefono,ModeloDominio.Categoria.A ); }
            if (this.Categoria == 10)
            {
                return new Cliente(this.DNI, this.Nombre, this.Telefono, ModeloDominio.Categoria.B);
            }
            if (this.Categoria == 15)
            {
                return new Cliente(this.DNI, this.Nombre, this.Telefono, ModeloDominio.Categoria.C);
            }
            return null;
        }
    }
}
