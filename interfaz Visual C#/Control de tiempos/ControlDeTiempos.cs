using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Text;
using System.Windows.Forms;

namespace Control_de_tiempos
{
    public partial class ControlDeTiempos : Form
    {
        private char Puerto = '0';
        private char iniciar = 's';
        private int n_intentos = 0;
        
        private enum sectores { Total, Primero, Segundo };

        private struct orden
        {
            private sectores sector_val;
            public sectores sector
            {
                get
                {
                    return sector_val;
                }
                set
                {
                    sector_val = value;
                }
            }

            private string tiempo_val;
            public string tiempo
            {
                get
                {
                    return tiempo_val;
                }
                set
                {
                    tiempo_val = value;
                }
            }

            private char record_val;
            public char record
            {
                get
                {
                    return record_val;
                }
                set
                {
                    record_val = value;
                }
            }
        };

        private string buffer_rx = "";
        private orden orden1;
        private char decimales = 'n';
        private int num_dec = 0;
        private char incompleto = 'n';
        private int aux;

        private double v = 0, t = 0, d = 0;
        private string v_string;

        
        public ControlDeTiempos()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SerialPort.DataReceived += new SerialDataReceivedEventHandler(SerialPort_DataReceived);

            do
            {
                try
                {
                    SerialPort.Open();
                    Puerto = '1';
                }
                catch (Exception)
                {
                    ComprobarPuerto dlg = new ComprobarPuerto();
                    dlg.ShowDialog(this);
                    if (dlg.DialogResult == DialogResult.Cancel)
                        Puerto = '2';
                }
            } while (Puerto == '0');

            if (Puerto == '2')
                Close();

            SerialPort.DiscardInBuffer();

            timer_ControlDeTiempos.Enabled = true;
        }

        private void menu_Salir(object sender, EventArgs e)
        {
            Close();
        }

        private void menu_AcercaDe(object sender, EventArgs e)
        {
            AcercaDe dlg = new AcercaDe();
            dlg.ShowDialog(this);
        }

        private void bt_Tiempos_Click(object sender, EventArgs e)
        {
            if (bt_Tiempos.Text != "Parar control")
            {
                bt_Tiempos.Text = "Parar control";
                bt_Tiempos.BackColor = Color.OrangeRed;
                bt_Sectores.Enabled = false;
                bt_Reset.Enabled = false;

                menu_ActivarTiempoPorSectores.Enabled = false;
                menu_Borrar.Enabled = false;
                
                tb_Tiempos1.Text = "0.00";
                if (bt_Sectores.Text == "Desactivar tiempo por sectores")
                {
                    tb_Tiempos2.Text = "0.00";
                    tb_Tiempos3.Text = "0.00";
                }
                else
                {
                    tb_Tiempos2.Text = "";
                    tb_Tiempos3.Text = "";
                }
                
                mtb_Distancia.BackColor = Color.OrangeRed;
                mtb_Distancia.Enabled = false;
                rb_Sectores0.Enabled = false;
                rb_Sectores1.Enabled = false;
                rb_Sectores2.Enabled = false;
                rb_Sectores3.Enabled = false;
                
                if (rb_Sectores3.Checked == false)
                {
                    tb_Velocidad.Text = "0.00";

                    d = System.Convert.ToDouble(mtb_Distancia.Text.ToString());
                    if (tb_Velocidad.Text[3] == '0')
                    {
                        d = d / 10;
                        if (tb_Velocidad.Text[2] == '0')
                            d = d / 10;
                    }
                    d = Math.Round(d, 2);
                }

                SerialPort.Write("s");
            }
            else
            {
                bt_Tiempos.Text = "Continuar control";
                bt_Tiempos.BackColor = Color.LawnGreen;
                bt_Sectores.Enabled = true;
                bt_Reset.Enabled = true;

                menu_ActivarTiempoPorSectores.Enabled = true;
                menu_Borrar.Enabled = true;

                tb_Tiempos1.Text = "";
                tb_Tiempos2.Text = "";
                tb_Tiempos3.Text = "";
                
                mtb_Distancia.BackColor = Color.MediumSlateBlue;
                mtb_Distancia.Enabled = true;
                rb_Sectores0.Enabled = true;
                rb_Sectores3.Enabled = true;
                tb_Velocidad.Text = "";

                if (bt_Sectores.Text == "Desactivar tiempo por sectores")
                {
                    rb_Sectores1.Enabled = true;
                    rb_Sectores2.Enabled = true;
                }

                SerialPort.Write("p");
            }
        }
        
        private void bt_Sectores_Click(object sender, EventArgs e)
        {
            if (bt_Sectores.Text == "Activar tiempo por sectores")
            {
                bt_Sectores.Text = "Desactivar tiempo por sectores";

                tb_Tiempos2.BackColor = SystemColors.Control;
                tb_Tiempos3.BackColor = SystemColors.Control;
                rb_Sectores1.Enabled = true;
                rb_Sectores2.Enabled = true;

                SerialPort.Write("2");
            }
            else
            {
                bt_Sectores.Text = "Activar tiempo por sectores";

                tb_Tiempos2.BackColor = SystemColors.ControlDark;
                tb_Tiempos3.BackColor = SystemColors.ControlDark;
                rb_Sectores1.Enabled = false;
                rb_Sectores2.Enabled = false;

                if (rb_Sectores1.Checked == true || rb_Sectores2.Checked == true)
                    rb_Sectores0.Checked = true;

                SerialPort.Write("1");
            }
        }

        private void bt_Borrar_Click(object sender, EventArgs e)
        {
            BorrarDatos dlg = new BorrarDatos();
            dlg.ShowDialog(this);

            if (dlg.DialogResult == DialogResult.OK)
            {
                tb_Tiempos1.Clear();
                tb_Tiempos2.Clear();
                tb_Tiempos3.Clear();
                lst_Tiempos1.Items.Clear();
                lst_Tiempos2.Items.Clear();
                lst_Tiempos3.Items.Clear();
                tb_MejorTiempo1.Clear();
                tb_MejorTiempo2.Clear();
                tb_MejorTiempo3.Clear();

                bt_Tiempos.Text = "Comenzar control";

                tb_Velocidad.Clear();
                lst_Velocidad.Items.Clear();
                tb_Vmax.Clear();

                SerialPort.Write("b");
            }
        }

        private void rb_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_Sectores3.Checked == false)
            {
                tb_Velocidad.BackColor = SystemColors.Control;
                mtb_Distancia.Enabled = true;
            }
            else
            {
                tb_Velocidad.BackColor = SystemColors.ControlDark;
                mtb_Distancia.Enabled = false;
            }
        }

        private void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            buffer_rx += SerialPort.ReadExisting();

            if (iniciar == 's' && buffer_rx == "k")
            {
                iniciar = 'n';
                timer_ControlDeTiempos.Enabled = false;
                this.Invoke(new EventHandler(Inicializar));
                buffer_rx = "";
            }
            else if (iniciar == 'n' && buffer_rx == "k")
                buffer_rx = "";
            else if (iniciar == 'n')
            {
                decimales = 'n';
                num_dec = 0;
                incompleto = 'n';

                while (buffer_rx.Length > 0 && incompleto == 'n')
                {
                    orden1.sector = sectores.Total;
                    orden1.tiempo = "";
                    orden1.record = 'n';

                    if (buffer_rx[0] == 'T')
                        orden1.record = 's';
                    else if (buffer_rx[0] == 'P')
                    {
                        orden1.sector = sectores.Primero;
                        orden1.record = 's';
                    }
                    else if (buffer_rx[0] == 'p')
                        orden1.sector = sectores.Primero;
                    else if (buffer_rx[0] == 'S')
                    {
                        orden1.sector = sectores.Segundo;
                        orden1.record = 's';
                    }
                    else if (buffer_rx[0] == 's')
                        orden1.sector = sectores.Segundo;

                    for (aux = 1; aux < buffer_rx.Length; aux++)
                    {
                        if (buffer_rx[aux] != 'f')
                        {
                            orden1.tiempo += buffer_rx[aux];
                            if (buffer_rx[aux] == '.')
                                decimales = 's';
                            else if (decimales == 's')
                                num_dec ++;
                        }
                        else if (buffer_rx[aux] == 'f')
                        {
                            string buffer_aux = "";
                            aux++;
                            for (; aux < buffer_rx.Length; aux++)
                                buffer_aux += buffer_rx[aux];
                            buffer_rx = buffer_aux;

                            break;
                        }
                    }

                    if (aux == buffer_rx.Length)
                        if (buffer_rx[aux - 1] != 'f')
                            incompleto = 's';

                    if (incompleto == 'n')
                    {
                        if (decimales == 'n')
                            orden1.tiempo += ".00";
                        else
                            for (; num_dec < 2; num_dec++)
                                orden1.tiempo += '0';

                        if (orden1.sector == sectores.Primero)
                        {
                            this.Invoke(new EventHandler(Agregar_tiempo));

                            if (rb_Sectores1.Checked == true)
                            {
                                t = Math.Round(System.Convert.ToDouble(orden1.tiempo), 2) / 100;
                                if (orden1.tiempo[3] == '0')
                                {
                                    t = t / 10;
                                    if (orden1.tiempo[2] == '0')
                                        t = t / 10;
                                }

                                v = Math.Round(d / t, 2);
                                v_string = v.ToString("0.00");
                                this.Invoke(new EventHandler(Agregar_velocidad));

                                if (orden1.record == 's')
                                    this.Invoke(new EventHandler(Agregar_Vmax));
                            }

                            if (orden1.record == 's')
                            {
                                this.Invoke(new EventHandler(Agregar_mejor_tiempo));
                                Console.Beep();
                            }

                            Console.Beep();
                        }
                        else if (orden1.sector == sectores.Segundo)
                        {
                            this.Invoke(new EventHandler(Agregar_tiempo));

                            if (rb_Sectores2.Checked == true)
                            {
                                t = Math.Round(System.Convert.ToDouble(orden1.tiempo), 2) / 100;
                                if (orden1.tiempo[3] == '0')
                                {
                                    t = t / 10;
                                    if (orden1.tiempo[2] == '0')
                                        t = t / 10;
                                }

                                v = Math.Round(d / t, 2);
                                v_string = v.ToString("0.00");
                                this.Invoke(new EventHandler(Agregar_velocidad));

                                if (orden1.record == 's')
                                    this.Invoke(new EventHandler(Agregar_Vmax));
                            }

                            if (orden1.record == 's')
                            {
                                this.Invoke(new EventHandler(Agregar_mejor_tiempo));
                                Console.Beep();
                            }

                            Console.Beep();
                        }
                        else
                        {
                            this.Invoke(new EventHandler(Agregar_tiempo));

                            if (rb_Sectores0.Checked == true)
                            {
                                t = Math.Round(System.Convert.ToDouble(orden1.tiempo), 2) / 100;

                                v = Math.Round(d / t, 2);
                                v_string = v.ToString("0.00");
                                this.Invoke(new EventHandler(Agregar_velocidad));

                                if (orden1.record == 's')
                                    this.Invoke(new EventHandler(Agregar_Vmax));
                            }

                            if (orden1.record == 's')
                            {
                                this.Invoke(new EventHandler(Agregar_mejor_tiempo));

                                if (bt_Sectores.Text == "Activar tiempo por sectores")
                                    Console.Beep();
                            }

                            if (bt_Sectores.Text == "Activar tiempo por sectores")
                                Console.Beep();
                        }
                    }
                }
            }
        }

        private void Inicializar(object a, EventArgs e)
        {
            menu_ControlDeTiempos.Enabled = true;
            bt_Reset.Enabled = true;
            bt_Sectores.Enabled = true;
            bt_Tiempos.Enabled = true;
            rb_Sectores0.Enabled = true;
            rb_Sectores3.Enabled = true;
        }

        private void Agregar_tiempo(object a, EventArgs e)
        {
            if (orden1.sector == sectores.Primero)
            {
                tb_Tiempos2.Text = orden1.tiempo;
                lst_Tiempos2.Items.Add(orden1.tiempo);
                lst_Tiempos2.SetSelected(lst_Tiempos2.Items.Count - 1, true);
            }
            else if (orden1.sector == sectores.Segundo)
            {
                tb_Tiempos3.Text = orden1.tiempo;
                lst_Tiempos3.Items.Add(orden1.tiempo);
                lst_Tiempos3.SetSelected(lst_Tiempos3.Items.Count - 1, true);
            }
            else
            {
                tb_Tiempos1.Text = orden1.tiempo;
                lst_Tiempos1.Items.Add(orden1.tiempo);
                lst_Tiempos1.SetSelected(lst_Tiempos1.Items.Count - 1, true);
            }
        }

        private void Agregar_mejor_tiempo(object a, EventArgs e)
        {
            if (orden1.sector == sectores.Primero)
                tb_MejorTiempo2.Text = orden1.tiempo;
            else if (orden1.sector == sectores.Segundo)
                tb_MejorTiempo3.Text = orden1.tiempo;
            else
                tb_MejorTiempo1.Text = orden1.tiempo;            
        }

        private void Agregar_velocidad(object a, EventArgs e)
        {
            tb_Velocidad.Text = v_string;
            lst_Velocidad.Items.Add(v_string);
            lst_Velocidad.SetSelected(lst_Velocidad.Items.Count - 1, true);
        }

        private void Agregar_Vmax(object a, EventArgs e)
        {
            tb_Vmax.Text = lst_Velocidad.Items[lst_Velocidad.Items.Count - 1].ToString();
        }

        private void timer_ControlDeTiempos_Tick(object sender, EventArgs e)
        {
            if (n_intentos < 3)
            {
                SerialPort.Write("r");
                n_intentos++;
            }
            else
            {
                timer_ControlDeTiempos.Enabled = false;

                ComprobarTx dlg = new ComprobarTx();
                dlg.ShowDialog(this);

                if (dlg.DialogResult == DialogResult.Cancel)
                    Close();
                else
                {
                    n_intentos = 0;
                    timer_ControlDeTiempos.Enabled = true;
                }
            }
        }
    }
}
