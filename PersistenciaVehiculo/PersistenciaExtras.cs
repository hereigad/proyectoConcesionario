using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModeloDominio;
using Persistencia;

namespace PersistenciaVehiculo {
    public static class PersistenciaExtras {
        public static Extra obtenerExtra(string nombre) {
            Extra e = new Extra(nombre, 0);
            ExtraDato ed = BD.SELECT_Extra(e);
            e = new Extra(ed.Nombre, ed.PVP);
            return e;
        }

        public static List<Extra> obtenerTodosExtras() {
            List<Extra> extras = new List<Extra>();
            List<ExtraDato> datos = BD.SELECT_ALL_Extra();
            foreach (ExtraDato n in datos) {
                extras.Add(obtenerExtra(n.Nombre));
            }
            return extras;
        }
    }
}
