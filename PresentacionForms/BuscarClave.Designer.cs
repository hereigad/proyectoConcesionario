namespace PresentacionForms
{
    partial class BuscarClave
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.textoCamb = new System.Windows.Forms.Label();
            this.tbTexto = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(137, 273);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Aceptar";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(383, 272);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "Cancelar";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // textoCamb
            // 
            this.textoCamb.AutoSize = true;
            this.textoCamb.Location = new System.Drawing.Point(180, 85);
            this.textoCamb.Name = "textoCamb";
            this.textoCamb.Size = new System.Drawing.Size(46, 17);
            this.textoCamb.TabIndex = 2;
            this.textoCamb.Text = "label1";
            // 
            // tbTexto
            // 
            this.tbTexto.Location = new System.Drawing.Point(332, 85);
            this.tbTexto.Name = "tbTexto";
            this.tbTexto.Size = new System.Drawing.Size(100, 22);
            this.tbTexto.TabIndex = 3;
            // 
            // BuscarClave
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(658, 374);
            this.Controls.Add(this.tbTexto);
            this.Controls.Add(this.textoCamb);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "BuscarClave";
            this.Text = "BuscarClave";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label textoCamb;
        private System.Windows.Forms.TextBox tbTexto;
    }
}