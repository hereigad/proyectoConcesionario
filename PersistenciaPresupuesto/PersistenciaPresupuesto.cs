using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Persistencia;
using ModeloDominio;

namespace PersistenciaPresupuesto
{
    public class PersistenciaPresupuesto
    {
        public static Presupuesto seleccionarPresupuesto(Presupuesto p) {
            PresupuestoDato pd = BD.SELECT_Presupuesto(p);
            Comercial comercial = BD.SELECT_Comercial(new ModeloDominio.Comercial(pd.Codigo, "","",null)).PasoAComercial();
            Cliente cliente = BD.SELECT_Cliente(new Cliente(pd.DNI, "", "", Categoria.A)).PasoACliente();

            List<Vehiculo> vehiculos = new List<Vehiculo>();
            Tabla_PresupuestoVehiculo tabla = BD.Presupuesto_Vehiculos;
            foreach(Presupuesto_VehiculosDato pvd in tabla)
            {
                Vehiculo v = BD.SELECT_Vehiculo(new Vehiculo(pvd.NumBastidor, "", "", "", 0.0f)).PasoAVehiculo();
                vehiculos.Add(v);
            }

            return pd.PasoAPresupuesto(comercial, cliente, vehiculos);
        }
    }
}
