using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;

namespace Csikó
{
    public partial class Csiko_Form : Form
    {
        private List<RectangleF> teglalap;
        public Csiko_Form()
        {
            InitializeComponent();
        }

        private void Csiko_Form_betoltes(object sender, EventArgs e)
        {
            TablaRajzolasa();
          
        }
        //Az összes találat lépés rajzolása, amit felvettünk

        private void LepesRajzolasa(List<Lepes> lep)
        {
            int count = lep.Count;
            for (int i = 0; i < count; i++)
            {
                using (Graphics g = Graphics.FromImage(pictureBox1.Image))
                
                {
                    //Rajzolás beállítások
                    Pen toll;
                    g.SmoothingMode = SmoothingMode.AntiAlias;
                    g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    g.PixelOffsetMode = PixelOffsetMode.HighQuality;
                    g.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
                    StringFormat format = new StringFormat()
                    {
                        Alignment = StringAlignment.Center,
                        LineAlignment = StringAlignment.Center
                    };
                    //Szám nyomtatása
                    g.DrawString(lep[i].Order.ToString(), new Font("Arial", 15), Brushes.Black, (lep[i].Y * 100) + 5, (lep[i].X * 100) + 5);
                    //Irányok rajzolása
                    if (i < count - 1)
                    {
                        if (i % 2 == 0) toll = new Pen(Color.Red, 8); else toll = new Pen(Color.Blue, 8);
                        toll.StartCap = LineCap.RoundAnchor;
                       // pictureBox2.Image = Enabled;
                        
                        toll.EndCap = LineCap.ArrowAnchor;
                        g.DrawLine(toll, (lep[i].Y * 100) + 50, (lep[i].X * 100) + 50, (lep[i + 1].Y * 100) + 50, (lep[i + 1].X * 100) + 50);
                    }
                    
                }
            }
        }

        //Rajz-Kick-off táblája
        private void TablaRajzolasa()
        {
            Bitmap kep = new Bitmap(800, 800);
            teglalap = new List<RectangleF>();

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    Rectangle r = new Rectangle { X = i * 100, Y = j * 100, Width = 100, Height = 100 };
                    using (Graphics g = Graphics.FromImage(kep))
                    {
                        Brush selPen = Brushes.White;
                        if ((j % 2 == 0 && i % 2 == 0) || (j % 2 != 0 && i % 2 != 0))
                        {
                            selPen = Brushes.White;
                        }
                        else if ((j % 2 == 0 && i % 2 != 0) || (j % 2 != 0 && i % 2 == 0))
                        {
                            selPen = Brushes.MidnightBlue;
                        }

                        g.FillRectangle(selPen, r);

                    }
                    teglalap.Add(r);
                }
            }
            pictureBox1.Image = kep;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            textBox1.Text = string.Empty;
            int x = int.Parse(textBox2.Text);
            int y = int.Parse(textBox3.Text);
            if (x < 0 || y < 0 || x > 7 || y > 7)
            {
                MessageBox.Show("0-7 számokat kell beírni!");
                button1.Enabled = true;
                return;
            }
            Csiko t = new Csiko(x, y);
            //Írja be az összes talált lépést, a szövegmezőben
            int[,] moveses = t.UjTabla();
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    textBox1.Text += $"{moveses[i, j]}\t\n";

                }
                textBox1.Text += Environment.NewLine;
            }
            //Az összes találta lépés rajzolása
            TablaRajzolasa();
            LepesRajzolasa(t.UjLepes());
            button1.Enabled = true;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Csiko_Form_Load(object sender, EventArgs e)
        {

        }
    }
}
