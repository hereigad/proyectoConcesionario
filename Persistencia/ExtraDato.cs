using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModeloDominio;

namespace Persistencia
{
    public class ExtraDato
    {
        private string nombre;
        private double pvp;

        public ExtraDato(Extra e)
        {
            this.nombre = e.Nombre;
            this.pvp = e.Pvp;
        }

        public string Nombre
        {
            get
            {
                return this.nombre;
            }
        }

        public double PVP
        {
            get
            {
                return this.PVP;
            }
        }
    }
}
