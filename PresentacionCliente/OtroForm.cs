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
            comboBox1.DataSource = todos;
            comboBox1.DisplayMember = "DNI";
                }

        private void btCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selec = comboBox1.SelectedIndex;
            this.lbApellidos.Text = todos.ElementAt(selec).Nombre.Substring(0, todos.ElementAt(selec).Nombre.IndexOf(','));
            this.tbNombre.Text = todos.ElementAt(selec).Nombre.Substring(todos.ElementAt(selec).Nombre.IndexOf(','), todos.ElementAt(selec).Nombre.Length);
        }
    }
}
