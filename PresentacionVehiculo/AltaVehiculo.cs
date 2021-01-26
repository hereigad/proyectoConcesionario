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
    public partial class AltaVehiculo : Form {
        private LogicaVehiculo lv;
        public AltaVehiculo(LogicaVehiculo lv) {
            InitializeComponent();
            this.lv = lv;
            List<Extra> extras = lv.obtenerExtras();
            foreach(Extra e in extras) {
                this.Extras.Items.Add(e.Nombre);
            }
        }

        private void cancelar_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void NuevoRadio_CheckedChanged(object sender, EventArgs e) {
            this.label7.Hide();
            this.label8.Hide();
            this.textBox6.Hide();
            this.textBox7.Hide();
            this.Extras.Show();
        }

        private void SegundaRadio_CheckedChanged(object sender, EventArgs e) {
            this.Extras.Hide();
            this.label7.Show();
            this.label8.Show();
            this.textBox6.Show();
            this.textBox7.Show();
        }
    }
}
