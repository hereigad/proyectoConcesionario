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
using PresentacionCliente;
using PresentacionPresupuesto;
using LogicaNegocioPresupuesto;
namespace Presentacion
{
    public partial class FormPrincipal : Form
    {
        private Comercial com;
        private PresentacionCliente.PresentacionCliente presCli;
        private PresentacionPresupuesto.PresentacionPresupuesto presPresupuesto;
        public FormPrincipal()
        {
            this.com = new Comercial(null,null,null,null);
            this.presCli = new PresentacionCliente.PresentacionCliente(this.com);
            this.presPresupuesto = new PresentacionPresupuesto.PresentacionPresupuesto(new LogicaPresupuesto(this.com));
            InitializeComponent();
        }

       

        private void BTaltaCliente_Click(object sender, EventArgs e)
        {
            presCli.addCliente();
        }

        private void BTbajaCliente_Click(object sender, EventArgs e)
        {
            presCli.deleteCliente();
        }

        private void BTbusquedaCliente_Click(object sender, EventArgs e)
        {
            presCli.showCliente();
        }

        private void altaToolStripMenuItem1_Click(object sender, EventArgs e) {

        }

        private void altaPresupuesto_Click(object sender, EventArgs e)
        {
            this.presPresupuesto.addPresupuesto();
        }
    }
}
