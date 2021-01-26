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
            this.label1 = new System.Windows.Forms.Label();
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
            this.listPresupuestos.Location = new System.Drawing.Point(12, 28);
            this.listPresupuestos.Name = "listPresupuestos";
            this.listPresupuestos.Size = new System.Drawing.Size(291, 316);
            this.listPresupuestos.TabIndex = 2;
            this.listPresupuestos.SelectedIndexChanged += new System.EventHandler(this.listPresupuestos_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Presupuestos:";
            // 
            // BusquedaPorCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(621, 389);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listPresupuestos);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.vistaPresupuesto);
            this.Name = "BusquedaPorCliente";
            this.Text = "BusquedaPorCliente";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private VistaPresupuesto vistaPresupuesto;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.ListBox listPresupuestos;
        private System.Windows.Forms.Label label1;
    }
}