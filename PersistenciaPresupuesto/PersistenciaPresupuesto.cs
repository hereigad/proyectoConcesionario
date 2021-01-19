using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Persistencia;
using ModeloDominio;

namespace PersistenciaPresupuesto
{
    public class PersistenciaPresupuesto
    {
        
        ////////////////////////////////////////////////////////////// TABLA PRESUPUESTO ///////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// pre: p distinto de null y existente en la base de datos; viene unicamente la clave
        /// post: devuelve el presupuesto de la base de datos según el id dado
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public static Presupuesto seleccionarPresupuesto(Presupuesto p) {
            PresupuestoDato pd = BD.SELECT_Presupuesto(p);
            
            Comercial comercial = BD.SELECT_Comercial(new ModeloDominio.Comercial(pd.Codigo, "","",null)).PasoAComercial();
            Cliente cliente = BD.SELECT_Cliente(new Cliente(pd.DNI, "", "", Categoria.A)).PasoACliente();
            List<Vehiculo> vehiculos = new List<Vehiculo>();
            List<Presupuesto_VehiculosDato> tabla = BD.SELECT_ALL_PresupuestoVehiculos();
            foreach(Presupuesto_VehiculosDato pvd in tabla)
            {
                Vehiculo v = BD.SELECT_Vehiculo(new Vehiculo(pvd.NumBastidor, "", "", "", 0.0f)).PasoAVehiculo();
                vehiculos.Add(v);
            }

            return pd.PasoAPresupuesto(comercial, cliente, vehiculos);
        }

        /// <summary>
        /// pre: -
        /// post: devuelve todos los presupuestos de la base de datos
        /// </summary>
        /// <returns></returns>
        public static List<Presupuesto> seleccionarTODOS_Presupuestos()
        {
            List<Presupuesto> lista = new List<Presupuesto>();
            List<PresupuestoDato> tabla = BD.SELECT_ALL_Presupuesto();
            foreach(PresupuestoDato pd in tabla)
            {
                Presupuesto p = seleccionarPresupuesto(new Presupuesto(pd.ID, pd.FechaRealizacion, pd.Estado, null, null, null));
                lista.Add(p);
            }
            return lista;
        }

        /// <summary>
        /// pre: p distinto de null
        /// post: devuelve TRUE si el presupuesto p existe en la base de datos; FALSE en caso contrario
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public static bool existePresupuesto(Presupuesto p)
        {
            bool existe = false;
            if (BD.EXISTE_Presupuesto(p))
            {
                existe = true;
            }
            return existe;
        }

        /// <summary>
        /// pre: p distinto de null
        /// post: devuelve TRUE si se ha llevado bien a cabo la operacion de eliminar; FALSE en caso contrario
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public static bool eliminarPresupuesto(Presupuesto p)
        {
            bool eliminado = false;
            if (BD.EXISTE_Presupuesto(p))
            {
                BD.SELECT_Presupuesto(p).Borrado = true;
                BD.UPDATE_Presupuesto(p);

                List<ClientePresupuesto> clientePresupuestos = BD.SELECT_ALL_ClientePresupuesto();
                foreach (ClientePresupuesto cp in clientePresupuestos)
                {
                    if (cp.Clave.Item2.Equals(p.ID))
                    {
                        clientePresupuestos.Remove(cp);
                    }
                }

                List<Presupuesto_VehiculosDato> presupuesto_Vehiculos = BD.SELECT_ALL_PresupuestoVehiculos();
                foreach (Presupuesto_VehiculosDato pvd in presupuesto_Vehiculos)
                {
                    if (pvd.Clave.Item1.Equals(p.ID))
                    {
                        presupuesto_Vehiculos.Remove(pvd);
                    }
                }
                eliminado = true;
            }
            return eliminado;
        }

        /// <summary>
        /// pre: p distinto de null; viene el objeto entero, no solo su clave; vehiculos, cliente y comercial del presupuesto dado, existen en la base de datos
        /// post: añade el presupuesto p a la base de datos y devuelve TRUE si se ha añadio con exito; FALSE en caso contrario
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public static bool anadirPresupuesto(Presupuesto p)
        {
            bool anadido = false;
            if(!existePresupuesto(p))
            {
                BD.INSERT_Presupuesto(p);
                BD.INSERT_ClientePresupuesto(p.Cliente, p);
                List<Vehiculo> v = p.Vehiculos;
                foreach(Vehiculo v1 in v)
                {
                    BD.INSERT_PresupuestoVehiculos(p, v1);
                }
                anadido = true;
            }
            return anadido;
        }

        ////////////////////////////////////////////////////////////////////////// TABLA PRESUPUESTO_VEHICULOS ////////////////////////////////////////////////////////////////
        
        /// <summary>
        /// pre: p distinto de null y existente en la base de datos
        /// post: devuelve un listado de vehiculos con el presupuesto p dado
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public static List<Vehiculo> seleccionarVehiculosPresupuesto(Presupuesto p)
        {
            List<Vehiculo> listado = new List<Vehiculo>();
            List<Presupuesto_VehiculosDato> tabla = BD.SELECT_ALL_PresupuestoVehiculos();
            foreach (Presupuesto_VehiculosDato pvd in tabla)
            {
                if(pvd.Clave.Item1.Equals(p.ID))
                {
                    string claveVehiculo = pvd.Clave.Item2;
                    Vehiculo v = BD.SELECT_Vehiculo(new Vehiculo(claveVehiculo, "", "", "", 0.0f)).PasoAVehiculo();
                    listado.Add(v);
                }
            }
            return listado;
        }

        /// <summary>
        /// pre: v distinto de null y existente en la base de datos; viene solo la clave del vehiculo (el numero de bastidor)
        /// post: devuelve una colección de presupuestos del vehiculo pedido
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        public static List<Presupuesto> seleccionarPresupuestosVehiculo(Vehiculo v)
        {
            List<Presupuesto> lista = new List<Presupuesto>();
            List<Presupuesto_VehiculosDato> tabla = BD.SELECT_ALL_PresupuestoVehiculos();
            foreach (Presupuesto_VehiculosDato pvd in tabla)
            {
                if (pvd.Clave.Item2.Equals(v.NumBastidor))
                {
                    string id = pvd.Clave.Item1;
                    Presupuesto p = seleccionarPresupuesto(new Presupuesto(id, DateTime.Now, EstadoPresupuesto.Aceptado, null, null, null));
                    lista.Add(p);
                }
            }
            return lista;
        }

        /// <summary>
        /// pre: p distinto de null y existente en la base de datos; los vehiculos pueden existir o no en la base de datos
        /// post: añade el listado de vehiculos al presupuesto p y devuelve TRUE; FALSE en caso contrario
        /// </summary>
        /// <param name="p"></param>
        /// <param name="vehiculos"></param>
        /// <returns></returns>
        public static bool anadirVehiculosPresupuesto(Presupuesto p, List<Vehiculo> vehiculos)
        {
            bool anadidos = false;
            foreach(Vehiculo v in vehiculos)
            {
                if(!BD.EXISTE_Vehiculo(v))
                {
                    BD.INSERT_Vehiculo(v);
                }
                BD.INSERT_PresupuestoVehiculos(p, v);
                anadidos = true;
            }
            return anadidos;
        }

        /// <summary>
        /// pre: p distinto de null y existente en la base de datos
        /// post: borra el listado de vehiculos del presupuesto p y devuelve TRUE; FALSE en caso contrario
        /// </summary>
        /// <param name="p"></param>
        /// <param name="vehiculos"></param>
        /// <returns></returns>
        public static bool borrarVehiculosPresupuesto(Presupuesto p, List<Vehiculo> vehiculos)
        {
            bool borrados = false;
            foreach(Vehiculo v in vehiculos)
            {
                BD.DELETE_PresupuestoVehiculos(p, v);
                borrados = true;
            }
            return borrados;
        }

        /// <summary>
        /// pre: p distinto de null y los vehiculos existentes en la vase de datos
        /// post: devuelve TRUE si existen los pares p,v; FALSE en caso contrario
        /// </summary>
        /// <param name="p"></param>
        /// <param name="vehiculos"></param>
        /// <returns></returns>
        public static bool existePresupuestoVehiculos(Presupuesto p, List<Vehiculo> vehiculos)
        {
            bool existe = false;
            foreach(Vehiculo v in vehiculos)
            {
                if (BD.EXISTE_PresupuestoVehiculo(p, v))
                {
                    existe = true;
                }
                else
                {
                    existe = false;
                    break;
                }
            }
            return existe;
        }

        ////////////////////////////////////////////////////////////// TABLA COMERCIAL //////////////////////////////////////////////////////////////////////
        
        /// <summary>
        /// pre: c distinto de null y existente en la base de datos
        /// post: devuelve el comercial con el codigo dado o null si no existe en la base de datos
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public static Comercial seleccionarComercial(Comercial c)
        {
            Comercial com = null;
            ComercialDato cd = BD.SELECT_Comercial(c);
            if(cd != null)
            {
                com = cd.PasoAComercial();
            }
            return com;
        }

        /// <summary>
        /// pre: c distinto de null
        /// post: devuelve TRUE si el comercial no existia y lo ha añadido; FALSE en caso contrario
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public static bool anadirComercial(Comercial c)
        {
            bool anadido = false;
            if(!BD.EXISTE_Comercial(c))
            {
                BD.INSERT_Comercial(c);
                anadido = true;
            }
            return anadido;
        }

        public static bool borrarComercial(Comercial c)
        {
            bool borrado = false;
            if(BD.EXISTE_Comercial(c))
            {
                BD.DELETE_Comercial(c);
                borrado = true;
            }
            return borrado;
        }

        public static bool existeComercial(Comercial c)
        {
            return BD.EXISTE_Comercial(c);
        }

        ////////////////////////////////////////////////////////// TABLA VEHICULOS_VENDIDOS //////////////////////////////////////////////////////////////////////
        
        /// <summary>
        /// pre: comercial c distinto de null y existente en la base de datos
        /// post: devuelve un listado de los vehiculos vendidos por el comercial c
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public static List<Vehiculo> seleccionarVehiculosVendidos(Comercial c)
        {
            List<Vehiculo> listado = new List<Vehiculo>();
            List<Vehiculos_VendidosDato> vvd = BD.SELECT_ALL_VehiculosVendidos();
            foreach(Vehiculos_VendidosDato wd in vvd)
            {
                if(wd.Clave.Item1.Equals(c.Codigo))
                {
                    string claveVehiculo = wd.Clave.Item2;
                    Vehiculo vehiculo = BD.SELECT_Vehiculo(new Vehiculo(claveVehiculo, "", "", "", 0.0f)).PasoAVehiculo();
                    listado.Add(vehiculo);
                }
            }
            return listado;
        }

        /// <summary>
        /// pre: comercial c distinto de null y existente en la base de datos y tambien los vehiculos
        /// post: añade el listado de vehiculos como vendidos en la base de datos
        /// </summary>
        /// <param name="c"></param>
        /// <param name="vehiculos"></param>
        /// <returns></returns>
        public static void anadirVehiculosVendidos(Comercial c, List<Vehiculo> vehiculos)
        {
            if(BD.EXISTE_Comercial(c))
            {
                foreach (Vehiculo v in vehiculos)
                {
                    if (BD.EXISTE_Vehiculo(v))
                    {
                        BD.INSERT_VehiculosVendidos(c, v);
                    }
                }
            }
            
        }

        /// <summary>
        /// pre: comercial c y vehiculos existentes en la base de datos y distintos de null
        /// post: para cada vehiculo, devuelve TRUE si existe el par c,v; FALSE en caso contrario
        /// </summary>
        /// <param name="c"></param>
        /// <param name="vehiculos"></param>
        /// <returns></returns>
        public static bool existeVehiculosVendidos(Comercial c, List<Vehiculo> vehiculos)
        {
            bool existe = false;
            foreach (Vehiculo v in vehiculos)
            {
                if (BD.EXISTE_VehiculosVendidos(c, v))
                {
                    existe = true;
                }
                else
                {
                    existe = false;
                    break;
                }
            }
            return existe;
        }

        /// <summary>
        /// pre: comercial c y vehiculos distintos de null y existentes en la base de datos, en la tabla vehiculos_vendidos
        /// post: para cada vehiculo de la lista, borra el par (c,v) si este existe
        /// </summary>
        /// <param name="c"></param>
        /// <param name="vehiculos"></param>
        public static void borrarVehiculosVendidos(Comercial c, List<Vehiculo> vehiculos)
        {
            foreach(Vehiculo v in vehiculos)
            {
                if(BD.EXISTE_VehiculosVendidos(c,v))
                {
                    BD.DELETE_VehiculosVendidos(c, v);
                }
            }
        }

        ////////////////////////////////////////////////////// TABLA CLIENTE_PRESUPUESTO //////////////////////////////////////////////////////////////////

        /// <summary>
        /// pre: presupuesto p distinto de null y existente en la base de datos
        /// post: devuelve el cliente del presupuesto p dado o null si no existe 
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public static Cliente seleccionarClientePresupuesto(Presupuesto p)
        {
            Cliente cli = null;
            List<ClientePresupuesto> tabla = BD.SELECT_ALL_ClientePresupuesto();
            foreach(ClientePresupuesto cp in tabla)
            {
                if(cp.Clave.Item2.Equals(p.ID))
                {
                    string dni = cp.Clave.Item1;
                    cli = BD.SELECT_Cliente(new Cliente(dni, "", "", Categoria.A)).PasoACliente();
                }
            }
            return cli;
        }

        /// <summary>
        /// pre: cliente c distinto de null y existente en la base de datos; viene solo la clave del cliente
        /// post: devuelve una coleccion de presupuestos del cliente c dado
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public static List<Presupuesto> seleccionarPresupuestosCliente(Cliente c)
        {
            List<Presupuesto> lista = new List<Presupuesto>();
            List<ClientePresupuesto> tabla = BD.SELECT_ALL_ClientePresupuesto();
            foreach (ClientePresupuesto cp in tabla)
            {
                if(cp.Clave.Item1.Equals(c.DNI))
                {
                    string id = cp.Clave.Item2;
                    Presupuesto p = seleccionarPresupuesto(new Presupuesto(id, DateTime.Now, EstadoPresupuesto.Aceptado, null, null, null));
                    lista.Add(p);
                }
            }
            return lista;
        }

        /// <summary>
        /// pre: c y p distintos de null
        /// post: devuelve TRUE si existe el par c,p; FALSE en caso contrario
        /// </summary>
        /// <param name="c"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        public static bool existeClientePresupuesto(Cliente c, Presupuesto p)
        {
            return BD.EXISTE_ClientePresupuesto(c, p);
        }

        /// <summary>
        /// pre: c y p distintos de null y no existen la base de datos
        /// post: añade el par c,p en la tabla clientePresupuesto
        /// </summary>
        /// <param name="c"></param>
        /// <param name="p"></param>
        public static void anadirClientePresupuesto(Cliente c, Presupuesto p)
        {
            BD.INSERT_ClientePresupuesto(c, p);
        }

        /// <summary>
        /// pre: cliente c y presupuesto p distintos de null
        /// post: borra el par (c,p) de la base de datos y devuelve TRUE; FALSE en caso contrario
        /// </summary>
        /// <param name="c"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        public static bool borarClientePresupuesto(Cliente c, Presupuesto p)
        {
            bool borrado = false;
            if(existeClientePresupuesto(c,p))
            {
                BD.DELETE_ClientePresupuesto(c, p);
                borrado = true;
            }
            return borrado;
        }

        /*
        /// <summary>
        /// pre: comercial y cliente, existentes en la base de datos; los vehiculos, pueden existir o no
        /// post: añade un nuevo presupuesto con el comercial, cliente y listado de vehiculos y lo añade en la base de datos
        /// </summary>
        /// <param name="com"></param>
        /// <param name="cli"></param>
        /// <param name="vehi"></param>
        /// <returns></returns>
        public static bool anadirPresupuesto(Comercial com, Cliente cli, List<Vehiculo> vehi)
        {
            bool alta = false;
            string id = com.Codigo + "_" + cli.DNI + "_" + vehi.Count(); // aqui no sabia que iba a poner en el id del presupuesto, que es clave.
                                                                        // Es algo que se me ha ocurrido. De alguna forma van a ser distintos, creo.
            Presupuesto p = new Presupuesto(id, DateTime.Now, EstadoPresupuesto.Pendiente, com, cli, vehi);
            if(!BD.EXISTE_Presupuesto(new Presupuesto(id, DateTime.Now, EstadoPresupuesto.Aceptado, null, null, null)))
            {
                BD.INSERT_Presupuesto(p);
                if(!BD.EXISTE_ClientePresupuesto(cli, p))
                {
                    BD.INSERT_ClientePresupuesto(cli, p);
                }
                foreach(Vehiculo v in vehi)
                {
                    if(!BD.EXISTE_Vehiculo(v))
                    {
                        BD.INSERT_Vehiculo(v);
                    }
                    BD.INSERT_PresupuestoVehiculos(p, v);
                }
                alta = true;
            }
            return alta;
        }
        
        
        /// <summary>
        /// pre: p distinto de null
        /// post: devuelve el cliente que tiene hecho el presupuesto p; null en el caso de que el presupuesto no existe en la base de datos
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public static Cliente clientePresupuesto(Presupuesto p)
        {
            Cliente c = null;
            if(BD.EXISTE_Presupuesto(p))
            {
                Tabla_ClientePresupuesto tabla = BD.ClientePresupuesto;
                foreach (ClientePresupuesto cp in tabla)
                {
                    if (cp.Clave.Item2.Equals(p.ID))
                    {
                        string dniCliente = cp.Clave.Item1;
                        ClienteDatos cd = BD.SELECT_Cliente(new Cliente(dniCliente, "", "", Categoria.A));
                        c = cd.PasoACliente();
                    }
                }
            }
            return c;
        }

        /// <summary>
        /// pre: el presupuesto p existe en la base de datos
        /// post: devuelve el estado del presupuesto dado
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public static EstadoPresupuesto obtenerEstadoPresupuesto(Presupuesto p)
        {
            return seleccionarPresupuesto(p).Estado;
        }

        /// <summary>
        /// pre: el presupuesto p existe en la base de datos
        /// post: devuelve TRUE si el presupuesto existe en la base de datos; FALSE en caso contrario
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public static bool presupuestoAceptado(Presupuesto p)
        {
            return seleccionarPresupuesto(p).isAceptado();
        }

        /// <summary>
        /// pre: c distinto de null
        /// post: devuelve el listado de presupuestos relacionados con el cliente
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public static List<Presupuesto> obtenerPresupuestosCliente(Cliente c)
        {
            List<Presupuesto> lista = new List<Presupuesto>();
            if(BD.EXISTE_Cliente(c))
            {
                Tabla_ClientePresupuesto tabla = BD.ClientePresupuesto;
                foreach(ClientePresupuesto cp in tabla)
                {
                    if(cp.Clave.Item1.Equals(c.DNI))
                    {
                        string idPresupuesto = cp.Clave.Item2;
                        Presupuesto p = seleccionarPresupuesto(new Presupuesto(idPresupuesto, new DateTime(), EstadoPresupuesto.Aceptado, null, null, null));
                        lista.Add(p);
                    }
                }
            }
            return lista;
        }

        /// <summary>
        /// pre: v distinto de null
        /// post: devuelve el listado de presupuestos relacionados con el vehiculo
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        public static List<Presupuesto> obtenerPresupuestosVehiculo(Vehiculo v)
        {
            List<Presupuesto> lista = new List<Presupuesto>();
            if(BD.EXISTE_Vehiculo(v))
            {
                Tabla_PresupuestoVehiculo tabla = BD.Presupuesto_Vehiculos;
                foreach(Presupuesto_VehiculosDato pvd in tabla)
                {
                    if(pvd.Clave.Item2.Equals(v.NumBastidor))
                    {
                        string idPresupuesto = pvd.Clave.Item1;
                        Presupuesto p = seleccionarPresupuesto(new Presupuesto(idPresupuesto, new DateTime(), EstadoPresupuesto.Aceptado, null, null, null));
                        lista.Add(p);
                    }
                }
            }
            return lista;
        }

        /// <summary>
        /// pre: -
        /// post: devuelve el listado de presupuestos en un estado dado
        /// </summary>
        /// <param name="estado"></param>
        /// <returns></returns>
        public static List<Presupuesto> presupuestosEnUnEstado(EstadoPresupuesto estado)
        {
            List<Presupuesto> lista = new List<Presupuesto>();
            TablaPresupuesto tabla = BD.Presupuestos;
            foreach(PresupuestoDato pd in tabla)
            {
                if(pd.Estado == estado)
                {
                    string idPresupuesto = pd.ID;
                    Presupuesto p = seleccionarPresupuesto(new Presupuesto(idPresupuesto, new DateTime(), estado, null, null, null));
                    lista.Add(p);
                }
            }
            return lista;
        }
        */
    }
}
