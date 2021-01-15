using ModeloDominio;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Persistencia;

namespace PersistenciaCliente
{
    public class PersistenciaCliente
    {

        public bool anadirCliente(Cliente c) {
            BD.INSERT_Cliente(c);
            if (BD.EXISTE_Cliente(c)) {
                return true;
            }
            return false;
        }
        public Cliente seleccionarCliente(Cliente c) {
            ClienteDatos cd = BD.SELECT_Cliente(c);
            if (cd.CategoriaCliente == 5) {
                return new Cliente(cd.DNI, cd.NombreCliente, cd.TlfCliente,Categoria.A);
            }
            if (cd.CategoriaCliente == 10) {
                return new Cliente(cd.DNI, cd.NombreCliente, cd.TlfCliente, Categoria.B);
            }
            if (cd.CategoriaCliente ==15){
                return new Cliente(cd.DNI, cd.NombreCliente, cd.TlfCliente, Categoria.C);
            }

            return null;
        }

        public bool eliminaCliente(Cliente c) {
            BD.DELETE_Cliente(c);
            if (BD.EXISTE_Cliente(c)) {
                return false;
            }
            return true;  
        }

        public bool existeCliente(Cliente c) {
            if (BD.EXISTE_Cliente(c)) {
                return true;
            }
            return false;
        }

        public List<Presupuesto> presupuestosDeCliente(Cliente c) {
            List<Presupuesto> lista = new List<Presupuesto>();
            Tabla_ClientePresupuesto tabla = BD.ClientePresupuesto;
            foreach (ClientePresupuesto p in tabla) {
                if (p.DNI.Equals(c.DNI)) { 
                //Llamar a metodo que recupera un presupuesto
                
                }
            }
            return lista;
        
        }
        public List<Presupuesto> presupuestosAceptados(Cliente c)
        {
            List<Presupuesto> listafin = new List<Presupuesto>();
            List<Presupuesto> lista = this.presupuestosDeCliente(c);
            foreach (Presupuesto p in lista)
            {
                if (p.Estado==EstadoPresupuesto.Aceptado)
                {

                    listafin.Add(p);

                }
            }
            return listafin;

        }
        public List<Cliente> clientesCategoria(Categoria cat) {
            List<Cliente> lista = new List<Cliente>();
            ColCliente colec = BD.Clientes;
            Cliente cliAux;
            foreach (ClienteDatos c in colec)
            {
                cliAux=seleccionarCliente(new Cliente(c.DNI, null, null, Categoria.A));
                if (cliAux.Categoria == cat) {
                    lista.Add(cliAux);
                }

            }
            return lista;
        }

        public List<Cliente> clientesConcesionario()
        {
            List<Cliente> lista = new List<Cliente>();
            ColCliente colec = BD.Clientes;
            foreach (ClienteDatos c in colec)
            {  
                    lista.Add(seleccionarCliente(new Cliente(c.DNI, null, null, Categoria.A)));
            }
            return lista;
        }

    }
}
