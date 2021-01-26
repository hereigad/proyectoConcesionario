﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using ModeloDominio;
using LogicaNegocioPresupuesto;
using LogicaNegocioCliente;
using LogicaNegocioVehiculo;

namespace PresentacionPresupuesto
{
    public partial class AltaPresupuesto : Form
    {
        private List<Vehiculo> vehiculosDisponibles;
        private List<Cliente> clientes;

        private LogicaCliente lnc;
        private LogicaPresupuesto lnp;
        private LogicaVehiculo lnv;


        public AltaPresupuesto()
        {
            InitializeComponent();
        }

        public AltaPresupuesto(LogicaPresupuesto l, LogicaCliente lc, LogicaVehiculo lv): this()
        {
            this.lnp = l;
            this.lnc = lc;
            this.lnv = lv;
            this.rellenarComboDNI();
            this.rellenarListVehiculosDisponibles();
        }

        private void rellenarComboDNI()
        {
            this.clientes = this.lnc.totalClientes();
            foreach(Cliente c in this.clientes)
            {
                this.comboDNI.Items.Add(c.DNI);
            }
        }

        private void rellenarListVehiculosDisponibles()
        {
            this.vehiculosDisponibles = this.lnv.obtenerTodosVehiculos();

            /*///prueba
            for(int i=0; i<10; i++)
            {
                Random r = new Random();
                int j = r.Next(0, 50);
                Vehiculo v = new Vehiculo("v" + j, "m" + j, "modelo" + j, "pot", j);
                this.lnv.altaVehiculo(v);
                this.vehiculosDisponibles.Add(v);
            }
            ///prueba*/

            foreach(Vehiculo v in this.vehiculosDisponibles)
            {
                this.listDisponibles.Items.Add(v.NumBastidor);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAnadir_Click(object sender, EventArgs e)
        {
            this.listPresupuesto.Items.Add(this.listDisponibles.SelectedItem);
            this.listDisponibles.Items.Remove(this.listDisponibles.SelectedItem);
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            this.listDisponibles.Items.Add(this.listPresupuesto.SelectedItem);
            this.listPresupuesto.Items.Remove(this.listPresupuesto.SelectedItem);
        }

        private void btnAlta_Click(object sender, EventArgs e)
        {
            string dniCliente = this.comboDNI.SelectedItem as string;
            List<string> numBastidores = new List<string>();
            foreach(string s in this.listPresupuesto.Items)
            {
                numBastidores.Add(s);
            }

            List<Vehiculo> vehiculos = new List<Vehiculo>();
            foreach(Vehiculo v in this.vehiculosDisponibles)
            {
                if (numBastidores.Contains(v.NumBastidor))
                {
                    vehiculos.Add(v);
                }
            }

            Cliente c = this.lnc.selCliente(new Cliente(dniCliente, "", "", Categoria.A));

            Presupuesto p = new Presupuesto(this.lnp.Comercial.Codigo+"-"+c.DNI+"-"+vehiculos.Count(), DateTime.Now, EstadoPresupuesto.Pendiente, this.lnp.Comercial, c, vehiculos);
            this.lnp.altaPresupuesto(p);
            this.Close();
        }
    }
}
