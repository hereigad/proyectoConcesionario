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
using LogicaNegocioVehiculo;

namespace PresentacionVehiculo {
    public partial class BusquedaVehiculo : Form {
        private LogicaVehiculo lv;
        public BusquedaVehiculo(LogicaVehiculo lv, string numBastidor) {
            InitializeComponent();
            this.lv = lv;
            Vehiculo v = lv.obtenerVehiculo(numBastidor);
            this.textBox1.Text = v.NumBastidor;
            this.textBox2.Text = v.Marca;
            this.textBox3.Text = v.Modelo;
            this.textBox4.Text = v.Potencia;
            this.textBox5.Text = v.Pvp.ToString();
            if(v.GetType() == typeof(VehiculoNuevo)) {
                VehiculoNuevo vn = (VehiculoNuevo) v;
                this.textBox7.Text = "Nuevo";
                foreach (Extra e in vn.Extras) {
                    this.Extras.Items.Add(e.Nombre);
                }
                this.Extras.Show();
            }
            if (v.GetType() == typeof(VehiculoSegundaMano)) {
                VehiculoSegundaMano vsm = (VehiculoSegundaMano) v;
                this.textBox7.Text = "Segunda Mano";
                this.textBox6.Text = vsm.Matricula;
                this.textBox8.Text = vsm.FechaMatricula.ToString();
                this.textBox6.Show();
                this.textBox8.Show();
                this.label7.Show();
                this.label8.Show();
            }
        }

        private void Aceptar_Click(object sender, EventArgs e) {
            this.DialogResult = DialogResult.OK;
        }
  
    }
}
