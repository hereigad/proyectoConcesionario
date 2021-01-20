using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersistenciaVehiculo;
using ModeloDominio;

namespace LogicaNegocioVehiculo
{
    public class LogicaVehiculo
    {
        public static bool altaVehiculo(Vehiculo v) {
            return PersistenciaVehiculo.PersistenciaVehiculo.altaVehiculo(v);
        }

        public static bool bajaVehiculo(string numBastidor) {
            return PersistenciaVehiculo.PersistenciaVehiculo.bajaVehiculo(numBastidor);
        }

        public static Vehiculo obtenerVehiculo(string numBastidor) {
            return PersistenciaVehiculo.PersistenciaVehiculo.obtenerVehiculo(numBastidor);
        }

        public static List<Vehiculo> obtenerTodosVehiculos() {
            return PersistenciaVehiculo.PersistenciaVehiculo.obtenerTodosVehiculos();
        }

        public static List<Vehiculo> obtenerVehiculosSegundaMano() {
            return PersistenciaVehiculo.PersistenciaVehiculo.obtenerVehiculosSegundaMano();
        }
    }
}
