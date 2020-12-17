using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeloDominio
{
    public class VehiculoSegundaMano : Vehiculo
    {
        private string matricula;
        private DateTime fechaMatricula;

        public VehiculoSegundaMano(string numBastidor, string marca, string modelo, string potencia, double pvp) : base(numBastidor, marca, modelo, potencia, pvp)
        {

        }
    }
}
