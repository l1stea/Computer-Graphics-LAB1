using System.Numerics;
using System.Windows.Forms;
using System.Windows.Forms.ComponentModel.Com2Interop;

namespace LAB1
{
    public partial class Form1 : Form
    {
        Bitmap flag;
        Color color;
        Size size;

        Decimal SizeArea;
        Decimal CenterX, CenterY;
        Decimal ScaleArea;

        public Form1()
        {
            this.InitializeComponent();

            flag = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            pictureBox1.Image = flag;
            color = new Color();
            size = pictureBox1.Size;

            CenterX = -0.5m;
            CenterY = 0;
            SizeArea = 3;
            ScaleArea = 3;
        }

        public void Draw_Fractal_Alg()
        {
            flag = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            pictureBox1.Image = flag;
            size = pictureBox1.Size;

            Complex Z;
            Complex Z0;
            Complex C;

            int i, x, y;

            for (x = 1; x < size.Width; x++)
            {
                for (y = 1; y < size.Height; y++)
                {
                    C = new Complex(
                        (CenterX - SizeArea / 2) + x * (SizeArea / size.Width),
                        (CenterY - SizeArea / 2) + y * (SizeArea / size.Height));
                    Z = new Complex();

                    for (i = 1; i <= 110; i++)
                    {
                        Z0 = Z;
                        Z = Z0 * Z0 + C;

                        if (Z.MagnitudeSQ > 4)
                        {
                            color = Color.FromArgb(255, 255, 255);
                            flag.SetPixel(x, y, color);
                            break;
                        }
                    }

                    if (i > 99)
                    {
                        color = Color.FromArgb(i + 50, i + 100, i + 140);
                        flag.SetPixel(x, y, color);
                    }
                }
                this.pictureBox1.Refresh();
            }
            this.pictureBox1.Refresh();
            MessageBox.Show("Построение закончено");
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Draw_Fractal_Alg();
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            int X = e.X,
                Y = e.Y;
            switch (e.Button)
            {
                case MouseButtons.Left:
                    CenterX = (CenterX - SizeArea / 2) + X * (SizeArea / size.Width);
                    CenterY = (CenterY - SizeArea / 2) + Y * (SizeArea / size.Height);
                    SizeArea /= ScaleArea;
                    Draw_Fractal_Alg();
                    break;
                case MouseButtons.Middle:
                    CenterX = -0.5m;
                    CenterY = 0;
                    SizeArea = 3;
                    ScaleArea = 3;
                    Draw_Fractal_Alg();
                    break;
                case MouseButtons.Right:
                    CenterX = (CenterX - SizeArea / 2) + X * (SizeArea / size.Width);
                    CenterY = (CenterY - SizeArea / 2) + Y * (SizeArea / size.Height);
                    SizeArea *= ScaleArea;
                    Draw_Fractal_Alg();
                    break;
                default:
                    break;
            }
        }
    }
}


public class Complex
{
    public Decimal X { get; set; }
    public Decimal Y { get; set; }

    public Decimal MagnitudeSQ
    {
        get
        {
            return X * X + Y * Y;
        }
    }

    public Complex()
    {
        X = 0;
        Y = 0;
    }

    public Complex(Decimal x, Decimal y)
    {
        X = x;
        Y = y;
    }

    public Complex(Complex C)
    {
        X = C.X;
        Y = C.Y;
    }

    public static Complex operator +(Complex c1, Complex c2)
    {
        return new Complex(c1.X + c2.X, c1.Y + c2.Y);
    }

    public static Complex operator *(Complex c1, Complex c2)
    {
        return new Complex(c1.X * c2.X - c1.Y * c2.Y, c1.X * c2.Y + c2.X * c1.Y);
    }
}
