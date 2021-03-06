﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModeloDominio;

namespace Persistencia
{
    public class PresupuestoDato
    {
        private string id;
        private string dni;
        private string codigo;
        private string estado;
        private DateTime fechaRealizacion;
        private String codComercial;
        private bool borrado = false;

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
            this.fechaRealizacion = presupuesto.FechaRealizacion;
            
           
        }

        public string ID
        {
            get
            {
                return this.id;
            }
        }

        public string DNI { get { return this.dni; } }
       
        public string Codigo { get { return this.codigo; } }
        public EstadoPresupuesto Estado
        {
            get
            {
                if(this.estado.Equals("Aceptado"))
                {
                    return EstadoPresupuesto.Aceptado;
                }
                else if(this.estado.Equals("Desestimado"))
                {
                    return EstadoPresupuesto.Desestimado;
                }
                else
                {
                    return EstadoPresupuesto.Pendiente;
                }
            }
        }

        public DateTime FechaRealizacion { get { return this.fechaRealizacion; } }
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

    
    public Presupuesto PasoAPresupuesto(Comercial c,Cliente cli, List<Vehiculo> vehiculos) {
        return new Presupuesto(this.ID,this.FechaRealizacion,this.Estado,c,cli, vehiculos);
    }
}
    }
