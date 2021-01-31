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
        /// <summary>
        /// pre: c no existe en la base de datos y no es nulo
        /// post: el cliente queda añadido
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public void addCliente(Cliente c)
        {
            PersistenciaCliente.PersistenciaCliente.anadirCliente(c);

        }
        /// <summary>
        /// pre: el DNI del cliente c debe existir en la BD
        /// post: devuelve un objeto cliente con todos los datos
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public Cliente selCliente(Cliente c) {
            return PersistenciaCliente.PersistenciaCliente.seleccionarCliente(c);
        
        }
        /// <summary>
        /// pre: 
        /// post: devuelve true si el cliente existe en la base de datos, false si no
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public bool existe(Cliente c) {
            return PersistenciaCliente.PersistenciaCliente.existeCliente(c);
        
        }

        /// <summary>
        /// pre: c existe en la base de datos y no es nulo
        /// post: borra el cliente c de la base de datos
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public void bajaCliente(Cliente c) {

            PersistenciaCliente.PersistenciaCliente.eliminaCliente(c);
        }


        /// <summary>
        /// pre: c existe en la base de datos y no es nulo
        /// post: devuelve la lista de los presupuestos del cliente c
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public List<Presupuesto> listaPresupuestosCliente(Cliente c) {

            return PersistenciaCliente.PersistenciaCliente.presupuestosDeCliente(c);
        }


        /// <summary>
        /// pre: c existe en la base de datos y no es nulo
        /// post: devuelve la lista de los presupuestos aceptados del cliente c
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
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

        /// <summary>
        /// pre: 
        /// post: devuelve la lista de los clientes con la categoria "categoria"
        /// </summary>
        /// <param name="categoria"></param>
        /// <returns></returns>
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


        /// <summary>
        /// pre: 
        /// post: devuelve todos los cientes del concesionario
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public List<Cliente> totalClientes() {
            return PersistenciaCliente.PersistenciaCliente.clientesConcesionario();
        
        }


        /// <summary>
        /// pre: Se envia un Comparison con el que se ordena la lista de los clientes
        /// post: devuelve un dictionary con los clientes y su importe
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public Dictionary<Cliente,double> OrdenarCliente(Comparison<Cliente> c) {
            Dictionary<Cliente, double> diccionario = new Dictionary<Cliente, double>();
            List<Cliente> ordenados = this.totalClientes();
            ordenados.Sort(c);
            foreach (Cliente cli in ordenados) {
                diccionario.Add(cli,obtieneImporte(cli));
            
            }
            return diccionario;
        }


        /// <summary>
        /// pre: c existe en la base de datos y no es nulo
        /// post: devuelve el importe total del cliente
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public static double obtieneImporte(Cliente c) {
            List<Presupuesto> presus = PersistenciaCliente.PersistenciaCliente.presupuestosDeCliente(c);
            double dineros = 0;
            foreach (Presupuesto p in presus) {
                foreach (Vehiculo v in PersistenciaPresupuesto.PersistenciaPresupuesto.seleccionarVehiculosPresupuesto(p)) {
                    dineros += v.Pvp;

                }
            }
            Cliente cli = PersistenciaCliente.PersistenciaCliente.seleccionarCliente(c);
            if (cli.Categoria == Categoria.A)
            {
                return dineros * 0.95;
            }
            if (cli.Categoria == Categoria.B) { return dineros * 0.9; }
            if (cli.Categoria== Categoria.C) { return dineros * 0.85; }

            return 0;

        }
        
    }
}
