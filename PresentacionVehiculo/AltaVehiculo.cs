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
        public AltaVehiculo(LogicaVehiculo lv, string numBastidor) {
            InitializeComponent();
            this.lv = lv;
            List<Extra> extras = lv.obtenerExtras();
            foreach(Extra e in extras) {
                this.Extras.Items.Add(e.Nombre);
            }
            this.textBox1.Text = numBastidor;
        }

        private void cancelar_Click(object sender, EventArgs e) {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void NuevoRadio_CheckedChanged(object sender, EventArgs e) {
            this.label7.Hide();
            this.label8.Hide();
            this.textBox6.Hide();
            this.dateTimePicker1.Hide();
            this.Extras.Show();
        }

        private void SegundaRadio_CheckedChanged(object sender, EventArgs e) {
            this.Extras.Hide();
            this.label7.Show();
            this.label8.Show();
            this.textBox6.Show();
            this.dateTimePicker1.Show();
        }

        private void Aceptar_Click(object sender, EventArgs e) {
            this.DialogResult = DialogResult.OK;
        }

        public string NumBastidor {
            get {
                return this.textBox1.Text;
            }
        }

        public string Marca {
            get {
                return this.textBox2.Text;
            }
        }

        public string Modelo {
            get {
                return this.textBox3.Text;
            }
        }

        public string Potencia {
            get {
                return this.textBox4.Text;
            }
        }

        public double PVP {
            get {
                return Double.Parse(this.textBox5.Text);
            }
        }

        public List<Extra> ExtraList {
            get {
                List<Extra> extras = new List<Extra>();
                foreach(string n in Extras.Items) {
                    extras.Add(lv.obtenerExtra(n));
                }
                return extras;
            }
        }

        public string Matricula {
            get {
                return this.textBox6.Text;
            }
        }

        public DateTime FechaMatriculacion {
            get {
                return this.dateTimePicker1.Value;
            }
        }

        public bool Nuevo {
            get {
                return this.NuevoRadio.Checked;
            }
        }

        public bool SegundaMano {
            get {
                return SegundaRadio.Checked;
            }
        }
    }
}
