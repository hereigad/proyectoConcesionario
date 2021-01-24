using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PresentacionForms;
using LogicaNegocioCliente;
using ModeloDominio;
using System.Windows.Forms;


namespace PresentacionCliente

{
    
    public class PresentacionCliente
    {
        private Comercial co;
        private LogicaCliente lnc;
        public PresentacionCliente(Comercial com) {
            this.co = com;
            this.lnc = new LogicaCliente(com);
        }

        /// <summary>
        /// pre: 
        /// post: Muestra un formulario para poder añadir un cliente
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public void addCliente() {
            ClaveCliente f = new ClaveCliente(this.co) ;
            f.ShowDialog();
            if (f.DialogResult == DialogResult.OK) {
                if (!this.lnc.existe(new Cliente(f.DNI, null, null, Categoria.A)))
                {
                    DatosCliente dc = new DatosCliente(f.DNI);
                    dc.ShowDialog();
                    if (dc.DialogResult == DialogResult.OK)
                    {
                        lnc.addCliente(new Cliente(dc.DNI, dc.Nombre, dc.Tfno, dc.Categoria));
                    }

                }
                else {
                    DialogResult dr=MessageBox.Show("¿Quiere introducir otro?","Este cliente ya existe",MessageBoxButtons.OKCancel,MessageBoxIcon.Question);
                     if (dr == DialogResult.OK)
                        {
                        this.addCliente();

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
        public void deleteCliente()
        {
            ClaveCliente f = new ClaveCliente(this.co);
            f.ShowDialog();
            if (f.DialogResult == DialogResult.OK)
            {
                if (this.lnc.existe(new Cliente(f.DNI, null, null, Categoria.A)))
                {
                    DatosCliente dc = new DatosCliente(f.DNI);
                    Cliente aux = this.lnc.selCliente(new Cliente(f.DNI, null, null, Categoria.A));
                    dc.Nombre = aux.Nombre;
                    dc.Tfno = aux.Telefono;
                    dc.Categoria = aux.Categoria;
                    dc.todoReadOnly();
                    dc.ShowDialog();
                    if (dc.DialogResult == DialogResult.OK)
                    {
                        DialogResult dr = MessageBox.Show("¿Seguro que quieres dar de baja al cliente?", "Aviso", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                        if (dr == DialogResult.OK)
                        {
                            lnc.bajaCliente(new Cliente(dc.DNI, dc.Nombre, dc.Tfno, dc.Categoria));
                            MessageBox.Show("Cliente eliminado", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else {
                            dc.ShowDialog();
                        }

                    }

                }
                else
                {
                    DialogResult dr = MessageBox.Show("¿Quiere introducir otro?", "Este cliente ya existe", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (dr == DialogResult.OK)
                    {
                        this.deleteCliente();

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
        public void showCliente()
        {
            ClaveCliente f = new ClaveCliente(this.co);
            f.ShowDialog();
            if (f.DialogResult == DialogResult.OK)
            {
                if (this.lnc.existe(new Cliente(f.DNI, null, null, Categoria.A)))
                {
                    DatosCliente dc = new DatosCliente(f.DNI);
                    Cliente aux = this.lnc.selCliente(new Cliente(f.DNI, null, null, Categoria.A));
                    dc.Nombre = aux.Nombre;
                    dc.Tfno = aux.Telefono;
                    dc.Categoria = aux.Categoria;
                    dc.todoReadOnly();
                    dc.botonesCambio();
                    dc.ShowDialog();
                   

                }
                else
                {
                    DialogResult dr = MessageBox.Show("¿Quiere introducir otro?", "Este cliente ya existe", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (dr == DialogResult.OK)
                    {
                        this.showCliente();

                    }
                }
            }



        }



    }
}
