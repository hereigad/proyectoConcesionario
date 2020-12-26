using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModeloDominio;

namespace Persistencia
{
    public class VehiculoDato
    {
        private string numBastidor;
        private string marca;
        private string modelo;
        private string potencia;
        private double pvp;
        private bool nuevo;
        private bool borrado = false;
        private List<Extra> extras;

        public VehiculoDato(Vehiculo v)
        {
            this.numBastidor = v.NumBastidor;
            this.marca = v.Marca;
            this.modelo = v.Modelo;
            this.potencia = v.Potencia;
            this.pvp = v.Pvp;
            if(v.GetType() == typeof(VehiculoNuevo))
            {
                VehiculoNuevo vn = (VehiculoNuevo)v;
                nuevo = true;
                extras = vn.Extras;
            }
            else
            {
                extras = null;
            }
        }

        public string NumBastidor
        {
            get
            {
                return this.numBastidor;
            }
        }

        public string Marca { get { return this.marca; } }
        public string Modelo { get { return this.modelo; } }
        public string Potencia { get { return this.potencia; } }
        public double PVP { get { return this.pvp; } }
        public bool Nuevo { get { return this.nuevo; } }

        public bool Borrado { get { return this.borrado; }
            set { this.borrado = value; }
        }
        public List<Extra> Extras { get { return this.extras; } }
        
        public Vehiculo PasoAVehiculo() {
            return new Vehiculo(this.NumBastidor,this.Marca,this.Modelo,this.Potencia,this.PVP);
        }

    }
}
