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
        public void addCliente(Cliente c)
        {
            PersistenciaCliente.PersistenciaCliente.anadirCliente(c);

        }
        public Cliente selCliente(String dni) {
            return PersistenciaCliente.PersistenciaCliente.seleccionarCliente(new Cliente(dni,null,null,Categoria.A));
        
        }

        public bool existe(String dni) {
            return PersistenciaCliente.PersistenciaCliente.existeCliente(new Cliente(dni, null, null, Categoria.A));
        
        }
        public void bajaCliente(String dni) {

            PersistenciaCliente.PersistenciaCliente.eliminaCliente(new Cliente(dni, null, null, Categoria.A));
        }
        public List<Presupuesto> listaPresupuestosCliente(String dni) {

            return PersistenciaCliente.PersistenciaCliente.presupuestosDeCliente(new Cliente(dni, null, null, Categoria.A));
        }
        public List<Presupuesto> listaPresupuestosAceptados(String dni) {
            return PersistenciaCliente.PersistenciaCliente.presupuestosAceptados(new Cliente(dni, null, null, Categoria.A));
        }
        public List<Cliente> clientePorCategoria(String categoria) {
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
    }
}
