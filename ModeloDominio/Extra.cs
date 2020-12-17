using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeloDominio
{
    public class Extra
    {
        private string nombre;
        private double pvp;

        public Extra(string nombre, double pvp)
        {
            this.nombre = nombre;
            this.pvp = pvp * 1.21;
        }

        public double Pvp
        {
            get
            {
                return this.pvp;
            }
        }
    }
}
