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
    public partial class ListadoVehiculos : Form {
        public ListadoVehiculos(LogicaVehiculo lv) {
            InitializeComponent();
            List<Vehiculo> vehiculos = lv.obtenerTodosVehiculos();
            this.dataGridView1.DataSource = vehiculos;
        }
    }
}
