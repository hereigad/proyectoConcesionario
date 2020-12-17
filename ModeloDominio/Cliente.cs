using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeloDominio
{
    public class Cliente
    {
        private string Dni;
        private string nombre;
        private string telefono;
        private Categoria categoria;

        public Cliente(string dni, string nom,string tlf,Categoria cat) {
            this.Dni = dni;
            this.nombre = nom;
            this.telefono = tlf;
            this.categoria = cat;
        }
        public string DNI
        {
            get
            {
                return this.DNI;
            }
        }
        public string Nombre
        {
            get
            {
                return this.nombre;
            }
        }
        public string Telefono
        {
            get
            {
                return this.telefono;
            }
            set {
                this.telefono = value;
                }
        }
        public Categoria Categoria
        {
            get
            {
                return this.categoria;
            }
            set
            {
                this.categoria = value;
            }
        }
    }
}
