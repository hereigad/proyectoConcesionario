namespace PresentacionPresupuesto
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
            this.vistaPresupuesto = new PresentacionPresupuesto.VistaPresupuesto();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.listPresupuestos = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // vistaPresupuesto
            // 
            this.vistaPresupuesto.Location = new System.Drawing.Point(309, 12);
            this.vistaPresupuesto.Name = "vistaPresupuesto";
            this.vistaPresupuesto.Size = new System.Drawing.Size(302, 338);
            this.vistaPresupuesto.TabIndex = 0;
            // 
            // btnCerrar
            // 
            this.btnCerrar.Location = new System.Drawing.Point(536, 356);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(75, 23);
            this.btnCerrar.TabIndex = 1;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // listPresupuestos
            // 
            this.listPresupuestos.FormattingEnabled = true;
            this.listPresupuestos.Location = new System.Drawing.Point(12, 12);
            this.listPresupuestos.Name = "listPresupuestos";
            this.listPresupuestos.Size = new System.Drawing.Size(291, 329);
            this.listPresupuestos.TabIndex = 2;
            // 
            // BusquedaPorCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(621, 389);
            this.Controls.Add(this.listPresupuestos);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.vistaPresupuesto);
            this.Name = "BusquedaPorCliente";
            this.Text = "BusquedaPorCliente";
            this.ResumeLayout(false);

        }

        #endregion

        private VistaPresupuesto vistaPresupuesto;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.ListBox listPresupuestos;
    }
}