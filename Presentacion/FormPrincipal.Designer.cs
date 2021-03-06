﻿namespace Presentacion
{
    partial class FormPrincipal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.clientesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BTaltaCliente = new System.Windows.Forms.ToolStripMenuItem();
            this.BTbajaCliente = new System.Windows.Forms.ToolStripMenuItem();
            this.BTbusquedaCliente = new System.Windows.Forms.ToolStripMenuItem();
            this.verTotalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmListas = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmDesplegable = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmUnoAUno = new System.Windows.Forms.ToolStripMenuItem();
            this.vehículosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.altaToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.bajaToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.busquedaToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.listadoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.presupuestosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.altaPresupuesto = new System.Windows.Forms.ToolStripMenuItem();
            this.búsquedaPorClienteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.búsquedaPorVehiculoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.recorrerUnoAUnoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listarTodosLosPresupuestosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configuraciónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.presupuestosEnEstadoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.obtenerDatosClienteDelPresupuestoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.unoAUnoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clientesToolStripMenuItem,
            this.vehículosToolStripMenuItem,
            this.presupuestosToolStripMenuItem,
            this.configuraciónToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(600, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // clientesToolStripMenuItem
            // 
            this.clientesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BTaltaCliente,
            this.BTbajaCliente,
            this.BTbusquedaCliente,
            this.verTotalToolStripMenuItem});
            this.clientesToolStripMenuItem.Name = "clientesToolStripMenuItem";
            this.clientesToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.clientesToolStripMenuItem.Text = "Clientes";
            // 
            // BTaltaCliente
            // 
            this.BTaltaCliente.Name = "BTaltaCliente";
            this.BTaltaCliente.Size = new System.Drawing.Size(126, 22);
            this.BTaltaCliente.Text = "Alta";
            this.BTaltaCliente.Click += new System.EventHandler(this.BTaltaCliente_Click);
            // 
            // BTbajaCliente
            // 
            this.BTbajaCliente.Name = "BTbajaCliente";
            this.BTbajaCliente.Size = new System.Drawing.Size(126, 22);
            this.BTbajaCliente.Text = "Baja";
            this.BTbajaCliente.Click += new System.EventHandler(this.BTbajaCliente_Click);
            // 
            // BTbusquedaCliente
            // 
            this.BTbusquedaCliente.Name = "BTbusquedaCliente";
            this.BTbusquedaCliente.Size = new System.Drawing.Size(126, 22);
            this.BTbusquedaCliente.Text = "Búsqueda";
            this.BTbusquedaCliente.Click += new System.EventHandler(this.BTbusquedaCliente_Click);
            // 
            // verTotalToolStripMenuItem
            // 
            this.verTotalToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmListas,
            this.tsmDesplegable,
            this.tsmUnoAUno});
            this.verTotalToolStripMenuItem.Name = "verTotalToolStripMenuItem";
            this.verTotalToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.verTotalToolStripMenuItem.Text = "Ver total";
            // 
            // tsmListas
            // 
            this.tsmListas.Name = "tsmListas";
            this.tsmListas.Size = new System.Drawing.Size(156, 22);
            this.tsmListas.Text = "Listas";
            this.tsmListas.Click += new System.EventHandler(this.tsmListas_Click);
            // 
            // tsmDesplegable
            // 
            this.tsmDesplegable.Name = "tsmDesplegable";
            this.tsmDesplegable.Size = new System.Drawing.Size(156, 22);
            this.tsmDesplegable.Text = "Desplegable";
            this.tsmDesplegable.Click += new System.EventHandler(this.tsmDesplegable_Click);
            // 
            // tsmUnoAUno
            // 
            this.tsmUnoAUno.Name = "tsmUnoAUno";
            this.tsmUnoAUno.Size = new System.Drawing.Size(156, 22);
            this.tsmUnoAUno.Text = "Paso uno a uno";
            this.tsmUnoAUno.Click += new System.EventHandler(this.tsmUnoAUno_Click);
            // 
            // vehículosToolStripMenuItem
            // 
            this.vehículosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.altaToolStripMenuItem1,
            this.bajaToolStripMenuItem1,
            this.busquedaToolStripMenuItem1,
            this.listadoToolStripMenuItem,
            this.unoAUnoToolStripMenuItem});
            this.vehículosToolStripMenuItem.Name = "vehículosToolStripMenuItem";
            this.vehículosToolStripMenuItem.Size = new System.Drawing.Size(69, 20);
            this.vehículosToolStripMenuItem.Text = "Vehículos";
            // 
            // altaToolStripMenuItem1
            // 
            this.altaToolStripMenuItem1.Name = "altaToolStripMenuItem1";
            this.altaToolStripMenuItem1.Size = new System.Drawing.Size(126, 22);
            this.altaToolStripMenuItem1.Text = "Alta";
            this.altaToolStripMenuItem1.Click += new System.EventHandler(this.altaVehiculo_Click);
            // 
            // bajaToolStripMenuItem1
            // 
            this.bajaToolStripMenuItem1.Name = "bajaToolStripMenuItem1";
            this.bajaToolStripMenuItem1.Size = new System.Drawing.Size(126, 22);
            this.bajaToolStripMenuItem1.Text = "Baja";
            this.bajaToolStripMenuItem1.Click += new System.EventHandler(this.bajaVehiculo_Click);
            // 
            // busquedaToolStripMenuItem1
            // 
            this.busquedaToolStripMenuItem1.Name = "busquedaToolStripMenuItem1";
            this.busquedaToolStripMenuItem1.Size = new System.Drawing.Size(126, 22);
            this.busquedaToolStripMenuItem1.Text = "Búsqueda";
            this.busquedaToolStripMenuItem1.Click += new System.EventHandler(this.busquedaVehiculo_Click);
            // 
            // unoAUnoToolStripMenuItem
            // 
            this.unoAUnoToolStripMenuItem.Name = "unoAUnoToolStripMenuItem";
            this.unoAUnoToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.unoAUnoToolStripMenuItem.Text = "Uno a uno";
            this.unoAUnoToolStripMenuItem.Click += new System.EventHandler(this.unoAUnoVehiculos_Click);
            //
            // listadoToolStripMenuItem
            // 
            this.listadoToolStripMenuItem.Name = "listadoToolStripMenuItem";
            this.listadoToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.listadoToolStripMenuItem.Text = "Listado";
            this.listadoToolStripMenuItem.Click += new System.EventHandler(this.listadoVehiculos_Click);
            //
            // presupuestosToolStripMenuItem
            // 
            this.presupuestosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.altaPresupuesto,
            this.búsquedaPorClienteToolStripMenuItem,
            this.búsquedaPorVehiculoToolStripMenuItem,
            this.recorrerUnoAUnoToolStripMenuItem,
            this.listarTodosLosPresupuestosToolStripMenuItem,
            this.presupuestosEnEstadoToolStripMenuItem,
            this.obtenerDatosClienteDelPresupuestoToolStripMenuItem});
            this.presupuestosToolStripMenuItem.Name = "presupuestosToolStripMenuItem";
            this.presupuestosToolStripMenuItem.Size = new System.Drawing.Size(89, 20);
            this.presupuestosToolStripMenuItem.Text = "Presupuestos";
            // 
            // altaPresupuesto
            // 
            this.altaPresupuesto.Name = "altaPresupuesto";
            this.altaPresupuesto.Size = new System.Drawing.Size(226, 22);
            this.altaPresupuesto.Text = "Alta";
            this.altaPresupuesto.Click += new System.EventHandler(this.altaPresupuesto_Click);
            // 
            // búsquedaPorClienteToolStripMenuItem
            // 
            this.búsquedaPorClienteToolStripMenuItem.Name = "búsquedaPorClienteToolStripMenuItem";
            this.búsquedaPorClienteToolStripMenuItem.Size = new System.Drawing.Size(226, 22);
            this.búsquedaPorClienteToolStripMenuItem.Text = "Búsqueda por Cliente";
            this.búsquedaPorClienteToolStripMenuItem.Click += new System.EventHandler(this.búsquedaPorClienteToolStripMenuItem_Click);
            // 
            // búsquedaPorVehiculoToolStripMenuItem
            // 
            this.búsquedaPorVehiculoToolStripMenuItem.Name = "búsquedaPorVehiculoToolStripMenuItem";
            this.búsquedaPorVehiculoToolStripMenuItem.Size = new System.Drawing.Size(226, 22);
            this.búsquedaPorVehiculoToolStripMenuItem.Text = "Búsqueda por Vehiculo";
            this.búsquedaPorVehiculoToolStripMenuItem.Click += new System.EventHandler(this.búsquedaPorVehiculoToolStripMenuItem_Click);
            // 
            // recorrerUnoAUnoToolStripMenuItem
            // 
            this.recorrerUnoAUnoToolStripMenuItem.Name = "recorrerUnoAUnoToolStripMenuItem";
            this.recorrerUnoAUnoToolStripMenuItem.Size = new System.Drawing.Size(226, 22);
            this.recorrerUnoAUnoToolStripMenuItem.Text = "Recorrer uno a uno";
            this.recorrerUnoAUnoToolStripMenuItem.Click += new System.EventHandler(this.recorrerUnoAUnoToolStripMenuItem_Click);
            // 
            // listarTodosLosPresupuestosToolStripMenuItem
            // 
            this.listarTodosLosPresupuestosToolStripMenuItem.Name = "listarTodosLosPresupuestosToolStripMenuItem";
            this.listarTodosLosPresupuestosToolStripMenuItem.Size = new System.Drawing.Size(226, 22);
            this.listarTodosLosPresupuestosToolStripMenuItem.Text = "Listar todos los presupuestos";
            this.listarTodosLosPresupuestosToolStripMenuItem.Click += new System.EventHandler(this.listarTodosLosPresupuestosToolStripMenuItem_Click);
            // 
            // configuraciónToolStripMenuItem
            // 
            this.configuraciónToolStripMenuItem.Name = "configuraciónToolStripMenuItem";
            this.configuraciónToolStripMenuItem.Size = new System.Drawing.Size(95, 20);
            this.configuraciónToolStripMenuItem.Text = "Configuración";
            // 
            // presupuestosEnEstadoToolStripMenuItem
            // 
            this.presupuestosEnEstadoToolStripMenuItem.Name = "presupuestosEnEstadoToolStripMenuItem";
            this.presupuestosEnEstadoToolStripMenuItem.Size = new System.Drawing.Size(226, 22);
            this.presupuestosEnEstadoToolStripMenuItem.Text = "Presupuestos en estado";
            this.presupuestosEnEstadoToolStripMenuItem.Click += new System.EventHandler(this.presupuestosEnEstadoToolStripMenuItem_Click);
            // 
            // obtenerDatosClienteDelPresupuestoToolStripMenuItem
            // 
            this.obtenerDatosClienteDelPresupuestoToolStripMenuItem.Name = "obtenerDatosClienteDelPresupuestoToolStripMenuItem";
            this.obtenerDatosClienteDelPresupuestoToolStripMenuItem.Size = new System.Drawing.Size(295, 22);
            this.obtenerDatosClienteDelPresupuestoToolStripMenuItem.Text = "Obtener datos del Cliente del presupuesto";
            this.obtenerDatosClienteDelPresupuestoToolStripMenuItem.Click += new System.EventHandler(this.obtenerDatosClienteDelPresupuestoToolStripMenuItem_Click);
            // 
            // FormPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 366);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FormPrincipal";
            this.Text = "FormPrincipal";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem clientesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem BTaltaCliente;
        private System.Windows.Forms.ToolStripMenuItem BTbajaCliente;
        private System.Windows.Forms.ToolStripMenuItem BTbusquedaCliente;
        private System.Windows.Forms.ToolStripMenuItem vehículosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem presupuestosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem configuraciónToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem altaToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem bajaToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem busquedaToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem altaPresupuesto;
        private System.Windows.Forms.ToolStripMenuItem búsquedaPorClienteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem búsquedaPorVehiculoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem recorrerUnoAUnoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listarTodosLosPresupuestosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem verTotalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmListas;
        private System.Windows.Forms.ToolStripMenuItem tsmDesplegable;
        private System.Windows.Forms.ToolStripMenuItem tsmUnoAUno;
        private System.Windows.Forms.ToolStripMenuItem listadoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem presupuestosEnEstadoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem obtenerDatosClienteDelPresupuestoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem unoAUnoToolStripMenuItem;
    }
}