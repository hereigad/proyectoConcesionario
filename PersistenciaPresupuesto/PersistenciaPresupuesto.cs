using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Persistencia;
using ModeloDominio;
using Persistencia;

namespace PersistenciaPresupuesto
{
    public class PersistenciaPresupuesto
    {
        public static Presupuesto seleccionarPresupuesto(Presupuesto p) {
            Presupuesto presupuesto = null;
            PresupuestoDato pd = BD.SELECT_Presupuesto(p);
            Comercial comercial = BD.SELECT_Comercial(new ModeloDominio.Comercial(pd.Codigo, "","",null)).PasoAComercial();
            Cliente cliente = BD.SELECT_Cliente(new Cliente(pd.DNI, "", "", Categoria.A)).PasoACliente();
            presupuesto = new Presupuesto(pd.ID, pd.FechaRealizacion, pd.Estado, comercial, cliente);
            return presupuesto;
        }
    }
}
