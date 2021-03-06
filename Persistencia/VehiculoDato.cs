﻿using System;
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
        private bool nuevo = false;
        private bool borrado = false;
        private string matricula;
        private DateTime? fechaMatricula;

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
                matricula = null;
                fechaMatricula = null;
            }
            else
            {
                VehiculoSegundaMano vsm = (VehiculoSegundaMano)v;
                matricula = vsm.Matricula;
                fechaMatricula = vsm.FechaMatricula;
            }
        }

        public string NumBastidor
        {
            get
            {
                return this.numBastidor;
            }
        }

        public string Marca { get { return this.marca; } }
        public string Modelo { get { return this.modelo; } }
        public string Potencia { get { return this.potencia; } }
        public double PVP { get { return this.pvp; } }
        public bool Nuevo { get { return this.nuevo; } }

        public bool Borrado { get { return this.borrado; }
            set { this.borrado = value; }
        }

        public string Matricula {
            get {
                return this.matricula;
            }
        }

        public DateTime? FechaMatricula {
            get {
                return this.fechaMatricula;
            }
        }
        
        public Vehiculo PasoAVehiculo() {
            return new Vehiculo(this.NumBastidor,this.Marca,this.Modelo,this.Potencia,this.PVP);
        }

    }
}
