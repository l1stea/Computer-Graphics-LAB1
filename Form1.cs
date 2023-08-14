using System.Drawing;

namespace LAB1
{
    public partial class Form1 : Form
    {
        private readonly Bitmap Flag;
        // Размер области
        private readonly decimal SizeArea;
        // Расположение центра по оси абсцисс, Расположение центра по оси ординат
        private readonly decimal CenterX, CenterY;


        public Form1()
        {
            InitializeComponent();
            Flag = new Bitmap(fractalPicture.Width, fractalPicture.Height);
            fractalPicture.Image = Flag;
            CenterX = -0.25m; 
            CenterY = 0;
            SizeArea = 2; 
        }

        private int xPixel;
        private int yPixel;
        private decimal xCoord;
        private decimal yCoord;


        private void Draw_fractal()
        {
            int Width = fractalPicture.Width;
            int Height = fractalPicture.Height;
            for (xPixel = 0; xPixel < Width; xPixel++)
            {
                for (yPixel = 0; yPixel < Height; yPixel++)
                {
                    xCoord = ConvertCoord(CenterX, xPixel, Width);
                    yCoord = ConvertCoord(CenterY, yPixel, Height);
                    DrawPixel();
                }
                fractalPicture.Refresh();
            }
        }


       private  Color GetColor()
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


        private decimal ConvertCoord(decimal centerCoord, int coordPicture, decimal sizeSide)
            => (centerCoord - SizeArea / 2) + coordPicture * (SizeArea / sizeSide);


        private void DrawPixel() => Flag.SetPixel(xPixel, yPixel, GetColor());

        private void Draw_click(object sender, EventArgs e)
        {
            drawButton.Enabled = false;
            Draw_fractal();
        }
    }
}