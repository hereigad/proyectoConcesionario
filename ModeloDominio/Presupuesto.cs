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

        public Presupuesto(string id, DateTime fecha, EstadoPresupuesto estado, Comercial comercial, Cliente cliente, Vehiculo[] vehiculos)
        {
            this.fechaRealizacion = fecha;
            this.id = id;
            this.comercial = comercial;
            this.cliente = cliente;
            this.vehiculos = vehiculos;
            this.estado = estado;
        }

        public Cliente Cliente
        {
            get
            {
                return this.cliente;
            }
        }

        public EstadoPresupuesto Estado
        {
            get
            {
                return this.estado;
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
