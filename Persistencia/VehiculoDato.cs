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
        private List<Extra> extras;

        private Vehiculo vehiculo;

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
            this.vehiculo = v;
        }

        public string NumBastidor
        {
            get
            {
                return this.numBastidor;
            }
        }

        public Vehiculo Vehiculo { get { return this.vehiculo; } }
    }
}
