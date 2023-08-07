using System.Windows.Forms;

namespace LAB1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        struct Complex
        {

            public double x;
            public double y;

        };

        public void draw_fractal(int Width, int Height, Pen drw_pen, Graphics g)
        {
            int iterations = 50, max = 3;
            int xc, yc;
            int x, y, n;
            double p, q;
            Complex z, c;
            xc = (Width - 10) / 2;
            yc = (Height - 10) / 2;

            for (y = -yc; y < yc; y++)
            {
                for (x = -xc; x < xc; x++)
                {
                    n = 0;
                    c.x = x * 0.01 + 1;
                    c.y = y * 0.01;

                    z.x = 0.5;
                    z.y = 0;

                    while ((z.x * z.x + z.y * z.y < max) && (n < iterations))
                    {
                        p = z.x - z.x * z.x + z.y * z.y;
                        q = z.y - 2 * z.x * z.y;
                        z.x = c.x * p - c.y * q;
                        z.y = c.x * q + c.y * p;
                        n++;
                    }
                    if (n < iterations)
                    {
                        drw_pen.Color = Color.FromArgb(255, 0, (n * 15) % 255, (n * 20) % 255);
                        g.DrawRectangle(drw_pen, xc + x, yc + y, 1, 1);
                    }

                }
            }
        }

        private void Draw_click(object sender, EventArgs e)
        {
            int Width = pictureBox1.Width, Height = pictureBox1.Height;

            Pen drw_pen = new Pen(Color.Black, 1);
            Graphics g = Graphics.FromHwnd(pictureBox1.Handle);
            draw_fractal(Width, Height, drw_pen, g);
        }

        private void Picture_box(object sender, EventArgs e)
        {

        }
    }
}