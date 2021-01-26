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
        private Comercial com;
        public LogicaVehiculo(Comercial c) {
            com = c;
        }

        public bool altaVehiculo(Vehiculo v) {
            return PersistenciaVehiculo.PersistenciaVehiculo.altaVehiculo(v);
        }

        public bool bajaVehiculo(string numBastidor) {
            return PersistenciaVehiculo.PersistenciaVehiculo.bajaVehiculo(numBastidor);
        }

        public Vehiculo obtenerVehiculo(string numBastidor) {
            return PersistenciaVehiculo.PersistenciaVehiculo.obtenerVehiculo(numBastidor);
        }

        public List<Vehiculo> obtenerTodosVehiculos() {
            return PersistenciaVehiculo.PersistenciaVehiculo.obtenerTodosVehiculos();
        }

        public List<Vehiculo> obtenerVehiculosSegundaMano() {
            return PersistenciaVehiculo.PersistenciaVehiculo.obtenerVehiculosSegundaMano();
        }

        public Extra obtenerExtra(string nombre) {
            return PersistenciaExtras.obtenerExtra(nombre);
        }

        public List<Extra> obtenerExtras() {
            return PersistenciaExtras.obtenerTodosExtras();
        }
    }
}
