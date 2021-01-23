namespace PresentacionCliente
{
    partial class OtroForm
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
            this.lbDNI = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.lbNombre = new System.Windows.Forms.Label();
            this.lbApellidos = new System.Windows.Forms.Label();
            this.btCerrar = new System.Windows.Forms.Button();
            this.tbNombre = new System.Windows.Forms.TextBox();
            this.tbApellidos = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lbDNI
            // 
            this.lbDNI.AutoSize = true;
            this.lbDNI.Location = new System.Drawing.Point(165, 71);
            this.lbDNI.Name = "lbDNI";
            this.lbDNI.Size = new System.Drawing.Size(35, 17);
            this.lbDNI.TabIndex = 0;
            this.lbDNI.Text = "DNI:";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(263, 71);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 24);
            this.comboBox1.TabIndex = 1;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // lbNombre
            // 
            this.lbNombre.AutoSize = true;
            this.lbNombre.Location = new System.Drawing.Point(168, 190);
            this.lbNombre.Name = "lbNombre";
            this.lbNombre.Size = new System.Drawing.Size(58, 17);
            this.lbNombre.TabIndex = 2;
            this.lbNombre.Text = "Nombre";
            // 
            // lbApellidos
            // 
            this.lbApellidos.AutoSize = true;
            this.lbApellidos.Location = new System.Drawing.Point(168, 249);
            this.lbApellidos.Name = "lbApellidos";
            this.lbApellidos.Size = new System.Drawing.Size(65, 17);
            this.lbApellidos.TabIndex = 3;
            this.lbApellidos.Text = "Apellidos";
            // 
            // btCerrar
            // 
            this.btCerrar.Location = new System.Drawing.Point(245, 358);
            this.btCerrar.Name = "btCerrar";
            this.btCerrar.Size = new System.Drawing.Size(103, 30);
            this.btCerrar.TabIndex = 4;
            this.btCerrar.Text = "Cerrar";
            this.btCerrar.UseVisualStyleBackColor = true;
            this.btCerrar.Click += new System.EventHandler(this.btCerrar_Click);
            // 
            // tbNombre
            // 
            this.tbNombre.Location = new System.Drawing.Point(263, 190);
            this.tbNombre.Name = "tbNombre";
            this.tbNombre.ReadOnly = true;
            this.tbNombre.Size = new System.Drawing.Size(121, 22);
            this.tbNombre.TabIndex = 5;
            // 
            // tbApellidos
            // 
            this.tbApellidos.Location = new System.Drawing.Point(263, 249);
            this.tbApellidos.Name = "tbApellidos";
            this.tbApellidos.ReadOnly = true;
            this.tbApellidos.Size = new System.Drawing.Size(121, 22);
            this.tbApellidos.TabIndex = 6;
            // 
            // OtroForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(601, 450);
            this.Controls.Add(this.tbApellidos);
            this.Controls.Add(this.tbNombre);
            this.Controls.Add(this.btCerrar);
            this.Controls.Add(this.lbApellidos);
            this.Controls.Add(this.lbNombre);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.lbDNI);
            this.Name = "OtroForm";
            this.Text = "OtroForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbDNI;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label lbNombre;
        private System.Windows.Forms.Label lbApellidos;
        private System.Windows.Forms.Button btCerrar;
        private System.Windows.Forms.TextBox tbNombre;
        private System.Windows.Forms.TextBox tbApellidos;
    }
}