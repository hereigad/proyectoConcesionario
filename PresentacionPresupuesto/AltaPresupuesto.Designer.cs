namespace PresentacionPresupuesto
{
    partial class AltaPresupuesto
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblDni = new System.Windows.Forms.Label();
            this.comboDNI = new System.Windows.Forms.ComboBox();
            this.listDisponibles = new System.Windows.Forms.ListBox();
            this.listPresupuesto = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAnadir = new System.Windows.Forms.Button();
            this.btnQuitar = new System.Windows.Forms.Button();
            this.btnAlta = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblDni
            // 
            this.lblDni.AutoSize = true;
            this.lblDni.Location = new System.Drawing.Point(75, 34);
            this.lblDni.Name = "lblDni";
            this.lblDni.Size = new System.Drawing.Size(64, 13);
            this.lblDni.TabIndex = 0;
            this.lblDni.Text = "DNI Cliente:";
            // 
            // comboDNI
            // 
            this.comboDNI.FormattingEnabled = true;
            this.comboDNI.Location = new System.Drawing.Point(145, 31);
            this.comboDNI.Name = "comboDNI";
            this.comboDNI.Size = new System.Drawing.Size(166, 21);
            this.comboDNI.TabIndex = 1;
            // 
            // listDisponibles
            // 
            this.listDisponibles.FormattingEnabled = true;
            this.listDisponibles.Location = new System.Drawing.Point(12, 108);
            this.listDisponibles.Name = "listDisponibles";
            this.listDisponibles.Size = new System.Drawing.Size(166, 186);
            this.listDisponibles.TabIndex = 2;
            // 
            // listPresupuesto
            // 
            this.listPresupuesto.FormattingEnabled = true;
            this.listPresupuesto.Location = new System.Drawing.Point(275, 108);
            this.listPresupuesto.Name = "listPresupuesto";
            this.listPresupuesto.Size = new System.Drawing.Size(166, 186);
            this.listPresupuesto.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 89);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Vehiculos Disponibles";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(275, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(164, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Vehiculos a hacer el presupuesto";
            // 
            // btnAnadir
            // 
            this.btnAnadir.Location = new System.Drawing.Point(184, 161);
            this.btnAnadir.Name = "btnAnadir";
            this.btnAnadir.Size = new System.Drawing.Size(85, 23);
            this.btnAnadir.TabIndex = 6;
            this.btnAnadir.Text = ">";
            this.btnAnadir.UseVisualStyleBackColor = true;
            // 
            // btnQuitar
            // 
            this.btnQuitar.Location = new System.Drawing.Point(184, 207);
            this.btnQuitar.Name = "btnQuitar";
            this.btnQuitar.Size = new System.Drawing.Size(85, 23);
            this.btnQuitar.TabIndex = 7;
            this.btnQuitar.Text = "<";
            this.btnQuitar.UseVisualStyleBackColor = true;
            // 
            // btnAlta
            // 
            this.btnAlta.Location = new System.Drawing.Point(184, 326);
            this.btnAlta.Name = "btnAlta";
            this.btnAlta.Size = new System.Drawing.Size(85, 23);
            this.btnAlta.TabIndex = 8;
            this.btnAlta.Text = "Dar de alta";
            this.btnAlta.UseVisualStyleBackColor = true;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(184, 372);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(85, 23);
            this.btnCancelar.TabIndex = 9;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // AltaPresupuesto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(476, 407);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAlta);
            this.Controls.Add(this.btnQuitar);
            this.Controls.Add(this.btnAnadir);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listPresupuesto);
            this.Controls.Add(this.listDisponibles);
            this.Controls.Add(this.comboDNI);
            this.Controls.Add(this.lblDni);
            this.Name = "AltaPresupuesto";
            this.Text = "Alta Presupuesto";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDni;
        private System.Windows.Forms.ComboBox comboDNI;
        private System.Windows.Forms.ListBox listDisponibles;
        private System.Windows.Forms.ListBox listPresupuesto;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnAnadir;
        private System.Windows.Forms.Button btnQuitar;
        private System.Windows.Forms.Button btnAlta;
        private System.Windows.Forms.Button btnCancelar;
    }
}

