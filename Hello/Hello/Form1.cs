using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hello
{
    public partial class Form1 : Form
    {
        public int Fi = 1;
        public int f = 0;
        public int fx = 1;
        public int fx2 = 0;
        public int fy = 1;
        public int fy2 = 0;
        Bitmap off;
        List<Hello> W = new List<Hello>();
        List<Line> L = new List<Line>();
        public Form1()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            this.Load += Form1_load;
            this.Paint += Form1_paint;
            this.MouseDown += Form1_MouseDown;
            this.MouseMove += Form1_MouseMove;
            this.MouseUp += Form1_MouseUp;
            Timer t = new Timer();
            t.Start();
            t.Tick += T_Tick;
            t.Interval = 1;
        }
        private void T_Tick(object  sender ,EventArgs e)
        {
            if(W[0].x== 0)
            {
                fx = 1;
                fx2 = 0;
            }
            if (W[0].x == (ClientSize.Width - 80))
            {
                fx = 0;
                fx2 = 1;
            }
            if (W[0].y == (L[0].y-20))
            {
                fy = 0;
                fy2 = 1;
            }
            if (W[0].y == 0)
            {
                fy2 = 0;
                fy = 1;
            }
            ////////////////////
            if(fx == 1)
            {
                W[0].x++;
            }
            if(fx2==1)
            {
                W[0].x--;
            }
            if (fy == 1)
            {
                W[0].y++;
            }
            if (fy2 == 1)
            {
                W[0].y--;
            }
            Dubblebuffer(CreateGraphics());
        }
        private void Form1_paint(object sender, PaintEventArgs e)
        {
            Dubblebuffer(e.Graphics);
        }
        void Dubblebuffer(Graphics g)
        {
            Graphics g2 = Graphics.FromImage(off);
            Drowscene(g2);
            g.DrawImage(off, 0, 0);
        }
        private void Form1_load(object sender, EventArgs e)
        {
            Hello pnn = new Hello();
            pnn.H = "Hello";
            pnn.x = 0;
            pnn.y = 0;
            W.Add(pnn);
            Line pnn2 = new Line();
            pnn2.x = 0;
            pnn2.y = ClientSize.Height / 2;
            pnn2.w = ClientSize.Width;
            pnn2.h = 20;
            L.Add(pnn2);
            off = new Bitmap(ClientSize.Width, ClientSize.Height);
        }
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if ( e.Y >= L[0].y&& e.Y <= (L[0].y+20))
                {
                    f = 1;
                }
            }
            
        }
        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            f = 0;
        }
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (f == 1)
            {
                L[0].y = e.Y;
            }
            Dubblebuffer(CreateGraphics());
        }
        void Drowscene(Graphics g)
        {
            g.Clear(Color.Black);
            for (int i = 0; i < W.Count; i++)
            {
                g.DrawString(W[i].H, new Font("Times New Roman (Headings CS)", 30), Brushes.White, W[i].x, W[i].y);
            }
            for (int i = 0; i < L.Count; i++)
            {
                Brush b = new SolidBrush(Color.White);
                g.FillRectangle(b, L[i].x, L[i].y, L[i].w, L[i].h);
            }
        }
    }
    class Hello
    {
        public string H;
        public int x;
        public int y;
    }
    class Line
    {
        public int x;
        public int y;
        public int w;
        public int h;
    }
}