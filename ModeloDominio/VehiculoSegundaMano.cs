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
        private DateTime? fechaMatricula;

        public VehiculoSegundaMano(string numBastidor, string marca, string modelo, string potencia, double pvp, string matricula, DateTime? fechaMatricula) : base(numBastidor, marca, modelo, potencia, pvp)
        {
            this.matricula = matricula;
            this.fechaMatricula = fechaMatricula;
        }

        public string Matricula
        {
            get
            {
                return this.matricula;
            }
        }

        public DateTime FechaMatricula
        {
            get
            {
                return this.fechaMatricula;
            }
        }
    }
}
