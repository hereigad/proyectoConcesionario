using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModeloDominio;
namespace LogicaNegocioVehiculo
{
    class Comparadores
    {
        public static int ComparaDNI(Cliente c1,Cliente c2) {
           return c1.DNI.CompareTo(c2.DNI);


        }
    }
}
