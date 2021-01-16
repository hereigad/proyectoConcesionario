using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModeloDominio;
using PersistenciaCliente;


namespace LogicaNegocioCliente
{
    public class LogicaCliente
    {
        private Cliente cli;
        public LogicaCliente(Cliente c) {
            this.cli = c;
        
        }
        public void addCliente()
        {
            PersistenciaCliente.PersistenciaCliente.anadirCliente(this.cli);

        }
        public Cliente selCliente() {
            return PersistenciaCliente.PersistenciaCliente.seleccionarCliente(this.cli);
        
        }

        public bool existe() {
            return PersistenciaCliente.PersistenciaCliente.existeCliente(this.cli);
        
        }
        public void bajaCliente() {

            PersistenciaCliente.PersistenciaCliente.eliminaCliente(this.cli);
        }
        public List<Presupuesto> listaPresupuestosCliente() {

            return PersistenciaCliente.PersistenciaCliente.presupuestosDeCliente(this.cli);
        }
        public List<Presupuesto> listaPresupuestosAceptados() {
            return PersistenciaCliente.PersistenciaCliente.presupuestosAceptados(this.cli);
        }

        public Cliente LCliente {
            get {

                return this.cli;
            }
            set {
                this.cli = value;
            }
        
        }
        public static List<Cliente> clientePorCategoria(String categoria) {
            if (categoria.Equals("A")) {
                return PersistenciaCliente.PersistenciaCliente.clientesCategoria(Categoria.A);
            }
            if (categoria.Equals("B"))
            {
                return PersistenciaCliente.PersistenciaCliente.clientesCategoria(Categoria.B);
            }
            if (categoria.Equals("C"))
            {
                return PersistenciaCliente.PersistenciaCliente.clientesCategoria(Categoria.C);
            }
            return null;
        }
        public static List<Cliente> totalClientes() {
            return PersistenciaCliente.PersistenciaCliente.clientesConcesionario();
        
        }
    }
}
