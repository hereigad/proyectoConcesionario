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
using PresentacionVehiculo;
namespace Presentacion
{
    public partial class FormPrincipal : Form
    {
        private Comercial com;
       
        private LogicaCliente lnc;
        private LogicaPresupuesto lnp;
        private LogicaVehiculo lv;
        public FormPrincipal()
        {
            this.com = new Comercial("1234abc", "Pepe", "Perez", new List<string>()); // lo he instanciado para luego añadirlo a la base de datos para poder hacer algunas pruebas
           
            
            InitializeComponent();
            this.lnp = new LogicaPresupuesto(this.com);
            this.lnp.altaComercial(this.com);
            lnc  = new LogicaCliente(com);
            lv = new LogicaVehiculo(com);
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
        private void altaVehiculo_Click(object sender, EventArgs e) {
            NumBastidorVehiculo nb = new NumBastidorVehiculo();
            nb.ShowDialog();
            if(nb.DialogResult == DialogResult.OK) {
                Vehiculo v = lv.obtenerVehiculo(nb.NumBastidor);
                if (v != null) {
                    DialogResult result = MessageBox.Show("El vehiculo ya existe", "Vehiculo existente", MessageBoxButtons.OK);
                    if (result == DialogResult.OK) {
                        nb.Close();
                    }
                } else {
                    AltaVehiculo alta = new AltaVehiculo(lv, nb.NumBastidor);
                    Vehiculo vehiculo = null;
                    alta.ShowDialog();
                    nb.Close();
                    if(alta.DialogResult == DialogResult.OK) {
                        if(alta.Nuevo) {
                            vehiculo = new VehiculoNuevo(alta.NumBastidor, alta.Marca, alta.Modelo, alta.Potencia, alta.PVP, alta.ExtraList);
                        }
                        if(alta.SegundaMano) {
                            vehiculo = new VehiculoSegundaMano(alta.NumBastidor, alta.Marca, alta.Modelo, alta.Potencia, alta.PVP, alta.Matricula, alta.FechaMatriculacion);
                        }
                        if(vehiculo != null) {
                            lv.altaVehiculo(vehiculo);
                        }
                    }
                }
            }
        }

        private void bajaVehiculo_Click(object sender, EventArgs e) {
            NumBastidorVehiculo nb = new NumBastidorVehiculo();
            nb.ShowDialog();
            if (nb.DialogResult == DialogResult.OK) {
                if(lv.bajaVehiculo(nb.NumBastidor)) {
                    DialogResult result = MessageBox.Show("Vehiculo eliminado", "Vehiculo eliminado", MessageBoxButtons.OK);
                    if (result == DialogResult.OK) {
                        nb.Close();
                    }
                }
                else {
                    DialogResult result = MessageBox.Show("El vehiculo no existe", "Vehiculo inexistente", MessageBoxButtons.OK);
                    if (result == DialogResult.OK) {
                        nb.Close();
                    }
                }
            }
        }

        private void busquedaVehiculo_Click(object sender, EventArgs e) {
            NumBastidorVehiculo nb = new NumBastidorVehiculo();
            nb.ShowDialog();
            if (nb.DialogResult == DialogResult.OK) {
                Vehiculo v = lv.obtenerVehiculo(nb.NumBastidor);
                if (v == null) {
                    DialogResult result = MessageBox.Show("El vehiculo no existe", "Vehiculo inexistente", MessageBoxButtons.OK);
                    if (result == DialogResult.OK) {
                        nb.Close();
                    }
                } else {
                    BusquedaVehiculo busqueda = new BusquedaVehiculo(lv, nb.NumBastidor);
                    Vehiculo vehiculo = null;
                    busqueda.ShowDialog();
                    nb.Close();
                    if (busqueda.DialogResult == DialogResult.OK) {
                        busqueda.Close();
                    }
                }
            }
        }
        private void listadoToolStripMenuItem_Click(object sender, EventArgs e) {
            ListadoVehiculos listado = new ListadoVehiculos(lv);
            listado.ShowDialog();
        }

        /// <summary>
        /// pre: -
        /// post: abre un formulario para dar de alta un nuevo presupuesto
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void altaPresupuesto_Click(object sender, EventArgs e)
        {
            AltaPresupuesto ap = new AltaPresupuesto(this.lnp, this.lnc, this.lv, this.com);
            ap.ShowDialog();
        }

        /// <summary>
        /// pre: -
        /// post: muestra un formulario para ver los presupuestos de un determinado cliente, si existen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void búsquedaPorClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clave clave = new Clave("DNI");
            clave.ShowDialog();
            if (clave.DialogResult == DialogResult.OK)
            {
                string dni = clave.ClaveO;
                if (this.lnc.existe(new Cliente(dni, "", "", Categoria.A)))
                {
                    BusquedaPorCliente bc = new BusquedaPorCliente(dni,this.lnp);
                    bc.ShowDialog();
                }
                else
                {
                    MessageBox.Show("El cliente con DNI " + dni + " no existe!");
                }
            }
        }

        /// <summary>
        /// pre: -
        /// post: muestra un formulario para ver los presupuestos de un determinado vehiculo, si existen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void búsquedaPorVehiculoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clave clave = new Clave("NumeroBastidor");
            clave.ShowDialog();
            if(clave.DialogResult == DialogResult.OK)
            {
                string numBastidor = clave.ClaveO;
                Vehiculo v = this.lv.obtenerVehiculo(numBastidor);
                if(v != null)
                {
                    BusquedaPorVehiculo bv = new BusquedaPorVehiculo(numBastidor, this.lnp);
                    bv.ShowDialog();
                }
                else
                {
                    MessageBox.Show("El vehiculo con el numero de bastidor " + numBastidor + " no existe!");
                }
            }
        }

        /// <summary>
        /// pre: -
        /// post: recorre uno a uno todos los presupuestos, mostrando su informacion
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void recorrerUnoAUnoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PresupuestoUnoAUno pap = new PresupuestoUnoAUno(this.lnp);
            pap.ShowDialog();
        }

        /// <summary>
        /// pre: -
        /// post: abre una ventana con la lista de todos los presupuestos de la base de datos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listarTodosLosPresupuestosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListadoPresupuestos listado = new ListadoPresupuestos(this.lnp);
            listado.ShowDialog();
        }

    }
}
