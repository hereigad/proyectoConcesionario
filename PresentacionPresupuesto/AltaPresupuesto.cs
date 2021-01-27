using System;
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
        private Comercial comercial;


        public AltaPresupuesto()
        {
            InitializeComponent();
        }

        public AltaPresupuesto(LogicaPresupuesto l, LogicaCliente lc, LogicaVehiculo lv, Comercial com): this()
        {
            this.lnp = l;
            this.lnc = lc;
            this.lnv = lv;
            this.comercial = com;
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
            if(this.listDisponibles.Items.Count > 0 && this.listDisponibles.SelectedItem != null)
            {
                this.listPresupuesto.Items.Add(this.listDisponibles.SelectedItem);
                this.listDisponibles.Items.Remove(this.listDisponibles.SelectedItem);
            }
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            if(this.listPresupuesto.Items.Count > 0 && this.listPresupuesto.SelectedItem != null)
            {
                this.listDisponibles.Items.Add(this.listPresupuesto.SelectedItem);
                this.listPresupuesto.Items.Remove(this.listPresupuesto.SelectedItem);
            }
        }

        private void btnAlta_Click(object sender, EventArgs e)
        {
            string dniCliente = this.comboDNI.SelectedItem as string;
            if(dniCliente == null)
            {
                MessageBox.Show("Elige un DNI de cliente de la lista");
            }
            else
            {
                List<string> numBastidores = new List<string>();
                foreach (string s in this.listPresupuesto.Items)
                {
                    numBastidores.Add(s);
                }

                List<Vehiculo> vehiculos = new List<Vehiculo>();
                foreach (Vehiculo v in this.vehiculosDisponibles)
                {
                    if (numBastidores.Contains(v.NumBastidor))
                    {
                        vehiculos.Add(v);
                    }
                }

                Cliente c = this.lnc.selCliente(new Cliente(dniCliente, "", "", Categoria.A));

                Random r = new Random(4253);
                string[] letra = { "A", "B", "C", "D", "E", "F", "G", "H" };
                int num1 = r.Next(0, 100);
                int num2 = r.Next(0, 50);
                string l = letra[r.Next(0, letra.Length)];
                string l1 = letra[r.Next(0, letra.Length)];
                // this.comercial.Codigo+"-"+c.DNI+"-"+vehiculos.Count()
                string id = num1 + l + num2 + l1;


                Presupuesto p = new Presupuesto(id, DateTime.Now, EstadoPresupuesto.Pendiente, this.comercial, c, vehiculos);
                this.lnp.altaPresupuesto(p);
                this.Close();
            }
        }
    }
}
