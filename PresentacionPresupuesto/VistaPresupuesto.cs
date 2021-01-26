using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ModeloDominio;

namespace PresentacionPresupuesto
{
    public partial class VistaPresupuesto : UserControl
    {
        private Presupuesto presupuesto;
        public VistaPresupuesto()
        {
            InitializeComponent();
        }

        public VistaPresupuesto(Presupuesto p): this()
        {
            //this.presupuesto = p;
            this.rellenarDatos(p);
        }

        /// <summary>
        /// pre: -
        /// post: rellena los campos con los datos del presupuesto
        /// </summary>
        public void rellenarDatos(Presupuesto p1)
        {
            this.listVehiculos.Items.Clear();
            this.listVehiculos.Refresh();
            this.presupuesto = p1;
            this.txtId.Text = this.presupuesto.ID;
            this.txtFecha.Text = this.presupuesto.FechaRealizacion.ToString();
            this.txtDNI.Text = this.presupuesto.Cliente.DNI;
            this.txtComercial.Text = this.presupuesto.Comercial.Codigo;
            
            switch (this.presupuesto.Estado)
            {
                case EstadoPresupuesto.Aceptado:
                    this.txtEstado.Text = "Aceptado";
                    break;
                case EstadoPresupuesto.Desestimado:
                    this.txtEstado.Text = "Desestimado";
                    break;
                default:
                    this.txtEstado.Text = "Pendiente";
                    break;
            }

            foreach(Vehiculo v in this.presupuesto.Vehiculos)
            {
                this.listVehiculos.Items.Add(v.NumBastidor);
            }
        }
    }
}
