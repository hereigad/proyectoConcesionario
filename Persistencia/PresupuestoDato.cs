using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModeloDominio;

namespace Persistencia
{
    class PresupuestoDato
    {
        private string id;
        private string dni;
        private string codigo;
        private string estado;
        private string fecahRealizacion;
        private bool borrado;

        private Presupuesto pr;

        public PresupuestoDato(Presupuesto presupuesto)
        {
            this.id = presupuesto.ID;
            this.dni = presupuesto.Cliente.DNI;
            this.codigo = presupuesto.Comercial.Codigo;
            if(presupuesto.Estado == EstadoPresupuesto.Aceptado)
            {
                this.estado = "Aceptado";
            }
            else if(presupuesto.Estado == EstadoPresupuesto.Desestimado)
            {
                this.estado = "Desestimado";
            }
            else if(presupuesto.Estado == EstadoPresupuesto.Pendiente)
            {
                this.estado = "Pendiente";
            }
            this.fecahRealizacion = presupuesto.FechaRealizacion.ToString();
            this.borrado = presupuesto.Borrado;
            this.pr = presupuesto;
        }

        public string ID
        {
            get
            {
                return this.id;
            }
        }

        public Presupuesto Presupuesto { get { return this.pr; } }
    }
}
