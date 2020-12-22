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
        private static TablaComercial comercial;

        public BD() { }

        public static TablaComercial Comercial
        {
            get
            {
                if(comercial == null)
                {
                    comercial = new TablaComercial();
                }
                return comercial;
            }
        }

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

        // CLIENTES

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
            bool existe = false;
            int i = 0;
            while (i<Clientes.Count) {
                if (Clientes.ElementAt(i).DNI.Equals(c.DNI)) {
                    existe = true;
                }
                i++;
            }
            return existe;
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

        // VEHICULOS

        /// <summary>
        /// pre: v distinto de null y el vehiculo v no existe en la base de datos
        /// post: añade v en la base de datos
        /// </summary>
        /// <param name="v"></param>
        public static void INSERT_Vehiculo(Vehiculo v)
        {
            Vehiculos.Add(new VehiculoDato(v));
        }

        /// <summary>
        /// pre: v distinto de null
        /// post: devuelve TRUE si el vehiculo v existe en la base de datos; FALSE en caso contrario
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        public static bool EXISTE_Vehiculo(Vehiculo v)
        {
            bool existe = false;
            int i = 0;
            while(i<Vehiculos.Count)
            {
                if(Vehiculos.ElementAt(i).NumBastidor.Equals(v.NumBastidor))
                {
                    existe = true;
                }
                i++;
            }
            return existe;
        }

        /// <summary>
        /// pre: v es distinto de null
        /// post: si existe v en la base de datos, actualiza sus datos con las de v pasado como parametro
        /// </summary>
        /// <param name="v"></param>
        public static void UPDATE_Vehiculo(Vehiculo v)
        {
            if(EXISTE_Vehiculo(v))
            {
                Vehiculos.Remove(new VehiculoDato(v).NumBastidor);
                BD.INSERT_Vehiculo(v);
            }
        }
        
        /// <summary>
        /// pre: v distinto de null
        /// post: si existe el vehiculo v, lo borra de la base de datos
        /// </summary>
        /// <param name="v"></param>
        public static void DELETE_Vehiculo(Vehiculo v)
        {
            if(EXISTE_Vehiculo(v))
            {
                Vehiculos.Remove(new VehiculoDato(v).NumBastidor);
            }
        }

        // PRESUPUESTOS

        /// <summary>
        /// pre: p distinto de null y no existe en la base de datos
        /// post: añade el presupuesto p en la base de datos
        /// </summary>
        /// <param name="p"></param>
        public static void INSERT_Presupuesto(Presupuesto p)
        {
            Presupuestos.Add(new PresupuestoDato(p));
        }

        /// <summary>
        /// pre: p distinto de null
        /// post: devuelve TRUE si el presupuesto existe en la base de datos; FALSE en caso contrario
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public static bool EXISTE_Presupuesto(Presupuesto p)
        {
            bool existe = false;
            int i = 0;
            while(i<Presupuestos.Count)
            {
                if(Presupuestos.ElementAt(i).ID.Equals(p.ID))
                {
                    existe = true;
                }
                i++;
            }
            return existe;
        }

        /// <summary>
        /// pre: p distinto de null
        /// post: si p existe en la base de datos, actualiza sus datos con la nueva informacion dada en p
        /// </summary>
        /// <param name="p"></param>
        public static void UPDATE_Presupuesto(Presupuesto p)
        {
            if(EXISTE_Presupuesto(p))
            {
                Presupuestos.Remove(new PresupuestoDato(p).ID);
                INSERT_Presupuesto(p);
            }
        }

        /// <summary>
        /// pre: p distinto de null
        /// post: si existe el presupuesto p, lo borra de la base de datos
        /// </summary>
        /// <param name="p"></param>
        public static void DELETE_Presupuesto(Presupuesto p)
        {
            if(EXISTE_Presupuesto(p) && !p.Borrado)
            {
                Presupuestos.Remove(new PresupuestoDato(p).ID);
                p.Borrado = true;
                INSERT_Presupuesto(p);
            }
        }

        // COMERCIAL

        /// <summary>
        /// pre:
        /// post:
        /// </summary>
        /// <param name="c"></param>
        public static void INSERT_Comercial(Comercial c)
        {

        }

        /// <summary>
        /// pre:
        /// post:
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public static bool EXISTE_Comercial(Comercial c)
        {
            return false;
        }

        /// <summary>
        /// pre:
        /// post:
        /// </summary>
        /// <param name="c"></param>
        private static void UPDATE_Comercial(Comercial c)
        {

        }

        /// <summary>
        /// pre:
        /// post:
        /// </summary>
        /// <param name="c"></param>
        private static void DELETE_Comercial(Comercial c)
        {

        }
    }
}
