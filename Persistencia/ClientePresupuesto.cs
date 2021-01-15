using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModeloDominio;

namespace Persistencia
{
    public class ClientePresupuesto
    {
        private String dni;
        private String id;
        private Tuple<String, String> clave;
        private bool borrado = false;
        public ClientePresupuesto(Cliente c,Presupuesto p) {
            this.dni = c.DNI;
            this.id = p.ID;
            this.clave= new Tuple<String, String>(this.dni,this.id);
        }
        public string DNI
        {
            get
            {
                return this.dni;
            }
        }
        public Tuple<String, String> Clave
        {
            get
            {
                return this.clave;
            }
        }
        public bool Borrado
        {
            get
            {
                return this.borrado;
            }
            set {
                this.borrado = value;
            }
        }

        public string ID
        {
            get
            {
                return this.id;
            }
        }


    }
}
