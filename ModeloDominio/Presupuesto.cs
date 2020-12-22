using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeloDominio
{
    public class Presupuesto
    {
        private DateTime fechaRealizacion;
        private string id;

        private EstadoPresupuesto estado;
        private Vehiculo[] vehiculos;
        private Cliente cliente;
        private Comercial comercial;
        private bool borrado;

        public Presupuesto(string id, DateTime fecha, EstadoPresupuesto estado, Comercial comercial, Cliente cliente, Vehiculo[] vehiculos, bool borrado)
        {
            this.fechaRealizacion = fecha;
            this.id = id;
            this.comercial = comercial;
            this.cliente = cliente;
            this.vehiculos = vehiculos;
            this.estado = estado;
            this.borrado = borrado;
        }

        public Cliente Cliente
        {
            get
            {
                return this.cliente;
            }
        }

        public bool Borrado
        {
            get
            {
                return this.borrado == true;
            }
            set
            {
                this.borrado = value;
            }
        }

        public Comercial Comercial
        {
            get
            {
                return this.comercial;
            }
        }

        public EstadoPresupuesto Estado
        {
            get
            {
                return this.estado;
            }
        }

        public Vehiculo[] Vehiculos
        {
            get
            {
                return this.vehiculos;
            }
        }

        public DateTime FechaRealizacion
        {
            get
            {
                return this.fechaRealizacion;
            }
        }

        public bool isAceptado()
        {
            return this.estado == EstadoPresupuesto.Aceptado;
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
