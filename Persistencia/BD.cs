using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModeloDominio;

namespace Persistencia
{
    class BD
    {
        private static ColCliente clientes;
        private static TablaVehiculo vehiculos;
        private static TablaPresupuesto presupuestos;

        public BD() { }

        public static ColCliente Clientes
        {
            get
            {
                if(clientes == null)
                {
                    clientes = new ColCliente();
                }
                return clientes;
            }
        }

        public static TablaVehiculo Vehiculos
        {
            get
            {
                if(vehiculos == null)
                {
                    vehiculos = new TablaVehiculo();
                }
                return vehiculos;
            }
        }

        public static TablaPresupuesto Presupuestos
        {
            get
            {
                if(presupuestos == null)
                {
                    presupuestos = new TablaPresupuesto();
                }
                return presupuestos;
            }
        }



        public static void INSERT_Cliente(Cliente c)
        {
            Clientes.Add(new ClienteDatos(c));
        }

        public static bool EXISTE_Cliente(Cliente c)
        {
            int i = 0;
            while (i<Clientes.Count) {
                if (Clientes.ElementAt(i).DNI.Equals(c.DNI)) {
                    return true;
                }
                i++;
            }
            return false;
        }

        public static void UPDATE_Cliente(Cliente c)
        {
            if(EXISTE_Cliente(c))
            {
                Clientes.Remove(new ClienteDatos(c).DNI);
                BD.INSERT_Cliente(c);
            }
        }



    }
}
