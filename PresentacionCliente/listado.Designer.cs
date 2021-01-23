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
            this.btDNI.Location = new System.Drawing.Point(104, 66);
            this.btDNI.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btDNI.Name = "btDNI";
            this.btDNI.Size = new System.Drawing.Size(160, 28);
            this.btDNI.TabIndex = 0;
            this.btDNI.Text = "DNI";
            this.btDNI.UseVisualStyleBackColor = true;
            this.btDNI.Click += new System.EventHandler(this.btDNI_Click);
            // 
            // lbDNI
            // 
            this.lbDNI.FormattingEnabled = true;
            this.lbDNI.ItemHeight = 16;
            this.lbDNI.Location = new System.Drawing.Point(104, 122);
            this.lbDNI.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lbDNI.Name = "lbDNI";
            this.lbDNI.Size = new System.Drawing.Size(159, 340);
            this.lbDNI.TabIndex = 1;
            // 
            // btNombre
            // 
            this.btNombre.Location = new System.Drawing.Point(336, 66);
            this.btNombre.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btNombre.Name = "btNombre";
            this.btNombre.Size = new System.Drawing.Size(160, 28);
            this.btNombre.TabIndex = 2;
            this.btNombre.Text = "Nombre";
            this.btNombre.UseVisualStyleBackColor = true;
            this.btNombre.Click += new System.EventHandler(this.btNombre_Click);
            // 
            // lbNombre
            // 
            this.lbNombre.FormattingEnabled = true;
            this.lbNombre.ItemHeight = 16;
            this.lbNombre.Location = new System.Drawing.Point(336, 122);
            this.lbNombre.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lbNombre.Name = "lbNombre";
            this.lbNombre.Size = new System.Drawing.Size(159, 340);
            this.lbNombre.TabIndex = 3;
            // 
            // btImporte
            // 
            this.btImporte.Location = new System.Drawing.Point(557, 66);
            this.btImporte.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btImporte.Name = "btImporte";
            this.btImporte.Size = new System.Drawing.Size(160, 28);
            this.btImporte.TabIndex = 4;
            this.btImporte.Text = "Importe";
            this.btImporte.UseVisualStyleBackColor = true;
            this.btImporte.Click += new System.EventHandler(this.btImporte_Click);
            // 
            // lbImporte
            // 
            this.lbImporte.FormattingEnabled = true;
            this.lbImporte.ItemHeight = 16;
            this.lbImporte.Location = new System.Drawing.Point(557, 122);
            this.lbImporte.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lbImporte.Name = "lbImporte";
            this.lbImporte.Size = new System.Drawing.Size(159, 340);
            this.lbImporte.TabIndex = 5;
            // 
            // btCerrar
            // 
            this.btCerrar.Location = new System.Drawing.Point(336, 511);
            this.btCerrar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btCerrar.Name = "btCerrar";
            this.btCerrar.Size = new System.Drawing.Size(160, 28);
            this.btCerrar.TabIndex = 6;
            this.btCerrar.Text = "Cerrar";
            this.btCerrar.UseVisualStyleBackColor = true;
            this.btCerrar.Click += new System.EventHandler(this.btCerrar_Click);
            // 
            // listado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(883, 612);
            this.Controls.Add(this.btCerrar);
            this.Controls.Add(this.lbImporte);
            this.Controls.Add(this.btImporte);
            this.Controls.Add(this.lbNombre);
            this.Controls.Add(this.btNombre);
            this.Controls.Add(this.lbDNI);
            this.Controls.Add(this.btDNI);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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