namespace Control_de_tiempos
{
    partial class ComprobarPuerto
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
            this.Cancelar_ComprobarPuerto = new System.Windows.Forms.Button();
            this.lb_Puerto = new System.Windows.Forms.Label();
            this.Aceptar_ComprobarPuerto = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // Cancelar_ComprobarPuerto
            // 
            this.Cancelar_ComprobarPuerto.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Cancelar_ComprobarPuerto.Location = new System.Drawing.Point(203, 90);
            this.Cancelar_ComprobarPuerto.Name = "Cancelar_ComprobarPuerto";
            this.Cancelar_ComprobarPuerto.Size = new System.Drawing.Size(75, 23);
            this.Cancelar_ComprobarPuerto.TabIndex = 1;
            this.Cancelar_ComprobarPuerto.Text = "Cancelar";
            this.Cancelar_ComprobarPuerto.UseVisualStyleBackColor = true;
            // 
            // lb_Puerto
            // 
            this.lb_Puerto.AutoSize = true;
            this.lb_Puerto.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_Puerto.ForeColor = System.Drawing.Color.Crimson;
            this.lb_Puerto.Location = new System.Drawing.Point(129, 15);
            this.lb_Puerto.Name = "lb_Puerto";
            this.lb_Puerto.Size = new System.Drawing.Size(149, 54);
            this.lb_Puerto.TabIndex = 2;
            this.lb_Puerto.Text = "Antes de continuar\r\nconecte el cable al\r\npuerto.";
            // 
            // Aceptar_ComprobarPuerto
            // 
            this.Aceptar_ComprobarPuerto.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Aceptar_ComprobarPuerto.Location = new System.Drawing.Point(122, 90);
            this.Aceptar_ComprobarPuerto.Name = "Aceptar_ComprobarPuerto";
            this.Aceptar_ComprobarPuerto.Size = new System.Drawing.Size(75, 23);
            this.Aceptar_ComprobarPuerto.TabIndex = 0;
            this.Aceptar_ComprobarPuerto.Text = "Aceptar";
            this.Aceptar_ComprobarPuerto.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Control_de_tiempos.Properties.Resources.Cable;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(101, 101);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // ComprobarPuerto
            // 
            this.AcceptButton = this.Aceptar_ComprobarPuerto;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Plum;
            this.CancelButton = this.Cancelar_ComprobarPuerto;
            this.ClientSize = new System.Drawing.Size(294, 129);
            this.ControlBox = false;
            this.Controls.Add(this.Aceptar_ComprobarPuerto);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lb_Puerto);
            this.Controls.Add(this.Cancelar_ComprobarPuerto);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ComprobarPuerto";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Comprobar puerto";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Cancelar_ComprobarPuerto;
        private System.Windows.Forms.Label lb_Puerto;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button Aceptar_ComprobarPuerto;
    }
}