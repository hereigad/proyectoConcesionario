using ModeloDominio;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Persistencia;
using PersistenciaPresupuesto;
using System.Data.SqlClient;

namespace PersistenciaCliente
{
    public class PersistenciaCliente
    {
        /// <summary>
        /// pre: c no existe en la base de datos y no es nulo
        /// post: devuelve true si el cliente ha sido añadido a la base de datos, false si no se ha podido
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public static bool anadirCliente(Cliente c) {
            string conexion = "Data Source=localhost;  User ID=sa ;Password=sasa;  Initial Catalog=ConcesionarioTOO";
            SqlConnection sqlc = null;
            SqlCommand com = null;
            bool exito = false;
            try
            {
                sqlc = new SqlConnection(conexion);
                sqlc.Open();
                com = new SqlCommand("INSERT INTO clientes VALUES (@DNI, @Nombre, @Telefono, @Categoria)", sqlc);
                com.Parameters.AddWithValue("@DNI", c.DNI);
                com.Parameters.AddWithValue("@Nombre", c.Nombre);
                com.Parameters.AddWithValue("@Telefono", c.Telefono);
                com.Parameters.AddWithValue("@Categoria", c.Categoria.ToString());
                com.ExecuteNonQuery();
                exito = true;
            }
            catch(SqlException e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                try
                {
                    if (sqlc != null)
                    {
                        sqlc.Close();
                    }
                }
                catch (SqlException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return exito;
        }

        /// <summary>
        /// pre: el DNI del cliente c debe existir en la Base de datos
        /// post: devuelve un objeto cliente con todos los datos del cliente c
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public static Cliente seleccionarCliente(Cliente c) {
            string conexion = "Data Source=localhost;  User ID=sa ;Password=sasa;  Initial Catalog=ConcesionarioTOO";
            Cliente cliente = null;
            SqlConnection sqlc = null;
            SqlCommand com = null;
            SqlDataReader reader = null;
            Categoria cat = Categoria.A;
            try
            {
                sqlc = new SqlConnection(conexion);
                sqlc.Open();
                com = new SqlCommand("SELECT * FROM clientes WHERE DNI = @DNI", sqlc);
                com.Parameters.AddWithValue("@DNI", c.DNI);
                reader = com.ExecuteReader();
                while(reader.Read())
                {
                    if(reader [3].ToString().Equals("A"))
                    {
                        cat = Categoria.A;
                    }
                    if (reader[3].ToString().Equals("B"))
                    {
                        cat = Categoria.B;
                    }
                    if (reader[3].ToString().Equals("C"))
                    {
                        cat = Categoria.C;
                    }
                    cliente = new Cliente(reader[0].ToString(), reader[1].ToString(), reader[2].ToString(), cat);
                }
            }
            catch(SqlException e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                try
                {
                    if (sqlc != null)
                    {
                        sqlc.Close();
                    }
                }
                catch (SqlException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return cliente;

        }
        /// <summary>
        /// pre: c no existe en la base de datos y no es nulo
        /// post: devuelve true si el cliente ha sido eliminado de la base de datos, false si no se ha podido
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public static bool eliminaCliente(Cliente c) {
            BD.DELETE_Cliente(c);
            if (BD.EXISTE_Cliente(c)) {
                return false;
            }
            return true;  
        }

        /// <summary>
        /// pre: 
        /// post: devuelve true si el cliente existe en la base de datos, false si no 
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public static bool existeCliente(Cliente c) {
            if (seleccionarCliente(c) != null) {
                return true;
            }
            return false;
        }

        /// <summary>
        /// pre: c no existe en la base de datos y no es nulo
        /// post: devuelve una lista con los presupuestos del cliente c
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public static List<Presupuesto> presupuestosDeCliente(Cliente c) {
            List<Presupuesto> lista = new List<Presupuesto>();
            Tabla_ClientePresupuesto tabla = BD.ClientePresupuesto;
            foreach (ClientePresupuesto p in tabla) {
                if (p.DNI.Equals(c.DNI)) {
                    lista.Add(PersistenciaPresupuesto.PersistenciaPresupuesto.seleccionarPresupuesto(new Presupuesto(p.ID,new DateTime(),EstadoPresupuesto.Aceptado,null,null,null)));    
                    
                }
            }
            return lista;
        
        }

        /// <summary>
        /// pre: c no existe en la base de datos y no es nulo
        /// post: devuelve una lista con los presupuestos aceptados del cliente c
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public static List<Presupuesto> presupuestosAceptados(Cliente c)
        {
            List<Presupuesto> listafin = new List<Presupuesto>();
            List<Presupuesto> lista = PersistenciaCliente.presupuestosDeCliente(c);
            foreach (Presupuesto p in lista)
            {
                if (p.Estado==EstadoPresupuesto.Aceptado)
                {

                    listafin.Add(p);

                }
            }
            return listafin;

        }


        /// <summary>
        /// pre: 
        /// post: devuelve una lista con todos los clientes pertenecientes a la categoria cat
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public static List<Cliente> clientesCategoria(Categoria cat) {
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
        /// <summary>
        /// pre:
        /// post: devuelve una lista con todos los clientes del concesionario
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public static List<Cliente> clientesConcesionario()
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
