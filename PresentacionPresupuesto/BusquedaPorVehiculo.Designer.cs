namespace PresentacionPresupuesto
{
    partial class BusquedaPorVehiculo
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
            this.vistaPresupuesto = new PresentacionPresupuesto.VistaPresupuesto();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listPresupuestos
            // 
            this.listPresupuestos.FormattingEnabled = true;
            this.listPresupuestos.Location = new System.Drawing.Point(12, 12);
            this.listPresupuestos.Name = "listPresupuestos";
            this.listPresupuestos.Size = new System.Drawing.Size(269, 329);
            this.listPresupuestos.TabIndex = 0;
            this.listPresupuestos.SelectedIndexChanged += new System.EventHandler(this.listPresupuestos_SelectedIndexChanged);
            // 
            // vistaPresupuesto
            // 
            this.vistaPresupuesto.Location = new System.Drawing.Point(287, 12);
            this.vistaPresupuesto.Name = "vistaPresupuesto";
            this.vistaPresupuesto.Size = new System.Drawing.Size(302, 338);
            this.vistaPresupuesto.TabIndex = 1;
            // 
            // btnCerrar
            // 
            this.btnCerrar.Location = new System.Drawing.Point(505, 348);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(75, 23);
            this.btnCerrar.TabIndex = 2;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // BusquedaPorVehiculo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(592, 383);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.vistaPresupuesto);
            this.Controls.Add(this.listPresupuestos);
            this.Name = "BusquedaPorVehiculo";
            this.Text = "BusquedaPorVehiculo";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listPresupuestos;
        private VistaPresupuesto vistaPresupuesto;
        private System.Windows.Forms.Button btnCerrar;
    }
}