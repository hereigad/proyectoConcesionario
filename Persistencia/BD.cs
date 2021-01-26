using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModeloDominio;

namespace Persistencia
{
    public class BD
    {
        private static ColCliente clientes;
        private static TablaVehiculo vehiculos;
        private static TablaPresupuesto presupuestos;
        private static TablaComercial comercial;
        private static Tabla_PresupuestoVehiculo presupuesto_vehiculo;
        private static Tabla_VehiculoVendido vehiculos_vendidos;
        private static TablaExtra extras;
        private static TablaExtraVehiculo vehiculo_extra;
        private static Tabla_ClientePresupuesto cliente_presupuesto;

        public BD() { }

        ///////////////////////////////////////////////////////////////////////////// TABLAS //////////////////////////////////////////////////////////////////////////////////////
        
        public static Tabla_VehiculoVendido Vehiculos_Vendidos
        {
            get
            {
                if(vehiculos_vendidos == null)
                {
                    vehiculos_vendidos = new Tabla_VehiculoVendido();
                }
                return vehiculos_vendidos;
            }
        }

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
        public static Tabla_ClientePresupuesto ClientePresupuesto
        {
            get
            {
                if (cliente_presupuesto == null)
                {
                    cliente_presupuesto = new Tabla_ClientePresupuesto();
                }
                return cliente_presupuesto;
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

        public static TablaExtra Extras
        {
            get
            {
                if(extras == null)
                {
                    extras = new TablaExtra();
                    extras.Add(new ExtraDato(new Extra("test1", 0)));
                    extras.Add(new ExtraDato(new Extra("test2", 0)));
                    extras.Add(new ExtraDato(new Extra("test3", 0)));
                    extras.Add(new ExtraDato(new Extra("test4", 0)));
                }
                return extras;
            }
        }

        public static TablaExtraVehiculo Vehiculo_Extra
        {
            get
            {
                if(vehiculo_extra == null)
                {
                    vehiculo_extra = new TablaExtraVehiculo();
                }
                return vehiculo_extra;
            }
        }

        //////////////////////////////////////////////////////////////////////////////////// CLIENTES /////////////////////////////////////////////////////////////////////////

        /// <summary>
        /// pre: DNI debe de corresponder con el DNI de un cliente almacenado
        /// post: devuelve el cliente según el DNI pasado en el paramatro c
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public static ClienteDatos SELECT_Cliente(Cliente c)
        {
            if(EXISTE_Cliente(c))
            {
                return Clientes[c.DNI];
               
            }
            return null;
        }

        public static List<ClienteDatos> SELECT_ALL_Cliente() {
            List<ClienteDatos> clientes = new List<ClienteDatos>();
            foreach(ClienteDatos n in Clientes) {
                clientes.Add(n);
            }
            return clientes;
        }

        /// <summary>
        /// pre: el cliente no existe en la base de datos y c es distinto de null
        /// post: añade el nuevo cliente en la base de datos
        /// </summary>
        /// <param name="c"></param>
        public static void INSERT_Cliente(Cliente c)
        {
            if(!EXISTE_Cliente(c))
            {
                Clientes.Add(new ClienteDatos(c));
            }
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
                    if (Clientes.ElementAt(i).Borrado == false)
                    {
                        existe = true;
                    }
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
                ClienteDatos cd = Clientes[c.DNI];
                Clientes.Remove(cd.DNI);
                cd.Borrado = true;
                Clientes.Add(cd);
            }
        }

        //////////////////////////////////////////////////////////////////////////////////// VEHICULOS ///////////////////////////////////////////////////////////////////////////////

        /// <summary>
        /// pre: numBast corresponde a un numero de bastidor existente en la base de datos
        /// post: devuelve el vehiculo según el numBastidor pasado en el paramatro numBast
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        public static VehiculoDato SELECT_Vehiculo(Vehiculo v)
        {
            if (EXISTE_Vehiculo(v))
            {
                return Vehiculos[v.NumBastidor];
               
            }
            return null;
        }

        public static List<VehiculoDato> SELECT_ALL_Vehiculo() {
            List<VehiculoDato> vehiculos = new List<VehiculoDato>();
            foreach (VehiculoDato n in Vehiculos) {
                vehiculos.Add(n);
            }
            return vehiculos;
        }

        /// <summary>
        /// pre: v distinto de null y el vehiculo v no existe en la base de datos
        /// post: añade v en la base de datos
        /// </summary>
        /// <param name="v"></param>
        public static void INSERT_Vehiculo(Vehiculo v)
        {
            if (!EXISTE_Vehiculo(v))
            {
                Vehiculos.Add(new VehiculoDato(v));
            }
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
                VehiculoDato act = Vehiculos.ElementAt(i);
                if (act.NumBastidor.Equals(v.NumBastidor))
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
                Vehiculos.Remove(v.NumBastidor);
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
                VehiculoDato ins = Vehiculos[v.NumBastidor];//new VehiculoDato(v);
                Vehiculos.Remove(v.NumBastidor);
                ins.Borrado = true;
                Vehiculos.Add(ins);
            }
        }

        ///////////////////////////////////////////////////////////////////////////////// PRESUPUESTOS //////////////////////////////////////////////////////////////////////////////////

        /// <summary>
        /// pre: p distinto de null y el presupuesto con el ID de p existe en la base de datos
        /// post: devuelve el presupuesto según el ID pasado en el paramatro p
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public static PresupuestoDato SELECT_Presupuesto(Presupuesto p)
        {
            if (EXISTE_Presupuesto(p))
            {
                PresupuestoDato pd = Presupuestos[p.ID];
                return pd;
            
           
          
                /*Comercial c = SELECT_Comercial(new Comercial(pd.Codigo, "", ""));
                Cliente cl = SELECT_Cliente(new Cliente(pd.DNI, "", "", Categoria.A));
                List<Vehiculo> vehiculos = SELECT_PresupuestoVehiculos(p);
                return new Presupuesto(pd.ID, pd.FechaRealizacion, pd.Estado, c, cl, vehiculos, pd.Borrado);*/
            }
            return null;
        }

        public static List<PresupuestoDato> SELECT_ALL_Presupuesto() {
            List<PresupuestoDato> presupuestos = new List<PresupuestoDato>();
            foreach (PresupuestoDato n in Presupuestos) {
                presupuestos.Add(n);
            }
            return presupuestos;
        }

        /// <summary>
        /// pre: p distinto de null y no existe en la base de datos
        /// post: añade el presupuesto p en la base de datos
        /// </summary>
        /// <param name="p"></param>
        public static void INSERT_Presupuesto(Presupuesto p)
        {
            if(!EXISTE_Presupuesto(p))
            {
                Presupuestos.Add(new PresupuestoDato(p));
            }
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
                    if (!Presupuestos.ElementAt(i).Borrado)
                    {
                        existe = true;
                    }
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
            if(EXISTE_Presupuesto(p))
            {
                PresupuestoDato pd = Presupuestos[p.ID];
                Presupuestos.Remove(new PresupuestoDato(p).ID);
                pd.Borrado = true;
                Presupuestos.Add(pd);
            }
        }

        ////////////////////////////////////////////////////////////////////////// COMERCIAL //////////////////////////////////////////////////////////////////////////////////////

        /// <summary>
        /// pre:codigo debe ser el codigo de un comercial guardado en la base de datos
        /// post: devuelve el comercial según el codigo pasado en el paramatro codigo
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public static ComercialDato SELECT_Comercial(Comercial c)
        {
            if(EXISTE_Comercial(c))
            {
                return Comercial[c.Codigo];
               
            }
            return null;
        }

        public static List<ComercialDato> SELECT_ALL_Comercial() {
            List<ComercialDato> comerciales = new List<ComercialDato>();
            foreach (ComercialDato n in Comercial) {
                comerciales.Add(n);
            }
            return comerciales;
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
                ComercialDato cd = Comercial.ElementAt(i);
                if (cd.Codigo.Equals(c.Codigo))
                {
                    if (cd.Borrado == false)
                    {
                        existe = true;
                    }
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
        public static void UPDATE_Comercial(Comercial c)
        {
            if(EXISTE_Comercial(c))
            {
                Comercial.Remove(new ComercialDato(c).Codigo);
                BD.INSERT_Comercial(c);
            }
        }

        /// <summary>
        /// pre: c distinto de null y existe en la base de datos
        /// post: si el comercial c existe en la base de datos, lo borra
        /// </summary>
        /// <param name="c"></param>
        public static void DELETE_Comercial(Comercial c)
        {
            ComercialDato cd = Comercial[c.Codigo];//new ComercialDato(c);
            Comercial.Remove(new ComercialDato(c).Codigo);
            cd.Borrado = true;
            Comercial.Add(cd);
        }

        //////////////////////////////////////////////////////////////////// Presupuesto_Vehiculos //////////////////////////////////////////////////////////////////////////////////////

        /// <summary>
        /// pre: p distinto de null y es un presupuesto presente en la base de datos en el cual se le puede pasar solo el identificador
        /// post: devuelve la tabla con las claves del vehiculo (el numero de bastidor) que tiene el presupuesto con el ID dado
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public static Presupuesto_VehiculosDato SELECT_PresupuestoVehiculos(Presupuesto p, Vehiculo v)
        {
            /*List<string> clavesVehiculos = new List<string>();
            Presupuesto presupuesto = BD.SELECT_Presupuesto(p);
             foreach(Vehiculo v in presupuesto.Vehiculos)
            {
                clavesVehiculos.Add(v.NumBastidor);
           }
            return clavesVehiculos;*/
            Tuple<string, string> clave = new Tuple<string, string>(p.ID, v.NumBastidor);
            return Presupuesto_Vehiculos[clave];
        }

        /// <summary>
        /// pre: el presupuesto p existe en la base de datos
        /// post: devuleve una coleccion de datos de vehiculos del presupuesto dado
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public static List<Presupuesto_VehiculosDato> SELECT_ALL_PresupuestoVehiculos(Presupuesto p) {
            List<Presupuesto_VehiculosDato> presupuesto_vehiculos = new List<Presupuesto_VehiculosDato>();
            foreach (Presupuesto_VehiculosDato n in Presupuesto_Vehiculos) {
                if (n.Clave.Item1.Equals(p.ID))
                {
                    presupuesto_vehiculos.Add(n);
                }
            }
            return presupuesto_vehiculos;
        }

        /// <summary>
        /// pre: el vehiculo v distinto de null y existente en la base de datos
        /// post: devuelve una coleccion de datos de presupuestos del vehiculo v dado
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        public static List<Presupuesto_VehiculosDato> SELECT_ALL_VehiculoPresupuestos(Vehiculo v)
        {
            List<Presupuesto_VehiculosDato> presupuesto_vehiculos = new List<Presupuesto_VehiculosDato>();
            foreach (Presupuesto_VehiculosDato n in Presupuesto_Vehiculos)
            {
                if (n.Clave.Item2.Equals(v.NumBastidor))
                {
                    presupuesto_vehiculos.Add(n);
                }
            }
            return presupuesto_vehiculos;
        }


        /// <summary>
        /// pre: el presupuesto p y vehiculo v, existen en la base de datos y p, v, distintos de null
        /// post: añade el par p,v
        /// </summary>
        /// <param name="p"></param>
        /// <param name="v"></param>
        public static void INSERT_PresupuestoVehiculos(Presupuesto p, Vehiculo v)
        {
            if(!EXISTE_PresupuestoVehiculo(p, v))
            {
                Presupuesto_Vehiculos.Add(new Presupuesto_VehiculosDato(p, v));
            }
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
            if (Presupuesto_Vehiculos.Contains(new Presupuesto_VehiculosDato(p, v).Clave))
            {
                existe = true;
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
            if(EXISTE_PresupuestoVehiculo(p,v))
            {
                Presupuesto_Vehiculos.Remove(new Presupuesto_VehiculosDato(p, v).Clave);
            }
        }

        ////////////////////////////////////////////////////////////////////////// VEHICULOS VENDIDOS ///////////////////////////////////////////////////////////////////////////////
        
        /// <summary>
        /// pre: c distinto de null y existente en la base de datos
        /// post: devuelve una fila con la clave del comercial y la del vehiculo o null si no existe
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public static Vehiculos_VendidosDato SELECT_VehiculosVendidos(Comercial c, Vehiculo v)
        {
            Vehiculos_VendidosDato vvd = null;
            Tuple<string, string> clave = new Tuple<string, string>(c.Codigo, v.NumBastidor);
            vvd = Vehiculos_Vendidos[clave];
            return vvd;
        }

        public static List<Vehiculos_VendidosDato> SELECT_ALL_VehiculosVendidos() {
            List<Vehiculos_VendidosDato> vehiculos_vendidos = new List<Vehiculos_VendidosDato>();
            foreach (Vehiculos_VendidosDato n in Vehiculos_Vendidos) {
                vehiculos_vendidos.Add(n);
            }
            return vehiculos_vendidos;
        }

        /// <summary>
        /// pre: c y v existen la base de datos cada uno en su tabla correspondiente
        /// post: añade el par c,v en la tabla VehiculosVendidos
        /// </summary>
        /// <param name="c"></param>
        /// <param name="v"></param>
        public static void INSERT_VehiculosVendidos(Comercial c, Vehiculo v)
        {
            Vehiculos_Vendidos.Add(new Vehiculos_VendidosDato(c, v));
        }

        /// <summary>
        /// pre: c y v distintos de null
        /// post: devuelve TRUE si existe el par c,v; FALSE en caso contrario
        /// </summary>
        /// <param name="c"></param>
        /// <param name="v"></param>
        /// <returns></returns>
        public static bool EXISTE_VehiculosVendidos(Comercial c, Vehiculo v)
        {
            bool existe = false;
            if(Vehiculos_Vendidos.Contains(new Vehiculos_VendidosDato(c,v).Clave))
            {
                existe = true;
            }
            return existe;
        }

        /// <summary>
        /// pre: c y v no nulos
        /// post: borra la tupla c,v de la base de datos
        /// </summary>
        /// <param name="c"></param>
        /// <param name="v"></param>
        public static void DELETE_VehiculosVendidos(Comercial c, Vehiculo v)
        {
            if(EXISTE_VehiculosVendidos(c,v))
            {
                Vehiculos_Vendidos.Remove(new Vehiculos_VendidosDato(c, v).Clave);
                ComercialDato cd = SELECT_Comercial(new Comercial(c.Codigo, "", "", null));
                c = cd.PasoAComercial();
                c.Vehiculos.Remove(v.NumBastidor);
                UPDATE_Comercial(c);
            }
        }

        ////////////////////////////////////////////////////////////////////////// Cliente Presupuesto ///////////////////////////////////////////////////////////////////////////////

        /// <summary>
        /// pre: c distinto de null y existente en la base de datos
        /// post: devuelve un listado con las claves de los vehiculos vendidos por el comercial c
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
      /*  public static ClientePresupuesto SELECT_ClientePresupuesto(Cliente c)
        {
            ClientePresupuesto clipres = ClientePresupuesto[c.DNI]; // le tienes que pasar una tupla formada por (dni, id), tal como has definido la clave en ClientePresupuesto.cs
            return clipres;
        }
      */

        public static List<ClientePresupuesto> SELECT_ALL_ClientePresupuesto() {
            List<ClientePresupuesto> cliente_presupuesto = new List<ClientePresupuesto>();
            foreach (ClientePresupuesto n in ClientePresupuesto) {
                cliente_presupuesto.Add(n);
            }
            return cliente_presupuesto;
        }

        /// <summary>
        /// pre: c y p distintos de null y no existen en la base de datos
        /// post: añade el par c,p en la tabla clientePresupuesto
        /// </summary>
        /// <param name="c"></param>
        /// <param name="v"></param>
        public static void INSERT_ClientePresupuesto(Cliente c, Presupuesto p)
        {
            ClientePresupuesto.Add(new ClientePresupuesto(c, p));
        }

        /// <summary>
        /// pre: c y p distintos de null
        /// post: devuelve TRUE si existe el par c,p; FALSE en caso contrario
        /// </summary>
        /// <param name="c"></param>
        /// <param name="v"></param>
        /// <returns></returns>
        public static bool EXISTE_ClientePresupuesto(Cliente c, Presupuesto p)
        {
            bool existe = false;
            if (ClientePresupuesto.Contains(new Tuple<String,String>(c.DNI,p.ID)))
            {
                existe = true;
            }
            return existe;
        }

        /// <summary>
        /// pre: c y v no nulos y existentes en la base de datos
        /// post: borra la tupla c,v de la base de datos
        /// </summary>
        /// <param name="c"></param>
        /// <param name="v"></param>
        public static void DELETE_ClientePresupuesto(Cliente c, Presupuesto p)
        {
            if (EXISTE_ClientePresupuesto(c, p))
            {
                ClientePresupuesto cpn = new ClientePresupuesto(c, p);
                cpn.Borrado = true;
                ClientePresupuesto.Remove(new Tuple<string, string>(c.DNI,p.ID));
                ClientePresupuesto.Add(cpn);
            }
        }

        ////////////////////////////////////////////////////////////////////////// EXTRA ///////////////////////////////////////////////////////////////////////////////

        /// <summary>
        /// pre: e distinto de null y existente en la base de datos
        /// post:
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        public static ExtraDato SELECT_Extra(Extra e)
        {
            if (EXISTE_Extra(e))
            {
                return Extras[e.Nombre];

            }
            return null;
        }

        public static List<ExtraDato> SELECT_ALL_Extra() {
            List<ExtraDato> extras = new List<ExtraDato>();
            foreach (ExtraDato n in Extras) {
                extras.Add(n);
            }
            return extras;
        }

        /// <summary>
        /// pre:
        /// post:
        /// </summary>
        /// <param name="e"></param>
        public static void INSERT_Extra(Extra e)
        {
            if (!EXISTE_Extra(e))
            {
                Extras.Add(new ExtraDato(e));
            }
        }

        /// <summary>
        /// pre:
        /// post:
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        public static bool EXISTE_Extra(Extra e)
        {
            bool existe = false;
            int i = 0;
            while (i < Extras.Count)
            {
                ExtraDato ed = Extras.ElementAt(i);
                if (ed.Nombre.Equals(e.Nombre))
                {
                    existe = true;
                }
                i++;
            }
            return existe;
        }

        /// <summary>
        /// pre:
        /// post: 
        /// </summary>
        /// <param name="e"></param>
        private static void UPDATE_Extra(Extra e)
        {
            if (EXISTE_Extra(e))
            {
                Extras.Remove(new ExtraDato(e).Nombre);
                BD.INSERT_Extra(e);
            }
        }

        /// <summary>
        /// pre:
        /// post:
        /// </summary>
        /// <param name="e"></param>
        private static void DELETE_Extra(Extra e)
        {
            if (EXISTE_Extra(e))
            {
                Extras.Remove(new ExtraDato(e).Nombre);
            }
        }

        ////////////////////////////////////////////////////////////////////////// EXTRA_VEHICULO ///////////////////////////////////////////////////////////////////////////////

        /// <summary>
        /// pre: e distinto de null y existente en la base de datos
        /// post:
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        public static List<ExtraVehiculoDato> SELECT_ExtraVehiculo(Vehiculo v)
        {
            if (EXISTE_ExtraVehiculo(v))
            {
                List<ExtraVehiculoDato> extras = new List<ExtraVehiculoDato>();
                foreach(ExtraVehiculoDato i in Vehiculo_Extra) {
                    if(i.NumBastidor_Nombre.Item1.Equals(v.NumBastidor)) {
                        extras.Add(i);
                    }
                }
                return extras;

            }
            return null;
        }

        public static List<ExtraVehiculoDato> SELECT_ALL_ExtraVehiculo() {
            List<ExtraVehiculoDato> extra_vehiculo = new List<ExtraVehiculoDato>();
            foreach (ExtraVehiculoDato n in Vehiculo_Extra) {
                extra_vehiculo.Add(n);
            }
            return extra_vehiculo;
        }

        /// <summary>
        /// pre:
        /// post:
        /// </summary>
        /// <param name="e"></param>
        public static void INSERT_ExtraVehiculo(Extra e, Vehiculo v)
        {
            if (!EXISTE_ExtraVehiculo(v))
            {
                Vehiculo_Extra.Add(new ExtraVehiculoDato(e, v));
            }
        }

        /// <summary>
        /// pre:
        /// post:
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        public static bool EXISTE_ExtraVehiculo(Vehiculo v)
        {
            bool existe = false;
            int i = 0;
            while (i < Vehiculo_Extra.Count)
            {
                ExtraVehiculoDato evd = Vehiculo_Extra.ElementAt(i);
                if (evd.NumBastidor_Nombre.Item1.Equals(v.NumBastidor))
                {
                    existe = true;
                }
                i++;
            }
            return existe;
        }

        /// <summary>
        /// pre:
        /// post: 
        /// </summary>
        /// <param name="e"></param>
        private static void UPDATE_ExtraVehiculo(Extra e, Vehiculo v)
        {
            if (EXISTE_ExtraVehiculo(v))
            {
                Extras.Remove(new ExtraVehiculoDato(e, v).NumBastidor_Nombre.Item1);
                BD.INSERT_ExtraVehiculo(e, v);
            }
        }

        /// <summary>
        /// pre:
        /// post:
        /// </summary>
        /// <param name="e"></param>
        private static void DELETE_ExtraVehiculo(Extra e, Vehiculo v)
        {
            if (EXISTE_ExtraVehiculo(v))
            {
                Extras.Remove(new ExtraVehiculoDato(e, v).NumBastidor_Nombre.Item1);
            }
        }
    }
}

