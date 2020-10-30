using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabalho3D
{
    class Reta
    {
        private static byte corR = 255;
        private static byte corG = 140;
        private static byte corB = 0;
        private static BitmapData imgDta;
        private static int height;
        private static int width;
        private static int[][] matBitmap;

        /*Teste*/
        public static BitmapData getImgDta()
        {
            return imgDta;
        }
        /*Teste*/

        public static void AlocarBitmap(Bitmap ret)
        {
            imgDta = ret.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
        }

        public static void HeightWidth(Bitmap ret)
        {
            height = ret.Height;
            width = ret.Width;
        }

        public static void DesalocarBitmap(Bitmap ret)
        {
            ret.UnlockBits(imgDta);
        } 

        public static void Bresenham(int x1, int y1, int x2, int y2)
        {
            int y, x;
            int dx, dy, incE, incNE, d;
            int incY, incX;

            dx = Math.Abs(x2 - x1);
            dy = Math.Abs(y2 - y1);

            incY = y2 - y1 > 0 ? 1 : -1;
            incX = x2 - x1 > 0 ? 1 : -1;
            y = y1;
            x = x1;

            if (dx > dy)
            {
                incE = 2 * dy;
                incNE = 2 * dy - 2 * dx;
                d = 2 * dy - dx;

                while (x != x2)
                {
                    if((y >= 0 && y < height) && (x >= 0 && x < width))
                        matBitmap[x][y] = 1;

                    if (d <= 0)
                    {
                        d += incE;
                    }
                    else
                    {
                        d += incNE;
                        y += incY;
                    }

                    x += incX;
                }
            }
            else
            {
                incE = 2 * dx;
                incNE = 2 * dx - 2 * dy;
                d = 2 * dx - dy;

                while (y != y2)
                {
                    if ((y >= 0 && y < height) && (x >= 0 && x < width))
                        matBitmap[x][y] = 1;

                    if (d <= 0)
                    {
                        d += incE;
                    }
                    else
                    {
                        d += incNE;
                        x += incX;
                    }

                    y += incY;
                }
            }
        }

        public static void IniciarMatriz()
        {
            matBitmap = new int[width][];
            for(int i = 0; i < width; i++)
            {
                matBitmap[i] = new int[height];
            }
        }

        public static void Desenhar()
        {
            int i, j;

            for (i = 0; i < width; i++)
            {
                for (j = 0; j < height; j++)
                {
                    if (matBitmap[i][j] == 1)
                        Pintar.setPixel(i, j, corR, corG, corB, imgDta);
                }
            }
        }
    }
}
