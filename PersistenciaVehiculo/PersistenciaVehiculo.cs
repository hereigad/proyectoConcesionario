using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModeloDominio;
using Persistencia;

namespace PersistenciaVehiculo
{
    public static class PersistenciaVehiculo
    {
        public static bool altaVehivehiculo(Vehiculo v)
        {
            BD.INSERT_Vehiculo(v);
            if(BD.EXISTE_Vehiculo(v))
            {
                return true;
            }
            return false;
        }

        public static bool bajaVehiculo(string numBastidor)
        {
            Vehiculo v = new Vehiculo(numBastidor, null, null, null, 0);
            BD.DELETE_Vehiculo(v);
            if(!BD.EXISTE_Vehiculo(v))
            {
                return true;
            }
            return false;
        }

        public static Vehiculo obtenerVehiculo(string numBastidor)
        {
            Vehiculo v = new Vehiculo(numBastidor, null, null, null, 0);
            VehiculoDato vd = BD.SELECT_Vehiculo(v);
            if(vd.Nuevo)
            {
                v = new VehiculoNuevo(vd.NumBastidor, vd.Marca, vd.Modelo, vd.Potencia, vd.PVP, vd.)
            }
        }
    }
}
