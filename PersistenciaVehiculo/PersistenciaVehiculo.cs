﻿using System;
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
        public static bool altaVehiculo(Vehiculo v)
        {
            if(BD.EXISTE_Vehiculo(v)) { 
                if(BD.SELECT_Vehiculo(v).Borrado == true) {
                    BD.UPDATE_Vehiculo(v);
                    return true;
                }
                return false;
            }
            if(v.GetType() == typeof(VehiculoNuevo)) {
                VehiculoNuevo vn = (VehiculoNuevo) v;
                foreach(Extra e in vn.Extras) {
                    BD.INSERT_ExtraVehiculo(e, v);
                }
            }
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
            if (BD.EXISTE_Vehiculo(v)) {
                BD.DELETE_Vehiculo(v);
                if (BD.SELECT_Vehiculo(v).Borrado == true) {
                    return true;
                }
            }
            
            return false;
        }

        public static Vehiculo obtenerVehiculo(string numBastidor)
        {
            Vehiculo v = new Vehiculo(numBastidor, null, null, null, 0);
            if (BD.EXISTE_Vehiculo(v)) {
                VehiculoDato vd = BD.SELECT_Vehiculo(v);
                if (vd.Nuevo) {
                    List<ExtraVehiculoDato> evd = BD.SELECT_ExtraVehiculo(v);
                    ExtraDato ed = null;
                    Extra e = null;
                    List<Extra> extras = new List<Extra>();
                    foreach (ExtraVehiculoDato n in evd) {
                        e = new Extra(n.NumBastidor_Nombre.Item2, 0);
                        ed = BD.SELECT_Extra(e);
                        e = new Extra(ed.Nombre, ed.PVP);
                        extras.Add(e);
                    }
                    v = new VehiculoNuevo(vd.NumBastidor, vd.Marca, vd.Modelo, vd.Potencia, vd.PVP, extras);
                } else {
                    v = new VehiculoSegundaMano(vd.NumBastidor, vd.Marca, vd.Modelo, vd.Potencia, vd.PVP, vd.Matricula, vd.FechaMatricula);
                }
                if(vd.Borrado) {
                    v = null;
                }
                return v;
            }
            return null;
        }

        public static List<Vehiculo> obtenerTodosVehiculos() {
            List<Vehiculo> vehiculos = new List<Vehiculo>();
            foreach(VehiculoDato n in BD.Vehiculos) {
                vehiculos.Add(obtenerVehiculo(n.NumBastidor));
            }
            return vehiculos;
        }

        public static List<Vehiculo> obtenerVehiculosSegundaMano() {
            List<Vehiculo> vehiculos = new List<Vehiculo>();
            foreach (VehiculoDato n in BD.Vehiculos) {
                if (!n.Nuevo) {
                    vehiculos.Add(obtenerVehiculo(n.NumBastidor));
                }
            }
            return vehiculos;
        }
    }
}
