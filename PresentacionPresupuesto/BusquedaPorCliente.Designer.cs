﻿namespace PresentacionPresupuesto
{
    partial class BusquedaPorCliente
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
            this.listPresupuestos = new System.Windows.Forms.ListBox();
            this.vistaPresupuesto1 = new VistaPresupuesto();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listPresupuestos
            // 
            this.listPresupuestos.FormattingEnabled = true;
            this.listPresupuestos.Location = new System.Drawing.Point(12, 12);
            this.listPresupuestos.Name = "listPresupuestos";
            this.listPresupuestos.Size = new System.Drawing.Size(222, 342);
            this.listPresupuestos.TabIndex = 0;
            this.listPresupuestos.SelectedIndexChanged += new System.EventHandler(this.listPresupuestos_SelectedIndexChanged);
            // 
            // vistaPresupuesto1
            // 
            this.vistaPresupuesto1.Location = new System.Drawing.Point(240, 12);
            this.vistaPresupuesto1.Name = "vistaPresupuesto1";
            this.vistaPresupuesto1.Size = new System.Drawing.Size(327, 294);
            this.vistaPresupuesto1.TabIndex = 1;
            // 
            // btnCerrar
            // 
            this.btnCerrar.Location = new System.Drawing.Point(492, 331);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(75, 23);
            this.btnCerrar.TabIndex = 2;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.button1_Click);
            // 
            // BusquedaPorCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(576, 363);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.vistaPresupuesto1);
            this.Controls.Add(this.listPresupuestos);
            this.Name = "BusquedaPorCliente";
            this.Text = "BusquedaCliente";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listPresupuestos;
        private VistaPresupuesto vistaPresupuesto1;
        private System.Windows.Forms.Button btnCerrar;
    }
}