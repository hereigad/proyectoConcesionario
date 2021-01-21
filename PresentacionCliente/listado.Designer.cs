namespace PresentacionCliente
{
    partial class listado
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
            this.btDNI = new System.Windows.Forms.Button();
            this.lbDNI = new System.Windows.Forms.ListBox();
            this.btNombre = new System.Windows.Forms.Button();
            this.lbNombre = new System.Windows.Forms.ListBox();
            this.btImporte = new System.Windows.Forms.Button();
            this.lbImporte = new System.Windows.Forms.ListBox();
            this.btCerrar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btDNI
            // 
            this.btDNI.Location = new System.Drawing.Point(78, 54);
            this.btDNI.Name = "btDNI";
            this.btDNI.Size = new System.Drawing.Size(120, 23);
            this.btDNI.TabIndex = 0;
            this.btDNI.Text = "DNI";
            this.btDNI.UseVisualStyleBackColor = true;
            // 
            // lbDNI
            // 
            this.lbDNI.FormattingEnabled = true;
            this.lbDNI.Location = new System.Drawing.Point(78, 99);
            this.lbDNI.Name = "lbDNI";
            this.lbDNI.Size = new System.Drawing.Size(120, 277);
            this.lbDNI.TabIndex = 1;
            // 
            // btNombre
            // 
            this.btNombre.Location = new System.Drawing.Point(252, 54);
            this.btNombre.Name = "btNombre";
            this.btNombre.Size = new System.Drawing.Size(120, 23);
            this.btNombre.TabIndex = 2;
            this.btNombre.Text = "Nombre";
            this.btNombre.UseVisualStyleBackColor = true;
            // 
            // lbNombre
            // 
            this.lbNombre.FormattingEnabled = true;
            this.lbNombre.Location = new System.Drawing.Point(252, 99);
            this.lbNombre.Name = "lbNombre";
            this.lbNombre.Size = new System.Drawing.Size(120, 277);
            this.lbNombre.TabIndex = 3;
            // 
            // btImporte
            // 
            this.btImporte.Location = new System.Drawing.Point(418, 54);
            this.btImporte.Name = "btImporte";
            this.btImporte.Size = new System.Drawing.Size(120, 23);
            this.btImporte.TabIndex = 4;
            this.btImporte.Text = "Importe";
            this.btImporte.UseVisualStyleBackColor = true;
            // 
            // lbImporte
            // 
            this.lbImporte.FormattingEnabled = true;
            this.lbImporte.Location = new System.Drawing.Point(418, 99);
            this.lbImporte.Name = "lbImporte";
            this.lbImporte.Size = new System.Drawing.Size(120, 277);
            this.lbImporte.TabIndex = 5;
            // 
            // btCerrar
            // 
            this.btCerrar.Location = new System.Drawing.Point(252, 415);
            this.btCerrar.Name = "btCerrar";
            this.btCerrar.Size = new System.Drawing.Size(120, 23);
            this.btCerrar.TabIndex = 6;
            this.btCerrar.Text = "Cerrar";
            this.btCerrar.UseVisualStyleBackColor = true;
            this.btCerrar.Click += new System.EventHandler(this.btCerrar_Click);
            // 
            // listado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(662, 497);
            this.Controls.Add(this.btCerrar);
            this.Controls.Add(this.lbImporte);
            this.Controls.Add(this.btImporte);
            this.Controls.Add(this.lbNombre);
            this.Controls.Add(this.btNombre);
            this.Controls.Add(this.lbDNI);
            this.Controls.Add(this.btDNI);
            this.Name = "listado";
            this.Text = "Listado de Cliente";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btDNI;
        private System.Windows.Forms.ListBox lbDNI;
        private System.Windows.Forms.Button btNombre;
        private System.Windows.Forms.ListBox lbNombre;
        private System.Windows.Forms.Button btImporte;
        private System.Windows.Forms.ListBox lbImporte;
        private System.Windows.Forms.Button btCerrar;
    }
}