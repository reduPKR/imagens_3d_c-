using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabalho3D.Scanline
{
    class ScanLine
    {
        public static void Scanline(BitmapData imgDta, Pontos[] pontos)
        {
            Preencher(imgDta, pontos);
        }

        private static void Preencher(BitmapData imgDta, Pontos[] pontos)
        {
            CabET cab = new CabET();
            criaET(cab, pontos);

            AET aet = new AET();
            ET aux = cab.getInicio();
            int y = aux.getNum();

            aet.copia_para_AET(aux.getInicio());
                aux = aux.getNext();
                while (aet.getInicio() != null)
                {
                    aet.removerYMax(y);
                    if (aet.getInicio() != null)
                    {
                        aet.ordenarXMin();
                        aet.desenhar(imgDta, y);
                        aet.atualizarXMin();
                        y++;

                        if (aux != null && y == aux.getNum())
                        {
                            aet.copia_para_AET(aux.getInicio());
                            aux = aux.getNext();
                        }
                    }
                }
        }

        private static void criaET(CabET cab, Pontos[] pontos)
        {
            ET et = new ET();
            Pontos p1, p2;
            int Ymax, Xmin, Xmax, Ymin;
            double Incx;


            for (int i = 0; i < pontos.Length-1; i++)
            {
                p1 = pontos[i];
                p2 = pontos[i+1];

                if (p1.getY() > p2.getY())
                {
                    Ymax = p1.getY();
                    Xmax = p1.getX();
                    Xmin = p2.getX();
                    Ymin = p2.getY();
                }
                else
                {
                    Xmax = p2.getX();
                    Ymax = p2.getY();
                    Xmin = p1.getX();
                    Ymin = p1.getY();
                }

                if (((double)Ymax - (double)Ymin) == 0)
                    Incx = 0;
                else
                    Incx = ((double)Xmax - (double)Xmin) / ((double)Ymax - (double)Ymin);

                cab.insere(Ymax, Xmin, Incx, Ymin);
            }
        }
    }
}
