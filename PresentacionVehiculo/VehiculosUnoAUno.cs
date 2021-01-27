using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LogicaNegocioVehiculo;
using ModeloDominio;

namespace PresentacionVehiculo {
    public partial class VehiculosUnoAUno : Form {
        public VehiculosUnoAUno(LogicaVehiculo lv) {
            InitializeComponent();
            this.bindingNavigator1.BindingSource = new BindingSource();
            this.bindingNavigator1.BindingSource.DataSource = lv.obtenerTodosVehiculos();
            if (this.bindingNavigator1.BindingSource.Count > 0) {
                Vehiculo v = (Vehiculo) this.bindingNavigator1.BindingSource.Current;
                this.textBox1.Text = v.NumBastidor;
                this.textBox2.Text = v.Marca;
                this.textBox3.Text = v.Modelo;
                this.textBox4.Text = v.Potencia;
                this.textBox5.Text = v.Pvp.ToString();
                this.bindingNavigator1.BindingSource.CurrentItemChanged += rellenar;
            }
        }

        private void rellenar(object sender, EventArgs e) {
            if (this.bindingNavigator1.BindingSource.Current != null) {
                Vehiculo v = (Vehiculo) this.bindingNavigator1.BindingSource.Current;
                this.textBox1.Text = v.NumBastidor;
                this.textBox2.Text = v.Marca;
                this.textBox3.Text = v.Modelo;
                this.textBox4.Text = v.Potencia;
                this.textBox5.Text = v.Pvp.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e) {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
