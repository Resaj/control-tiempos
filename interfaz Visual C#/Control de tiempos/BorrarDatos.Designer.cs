namespace Control_de_tiempos
{
    partial class BorrarDatos
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
            this.lb_BorrarDatos = new System.Windows.Forms.Label();
            this.bt_Aceptar = new System.Windows.Forms.Button();
            this.bt_Cancelar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lb_BorrarDatos
            // 
            this.lb_BorrarDatos.AutoSize = true;
            this.lb_BorrarDatos.BackColor = System.Drawing.Color.Plum;
            this.lb_BorrarDatos.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_BorrarDatos.Location = new System.Drawing.Point(12, 9);
            this.lb_BorrarDatos.Name = "lb_BorrarDatos";
            this.lb_BorrarDatos.Size = new System.Drawing.Size(212, 34);
            this.lb_BorrarDatos.TabIndex = 0;
            this.lb_BorrarDatos.Text = "Va a borrar todos los datos,\r\n¿desea continuar?";
            this.lb_BorrarDatos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // bt_Aceptar
            // 
            this.bt_Aceptar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.bt_Aceptar.Location = new System.Drawing.Point(33, 53);
            this.bt_Aceptar.Name = "bt_Aceptar";
            this.bt_Aceptar.Size = new System.Drawing.Size(75, 23);
            this.bt_Aceptar.TabIndex = 1;
            this.bt_Aceptar.Text = "Aceptar";
            this.bt_Aceptar.UseVisualStyleBackColor = true;
            // 
            // bt_Cancelar
            // 
            this.bt_Cancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bt_Cancelar.Location = new System.Drawing.Point(127, 53);
            this.bt_Cancelar.Name = "bt_Cancelar";
            this.bt_Cancelar.Size = new System.Drawing.Size(75, 23);
            this.bt_Cancelar.TabIndex = 2;
            this.bt_Cancelar.Text = "Cancelar";
            this.bt_Cancelar.UseVisualStyleBackColor = true;
            // 
            // BorrarDatos
            // 
            this.AcceptButton = this.bt_Aceptar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Plum;
            this.CancelButton = this.bt_Cancelar;
            this.ClientSize = new System.Drawing.Size(231, 84);
            this.ControlBox = false;
            this.Controls.Add(this.bt_Cancelar);
            this.Controls.Add(this.bt_Aceptar);
            this.Controls.Add(this.lb_BorrarDatos);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "BorrarDatos";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Borrar datos";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lb_BorrarDatos;
        private System.Windows.Forms.Button bt_Aceptar;
        private System.Windows.Forms.Button bt_Cancelar;
    }
}