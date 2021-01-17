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
        /// <summary>
        /// pre: p distinto de null
        /// post: devuelve TRUE si el presupuesto p existe en la base de datos; FALSE en caso contrario
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public static bool existePresupuesto(Presupuesto p)
        {
            bool existe = false;
            if(BD.EXISTE_Presupuesto(p))
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
            if(BD.EXISTE_Presupuesto(p))
            {
                BD.SELECT_Presupuesto(p).Borrado = true;
                
                Tabla_ClientePresupuesto clientePresupuestos = BD.ClientePresupuesto;
                foreach(ClientePresupuesto cp in clientePresupuestos)
                {
                    if(cp.Clave.Item2.Equals(p.ID))
                    {
                        clientePresupuestos.Remove(cp.Clave);
                    }
                }

                Tabla_PresupuestoVehiculo presupuesto_Vehiculos = BD.Presupuesto_Vehiculos;
                foreach(Presupuesto_VehiculosDato pvd in presupuesto_Vehiculos)
                {
                    if(pvd.Clave.Item1.Equals(p.ID))
                    {
                        presupuesto_Vehiculos.Remove(pvd.Clave);
                    }
                }
                eliminado = true;
            }
            return eliminado;
        }

        /// <summary>
        /// pre: p distinto de null y existente en la base de datos
        /// post: devuelve el presupuesto de la base de datos según el id dado
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public static Presupuesto seleccionarPresupuesto(Presupuesto p) {
            PresupuestoDato pd = BD.SELECT_Presupuesto(p);
            
            Comercial comercial = BD.SELECT_Comercial(new ModeloDominio.Comercial(pd.Codigo, "","",null)).PasoAComercial();
            Cliente cliente = BD.SELECT_Cliente(new Cliente(pd.DNI, "", "", Categoria.A)).PasoACliente();
            List<Vehiculo> vehiculos = new List<Vehiculo>();
            Tabla_PresupuestoVehiculo tabla = BD.Presupuesto_Vehiculos;
            foreach(Presupuesto_VehiculosDato pvd in tabla)
            {
                Vehiculo v = BD.SELECT_Vehiculo(new Vehiculo(pvd.NumBastidor, "", "", "", 0.0f)).PasoAVehiculo();
                vehiculos.Add(v);
            }

            return pd.PasoAPresupuesto(comercial, cliente, vehiculos);
        }

        /// <summary>
        /// pre: comercial y cliente, existentes en la base de datos; los vehiculos, pueden existir o no
        /// post: crea un nuevo presupuesto con el comercial, cliente y listado de vehiculos y lo añade en la base de datos
        /// </summary>
        /// <param name="com"></param>
        /// <param name="cli"></param>
        /// <param name="vehi"></param>
        /// <returns></returns>
        public static bool crearPresupuesto(Comercial com, Cliente cli, List<Vehiculo> vehi)
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
    }
}
