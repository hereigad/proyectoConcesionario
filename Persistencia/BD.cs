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


        /// <summary>
        /// pre: el cliente no existe en la base de datos y c es distinto de null
        /// post: añade el nuevo cliente en la base de datos
        /// </summary>
        /// <param name="c"></param>
        public static void INSERT_Cliente(Cliente c)
        {
            Clientes.Add(new ClienteDatos(c));
        }

        /// <summary>
        /// pre: c distinto de null
        /// post: devuelve TRUE si el cliente existe en la base de datos; FALSE en caso contrario
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
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

        /// <summary>
        /// pre: c es distinto de null
        /// post: si existe el cliente en la base de datos, actualiza sus datos
        /// </summary>
        /// <param name="c"></param>
        public static void UPDATE_Cliente(Cliente c)
        {
            if(EXISTE_Cliente(c))
            {
                Clientes.Remove(new ClienteDatos(c).DNI);
                BD.INSERT_Cliente(c);
            }
        }

        /// <summary>
        /// pre: c distinto de null
        /// post: si existe el cliente en la base de datos, lo borra
        /// </summary>
        /// <param name="c"></param>
        public static void DELETE_Cliente(Cliente c)
        {
            if(EXISTE_Cliente(c))
            {
                Clientes.Remove(new ClienteDatos(c).DNI);
            }
        }



    }
}
