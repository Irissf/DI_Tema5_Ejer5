using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DI_Tema5_Ejer5
{ 
    public enum eTipo
    {
        NUMERICO,TEXTUAL
    }
    public partial class UserControl1 : UserControl
    {
        Color color = Color.Red;
        bool correcto;


        public UserControl1()
        {
            InitializeComponent();
        }

        /*===============================================================================
                    ___  ____ ____ ___  _ ____ ___  ____ ___  ____ ____ 
                    |__] |__/ |  | |__] | |___ |  \ |__| |  \ |___ [__  
                    |    |  \ |__| |    | |___ |__/ |  | |__/ |___ ___]

        ===============================================================================*/
        [Category("aa")]
        [Description("Acceder a txt del textbox")]
        public string Texto
        {
            set
            {
                textBox1.Text = value;
                Refresh();
            }
            get
            {
                return textBox1.Text;
            }
        }

        [Category("aa")]
        [Description("Acceder al multiline del texbox")]
        public bool Multilinea
        {
            set
            {
                textBox1.Multiline = value;
                Refresh();
            }
            get
            {
                return textBox1.Multiline;
            }
        }

        private eTipo tipoDeDato = eTipo.TEXTUAL;
        [Category("aa")]
        [Description("numérico o textual")]
        public eTipo TipoDeDato
        {
            set
            {
                tipoDeDato = value;
                Refresh();
            }
            get
            {
                return tipoDeDato;
            }
        }

        /*===============================================================================
                            ____ ____ ____ ____ _    ____ ____ ____ ____ 
                            |__/ |___ |    |  | |    |  | |    |__| |__/ 
                            |  \ |___ |___ |__| |___ |__| |___ |  | |  \
         
         ===============================================================================*/


        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            textBox1.Location = new Point(10, 10);
            this.Height = textBox1.Height + (20);
            textBox1.Width = this.Width - (20);

            
            Graphics g = e.Graphics;
            Pen pen = new Pen(color);

            g.DrawRectangle(pen, 5, 5, textBox1.Width + 10, textBox1.Height + 10);
        }

        private void TextChange(object sender, EventArgs e)
        {
            correcto = true;
            //this.OnTextChanged(e);
            validarCadena(textBox1.Text);
            Refresh();
        }

        private void validarCadena(string cadena)
        {
            for (int i = 0; i < cadena.Length; i++)
            {
                if (tipoDeDato == eTipo.NUMERICO)
                {
                    if (cadena[i] >= 48 && cadena[i] <= 57 || cadena[i] == 13 || cadena[i] == 10)
                    {
                        if (correcto)
                        {
                            color = Color.Green;
                        }
                        
                    }
                    else
                    {
                        color = Color.Red;
                        correcto = false;
                    }
                }
                else
                {
                    if (cadena[i] >= 65 && cadena[i] <= 90 || cadena[i] >= 97 && cadena[i] <= 122 || cadena[i] == 13 || cadena[i] == 10)
                    {
                        if (correcto)
                        {
                            color = Color.Green;
                        }
                    }
                    else
                    {
                        color = Color.Red;
                        correcto = false;
                    }
                }
            }
        }
    }

}
