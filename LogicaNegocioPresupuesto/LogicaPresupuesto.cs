﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PersistenciaPresupuesto;
using ModeloDominio;

namespace LogicaNegocioPresupuesto
{
    public class LogicaPresupuesto
    {
        /*private Cliente cliente;
        private List<Vehiculo> vehiculos;
        private DateTime fechaRealizacion;*/
        private Comercial comercial;
        //private EstadoPresupuesto estado;

        public LogicaPresupuesto(Comercial com)
        {
            this.comercial = com;
        }

        public Comercial Comercial { get { return this.comercial; } }

        /// <summary>
        /// pre: presupuesto p distinto de null
        /// post: da de alta un nuevo presupuesto
        /// </summary>
        /// <param name="p"></param>
        public void altaPresupuesto(Presupuesto p)
        {
            Presupuesto p1 = new Presupuesto(p.ID, p.FechaRealizacion, p.Estado, p.Comercial, p.Cliente, p.Vehiculos);
            PersistenciaPresupuesto.PersistenciaPresupuesto.anadirPresupuesto(p1);
        }

        /// <summary>
        /// pre: p distinto de null; basta solo con la clave del presupuesto
        /// post: devuelve el cliente del presupuesto dado o null si no existe el presupuesto
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public Cliente obtenerCliente(Presupuesto p)
        {
            Cliente cli = null;
            if (PersistenciaPresupuesto.PersistenciaPresupuesto.existePresupuesto(p))
            {
                cli = PersistenciaPresupuesto.PersistenciaPresupuesto.seleccionarClientePresupuesto(p);
            }
            return cli;
        }

        /// <summary>
        /// pre: p distinto de null y basta solo con la clave; el presupuesto p existe en la base de datos
        /// post: devuelve el estado del presupuesto p
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public EstadoPresupuesto estadoDelPresupuesto(Presupuesto p)
        {
            return PersistenciaPresupuesto.PersistenciaPresupuesto.seleccionarPresupuesto(p).Estado;
        }

        /// <summary>
        /// pre: p distinto de null y basta solo con la clave; el presupuesto p existe en la base de datos
        /// post: devuelve TRUE si el presupuesto p es aceptado; FALSE en caso contrario
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public bool presupuestoAceptado(Presupuesto p)
        {
            return PersistenciaPresupuesto.PersistenciaPresupuesto.seleccionarPresupuesto(p).Estado == EstadoPresupuesto.Aceptado;
        }

        /// <summary>
        /// pre: p distinto de null y viene solo la clave
        /// post: devuelve los datos del presupuesto p con el id dado o null si no existe
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public Presupuesto obtenerPresupuesto(Presupuesto p)
        {
            Presupuesto presupuesto = null;
            if (PersistenciaPresupuesto.PersistenciaPresupuesto.existePresupuesto(p))
            {
                presupuesto = PersistenciaPresupuesto.PersistenciaPresupuesto.seleccionarPresupuesto(p);
            }
            return presupuesto;
        }

        /// <summary>
        /// pre: c distinto de null; viene solo la clave, el DNI; el cliente existe en la base de datos
        /// post: devuelve el listado de presupuestos del cliente dado
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public List<Presupuesto> obtenerPresupuestosCliente(Cliente c)
        {
            List<Presupuesto> lista = new List<Presupuesto>();
            lista = PersistenciaPresupuesto.PersistenciaPresupuesto.seleccionarPresupuestosCliente(c);
            return lista;
        }

        /// <summary>
        /// pre: v distinto de null y existente en la base de datos; viene solo la clave del vehiculo (el numero de bastidor)
        /// post: devuelve una colección de presupuestos del vehiculo pedido
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        public List<Presupuesto> obtenerPresupuestosVehiculo(Vehiculo v)
        {
            List<Presupuesto> lista = new List<Presupuesto>();
            lista = PersistenciaPresupuesto.PersistenciaPresupuesto.seleccionarPresupuestosVehiculo(v);
            return lista;
        }

        /// <summary>
        /// pre: -
        /// post: devuelve una colección de presupuestos con el estado dado
        /// </summary>
        /// <param name="estado"></param>
        /// <returns></returns>
        public List<Presupuesto> obtenerPresupuestosEnEstado(EstadoPresupuesto estado)
        {
            List<Presupuesto> lista = new List<Presupuesto>();
            List<Presupuesto> list = PersistenciaPresupuesto.PersistenciaPresupuesto.seleccionarTODOS_Presupuestos();
            foreach (Presupuesto p in list)
            {
                if (p.Estado == estado)
                {
                    lista.Add(p);
                }
            }
            return lista;
        }
    }
}
