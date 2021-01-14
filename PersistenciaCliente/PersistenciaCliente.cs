using ModeloDominio;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Persistencia;

namespace PersistenciaCliente
{
    class PersistenciaCliente
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


        
        }

    }
}
