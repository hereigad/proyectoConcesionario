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
        public PresentacionCliente(Comercial com) {
            this.co = com;
        }
        public void addCliente() {


            ClaveCliente f = new ClaveCliente(this.co) ;
            f.ShowDialog();
            if (f.DialogResult == DialogResult.OK) { 
            
            
            
            }
            
        
        }

    }
}
