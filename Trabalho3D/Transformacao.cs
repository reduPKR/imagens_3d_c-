using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabalho3D
{
    class Transformacao
    {
        private static double[][] matriz;

        private static void MultiplicarMatriz(double[][] mat)
        {
            int i, j, k;
            double[][] ret = new double[4][];
            for (i = 0; i < 4; i++)
                ret[i] = new double[4];

            for (i = 0; i < 4; i++)
            {
                for (j = 0; j < 4; j++)
                {
                    for (k = 0; k < 4; k++)
                        ret[i][j] += matriz[i][k] * mat[k][j];
                }
            }

            matriz = ret;
        }

        public static double[] MatrizAcumulada(double x, double y, double z)
        {
            int i, j;
            double[] vet = { x, y, z, 1 };
            double[] resul = new double[4];

            for (i = 0; i < 4; i++)
            {
                for (j = 0; j < 4; j++)
                {
                    resul[i] += vet[j] * matriz[j][i];
                }

            }
            return resul;
        }

        public static void ZerarMatriz()
        {
            matriz = null;
        }

        public static void Translacao(int tx, int ty, int tz)
        {
            int i;
            double[][] mat = new double[4][];
            for (i = 0; i < 4; i++)
                mat[i] = new double[4];

            mat[3][0] = tx;
            mat[3][1] = ty;
            mat[3][2] = tz;
            for (i = 0; i < 4; i++)
                mat[i][i] = 1;

            if (matriz == null)
            {
                matriz = mat;
            }
            else
                MultiplicarMatriz(mat);
        }

        public static void Escala(double sx, double sy, double sz)
        {
            int i;
            double[][] mat = new double[4][];
            for (i = 0; i < 4; i++)
                mat[i] = new double[4];

            mat[0][0] = sx;
            mat[1][1] = sy;
            mat[2][2] = sz;
            mat[3][3] = 1;

            if (matriz == null)
            {
                matriz = mat;
            }
            else
                MultiplicarMatriz(mat);
        }

        public static void RotacaoY(double a)
        {
            double ang = a * Math.PI / 180;
            double[][] mat = new double[4][];
            for (int i = 0; i < 4; i++)
                mat[i] = new double[4];
            //[Col][Lin]
            mat[0][0] = 1;
            mat[1][1] = Math.Cos(ang);//lin 1 col 1
            mat[1][2] = Math.Sin(ang);//Lin 2 col 1
            mat[2][1] = -1 * Math.Sin(ang);//lin 1 col 2
            mat[2][2] = Math.Cos(ang);
            mat[3][3] = 1;

            if (matriz == null)
            {
                matriz = mat;
            }
            else
                MultiplicarMatriz(mat);
        }

        public static void RotacaoX(double a)
        {
            double ang = a * Math.PI / 180;
            double[][] mat = new double[4][];
            for (int i = 0; i < 4; i++)
                mat[i] = new double[4];

            mat[0][0] = Math.Cos(ang);
            mat[0][2] = -1 * Math.Sin(ang);
            mat[1][1] = 1;
            mat[2][0] = Math.Sin(ang);          
            mat[2][2] = Math.Cos(ang);
            mat[3][3] = 1;

            if (matriz == null)
            {
                matriz = mat;
            }
            else
                MultiplicarMatriz(mat);
        }

        public static void RotacaoZ(double a)
        {
            double ang = a * Math.PI / 180;
            double[][] mat = new double[4][];
            for (int i = 0; i < 4; i++)
                mat[i] = new double[4];
             
            mat[0][0] = Math.Cos(ang);
            mat[0][1] = Math.Sin(ang);
            mat[1][0] = -1 * Math.Sin(ang);
            mat[1][1] = Math.Cos(ang);
            mat[2][2] = 1;
            mat[3][3] = 1;
            if (matriz == null)
            {
                matriz = mat;
            }
            else
                MultiplicarMatriz(mat);
        }
    }
}
