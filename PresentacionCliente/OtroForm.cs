using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LogicaNegocioCliente;
using ModeloDominio;


namespace PresentacionCliente
{
    public partial class OtroForm : Form
    {
        LogicaCliente log;
        List<Cliente> todos;
        public OtroForm(LogicaNegocioCliente.LogicaCliente ln)
        {
            this.log = ln;
            InitializeComponent();
            todos = log.totalClientes();
           
            foreach (Cliente c in todos) {
                this.comboBox1.Items.Add(c.DNI);
            }
            this.comboBox1.SelectedIndex = 0;


       }


        /// <summary>
        /// pre: 
        /// post:Cierra el formulario
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        private void btCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        /// <summary>
        /// pre: 
        /// post: Cambia el Cliente seleccionado
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selec = comboBox1.SelectedIndex;
            String nombre = todos.ElementAt(selec).Nombre;
            this.tbApellidos.Text = todos.ElementAt(selec).Nombre.Substring(0, todos.ElementAt(selec).Nombre.IndexOf(','));
            this.tbNombre.Text = nombre.Remove(0, todos.ElementAt(selec).Nombre.IndexOf(',')+1);

           
        }
    }
}
