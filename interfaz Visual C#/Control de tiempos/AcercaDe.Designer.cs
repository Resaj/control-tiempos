namespace Control_de_tiempos
{
    partial class AcercaDe
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
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
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.bt_Aceptar = new System.Windows.Forms.Button();
            this.lb_Datos3 = new System.Windows.Forms.Label();
            this.lb_Datos2 = new System.Windows.Forms.Label();
            this.lb_Datos1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // bt_Aceptar
            // 
            this.bt_Aceptar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.bt_Aceptar.Location = new System.Drawing.Point(268, 231);
            this.bt_Aceptar.Name = "bt_Aceptar";
            this.bt_Aceptar.Size = new System.Drawing.Size(75, 23);
            this.bt_Aceptar.TabIndex = 0;
            this.bt_Aceptar.Text = "Aceptar";
            this.bt_Aceptar.UseVisualStyleBackColor = true;
            // 
            // lb_Datos3
            // 
            this.lb_Datos3.AutoSize = true;
            this.lb_Datos3.BackColor = System.Drawing.Color.Transparent;
            this.lb_Datos3.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_Datos3.ForeColor = System.Drawing.Color.Goldenrod;
            this.lb_Datos3.Location = new System.Drawing.Point(166, 160);
            this.lb_Datos3.Name = "lb_Datos3";
            this.lb_Datos3.Size = new System.Drawing.Size(177, 21);
            this.lb_Datos3.TabIndex = 1;
            this.lb_Datos3.Text = "Rubén Espino San José";
            // 
            // lb_Datos2
            // 
            this.lb_Datos2.AutoSize = true;
            this.lb_Datos2.BackColor = System.Drawing.Color.Transparent;
            this.lb_Datos2.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_Datos2.ForeColor = System.Drawing.Color.Goldenrod;
            this.lb_Datos2.Location = new System.Drawing.Point(297, 195);
            this.lb_Datos2.Name = "lb_Datos2";
            this.lb_Datos2.Size = new System.Drawing.Size(46, 21);
            this.lb_Datos2.TabIndex = 2;
            this.lb_Datos2.Text = "2011";
            // 
            // lb_Datos1
            // 
            this.lb_Datos1.AutoSize = true;
            this.lb_Datos1.BackColor = System.Drawing.Color.Transparent;
            this.lb_Datos1.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_Datos1.ForeColor = System.Drawing.Color.Red;
            this.lb_Datos1.Location = new System.Drawing.Point(38, 9);
            this.lb_Datos1.Name = "lb_Datos1";
            this.lb_Datos1.Size = new System.Drawing.Size(280, 42);
            this.lb_Datos1.TabIndex = 3;
            this.lb_Datos1.Text = "Aplicación para el control de tiempos\r\ny velocidades";
            // 
            // AcercaDe
            // 
            this.AcceptButton = this.bt_Aceptar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.BackgroundImage = global::Control_de_tiempos.Properties.Resources.Puma_preview;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(355, 266);
            this.Controls.Add(this.lb_Datos1);
            this.Controls.Add(this.lb_Datos2);
            this.Controls.Add(this.lb_Datos3);
            this.Controls.Add(this.bt_Aceptar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AcercaDe";
            this.ShowIcon = false;
            this.Text = "Acerca de";
            this.Load += new System.EventHandler(this.AcercaDe_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bt_Aceptar;
        private System.Windows.Forms.Label lb_Datos3;
        private System.Windows.Forms.Label lb_Datos2;
        private System.Windows.Forms.Label lb_Datos1;
    }
}