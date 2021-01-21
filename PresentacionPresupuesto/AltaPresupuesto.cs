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
        public AltaPresupuesto(LogicaPresupuesto l)
        {
            
            InitializeComponent();
        }
    }
}
