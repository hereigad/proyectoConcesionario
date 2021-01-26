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
using PresentacionCliente;
using PresentacionPresupuesto;
using LogicaNegocioPresupuesto;
using LogicaNegocioVehiculo;
using LogicaNegocioCliente;
namespace Presentacion
{
    public partial class FormPrincipal : Form
    {
        private Comercial com;
       
        //private PresentacionPresupuesto.PresentacionPresupuesto presPresupuesto;
        private LogicaCliente lnc;
        private LogicaPresupuesto lnp;
        public FormPrincipal()
        {
            this.com = new Comercial(null,null,null,null);
           
            
            InitializeComponent();
            lnc  = new LogicaCliente(com);
            this.lnp = new LogicaPresupuesto(this.com);
            //this.presPresupuesto = new PresentacionPresupuesto.PresentacionPresupuesto(this.lnp, new LogicaVehiculo(), this.lnc);
        }



        /// <summary>
        /// pre: 
        /// post: Muestra un formulario para poder añadir un cliente
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        private void BTaltaCliente_Click(object sender, EventArgs e)
        {
            Clave f = new Clave("DNI");
            f.ShowDialog();
            if (f.DialogResult == DialogResult.OK)
            {
                
                if (!this.lnc.existe(new Cliente(f.ClaveO, null, null, Categoria.A)))
                {
                    DatosCliente dc = new DatosCliente(f.ClaveO);
                    f.Close();
                    dc.ShowDialog();
                    if (dc.DialogResult == DialogResult.OK)
                    {
                        lnc.addCliente(new Cliente(dc.DNI, dc.Nombre, dc.Tfno, dc.Categoria));
                        dc.Close();
                    }

                }
                else
                {
                    DialogResult dr = MessageBox.Show("¿Quiere introducir otro?", "Este cliente ya existe", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (dr == DialogResult.OK)
                    {
                        f.Close();
                        this.BTaltaCliente.PerformClick();

                    }
                }
            }
        }

        /// <summary>
        /// pre: 
        /// post: muestra el formulario para poder eliminar un cliente
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        private void BTbajaCliente_Click(object sender, EventArgs e)
        {
            Clave f = new Clave("DNI");
            f.ShowDialog();
            if (f.DialogResult == DialogResult.OK)
            {
                if (this.lnc.existe(new Cliente(f.ClaveO, null, null, Categoria.A)))
                {
                    DatosCliente dc = new DatosCliente(f.ClaveO);
                    Cliente aux = this.lnc.selCliente(new Cliente(f.ClaveO, null, null, Categoria.A));
                    dc.Nombre = aux.Nombre;
                    dc.Tfno = aux.Telefono;
                    dc.Categoria = aux.Categoria;
                    dc.todoReadOnly();
                    f.Close();
                    dc.ShowDialog();
                    if (dc.DialogResult == DialogResult.OK)
                    {
                        DialogResult dr = MessageBox.Show("¿Seguro que quieres dar de baja al cliente?", "Aviso", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                        if (dr == DialogResult.OK)
                        {
                            
                            lnc.bajaCliente(new Cliente(dc.DNI, dc.Nombre, dc.Tfno, dc.Categoria));
                            MessageBox.Show("Cliente eliminado", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            dc.ShowDialog();
                        }

                    }

                }
                else
                {
                    DialogResult dr = MessageBox.Show("¿Quiere introducir otro?", "Este cliente ya existe", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (dr == DialogResult.OK)
                    {
                        f.Close();
                        this.BTbajaCliente.PerformClick();

                    }
                }
            }



        }


        /// <summary>
        /// pre: 
        /// post: Muestra el cliente en modo solo lectura
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        private void BTbusquedaCliente_Click(object sender, EventArgs e)
        {
            Clave f = new Clave("DNI");
            f.ShowDialog();
            if (f.DialogResult == DialogResult.OK)
            {
                if (this.lnc.existe(new Cliente(f.ClaveO, null, null, Categoria.A)))
                {
                    DatosCliente dc = new DatosCliente(f.ClaveO);
                    Cliente aux = this.lnc.selCliente(new Cliente(f.ClaveO, null, null, Categoria.A));
                    dc.Nombre = aux.Nombre;
                    dc.Tfno = aux.Telefono;
                    dc.Categoria = aux.Categoria;
                    dc.todoReadOnly();
                    dc.botonesCambio();
                    f.Close();
                    dc.ShowDialog();


                }
                else
                {

                    DialogResult dr = MessageBox.Show("¿Quiere introducir otro?", "Este cliente ya existe", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (dr == DialogResult.OK)
                    {
                        f.Close();
                        this.BTbusquedaCliente.PerformClick();

                    }
                    else {
                        f.Close();
                    }
                }
            }



        }
        private void tsmListas_Click(object sender, EventArgs e)
        {
            PresentacionCliente.listado lis = new PresentacionCliente.listado(lnc);
            lis.ShowDialog();
        }

        private void tsmDesplegable_Click(object sender, EventArgs e)
        {
            PresentacionCliente.OtroForm desp = new PresentacionCliente.OtroForm(lnc);
            desp.ShowDialog();
        }

        private void tsmUnoAUno_Click(object sender, EventArgs e)
        {
            PresentacionCliente.UnoaUno un = new PresentacionCliente.UnoaUno(lnc);
            un.ShowDialog();
        }
        private void altaToolStripMenuItem1_Click(object sender, EventArgs e) {

        }

        private void altaPresupuesto_Click(object sender, EventArgs e)
        {
            AltaPresupuesto ap = new AltaPresupuesto(this.lnp);
            ap.ShowDialog();
        }

        private void búsquedaPorClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clave clave = new Clave("DNI");
            clave.ShowDialog();
            if (clave.DialogResult == DialogResult.OK)
            {
                string dni = clave.ClaveO;
                if (this.lnc.existe(new Cliente(dni, "", "", Categoria.A)))
                {
                    BusquedaPorCliente bc = new BusquedaPorCliente(this.lnp, dni);
                    bc.ShowDialog();
                }
                else
                {
                    MessageBox.Show("El cliente con DNI " + dni + " no existe!");
                }
            }
        }

        private void búsquedaPorVehiculoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void recorrerUnoAUnoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void listarTodosLosPresupuestosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

       
    }
}
