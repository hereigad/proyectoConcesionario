using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeloDominio
{
    public class Vehiculo: IEquatable<Vehiculo>
    {
        private string numBastidor;
        private string marca;
        private string modelo;
        private string potencia;
        private double pvp;

        public Vehiculo(string numBastidor, string marca, string modelo, string potencia, double pvp)
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

        public double Pvp
        {
            get
            {
                return this.pvp;
            }
            set
            {
                this.pvp = value;
            }
        }

        public bool Equals(Vehiculo v)
        {
            if(this.numBastidor.Equals(v.NumBastidor))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
