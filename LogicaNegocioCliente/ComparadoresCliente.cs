using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModeloDominio;


namespace LogicaNegocioCliente
{
    public class ComparadoresCliente
    {
        /// <summary>
        /// pre: 
        /// post: compara los clientes por su DNI
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public static int ComparaDNI(Cliente c1, Cliente c2) {
            return c1.DNI.CompareTo(c2.DNI);
        
        }

        /// <summary>
        /// pre:
        /// post: compara los clientes por su Nombre
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public static int ComparaNombre(Cliente c1, Cliente c2) {
            return c1.Nombre.CompareTo(c2.Nombre);
        
        }

        /// <summary>
        /// pre: 
        /// post: compara los clientes por su importe
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public static int ComparaImporte(Cliente c1, Cliente c2) {
            return (int)(LogicaCliente.obtieneImporte(c1) - LogicaCliente.obtieneImporte(c2));
        
        }

    }
}
