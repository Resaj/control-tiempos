namespace Control_de_tiempos
{
    partial class ComprobarTx
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
            this.bt_Aceptar = new System.Windows.Forms.Button();
            this.bt_Cancelar = new System.Windows.Forms.Button();
            this.lb_ComprobarComunicación = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // bt_Aceptar
            // 
            this.bt_Aceptar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.bt_Aceptar.Location = new System.Drawing.Point(153, 89);
            this.bt_Aceptar.Name = "bt_Aceptar";
            this.bt_Aceptar.Size = new System.Drawing.Size(75, 23);
            this.bt_Aceptar.TabIndex = 0;
            this.bt_Aceptar.Text = "Aceptar";
            this.bt_Aceptar.UseVisualStyleBackColor = true;
            // 
            // bt_Cancelar
            // 
            this.bt_Cancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bt_Cancelar.Location = new System.Drawing.Point(234, 89);
            this.bt_Cancelar.Name = "bt_Cancelar";
            this.bt_Cancelar.Size = new System.Drawing.Size(75, 23);
            this.bt_Cancelar.TabIndex = 1;
            this.bt_Cancelar.Text = "Cancelar";
            this.bt_Cancelar.UseVisualStyleBackColor = true;
            // 
            // lb_ComprobarComunicación
            // 
            this.lb_ComprobarComunicación.AutoSize = true;
            this.lb_ComprobarComunicación.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_ComprobarComunicación.ForeColor = System.Drawing.Color.Crimson;
            this.lb_ComprobarComunicación.Location = new System.Drawing.Point(129, 12);
            this.lb_ComprobarComunicación.Name = "lb_ComprobarComunicación";
            this.lb_ComprobarComunicación.Size = new System.Drawing.Size(180, 54);
            this.lb_ComprobarComunicación.TabIndex = 2;
            this.lb_ComprobarComunicación.Text = "Compruebe que el\r\ndispositivo está\r\nconectado y resetéelo.";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Control_de_tiempos.Properties.Resources.Peligro;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(101, 100);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // ComprobarTx
            // 
            this.AcceptButton = this.bt_Aceptar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Plum;
            this.CancelButton = this.bt_Cancelar;
            this.ClientSize = new System.Drawing.Size(321, 129);
            this.ControlBox = false;
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lb_ComprobarComunicación);
            this.Controls.Add(this.bt_Cancelar);
            this.Controls.Add(this.bt_Aceptar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ComprobarTx";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Comprobar comunicación";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bt_Aceptar;
        private System.Windows.Forms.Button bt_Cancelar;
        private System.Windows.Forms.Label lb_ComprobarComunicación;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}