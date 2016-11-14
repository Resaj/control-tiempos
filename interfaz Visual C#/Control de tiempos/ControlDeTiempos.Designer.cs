namespace Control_de_tiempos
{
    partial class ControlDeTiempos
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
            this.components = new System.ComponentModel.Container();
            this.menu_ControlDeTiempos = new System.Windows.Forms.MenuStrip();
            this.archivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.herramientasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_Borrar = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_ActivarTiempoPorSectores = new System.Windows.Forms.ToolStripMenuItem();
            this.ayudaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.acercaDeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lst_Tiempos1 = new System.Windows.Forms.ListBox();
            this.lst_Tiempos2 = new System.Windows.Forms.ListBox();
            this.lb_Datos1 = new System.Windows.Forms.Label();
            this.lb_Datos2 = new System.Windows.Forms.Label();
            this.lb_Datos3 = new System.Windows.Forms.Label();
            this.lst_Tiempos3 = new System.Windows.Forms.ListBox();
            this.tb_MejorTiempo1 = new System.Windows.Forms.TextBox();
            this.tb_MejorTiempo2 = new System.Windows.Forms.TextBox();
            this.tb_MejorTiempo3 = new System.Windows.Forms.TextBox();
            this.bt_Sectores = new System.Windows.Forms.Button();
            this.bt_Reset = new System.Windows.Forms.Button();
            this.bt_Tiempos = new System.Windows.Forms.Button();
            this.tb_Tiempos1 = new System.Windows.Forms.TextBox();
            this.tb_Tiempos2 = new System.Windows.Forms.TextBox();
            this.tb_Tiempos3 = new System.Windows.Forms.TextBox();
            this.mtb_Distancia = new System.Windows.Forms.MaskedTextBox();
            this.lb_Velocidad1 = new System.Windows.Forms.Label();
            this.lb_Velocidad3 = new System.Windows.Forms.Label();
            this.rb_Sectores2 = new System.Windows.Forms.RadioButton();
            this.rb_Sectores1 = new System.Windows.Forms.RadioButton();
            this.lb_Velocidad4 = new System.Windows.Forms.Label();
            this.lb_Velocidad2 = new System.Windows.Forms.Label();
            this.tb_Velocidad = new System.Windows.Forms.TextBox();
            this.tb_Vmax = new System.Windows.Forms.TextBox();
            this.lst_Velocidad = new System.Windows.Forms.ListBox();
            this.rb_Sectores3 = new System.Windows.Forms.RadioButton();
            this.SerialPort = new System.IO.Ports.SerialPort(this.components);
            this.timer_ControlDeTiempos = new System.Windows.Forms.Timer(this.components);
            this.rb_Sectores0 = new System.Windows.Forms.RadioButton();
            this.menu_ControlDeTiempos.SuspendLayout();
            this.SuspendLayout();
            // 
            // menu_ControlDeTiempos
            // 
            this.menu_ControlDeTiempos.Enabled = false;
            this.menu_ControlDeTiempos.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivoToolStripMenuItem,
            this.herramientasToolStripMenuItem,
            this.ayudaToolStripMenuItem});
            this.menu_ControlDeTiempos.Location = new System.Drawing.Point(0, 0);
            this.menu_ControlDeTiempos.Name = "menu_ControlDeTiempos";
            this.menu_ControlDeTiempos.Size = new System.Drawing.Size(673, 24);
            this.menu_ControlDeTiempos.TabIndex = 0;
            this.menu_ControlDeTiempos.Text = "menu_ControlDeTiempos";
            // 
            // archivoToolStripMenuItem
            // 
            this.archivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.salirToolStripMenuItem});
            this.archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            this.archivoToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
            this.archivoToolStripMenuItem.Text = "Archivo";
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(105, 22);
            this.salirToolStripMenuItem.Text = "Salir";
            this.salirToolStripMenuItem.Click += new System.EventHandler(this.menu_Salir);
            // 
            // herramientasToolStripMenuItem
            // 
            this.herramientasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu_Borrar,
            this.menu_ActivarTiempoPorSectores});
            this.herramientasToolStripMenuItem.Name = "herramientasToolStripMenuItem";
            this.herramientasToolStripMenuItem.Size = new System.Drawing.Size(83, 20);
            this.herramientasToolStripMenuItem.Text = "Herramientas";
            // 
            // menu_Borrar
            // 
            this.menu_Borrar.Name = "menu_Borrar";
            this.menu_Borrar.Size = new System.Drawing.Size(217, 22);
            this.menu_Borrar.Text = "Borrar tiempos";
            this.menu_Borrar.Click += new System.EventHandler(this.bt_Borrar_Click);
            // 
            // menu_ActivarTiempoPorSectores
            // 
            this.menu_ActivarTiempoPorSectores.Name = "menu_ActivarTiempoPorSectores";
            this.menu_ActivarTiempoPorSectores.Size = new System.Drawing.Size(217, 22);
            this.menu_ActivarTiempoPorSectores.Text = "Activar tiempo por sectores";
            this.menu_ActivarTiempoPorSectores.Click += new System.EventHandler(this.bt_Sectores_Click);
            // 
            // ayudaToolStripMenuItem
            // 
            this.ayudaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.acercaDeToolStripMenuItem});
            this.ayudaToolStripMenuItem.Name = "ayudaToolStripMenuItem";
            this.ayudaToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.ayudaToolStripMenuItem.Text = "Ayuda";
            // 
            // acercaDeToolStripMenuItem
            // 
            this.acercaDeToolStripMenuItem.Name = "acercaDeToolStripMenuItem";
            this.acercaDeToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.acercaDeToolStripMenuItem.Text = "Acerca de";
            this.acercaDeToolStripMenuItem.Click += new System.EventHandler(this.menu_AcercaDe);
            // 
            // lst_Tiempos1
            // 
            this.lst_Tiempos1.FormattingEnabled = true;
            this.lst_Tiempos1.Location = new System.Drawing.Point(21, 108);
            this.lst_Tiempos1.Name = "lst_Tiempos1";
            this.lst_Tiempos1.Size = new System.Drawing.Size(120, 160);
            this.lst_Tiempos1.TabIndex = 2;
            // 
            // lst_Tiempos2
            // 
            this.lst_Tiempos2.FormattingEnabled = true;
            this.lst_Tiempos2.Location = new System.Drawing.Point(190, 108);
            this.lst_Tiempos2.Name = "lst_Tiempos2";
            this.lst_Tiempos2.Size = new System.Drawing.Size(120, 160);
            this.lst_Tiempos2.TabIndex = 3;
            // 
            // lb_Datos1
            // 
            this.lb_Datos1.AutoSize = true;
            this.lb_Datos1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_Datos1.ForeColor = System.Drawing.Color.DarkSlateBlue;
            this.lb_Datos1.Location = new System.Drawing.Point(18, 45);
            this.lb_Datos1.Name = "lb_Datos1";
            this.lb_Datos1.Size = new System.Drawing.Size(128, 16);
            this.lb_Datos1.TabIndex = 4;
            this.lb_Datos1.Text = "Tiempo por vuelta:";
            // 
            // lb_Datos2
            // 
            this.lb_Datos2.AutoSize = true;
            this.lb_Datos2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_Datos2.ForeColor = System.Drawing.Color.DarkSlateBlue;
            this.lb_Datos2.Location = new System.Drawing.Point(187, 45);
            this.lb_Datos2.Name = "lb_Datos2";
            this.lb_Datos2.Size = new System.Drawing.Size(134, 15);
            this.lb_Datos2.TabIndex = 5;
            this.lb_Datos2.Text = "Tiempo del 1er sector:";
            // 
            // lb_Datos3
            // 
            this.lb_Datos3.AutoSize = true;
            this.lb_Datos3.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_Datos3.ForeColor = System.Drawing.Color.DarkSlateBlue;
            this.lb_Datos3.Location = new System.Drawing.Point(357, 45);
            this.lb_Datos3.Name = "lb_Datos3";
            this.lb_Datos3.Size = new System.Drawing.Size(126, 15);
            this.lb_Datos3.TabIndex = 7;
            this.lb_Datos3.Text = "Tiempo del 2º sector:";
            // 
            // lst_Tiempos3
            // 
            this.lst_Tiempos3.FormattingEnabled = true;
            this.lst_Tiempos3.Location = new System.Drawing.Point(360, 108);
            this.lst_Tiempos3.Name = "lst_Tiempos3";
            this.lst_Tiempos3.Size = new System.Drawing.Size(120, 160);
            this.lst_Tiempos3.TabIndex = 9;
            // 
            // tb_MejorTiempo1
            // 
            this.tb_MejorTiempo1.BackColor = System.Drawing.Color.PaleGreen;
            this.tb_MejorTiempo1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_MejorTiempo1.Location = new System.Drawing.Point(21, 283);
            this.tb_MejorTiempo1.Name = "tb_MejorTiempo1";
            this.tb_MejorTiempo1.ReadOnly = true;
            this.tb_MejorTiempo1.Size = new System.Drawing.Size(120, 26);
            this.tb_MejorTiempo1.TabIndex = 10;
            this.tb_MejorTiempo1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tb_MejorTiempo2
            // 
            this.tb_MejorTiempo2.BackColor = System.Drawing.Color.PaleGreen;
            this.tb_MejorTiempo2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_MejorTiempo2.Location = new System.Drawing.Point(190, 283);
            this.tb_MejorTiempo2.Name = "tb_MejorTiempo2";
            this.tb_MejorTiempo2.ReadOnly = true;
            this.tb_MejorTiempo2.Size = new System.Drawing.Size(120, 26);
            this.tb_MejorTiempo2.TabIndex = 11;
            this.tb_MejorTiempo2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tb_MejorTiempo3
            // 
            this.tb_MejorTiempo3.BackColor = System.Drawing.Color.PaleGreen;
            this.tb_MejorTiempo3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_MejorTiempo3.Location = new System.Drawing.Point(360, 283);
            this.tb_MejorTiempo3.Name = "tb_MejorTiempo3";
            this.tb_MejorTiempo3.ReadOnly = true;
            this.tb_MejorTiempo3.Size = new System.Drawing.Size(120, 26);
            this.tb_MejorTiempo3.TabIndex = 12;
            this.tb_MejorTiempo3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // bt_Sectores
            // 
            this.bt_Sectores.Enabled = false;
            this.bt_Sectores.Location = new System.Drawing.Point(190, 339);
            this.bt_Sectores.Name = "bt_Sectores";
            this.bt_Sectores.Size = new System.Drawing.Size(120, 38);
            this.bt_Sectores.TabIndex = 13;
            this.bt_Sectores.Text = "Activar tiempo por sectores";
            this.bt_Sectores.UseVisualStyleBackColor = true;
            this.bt_Sectores.Click += new System.EventHandler(this.bt_Sectores_Click);
            // 
            // bt_Reset
            // 
            this.bt_Reset.BackColor = System.Drawing.Color.OrangeRed;
            this.bt_Reset.Enabled = false;
            this.bt_Reset.Location = new System.Drawing.Point(21, 363);
            this.bt_Reset.Name = "bt_Reset";
            this.bt_Reset.Size = new System.Drawing.Size(120, 23);
            this.bt_Reset.TabIndex = 14;
            this.bt_Reset.Text = "Borrar tiempos";
            this.bt_Reset.UseVisualStyleBackColor = false;
            this.bt_Reset.Click += new System.EventHandler(this.bt_Borrar_Click);
            // 
            // bt_Tiempos
            // 
            this.bt_Tiempos.BackColor = System.Drawing.Color.LawnGreen;
            this.bt_Tiempos.Enabled = false;
            this.bt_Tiempos.Location = new System.Drawing.Point(21, 334);
            this.bt_Tiempos.Name = "bt_Tiempos";
            this.bt_Tiempos.Size = new System.Drawing.Size(120, 23);
            this.bt_Tiempos.TabIndex = 16;
            this.bt_Tiempos.Text = "Comenzar control";
            this.bt_Tiempos.UseVisualStyleBackColor = false;
            this.bt_Tiempos.Click += new System.EventHandler(this.bt_Tiempos_Click);
            // 
            // tb_Tiempos1
            // 
            this.tb_Tiempos1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_Tiempos1.Location = new System.Drawing.Point(21, 72);
            this.tb_Tiempos1.Name = "tb_Tiempos1";
            this.tb_Tiempos1.ReadOnly = true;
            this.tb_Tiempos1.Size = new System.Drawing.Size(120, 20);
            this.tb_Tiempos1.TabIndex = 18;
            this.tb_Tiempos1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tb_Tiempos2
            // 
            this.tb_Tiempos2.BackColor = System.Drawing.SystemColors.ControlDark;
            this.tb_Tiempos2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_Tiempos2.Location = new System.Drawing.Point(190, 72);
            this.tb_Tiempos2.Name = "tb_Tiempos2";
            this.tb_Tiempos2.ReadOnly = true;
            this.tb_Tiempos2.Size = new System.Drawing.Size(120, 20);
            this.tb_Tiempos2.TabIndex = 19;
            this.tb_Tiempos2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tb_Tiempos3
            // 
            this.tb_Tiempos3.BackColor = System.Drawing.SystemColors.ControlDark;
            this.tb_Tiempos3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_Tiempos3.Location = new System.Drawing.Point(360, 72);
            this.tb_Tiempos3.Name = "tb_Tiempos3";
            this.tb_Tiempos3.ReadOnly = true;
            this.tb_Tiempos3.Size = new System.Drawing.Size(120, 20);
            this.tb_Tiempos3.TabIndex = 20;
            this.tb_Tiempos3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // mtb_Distancia
            // 
            this.mtb_Distancia.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.mtb_Distancia.Location = new System.Drawing.Point(472, 337);
            this.mtb_Distancia.Mask = "9,99";
            this.mtb_Distancia.Name = "mtb_Distancia";
            this.mtb_Distancia.PromptChar = '0';
            this.mtb_Distancia.Size = new System.Drawing.Size(37, 20);
            this.mtb_Distancia.TabIndex = 29;
            this.mtb_Distancia.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mtb_Distancia.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePrompt;
            // 
            // lb_Velocidad1
            // 
            this.lb_Velocidad1.AutoSize = true;
            this.lb_Velocidad1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_Velocidad1.ForeColor = System.Drawing.Color.DarkSlateBlue;
            this.lb_Velocidad1.Location = new System.Drawing.Point(535, 46);
            this.lb_Velocidad1.Name = "lb_Velocidad1";
            this.lb_Velocidad1.Size = new System.Drawing.Size(105, 15);
            this.lb_Velocidad1.TabIndex = 26;
            this.lb_Velocidad1.Text = "VELOCIDAD (m/s)";
            // 
            // lb_Velocidad3
            // 
            this.lb_Velocidad3.AutoSize = true;
            this.lb_Velocidad3.BackColor = System.Drawing.Color.Plum;
            this.lb_Velocidad3.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_Velocidad3.Location = new System.Drawing.Point(515, 338);
            this.lb_Velocidad3.Name = "lb_Velocidad3";
            this.lb_Velocidad3.Size = new System.Drawing.Size(48, 15);
            this.lb_Velocidad3.TabIndex = 25;
            this.lb_Velocidad3.Text = "metros";
            // 
            // rb_Sectores2
            // 
            this.rb_Sectores2.AutoSize = true;
            this.rb_Sectores2.BackColor = System.Drawing.Color.Plum;
            this.rb_Sectores2.Enabled = false;
            this.rb_Sectores2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb_Sectores2.Location = new System.Drawing.Point(500, 392);
            this.rb_Sectores2.Name = "rb_Sectores2";
            this.rb_Sectores2.Size = new System.Drawing.Size(73, 19);
            this.rb_Sectores2.TabIndex = 24;
            this.rb_Sectores2.Text = "Sector 2";
            this.rb_Sectores2.UseVisualStyleBackColor = false;
            // 
            // rb_Sectores1
            // 
            this.rb_Sectores1.AutoSize = true;
            this.rb_Sectores1.BackColor = System.Drawing.Color.Plum;
            this.rb_Sectores1.Enabled = false;
            this.rb_Sectores1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb_Sectores1.Location = new System.Drawing.Point(421, 392);
            this.rb_Sectores1.Name = "rb_Sectores1";
            this.rb_Sectores1.Size = new System.Drawing.Size(73, 19);
            this.rb_Sectores1.TabIndex = 23;
            this.rb_Sectores1.Text = "Sector 1";
            this.rb_Sectores1.UseVisualStyleBackColor = false;
            // 
            // lb_Velocidad4
            // 
            this.lb_Velocidad4.AutoSize = true;
            this.lb_Velocidad4.BackColor = System.Drawing.Color.Plum;
            this.lb_Velocidad4.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_Velocidad4.Location = new System.Drawing.Point(417, 371);
            this.lb_Velocidad4.Name = "lb_Velocidad4";
            this.lb_Velocidad4.Size = new System.Drawing.Size(172, 15);
            this.lb_Velocidad4.TabIndex = 22;
            this.lb_Velocidad4.Text = "Tomar la velocidad media en:";
            // 
            // lb_Velocidad2
            // 
            this.lb_Velocidad2.AutoSize = true;
            this.lb_Velocidad2.BackColor = System.Drawing.Color.Plum;
            this.lb_Velocidad2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_Velocidad2.Location = new System.Drawing.Point(388, 324);
            this.lb_Velocidad2.Name = "lb_Velocidad2";
            this.lb_Velocidad2.Padding = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.lb_Velocidad2.Size = new System.Drawing.Size(230, 33);
            this.lb_Velocidad2.TabIndex = 21;
            this.lb_Velocidad2.Text = "Introduzca la distancia entre los puntos\r\nde medición:";
            // 
            // tb_Velocidad
            // 
            this.tb_Velocidad.BackColor = System.Drawing.SystemColors.Control;
            this.tb_Velocidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_Velocidad.Location = new System.Drawing.Point(530, 72);
            this.tb_Velocidad.Name = "tb_Velocidad";
            this.tb_Velocidad.ReadOnly = true;
            this.tb_Velocidad.Size = new System.Drawing.Size(120, 20);
            this.tb_Velocidad.TabIndex = 32;
            this.tb_Velocidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tb_Vmax
            // 
            this.tb_Vmax.BackColor = System.Drawing.Color.PaleGreen;
            this.tb_Vmax.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_Vmax.Location = new System.Drawing.Point(530, 283);
            this.tb_Vmax.Name = "tb_Vmax";
            this.tb_Vmax.ReadOnly = true;
            this.tb_Vmax.Size = new System.Drawing.Size(120, 26);
            this.tb_Vmax.TabIndex = 31;
            this.tb_Vmax.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lst_Velocidad
            // 
            this.lst_Velocidad.FormattingEnabled = true;
            this.lst_Velocidad.Location = new System.Drawing.Point(530, 108);
            this.lst_Velocidad.Name = "lst_Velocidad";
            this.lst_Velocidad.Size = new System.Drawing.Size(120, 160);
            this.lst_Velocidad.TabIndex = 30;
            // 
            // rb_Sectores3
            // 
            this.rb_Sectores3.AutoSize = true;
            this.rb_Sectores3.BackColor = System.Drawing.Color.Plum;
            this.rb_Sectores3.Enabled = false;
            this.rb_Sectores3.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb_Sectores3.Location = new System.Drawing.Point(579, 392);
            this.rb_Sectores3.Name = "rb_Sectores3";
            this.rb_Sectores3.Size = new System.Drawing.Size(71, 19);
            this.rb_Sectores3.TabIndex = 33;
            this.rb_Sectores3.Text = "Ninguno";
            this.rb_Sectores3.UseVisualStyleBackColor = false;
            this.rb_Sectores3.CheckedChanged += new System.EventHandler(this.rb_CheckedChanged);
            // 
            // SerialPort
            // 
            this.SerialPort.BaudRate = 115200;
            this.SerialPort.PortName = "COM2";
            this.SerialPort.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.SerialPort_DataReceived);
            // 
            // timer_ControlDeTiempos
            // 
            this.timer_ControlDeTiempos.Interval = 200;
            this.timer_ControlDeTiempos.Tick += new System.EventHandler(this.timer_ControlDeTiempos_Tick);
            // 
            // rb_Sectores0
            // 
            this.rb_Sectores0.AutoSize = true;
            this.rb_Sectores0.BackColor = System.Drawing.Color.Plum;
            this.rb_Sectores0.Checked = true;
            this.rb_Sectores0.Enabled = false;
            this.rb_Sectores0.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb_Sectores0.Location = new System.Drawing.Point(362, 392);
            this.rb_Sectores0.Name = "rb_Sectores0";
            this.rb_Sectores0.Size = new System.Drawing.Size(53, 19);
            this.rb_Sectores0.TabIndex = 39;
            this.rb_Sectores0.TabStop = true;
            this.rb_Sectores0.Text = "Total";
            this.rb_Sectores0.UseVisualStyleBackColor = false;
            // 
            // ControlDeTiempos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Plum;
            this.ClientSize = new System.Drawing.Size(673, 428);
            this.Controls.Add(this.rb_Sectores0);
            this.Controls.Add(this.rb_Sectores3);
            this.Controls.Add(this.tb_Velocidad);
            this.Controls.Add(this.tb_Vmax);
            this.Controls.Add(this.lst_Velocidad);
            this.Controls.Add(this.mtb_Distancia);
            this.Controls.Add(this.lb_Velocidad1);
            this.Controls.Add(this.lb_Velocidad3);
            this.Controls.Add(this.rb_Sectores2);
            this.Controls.Add(this.rb_Sectores1);
            this.Controls.Add(this.lb_Velocidad4);
            this.Controls.Add(this.lb_Velocidad2);
            this.Controls.Add(this.tb_Tiempos3);
            this.Controls.Add(this.tb_Tiempos2);
            this.Controls.Add(this.tb_Tiempos1);
            this.Controls.Add(this.bt_Tiempos);
            this.Controls.Add(this.bt_Reset);
            this.Controls.Add(this.bt_Sectores);
            this.Controls.Add(this.tb_MejorTiempo3);
            this.Controls.Add(this.tb_MejorTiempo2);
            this.Controls.Add(this.tb_MejorTiempo1);
            this.Controls.Add(this.lst_Tiempos3);
            this.Controls.Add(this.lb_Datos3);
            this.Controls.Add(this.lb_Datos2);
            this.Controls.Add(this.lb_Datos1);
            this.Controls.Add(this.lst_Tiempos2);
            this.Controls.Add(this.lst_Tiempos1);
            this.Controls.Add(this.menu_ControlDeTiempos);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MainMenuStrip = this.menu_ControlDeTiempos;
            this.MaximizeBox = false;
            this.Name = "ControlDeTiempos";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Control de tiempos";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menu_ControlDeTiempos.ResumeLayout(false);
            this.menu_ControlDeTiempos.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menu_ControlDeTiempos;
        private System.Windows.Forms.ToolStripMenuItem archivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ayudaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem acercaDeToolStripMenuItem;
        private System.Windows.Forms.ListBox lst_Tiempos1;
        private System.Windows.Forms.ListBox lst_Tiempos2;
        private System.Windows.Forms.Label lb_Datos1;
        private System.Windows.Forms.Label lb_Datos2;
        private System.Windows.Forms.Label lb_Datos3;
        private System.Windows.Forms.ListBox lst_Tiempos3;
        private System.Windows.Forms.TextBox tb_MejorTiempo1;
        private System.Windows.Forms.TextBox tb_MejorTiempo2;
        private System.Windows.Forms.TextBox tb_MejorTiempo3;
        private System.Windows.Forms.Button bt_Sectores;
        private System.Windows.Forms.Button bt_Reset;
        private System.Windows.Forms.Button bt_Tiempos;
        private System.Windows.Forms.ToolStripMenuItem herramientasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menu_ActivarTiempoPorSectores;
        private System.Windows.Forms.TextBox tb_Tiempos1;
        private System.Windows.Forms.TextBox tb_Tiempos2;
        private System.Windows.Forms.TextBox tb_Tiempos3;
        private System.Windows.Forms.ToolStripMenuItem menu_Borrar;
        private System.Windows.Forms.MaskedTextBox mtb_Distancia;
        private System.Windows.Forms.Label lb_Velocidad1;
        private System.Windows.Forms.Label lb_Velocidad3;
        private System.Windows.Forms.RadioButton rb_Sectores2;
        private System.Windows.Forms.RadioButton rb_Sectores1;
        private System.Windows.Forms.Label lb_Velocidad4;
        private System.Windows.Forms.Label lb_Velocidad2;
        private System.Windows.Forms.TextBox tb_Velocidad;
        private System.Windows.Forms.TextBox tb_Vmax;
        private System.Windows.Forms.ListBox lst_Velocidad;
        private System.Windows.Forms.RadioButton rb_Sectores3;
        private System.IO.Ports.SerialPort SerialPort;
        private System.Windows.Forms.Timer timer_ControlDeTiempos;
        private System.Windows.Forms.RadioButton rb_Sectores0;
    }
}

