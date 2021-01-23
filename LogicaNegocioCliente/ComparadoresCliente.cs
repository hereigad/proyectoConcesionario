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
        public static int ComparaDNI(Cliente c1, Cliente c2) {
            return c1.DNI.CompareTo(c2.DNI);
        
        }
        public static int ComparaNombre(Cliente c1, Cliente c2) {
            return c1.Nombre.CompareTo(c2.Nombre);
        
        }

        public static int ComparaImporte(Cliente c1, Cliente c2) {
            return (int)(LogicaCliente.obtieneImporte(c1) - LogicaCliente.obtieneImporte(c2));
        
        }

    }
}
