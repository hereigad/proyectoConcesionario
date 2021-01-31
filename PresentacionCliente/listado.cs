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
using LogicaNegocioCliente;

namespace PresentacionCliente
{
    public partial class listado : Form
    {
        private Dictionary<Cliente, double> diccio;
        LogicaCliente log;
        List<ClienteAux> fuente;
        public listado(LogicaNegocioCliente.LogicaCliente ln)
        {

            this.log = ln;
            InitializeComponent();
            diccio = ln.OrdenarCliente(LogicaNegocioCliente.ComparadoresCliente.ComparaDNI);
            BindingSource bd = new BindingSource();
            fuente = this.pasarALista(diccio);
            bd.DataSource = fuente;
            this.lbDNI.DataSource = bd;
            this.lbDNI.DisplayMember = "DNI";
            this.lbNombre.DataSource = bd;
            this.lbNombre.DisplayMember = "Nombre";
            this.lbImporte.DataSource = bd;
            this.lbImporte.DisplayMember = "Importe";

        }
        /// <summary>
        /// pre: 
        /// post: Pasa un diccionario a una lista de Clientes Auxiliares
        /// </summary>
        /// <param name="diccio"></param>
        /// <returns></returns>
        private List<ClienteAux> pasarALista(Dictionary<Cliente, double> diccio)
        {
            List<ClienteAux> solu = new List<ClienteAux>();
            int i = 0;
            while (i < diccio.Count()) {
                Cliente actual=diccio.ToList().ElementAt(i).Key;
                solu.Add(new ClienteAux(actual.DNI,actual.Nombre,actual.Telefono,actual.Categoria, diccio.ToList().ElementAt(i).Value));
                i++;
            }
            return solu;
        }

        /// <summary>
        /// pre: 
        /// post: Cierra el formulario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <returns></returns>
        private void btCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        /// <summary>
        /// pre: 
        /// post: Ordena la lista por DNI
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <returns></returns>
        private void btDNI_Click(object sender, EventArgs e)
        {
            diccio = log.OrdenarCliente(LogicaNegocioCliente.ComparadoresCliente.ComparaDNI);
            this.fuente = this.pasarALista(diccio);
            lbDNI.DataSource = this.fuente;
            lbDNI.Refresh();
            lbDNI.Update();
            lbImporte.DataSource = this.fuente;
            lbImporte.Refresh();
            lbImporte.Update();
            lbNombre.DataSource = this.fuente;
            lbNombre.Refresh();
            lbNombre.Update();
        }


        /// <summary>
        /// pre: 
        /// post: Ordena la lista por nombre
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <returns></returns>
        private void btNombre_Click(object sender, EventArgs e)
        {
            diccio = log.OrdenarCliente(LogicaNegocioCliente.ComparadoresCliente.ComparaNombre);
            this.fuente = this.pasarALista(diccio);
            lbDNI.DataSource = this.fuente;
            lbDNI.Refresh();
            lbDNI.Update();
            lbImporte.DataSource = this.fuente;
            lbImporte.Refresh();
            lbImporte.Update();
            lbNombre.DataSource = this.fuente;
            lbNombre.Refresh();
            lbNombre.Update();

        }

        /// <summary>
        /// pre: 
        /// post: Ordena la lista por importe
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <returns></returns>
        private void btImporte_Click(object sender, EventArgs e)
        {
            diccio = log.OrdenarCliente(LogicaNegocioCliente.ComparadoresCliente.ComparaImporte);
            this.fuente = this.pasarALista(diccio);
            lbDNI.DataSource = this.fuente;
            lbDNI.Refresh();
            lbDNI.Update();
            lbImporte.DataSource = this.fuente;
            lbImporte.Refresh();
            lbImporte.Update();
            lbNombre.DataSource = this.fuente;
            lbNombre.Refresh();
            lbNombre.Update();
        }
    }

    public class ClienteAux : Cliente
    {
        private double importe;
        public ClienteAux(String dni, String nombre, String tfno, Categoria cat, double import):base(dni, nombre, tfno, cat) {
         this.importe=import;   
        }
        public double Importe {
            get {
                return this.importe;
            }
            set {
                this.importe = value;
            }
        }
    }
}
