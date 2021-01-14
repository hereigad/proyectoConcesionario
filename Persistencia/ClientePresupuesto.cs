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
        private bool borrado = false;
        public ClientePresupuesto(Cliente c,Presupuesto p) {
            this.dni = c.DNI;
            this.id = p.ID;
        }
        public string DNI
        {
            get
            {
                return this.dni;
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
