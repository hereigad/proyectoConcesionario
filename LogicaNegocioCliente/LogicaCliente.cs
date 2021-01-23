using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModeloDominio;
using PersistenciaCliente;
using PersistenciaPresupuesto;


namespace LogicaNegocioCliente
{
    public class LogicaCliente
    {
        private Comercial com;
        
        public LogicaCliente(Comercial c) {
            this.com = c;
        
        }
        public void addCliente(Cliente c)
        {
            PersistenciaCliente.PersistenciaCliente.anadirCliente(c);

        }
        public Cliente selCliente(Cliente c) {
            return PersistenciaCliente.PersistenciaCliente.seleccionarCliente(c);
        
        }

        public bool existe(Cliente c) {
            return PersistenciaCliente.PersistenciaCliente.existeCliente(c);
        
        }
        public void bajaCliente(Cliente c) {

            PersistenciaCliente.PersistenciaCliente.eliminaCliente(c);
        }
        public List<Presupuesto> listaPresupuestosCliente(Cliente c) {

            return PersistenciaCliente.PersistenciaCliente.presupuestosDeCliente(c);
        }
        public List<Presupuesto> listaPresupuestosAceptados(Cliente c) {
            return PersistenciaCliente.PersistenciaCliente.presupuestosAceptados(c);
        }

        public Comercial Comercial {
            get {

                return this.com;
            }
            set {
                this.com = value;
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
        public List<Cliente> totalClientes() {
            return PersistenciaCliente.PersistenciaCliente.clientesConcesionario();
        
        }

        public Dictionary<Cliente,double> OrdenarCliente(Comparison<Cliente> c) {
            Dictionary<Cliente, double> diccionario = new Dictionary<Cliente, double>();
            List<Cliente> ordenados = this.totalClientes();
            ordenados.Sort(c);
            foreach (Cliente cli in ordenados) {
                diccionario.Add(cli,obtieneImporte(cli));
            
            }
            return diccionario;
        }
      
        public static double obtieneImporte(Cliente c) {
            List<Presupuesto> presus = PersistenciaCliente.PersistenciaCliente.presupuestosDeCliente(c);
            double dineros = 0;
            foreach (Presupuesto p in presus) {
                foreach (Vehiculo v in PersistenciaPresupuesto.PersistenciaPresupuesto.seleccionarVehiculosPresupuesto(p)) {
                    dineros += v.Pvp;

                }
            }
            return dineros;
        }
        
    }
}
