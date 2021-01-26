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
    public partial class NumBastidorVehiculo : Form {
        private LogicaVehiculo lv;
        public NumBastidorVehiculo(LogicaVehiculo lv) {
            InitializeComponent();
            this.lv = lv;
        }

        private void Form1_Load(object sender, EventArgs e) {

        }

        private void button1_Click(object sender, EventArgs e) {
            Vehiculo v = lv.obtenerVehiculo(this.textBox1.Text);
            if (v != null) {
                DialogResult result = MessageBox.Show("El vehiculo ya existe", "Vehiculo existente", MessageBoxButtons.OK);
                if (result == System.Windows.Forms.DialogResult.OK) {
                    this.Close();
                }
            }
            else {
                AltaVehiculo alta = new AltaVehiculo(lv);
                alta.Visible = true;
                this.Close();
                alta.Activate();
            }
        }
    }
}
