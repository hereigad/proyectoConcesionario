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
        private static Tabla_VehiculoVendido vehiculos_vendidos;

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
        /// pre: DNI debe de corresponder con el DNI de un cliente almacenado
        /// post: devuelve el cliente según el DNI pasado en el paramatro c
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public static Cliente SELECT_Cliente(Cliente c)
        {
            ClienteDatos dev = Clientes[c.DNI];
            if (dev.Borrado == false)
            {
                return dev.PasoACliente();
            }
            else {
                return null;
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
        public static Vehiculo SELECT_Vehiculo(Vehiculo v)
        {
            VehiculoDato dev = Vehiculos[v.NumBastidor];
            if (dev.Borrado == false)
            {
                return dev.PasoAVehiculo();
            }
            else
            {
                return null;
            }
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
                VehiculoDato act = Vehiculos.ElementAt(i);
                if (act.NumBastidor.Equals(v.NumBastidor))
                {
                    if (act.Borrado == false)
                    {
                        existe = true;
                    }
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
                VehiculoDato ins = Vehiculos[v.NumBastidor];//new VehiculoDato(v);
                Vehiculos.Remove(new VehiculoDato(v).NumBastidor);
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
        public static Presupuesto SELECT_Presupuesto(Presupuesto p)
        {
            PresupuestoDato pd = Presupuestos[p.ID];
            Comercial c = SELECT_Comercial(new Comercial(pd.Codigo,"","",null));
            Cliente cli = SELECT_Cliente(new Cliente(pd.DNI,"","",Categoria.A));
            //Aqui añadir el select de presupuestoVehiculos
            List<Vehiculo> listVeh = null;

            return pd.PasoAPresupuesto(listVeh,c,cli);
            /*Comercial c = SELECT_Comercial(new Comercial(pd.Codigo, "", ""));
            Cliente cl = SELECT_Cliente(new Cliente(pd.DNI, "", "", Categoria.A));
            List<Vehiculo> vehiculos = SELECT_PresupuestoVehiculos(p);
            return new Presupuesto(pd.ID, pd.FechaRealizacion, pd.Estado, c, cl, vehiculos, pd.Borrado);*/
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
        public static Comercial SELECT_Comercial(Comercial c)
        {
            ComercialDato dev = Comercial[c.Codigo];
            if (dev.Borrado == false)
            {
                return dev.PasoAComercial();
            }
            else
            {
                return null;
            }
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
                ComercialDato cd = Comercial[c.Codigo];//new ComercialDato(c);
                Comercial.Remove(new ComercialDato(c).Codigo);
                cd.Borrado = true;
                Comercial.Add(cd);
            }
        }

        //////////////////////////////////////////////////////////////////// Presupuesto_Vehiculos //////////////////////////////////////////////////////////////////////////////////////

        /// <summary>
        /// pre: p distinto de null y es un presupuesto presente en la base de datos en el cual se le puede pasar solo el identificador
        /// post: devuelve una lista con las claves de los vehiculos (el numero de bastidor) que tienen el presupuesto con el ID dado
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public static List<string> SELECT_PresupuestoVehiculos(Presupuesto p)
        {
            List<string> clavesVehiculos = new List<string>();
            Presupuesto presupuesto = BD.SELECT_Presupuesto(p);
            foreach(Vehiculo v in presupuesto.Vehiculos)
            {
                clavesVehiculos.Add(v.NumBastidor);
            }
            return clavesVehiculos;
        }

        
        /// <summary>
        /// pre: el presupuesto p y vehiculo v, existen en la base de datos y p, v, distintos de null
        /// post: añade el par p,v
        /// </summary>
        /// <param name="p"></param>
        /// <param name="v"></param>
        public static void INSERT_PresupuestoVehiculos(Presupuesto p, Vehiculo v)
        {
            Presupuesto_Vehiculos.Add(new Presupuesto_VehiculosDato(p,v));
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
            if(EXISTE_Presupuesto(p))
            {
                List<string> numBastidores = BD.SELECT_PresupuestoVehiculos(p);
                if(numBastidores.Contains(v.NumBastidor))
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
            Presupuesto_Vehiculos.Remove(new Presupuesto_VehiculosDato(p, v).ID);
        }

        ////////////////////////////////////////////////////////////////////////// VEHICULOS VENDIDOS ///////////////////////////////////////////////////////////////////////////////
        
        /// <summary>
        /// pre: c distinto de null y existente en la base de datos
        /// post: devuelve un listado con las claves de los vehiculos vendidos por el comercial c
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public static List<string> SELECT_VehiculosVendidos(Comercial c)
        {
            //return Vehiculos_Vendidos[v.NumBastidor];
            List<string> numBastidores = new List<string>();
            c = BD.SELECT_Comercial(new Comercial(c.Codigo,"","",null));
            foreach (string v in c.Vehiculos)
            {
                numBastidores.Add(v);
            }
            return numBastidores;
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
            c = BD.SELECT_Comercial(new Comercial(c.Codigo, "", "", null));
            c.Vehiculos.Add(v.NumBastidor);
            BD.UPDATE_Comercial(c);
        }

        /// <summary>
        /// pre: c y v existen en la base de datos cada uno en su tabla correspondiente
        /// post: devuelve TRUE si existe el par c,v; FALSE en caso contrario
        /// </summary>
        /// <param name="c"></param>
        /// <param name="v"></param>
        /// <returns></returns>
        public static bool EXISTE_VehiculosVendidos(Comercial c, Vehiculo v)
        {
            bool existe = false;
            if(Vehiculos_Vendidos.Contains(new Vehiculos_VendidosDato(c,v).Codigo))
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
        public static void DELETE_VehiculosVendidos(Comercial c, Vehiculo v)
        {
            Vehiculos_Vendidos.Remove(new Vehiculos_VendidosDato(c, v).Codigo);
            c = SELECT_Comercial(new Comercial(c.Codigo, "", "", null));
            c.Vehiculos.Remove(v.NumBastidor);
            UPDATE_Comercial(c);
        }
    }
}
