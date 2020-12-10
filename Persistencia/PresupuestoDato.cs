using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia
{
    class PresupuestoDato
    {
        private string id;
        private string dni;
        private string codigo;
        private string estado;
        private string fecahRealizacion;

        public PresupuestoDato(string id, string dni, string cod, string estado, string fecha)
        {
            this.id = id;
            this.dni = dni;
            this.codigo = cod;
            this.estado = estado;
            this.fecahRealizacion = fecha;
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
