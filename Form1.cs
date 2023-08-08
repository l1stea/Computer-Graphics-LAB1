using System.Windows.Forms;
using System.Windows.Forms.ComponentModel.Com2Interop;

namespace LAB1
{
    public partial class Form1 : Form
    {
        public Form1() {
            InitializeComponent();
        }

        struct Complex {
            public double x;
            public double y;

        };

        public void draw_fractal(int Width, int Height, Pen drw_pen, Graphics g) {
            int iterations = 50;
            double max = 1.64;//1.64
            //double max = 4;//1.64
            int xc, yc;
            int x, y, n;
            Complex z, c;
            xc = (Width + 200) / 2;
            yc = (Height + 100) / 2;

            for (y = -yc; y < yc; y++) {
                for (x = -xc; x < xc; x++) {
                    n = 0;
                    c.x = x * 0.009 + 1;
                    c.y = y * 0.009;

                    z.x = 0;
                    z.y = 0;

                    double x0 = -1.5; // x0 = -1.5 xn = 1.0 y0 = -0.8 yn = 0.8
                    double y0 = -0.8;
                    double xn = 1;
                    double yn = 0.8;
                    //double x0 = -2.2;
                    //double y0 = -1.2;
                    //double xn = 1;
                    //double yn = 1.2;

                    while ((z.x * z.x + z.y * z.y <= max) && (n < iterations)) {
                        
                        double xtime = z.x;
                        if ((z.x >= x0 && z.x < xn) && (z.y >= y0 && z.y < yn))
                        {
                            n++;
                            z.x = xtime * xtime - z.y * z.y + c.x; // xn1 == xn+1
                            z.y = 2 * xtime * z.y + c.y; // yn1 == yn+1
                        }
                        else break;


                    };

                    if (n < iterations) {
                        drw_pen.Color = Color.FromArgb(255, 0, (n * 5) % 255, (n * 10) % 255);
                        g.DrawRectangle(drw_pen, xc + x, yc + y, 1, 1);
                    }

                }
            }
        }

        private void Draw_click(object sender, EventArgs e) {
            int Width = pictureBox1.Width, Height = pictureBox1.Height;

            Pen drw_pen = new Pen(Color.Black, 1);
            Graphics g = Graphics.FromHwnd(pictureBox1.Handle);
            draw_fractal(Width, Height, drw_pen, g);
        }

        private void Picture_box(object sender, EventArgs e) {

        }
    }
}