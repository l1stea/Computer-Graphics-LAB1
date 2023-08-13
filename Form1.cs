using System.Drawing;

namespace LAB1
{
    public partial class Form1 : Form
    {
        readonly Bitmap Flag;
        readonly decimal SizeArea;
        private readonly decimal CenterX, CenterY;


        public Form1()
        {
            InitializeComponent();
            Flag = new Bitmap(fractalPicture.Width, fractalPicture.Height);
            fractalPicture.Image = Flag;
            CenterX = -0.5m;
            CenterY = 0;
            SizeArea = 3;
        }

        int xCoordPicture;
        int yCoordPicture;
        decimal xCoord;
        decimal yCoord;


        public void Draw_fractal()
        {
            int Width = fractalPicture.Width;
            int Height = fractalPicture.Height;
            for (xCoordPicture = 0; xCoordPicture < Width; xCoordPicture++)
            {
                for (yCoordPicture = 0; yCoordPicture < Height; yCoordPicture++)
                {
                    xCoord = ConvertCoord(CenterX, xCoordPicture, Width);
                    yCoord = ConvertCoord(CenterY, yCoordPicture, Height);
                    DrawPixel();
                }
                fractalPicture.Refresh();
            }
        }

        Color GetColorCoord()
        {
            decimal x0 = (decimal)-1.5;
            decimal y0 = (decimal)-0.8;
            decimal xn = 1;
            decimal yn = (decimal)0.8;
            int iterations = 110;
            decimal maxMagnitude = 4;
            // Заданные границы
            if (xCoord >= x0 && xCoord <= xn && yCoord >= y0 && yCoord <= yn)
            {
                Complex Z, C, Z0;
                C = new Complex(xCoord, yCoord);
                Z = new Complex();
                int i;
                for ( i = 1; i <= iterations; i++)
                {
                    Z0 = Z;
                    Z = Z0 * Z0 + C;
                    if (Z.MagnitudeSQ > maxMagnitude)
                    {
                        return Color.FromArgb(255, 0, (i * 5) % 255, (i * 10) % 255);
                    }
                }
                // В зоне, но итераций больше некоторого числа
                if (i > 99)
                {
                    return Color.FromArgb(255, 255, 255, 255);
                }
            }
            // Вне зоны
            return Color.FromArgb(255, 100, 100, 100); 
        }


        decimal ConvertCoord(decimal centerCoord, int coordPicture, decimal sizeSide)
            => (centerCoord - SizeArea / 2) + coordPicture * (SizeArea / sizeSide);


        void DrawPixel() => Flag.SetPixel(xCoordPicture, yCoordPicture, GetColorCoord());

        private void Draw_click(object sender, EventArgs e)
        {
            Draw_fractal();
        }
    }
}