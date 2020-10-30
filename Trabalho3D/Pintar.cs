using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabalho3D
{
    class Pintar
    {
        public static void setPixel(int x, int y, byte corR, byte corG, byte corB, BitmapData imgDta)
        {
            unsafe
            {
                byte* pImg = (byte*)imgDta.Scan0.ToPointer();
                byte* ini = pImg;

                pImg = (byte*)(ini + ((y * imgDta.Stride) + (x * 3)));

                *(pImg++) = corB;
                *(pImg++) = corG;
                *(pImg++) = corR;
            }
        }
    }
}
