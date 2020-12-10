using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeloDominio
{
    public class Vehiculo
    {
        private string numBastidor;
        private string marca;
        private string modelo;
        private string potencia;
        private int pvp;

        public Vehiculo(string numBastidor, string marca, string modelo, string potencia, int pvp)
        {
            this.numBastidor = numBastidor;
            this.marca = marca;
            this.modelo = modelo;
            this.potencia = potencia;
            this.pvp = pvp;
        }

        public string NumBastidor
        {
            get
            {
                return this.numBastidor;
            }
        } 

        public string Marca
        {
            get
            {
                return this.marca;
            }
        }

        public string Modelo
        {
            get
            {
                return this.modelo;
            }
        }

        public string Potencia
        {
            get
            {
                return this.potencia;
            }
        }

        public int Pvp
        {
            get
            {
                return this.pvp;
            }
        }
    }
}
