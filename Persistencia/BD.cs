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
        private static Tabla_PresupuestoVehiculo presupuesto_vehiculo;

        public BD() { }

        ///////////////////////////////////////////////////////////////////////////// TABLAS //////////////////////////////////////////////////////////////////////////////////////
        
        public static Tabla_PresupuestoVehiculo Presupuesto_Vehiculos
        {
            get
            {
                if(presupuesto_vehiculo == null)
                {
                    presupuesto_vehiculo = new Tabla_PresupuestoVehiculo();
                }
                return presupuesto_vehiculo;
            }
        }

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

        //////////////////////////////////////////////////////////////////////////////////// CLIENTES /////////////////////////////////////////////////////////////////////////

        /// <summary>
        /// pre: c distinto de null y el cliente con el dni de c existe en la base de datos
        /// post: devuelve el cliente según el DNI pasado en el paramatro c
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public static Cliente SELECT_Cliente(Cliente c)
        {
            ClienteDatos cd = Clientes[c.DNI];
            return cd.Cliente;
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

        //////////////////////////////////////////////////////////////////////////////////// VEHICULOS ///////////////////////////////////////////////////////////////////////////////

        /// <summary>
        /// pre: v distinto de null y el vehiculo con el numBastidor de v existe en la base de datos
        /// post: devuelve el vehiculo según el numBastidor pasado en el paramatro v
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        public static Vehiculo SELECT_Vehiculo(Vehiculo v)
        {
            VehiculoDato vd = Vehiculos[v.NumBastidor];
            return vd.Vehiculo;
        }

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

        ///////////////////////////////////////////////////////////////////////////////// PRESUPUESTOS //////////////////////////////////////////////////////////////////////////////////

        /// <summary>
        /// pre: p distinto de null y el presupuesto con el ID de p existe en la base de datos
        /// post: devuelve el presupuesto según el ID pasado en el paramatro p
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public static Presupuesto SELECT_Presupuesto(Presupuesto p)
        {
            PresupuestoDato pd = Presupuestos[p.ID];
            return pd.Presupuesto;
        }

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
                BD.INSERT_Presupuesto(p);
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
                BD.INSERT_Presupuesto(p);
            }
        }

        ////////////////////////////////////////////////////////////////////////// COMERCIAL //////////////////////////////////////////////////////////////////////////////////////

        /// <summary>
        /// pre: c distinto de null y el comercial con el codigo de c existe en la base de datos
        /// post: devuelve el comercial según el codigo pasado en el paramatro c
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public static Comercial SELECT_Comercial(Comercial c)
        {
            ComercialDato cd = Comercial[c.Codigo];
            return cd.Comercial;
        }

        /// <summary>
        /// pre: el comercial c no existe en la base de datos y c distinto de null
        /// post: añade un nuevo comercial a la base de datos
        /// </summary>
        /// <param name="c"></param>
        public static void INSERT_Comercial(Comercial c)
        {
            Comercial.Add(new ComercialDato(c));
        }

        /// <summary>
        /// pre: c distinto de null
        /// post: devuelve TRUE si el comercial c existe en la base de datos; FALSE en caso contrario
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public static bool EXISTE_Comercial(Comercial c)
        {
            bool existe = false;
            int i = 0;
            while(i<Comercial.Count)
            {
                if(Comercial.ElementAt(i).Codigo.Equals(c.Codigo))
                {
                    existe = true;
                }
                i++;
            }
            return existe;
        }

        /// <summary>
        /// pre: c distinto de null
        /// post: si el comercial c existe en la base de datos, actualiza sus datos con los datos que vienen en el parametro
        /// </summary>
        /// <param name="c"></param>
        private static void UPDATE_Comercial(Comercial c)
        {
            if(EXISTE_Comercial(c))
            {
                Comercial.Remove(new ComercialDato(c).Codigo);
                BD.INSERT_Comercial(c);
            }
        }

        /// <summary>
        /// pre: c distinto de null
        /// post: si el comercial c existe en la base de datos, lo borra
        /// </summary>
        /// <param name="c"></param>
        private static void DELETE_Comercial(Comercial c)
        {
            if(EXISTE_Comercial(c))
            {
                Comercial.Remove(new ComercialDato(c).Codigo);
            }
        }

        //////////////////////////////////////////////////////////////////// Presupuesto_Vehiculos //////////////////////////////////////////////////////////////////////////////////////

        /// <summary>
        /// pre: p distinto de null
        /// post: devuelve una lista de vehiculos que tienen un presupuesto p
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public static List<Vehiculo> SELECT_PresupuestoVehiculos(Presupuesto p)
        {
            Presupuesto pres = BD.SELECT_Presupuesto(p);
            return pres.Vehiculos;
        }

        /// <summary>
        /// pre: el presupuesto p y vehiculo v, existen en la base de datos y p, v, distintos de null
        /// post: añade el vehiculo v al presupuesto p
        /// </summary>
        /// <param name="p"></param>
        /// <param name="v"></param>
        public static void INSERT_PresupuestoVehiculos(Presupuesto p, Vehiculo v)
        {
            Presupuesto p1 = BD.SELECT_Presupuesto(p);
            Vehiculo v1 = BD.SELECT_Vehiculo(v);
            p1.Vehiculos.Add(v1);
            UPDATE_Presupuesto(p1);
            Presupuesto_Vehiculos.Add(new Presupuesto_VehiculosDato(p1, v1));
        }

        /// <summary>
        /// pre: p y v distintos de null
        /// post: devuelve TRUE si existe el par p,v en la base de datos, es decir si un vehiculo pertenece a un presupuesto determinado; FALSE en caso contrario
        /// </summary>
        /// <param name="p"></param>
        /// <param name="v"></param>
        /// <returns></returns>
        public static bool EXISTE_PresupuestoVehiculo(Presupuesto p, Vehiculo v)
        {
            bool existe = false;
            if(EXISTE_Presupuesto(p) && EXISTE_Vehiculo(v))
            {
                Presupuesto p1 = BD.SELECT_Presupuesto(p);
                Vehiculo v1 = BD.SELECT_Vehiculo(v);
                if(Presupuesto_Vehiculos.Contains(new Presupuesto_VehiculosDato(p1, v1).ID))
                {
                    existe = true;
                }
            }
            return existe;
        }

        /// <summary>
        /// pre: el presupuesto p y el vehiculo v existen en la base de datos
        /// post: borran el par p,v de la base de datos
        /// </summary>
        /// <param name="p"></param>
        /// <param name="v"></param>
        public static void DELETE_PresupuestoVehiculos(Presupuesto p, Vehiculo v)
        {
            Presupuesto p1 = BD.SELECT_Presupuesto(p);
            Vehiculo v1 = BD.SELECT_Vehiculo(v);
            Presupuesto_Vehiculos.Remove(new Presupuesto_VehiculosDato(p1, v1).ID);
        }
    }
}
